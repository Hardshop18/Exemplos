using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste.MySql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
            stringBuilder.Server = "hardshop.ddns.net";
            stringBuilder.Database = "sinca_vitoria";
            stringBuilder.UserID = "sinca_vitoria";
            stringBuilder.Password = "yUCKQn8T";
            stringBuilder.Port = 3306;

            stringBuilder.ConvertZeroDateTime = true;
            stringBuilder.UseAffectedRows = false;
            stringBuilder.SslMode = MySqlSslMode.None;

            MySqlConnection mySql = new MySqlConnection(stringBuilder.ConnectionString);
            try
            {
                mySql.Open();
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
