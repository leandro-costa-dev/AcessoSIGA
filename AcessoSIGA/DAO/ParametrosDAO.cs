using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class ParametrosDAO
    {
        public static Semaphore threadPool = new Semaphore(1, 1);

        //-------------Gravar parâmetros do Sistema----------
        public void GravarParametros(Parametros p)
        {
            ConexaoSQL conexaoSQL = new ConexaoSQL();

            if (conexaoSQL.ExisteInformacoes("PARAMETROS"))
            {
                //--------UPDATE---------              

                var con = conexaoSQL.ConectarBancoSQL(false);
                var cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "UPDATE PARAMETROS SET " +
                        "cdCliente = @cdCliente, " +
                        "nmCliente = @nmCliente, " +
                        "cnpj = @cnpj, " +
                        "cdContato = @cdContato, " +
                        "nmContato = @nmContato, " +
                        "cdLocalidade = @cdLocalidade, " +
                        "nmLocalidade = @nmLocalidade, " +
                        "email = @email, " +
                        "login = @login, " +
                        "senhaContato = @senhaContato, " +
                        "idChamado = @idChamado, " +
                        "tipoChamado = @tipoChamado, " +
                        "cdCategoria = @cdCategoria, " +
                        "cdSeveridade = @cdSeveridade, " +
                        "cdAnimo = @cdAnimo, " +
                        "cdOrigem = @cdOrigem, " +
                        "urlWs = @urlWs, " +
                        "usuarioWs = @usuarioWs, " +
                        "senhaWs = @senhaWs, " +
                        "empresaWs = @empresaWs, " +
                        "servidor = @servidor, " +
                        "banco = @banco, " +
                        "usuario = @usuario, " +
                        "senhaBanco = @senhaBanco";

                    cmd.Parameters.AddWithValue("@cdCliente", p.Cliente.cdCliente);
                    cmd.Parameters.AddWithValue("@nmCliente", p.Cliente.nmCliente);
                    cmd.Parameters.AddWithValue("@cnpj", p.Cliente.cnpj);

                    cmd.Parameters.AddWithValue("@cdContato", p.Contato.cdContato);
                    cmd.Parameters.AddWithValue("@nmContato", p.Contato.nmContato);
                    cmd.Parameters.AddWithValue("@cdLocalidade", p.Contato.cdLocalidade);
                    cmd.Parameters.AddWithValue("@nmLocalidade", p.Contato.nmLocalidade);
                    cmd.Parameters.AddWithValue("@email", p.Contato.email);
                    cmd.Parameters.AddWithValue("@login", p.Contato.login);
                    cmd.Parameters.AddWithValue("@senhaContato", p.Contato.senhaContato);

                    cmd.Parameters.AddWithValue("@idChamado", p.Ticket.idChamado);
                    cmd.Parameters.AddWithValue("@tipoChamado", p.Ticket.tipoChamado);
                    cmd.Parameters.AddWithValue("@cdCategoria", p.Ticket.cdCategoria);
                    cmd.Parameters.AddWithValue("@cdSeveridade", p.Ticket.cdSeveridade);
                    cmd.Parameters.AddWithValue("@cdAnimo", p.Ticket.cdAnimo);
                    cmd.Parameters.AddWithValue("@cdOrigem", p.Ticket.cdOrigem);

                    cmd.Parameters.AddWithValue("@urlWs", p.urlWs);
                    cmd.Parameters.AddWithValue("@usuarioWs", p.usuarioWs);
                    cmd.Parameters.AddWithValue("@senhaWs", p.senhaWs);
                    cmd.Parameters.AddWithValue("@empresaWs", p.empresaWs);

                    cmd.Parameters.AddWithValue("@servidor", p.servidor);
                    cmd.Parameters.AddWithValue("@banco", p.banco);
                    cmd.Parameters.AddWithValue("@usuario", p.usuario);
                    cmd.Parameters.AddWithValue("@senhaBanco", p.senhaBanco);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Configurações gravadas com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    Util.GravarLog("Banco de Dados ", "Ocorreu erro ao atualizar as configurações no banco de dados! " + ex.Message);                    
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {
                //--------INSERT--------
                var con = conexaoSQL.ConectarBancoSQL(false);
                var cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "INSERT INTO PARAMETROS(cdCliente, nmCliente, cnpj, cdContato, nmContato, cdLocalidade, nmLocalidade, email, login, senhaContato, idChamado, tipoChamado, cdCategoria, cdSeveridade, cdAnimo, cdOrigem, urlWs, usuarioWs, senhaWs, empresaWs, servidor, banco, usuario, senhaBanco) " +
                                                    "VALUES (@cdCliente, @nmCliente, @cnpj, @cdContato, @nmContato, @cdLocalidade, @nmLocalidade, @email, @login, @senhaContato, @idChamado, @tipoChamado, @cdCategoria, @cdSeveridade, @cdAnimo, @cdOrigem, @urlWs, @usuarioWs, @senhaWs, @empresaWs, @servidor, @banco, @usuario, @senhaBanco)";

                    cmd.Parameters.AddWithValue("@cdCliente", p.Cliente.cdCliente);
                    cmd.Parameters.AddWithValue("@nmCliente", p.Cliente.nmCliente);
                    cmd.Parameters.AddWithValue("@cnpj", p.Cliente.cnpj);

                    cmd.Parameters.AddWithValue("@cdContato", p.Contato.cdContato);
                    cmd.Parameters.AddWithValue("@nmContato", p.Contato.nmContato);
                    cmd.Parameters.AddWithValue("@cdLocalidade", p.Contato.cdLocalidade);
                    cmd.Parameters.AddWithValue("@nmLocalidade", p.Contato.nmLocalidade);
                    cmd.Parameters.AddWithValue("@email", p.Contato.email);
                    cmd.Parameters.AddWithValue("@login", p.Contato.login);
                    cmd.Parameters.AddWithValue("@senhaContato", p.Contato.senhaContato);

                    cmd.Parameters.AddWithValue("@idChamado", p.Ticket.idChamado);
                    cmd.Parameters.AddWithValue("@tipoChamado", p.Ticket.tipoChamado);
                    cmd.Parameters.AddWithValue("@cdCategoria", p.Ticket.cdCategoria);
                    cmd.Parameters.AddWithValue("@cdSeveridade", p.Ticket.cdSeveridade);
                    cmd.Parameters.AddWithValue("@cdAnimo", p.Ticket.cdAnimo);
                    cmd.Parameters.AddWithValue("@cdOrigem", p.Ticket.cdOrigem);

                    cmd.Parameters.AddWithValue("@urlWs", p.urlWs);
                    cmd.Parameters.AddWithValue("@usuarioWs", p.usuarioWs);
                    cmd.Parameters.AddWithValue("@senhaWs", p.senhaWs);
                    cmd.Parameters.AddWithValue("@empresaWs", p.empresaWs);

                    cmd.Parameters.AddWithValue("@servidor", p.servidor);
                    cmd.Parameters.AddWithValue("@banco", p.banco);
                    cmd.Parameters.AddWithValue("@usuario", p.usuario);
                    cmd.Parameters.AddWithValue("@senhaBanco", p.senhaBanco);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Configurações gravadas com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    Util.GravarLog("Banco de Dados ", "Ocorreu erro ao gravar as configurações no banco de dados! " + ex.Message);                    
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public Parametros ConsultarParametros()
        {
            threadPool.WaitOne();

            Parametros parametros = new Parametros();

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            
            ConexaoSQL conexaoSQL = new ConexaoSQL();
            
            var con = conexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM PARAMETROS";

            try
            {
                Cliente cliente = new Cliente();
                Contato contato = new Contato();
                Ticket ticket = new Ticket();

                da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    cliente.cdCliente = Convert.ToInt32(row["cdCliente"]);
                    cliente.nmCliente = Convert.ToString(row["nmCliente"]);
                    cliente.cnpj = Convert.ToString(row["cnpj"]);

                    contato.cdContato = Convert.ToInt32(row["cdContato"]);
                    contato.nmContato = Convert.ToString(row["nmContato"]);
                    contato.cdLocalidade = Convert.ToInt32(row["cdLocalidade"]);
                    contato.nmLocalidade = Convert.ToString(row["nmLocalidade"]);
                    contato.email = Convert.ToString(row["email"]);
                    contato.login = Convert.ToString(row["login"]);
                    contato.senhaContato = Convert.ToString(row["senhaContato"]);

                    ticket.idChamado = Convert.ToInt32(row["idChamado"]);
                    ticket.tipoChamado = Convert.ToInt32(row["tipoChamado"]);
                    ticket.cdCategoria = Convert.ToInt32(row["cdCategoria"]);
                    ticket.cdSeveridade = Convert.ToInt32(row["cdSeveridade"]);
                    ticket.cdAnimo = Convert.ToInt32(row["cdAnimo"]);
                    ticket.cdOrigem = Convert.ToInt32(row["cdOrigem"]);

                    parametros.urlWs = Convert.ToString(row["urlWs"]);
                    parametros.usuarioWs = Convert.ToString(row["usuarioWs"]);
                    parametros.senhaWs = Convert.ToString(row["senhaWs"]);
                    parametros.empresaWs = Convert.ToInt32(row["empresaWs"]);

                    parametros.servidor = Convert.ToString(row["servidor"]);
                    parametros.banco = Convert.ToString(row["banco"]);
                    parametros.usuario = Convert.ToString(row["usuario"]);
                    parametros.senhaBanco = Convert.ToString(row["senhaBanco"]);

                    parametros.Cliente = cliente;
                    parametros.Contato = contato;
                    parametros.Ticket = ticket;
                }
            }
            catch (Exception ex)
            {
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar os parâmetros no banco de dados! " + ex.Message);                
            }
            finally
            {
                con.Close();
            }
            threadPool.Release();
            return parametros;            
        }        
    }
}
