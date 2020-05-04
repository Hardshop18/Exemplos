using SyncWooCommerce.Utilitarios;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace SyncWooCommerce.Ef
{
    public class ContextDB : DbContext
    {
        public ContextDB() : base(GetEntityConnectionString.EntityConnection(ArquivoDeConfiguracao.GetConfiguracao("Conectar"), ArquivoDeConfiguracao.GetConfiguracao("ConnectionString")), true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (Database.Connection.Database == "postgres")
                modelBuilder.HasDefaultSchema("public");

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass //&& typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();

            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(mappingClass);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
