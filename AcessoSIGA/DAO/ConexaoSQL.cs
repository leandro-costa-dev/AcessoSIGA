using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AcessoSIGA
{
    public class ConexaoSQL
    {

        public static string servidor = @"LEANDRO-PC";
        public static string banco_master = "master";
        public static string banco = "SIGA";
        public static string usuario = "leandro";
        public static string senha = "12345678";

        public SqlConnection sqlConnection = new SqlConnection();

        //Abrir a conexão com banco de dados
        public SqlConnection ConectarBancoSQL(bool master)
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
                    Util.GravarLog("Banco de Dados ", "Ocorreu erro na conexão com banco de dados! " + ex.Message);                    
                }
            }
            return sqlConnection;
        }

        //Criar banco de dados
        public bool CriarBancoSQL()
        {
            bool resultado = false;

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
                    resultado = true;
                }
                catch (Exception ex)
                {
                    Util.GravarLog("Banco de Dados ", "Ocorreu erro ao criar o banco de dados! " + ex.Message);                   
                }
                finally
                {
                    con.Close();
                }
            }
            return resultado;
        }

        //Criar tabelas no banco de dados
        public bool CriarTabelasSQL()
        {
            bool resultado = false;

            if (!ConsultarTabelaSQL("SIGA", "parametros"))
            {
                SqlConnection con = ConectarBancoSQL(false);
                SqlCommand cmd_parametros = con.CreateCommand();
                SqlCommand cmd_chamados = con.CreateCommand();
                SqlCommand cmd_historico = con.CreateCommand();
                SqlCommand cmd_anexo = con.CreateCommand();

                try
                {
                    cmd_parametros.CommandText = (@"CREATE TABLE PARAMETROS(
                        cdCliente INT, 
                        nmCliente VARCHAR (100), 
                        cnpj VARCHAR (14), 
                        cdContato INT, 
                        nmContato VARCHAR(100), 
                        cdLocalidade INT, 
                        nmLocalidade VARCHAR(40), 
                        email VARCHAR(100), 
                        login VARCHAR(50), 
                        senhaContato VARCHAR(50), 
                        idChamado INT, 
                        tipoChamado INT, 
                        cdCategoria INT, 
                        cdSeveridade INT, 
                        cdAnimo INT, 
                        cdOrigem INT, 
                        urlWs VARCHAR(50), 
                        usuarioWs VARCHAR(30), 
                        senhaWs VARCHAR(30), 
                        empresaWs INT, 
                        servidor VARCHAR(100), 
                        banco VARCHAR(40), 
                        usuarioBanco VARCHAR(20), 
                        senhaBanco VARCHAR(20))");

                    cmd_chamados.CommandText = (@"CREATE TABLE CHAMADO(
                        cdChamado int NOT NULL PRIMARY KEY, 
                        idChamado int NOT NULL, 
                        titChamado VARCHAR (100), 
                        dsChamado VARCHAR(500), 
                        cdCliente INT, 
                        nmCliente VARCHAR(100), 
                        cdContato INT, 
                        nmContato VARCHAR(100), 
                        sitChamado VARCHAR(10), 
                        nmSituacao VARCHAR(50), 
                        dataChamado VARCHAR(20))");

                    cmd_historico.CommandText = (@"CREATE TABLE HISTORICO(
                        id INT IDENTITY(1, 1) PRIMARY KEY, 
                        cdChamado INT NOT NULL, 
                        cdAcompanhamento INT NOT NULL, 
                        nmTipoacompanhamento VARCHAR(100), 
                        dsAcompanhamento VARCHAR(500), 
                        nmUsuario VARCHAR(100), 
                        dtAcompanhamento VARCHAR(50), 
                        idPrivado VARCHAR(10), 
                        controle VARCHAR(2), 
                        CONSTRAINT fk_cdChamado FOREIGN KEY(cdChamado) 
                        REFERENCES CHAMADO(cdChamado) 
                        ON DELETE CASCADE 
                        ON UPDATE CASCADE)");

                    cmd_anexo.CommandText = (@"CREATE TABLE ANEXO(
                        id INT IDENTITY(1, 1) PRIMARY KEY, 
                        cdChamado INT NOT NULL, 
                        nrSequencia INT NOT NULL, 
                        nmAnexo VARCHAR(100), 
                        dsAnexo VARCHAR(MAX), 
                        dtAnexo VARCHAR(20), 
                        cdUsuario INT, 
                        nmUsuario VARCHAR(50), 
                        vlTamanho VARCHAR(20), 
                        cdSituacao INT, 
                        idPrivado CHAR(1), 
                        CONSTRAINT fk_anexoChamado FOREIGN KEY(cdChamado) 
                        REFERENCES CHAMADO(cdChamado) 
                        ON DELETE CASCADE 
                        ON UPDATE CASCADE)");

                    cmd_parametros.ExecuteNonQuery();
                    Console.WriteLine("Tabela parâmetros criada com sucesso!");

                    cmd_chamados.ExecuteNonQuery();
                    Console.WriteLine("Tabela chamados criada com sucesso!");

                    cmd_historico.ExecuteNonQuery();
                    Console.WriteLine("Tabela historico criada com sucesso!");

                    cmd_anexo.ExecuteNonQuery();
                    Console.WriteLine("Tabela anexo criada com sucesso!");

                    resultado = true;

                }
                catch (Exception ex)
                {
                    Util.GravarLog("Banco de Dados ", "Ocorreu erro ao criar as tabelas no banco de dados! " + ex.Message);                    
                }
                finally
                {
                    con.Close();
                }
            }
            return resultado;
        }

        //Consultar se existe o banco de dados
        public bool ConsultarBancoSQL(string banco)
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
            }
            catch (Exception ex)
            {
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar o banco de dados! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return resultado;
        }

        //Consultar se existe a tabela no banco de dados
        public bool ConsultarTabelaSQL(string banco, string tabela)
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
            }
            catch (Exception ex)
            {
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar a tabela no banco de dados! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return resultado;
        }

        //Verifica se existe informações na tabela
        public bool ExisteInformacoes(string tabelaBanco)
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
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar informações na tabela no banco de dados! " + ex.Message);                
            }
            finally
            {
                con.Close();
            }
            return resultado;            
        }

        //Fechar conexão com banco de dados
        public void FecharConexaoSQL()
        {
            if (sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();

                Console.WriteLine("Conexao com banco de dados encerrada!");
            }            
        }
    }
}
