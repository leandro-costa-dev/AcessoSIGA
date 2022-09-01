using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public static class ConexaoSQL
    {
        public static string servidor = @"LEANDRO-PC\MSSQLSERVER2019";
        public static string banco = "master";
        public static string usuario = "leandro";
        public static string senha = "12345678";

        public static SqlConnection sqlConnection = new SqlConnection();
        public static SqlConnection ConectarBancoSQL()
        {
            try
            {                
                sqlConnection.ConnectionString = "Data Source = " + servidor + "; Initial Catalog = " + banco + "; User Id = " + usuario + "; Password = " + senha;
                sqlConnection.Open();

                return sqlConnection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu erro na conexão com banco de dados! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public static void FecharConexaoSQL()
        {
            if (sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }            
        }
    }
}
