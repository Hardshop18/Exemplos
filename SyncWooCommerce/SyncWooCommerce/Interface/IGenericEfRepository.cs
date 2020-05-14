using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SyncWooCommerce.Interface
{
    public interface IGenericEfRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> GetManyQueryable(Expression<Func<TEntity, bool>> where);
        TEntity Get(Expression<Func<TEntity, Boolean>> where);
        void Delete(Expression<Func<TEntity, Boolean>> where);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate, params string[] include);
        bool Exists(object primaryKey);
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetPaginado<TKey>(Expression<Func<TEntity, TKey>> orderBy, int pagina, int qtdeItens);
    }
}
