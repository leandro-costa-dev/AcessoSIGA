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
        public static string banco_master = "master";
        public static string banco = "SIGA";
        public static string usuario = "leandro";
        public static string senha = "12345678";

        public static SqlConnection sqlConnection = new SqlConnection();

        //Abrir a conexão com banco de dados
        public static SqlConnection ConectarBancoSQL(bool master)
        {
            if (!sqlConnection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    if (master)
                    {
                        sqlConnection.ConnectionString = "Data Source = " + servidor + "; Initial Catalog = " + banco_master + "; User Id = " + usuario + "; Password = " + senha;
                        sqlConnection.Open();
                    }
                    else
                    {
                        sqlConnection.ConnectionString = "Data Source = " + servidor + "; Initial Catalog = " + banco + "; User Id = " + usuario + "; Password = " + senha;
                        sqlConnection.Open();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu erro na conexão com banco de dados! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return sqlConnection;
        }

        //Criar banco de dados
        public static void CriarBancoSQL()
        {
            if (!ConsultarBancoSQL(banco))
            {
                string sql = "CREATE DATABASE " + banco;

                SqlConnection con = ConectarBancoSQL(true);
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = sql;

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Banco de dados criado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu erro criar o banco de dados! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        //Criar tabelas no banco de dados
        public static void CriarTabelasSQL()
        {
            if (!ConsultarTabelaSQL("SIGA", "parametros"))
            {
                SqlConnection con = ConectarBancoSQL(false);
                SqlCommand cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = ("CREATE TABLE PARAMETROS(" +
                        "cdCliente int, " +
                        "nmCliente VarChar (100), " +
                        "cnpj VarChar (14), " +
                        "cdContato int, " +
                        "nmContato VarChar (100), " +
                        "email VarChar (100), " +
                        "login VarChar (50), " +
                        "servidor VarChar (100), " +
                        "banco VarChar(40), " +
                        "usuario VarChar(20), " +
                        "senha VarChar(20));");

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu erro ao criar as tabelas no banco de dados! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        //Consultar se existe o banco de dados
        public static bool ConsultarBancoSQL(string banco)
        {
            bool resultado = false;
            string sql = "SELECT * FROM MASTER..sysdatabases WHERE name ='" + banco + "'";

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            SqlConnection con = ConectarBancoSQL(true);
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = sql;

            try
            {
                da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("Banco de dados existente!");
                    resultado = true;
                }

                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu erro consultar o banco de dados! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return resultado;
            }
            finally
            {
                con.Close();
            }
        }

        //Consultar se existe a tabela no banco de dados
        public static bool ConsultarTabelaSQL(string banco, string tabela)
        {
            bool resultado = false;
            string sql = "SELECT* FROM " + banco + ".information_schema.tables WHERE TABLE_NAME = '" + tabela + "'";

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            SqlConnection con = ConectarBancoSQL(false);
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = sql;

            try
            {               
                da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("Tabela existente!");
                    resultado = true;
                }
                
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu erro consultar o banco de dados! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return resultado;
            }
            finally
            {
                con.Close();
            }

        }

        //Verifica se existe informações na tabela
        public static bool ExisteInformacoes(string tabelaBanco)
        {
            bool resultado = false;

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var con = ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM " + tabelaBanco;

            try
            {
                da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu erro consultar informações da tabela no banco de dados! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            return resultado;            
        }

        //Fechar conexão com banco de dados
        public static void FecharConexaoSQL()
        {
            if (sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();

                Console.WriteLine("Conexao com banco de dados encerrada!");
            }            
        }
    }
}
