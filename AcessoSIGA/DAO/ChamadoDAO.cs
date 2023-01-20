using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class ChamadoDAO
    {
        //public static Semaphore threadPool = new Semaphore(1, 1);

        //Grava/Atualiza chamado no banco de dados
        public void GravarChamado(Ticket t)
        {
            //threadPool.WaitOne();

            if (ExisteChamado(t.cdChamado))
            {
                //-------------UPDATE-----------------
                ConexaoSQL conexaoSQL = new ConexaoSQL();

                var con = conexaoSQL.ConectarBancoSQL(false);
                var cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "UPDATE CHAMADO SET " +
                                        "idChamado=@idChamado, " +
                                        "titChamado=@titChamado, " +
                                        "dsChamado=@dsChamado, " +
                                        "cdCliente=@cdCliente, " +
                                        "nmCliente=@nmCliente, " +
                                        "cdContato=@cdContato, " +
                                        "nmContato=@nmContato, " +
                                        "sitChamado=@cdSituacao, " +
                                        "nmSituacao=@nmSituacao, " +
                                        "dataChamado=@dataChamado " +
                                        "WHERE cdChamado=@cdChamado";

                    cmd.Parameters.AddWithValue("@cdChamado", t.cdChamado);
                    cmd.Parameters.AddWithValue("@idChamado", t.idChamado);
                    cmd.Parameters.AddWithValue("@titChamado", t.titChamado);
                    cmd.Parameters.AddWithValue("@dsChamado", t.dsChamado);
                    cmd.Parameters.AddWithValue("@cdCliente", t.cdCliente);
                    cmd.Parameters.AddWithValue("@nmCliente", t.nmCliente);
                    cmd.Parameters.AddWithValue("@cdContato", t.cdContato);
                    cmd.Parameters.AddWithValue("@nmContato", t.nmContato);
                    cmd.Parameters.AddWithValue("@cdSituacao", t.cdSituacao);
                    cmd.Parameters.AddWithValue("@nmSituacao", t.nmSituacao);
                    cmd.Parameters.AddWithValue("@dataChamado", t.dataChamado);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Chamado atualizado com sucesso!");

                }
                catch (Exception ex)
                {
                    Util.GravarLog("Banco de Dados ", "Ocorreu erro ao atualizar as informações do chamado no banco de dados! " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                //-------------INSERT-----------------
                ConexaoSQL conexaoSQL = new ConexaoSQL();

                var con = conexaoSQL.ConectarBancoSQL(false);
                var cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "INSERT INTO CHAMADO(cdChamado, idChamado, titChamado, dsChamado, cdCliente, nmCliente, cdContato, nmContato, sitChamado, nmSituacao, dataChamado)" +
                                       "VALUES(@cdChamado, @idChamado, @titChamado, @dsChamado, @cdCliente, @nmCliente, @cdContato, @nmContato, @cdSituacao, @nmSituacao, @dataChamado)";

                    cmd.Parameters.AddWithValue("@cdChamado", t.cdChamado);
                    cmd.Parameters.AddWithValue("@idChamado", t.idChamado);
                    cmd.Parameters.AddWithValue("@titChamado", t.titChamado);
                    cmd.Parameters.AddWithValue("@dsChamado", t.dsChamado);
                    cmd.Parameters.AddWithValue("@cdCliente", t.cdCliente);
                    cmd.Parameters.AddWithValue("@nmCliente", t.nmCliente);
                    cmd.Parameters.AddWithValue("@cdContato", t.cdContato);
                    cmd.Parameters.AddWithValue("@nmContato", t.nmContato);
                    cmd.Parameters.AddWithValue("@cdSituacao", t.cdSituacao);
                    cmd.Parameters.AddWithValue("@nmSituacao", t.nmSituacao);
                    cmd.Parameters.AddWithValue("@dataChamado", t.dataChamado);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Chamado gravado com sucesso!");

                }
                catch (Exception ex)
                {
                    Util.GravarLog("Banco de Dados ", "Ocorreu erro ao gravar chamado no banco de dados! " + ex.Message);
                }
                finally
                {
                    con.Close();
                }                
            }
            //threadPool.Release();
        }

        //Verifica no BD se existe chamado
        public bool ExisteChamado(int cdChamado)
        {
            bool resultado = false;

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            ConexaoSQL conexaoSQL = new ConexaoSQL();

            var con = conexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM CHAMADO WHERE cdChamado=" + cdChamado;

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
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar o chamado no banco de dados! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return resultado;
        }

        //Consulta no BD de chamados com situação diferente de encerrado
        public List<Ticket> ConsultaChamadosAtivos()
        {
            List<Ticket> lista = new List<Ticket>();

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            ConexaoSQL conexaoSQL = new ConexaoSQL();

            var con = conexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM CHAMADO WHERE sitChamado <> 7";

            try
            {
                da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Ticket ticket = new Ticket();

                    ticket.cdChamado = Convert.ToInt32(row["cdChamado"]);

                    lista.Add(ticket);
                }
            }
            catch (Exception ex)
            {
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar os chamados ativos no banco de dados! " + ex.Message);                
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        //Consulta no BD informações do chamado
        public Ticket ConsultaChamado(int cdChamado)
        {
            Ticket ticket = new Ticket();

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            ConexaoSQL conexaoSQL = new ConexaoSQL();

            var con = conexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM CHAMADO WHERE cdChamado=" + cdChamado;

                da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    ticket.cdChamado = Convert.ToInt32(row["cdChamado"]);
                    ticket.idChamado = Convert.ToInt32(row["idChamado"]);
                    ticket.titChamado = Convert.ToString(row["titChamado"]);
                    ticket.dsChamado = Convert.ToString(row["dsChamado"]);
                    ticket.cdCliente = Convert.ToInt32(row["cdCliente"]);
                    ticket.nmCliente = Convert.ToString(row["nmCliente"]);
                    ticket.cdContato = Convert.ToInt32(row["cdContato"]);
                    ticket.nmContato = Convert.ToString(row["nmContato"]);
                    ticket.cdSituacao = Convert.ToInt32(row["sitChamado"]);
                    ticket.nmSituacao = Convert.ToString(row["nmSituacao"]);
                    ticket.dataChamado = Convert.ToString(row["dataChamado"]);

                }
            }
            catch (Exception ex)
            {
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar informações do chamado no banco de dados! " + ex.Message);                
            }
            finally
            {
                con.Close();
            }
            return ticket;
        }

        //Consulta no BD todos os chamados do contato informado
        public List<Ticket> ConsultaChamadosContato(Parametros p)
        {
            List<Ticket> listaTicket = new List<Ticket>();

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            ConexaoSQL conexaoSQL = new ConexaoSQL();

            var con = conexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM CHAMADO WHERE cdContato=" + p.Contato?.cdContato;

                da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Ticket ticket = new Ticket();

                    ticket.cdChamado = Convert.ToInt32(row["cdChamado"]);
                    ticket.idChamado = Convert.ToInt32(row["idChamado"]);
                    ticket.titChamado = Convert.ToString(row["titChamado"]);
                    ticket.dsChamado = Convert.ToString(row["dsChamado"]);
                    ticket.cdCliente = Convert.ToInt32(row["cdCliente"]);
                    ticket.nmCliente = Convert.ToString(row["nmCliente"]);
                    ticket.cdContato = Convert.ToInt32(row["cdContato"]);
                    ticket.nmContato = Convert.ToString(row["nmContato"]);
                    ticket.cdSituacao = Convert.ToInt32(row["sitChamado"]);
                    ticket.nmSituacao = Convert.ToString(row["nmSituacao"]);
                    ticket.dataChamado = Convert.ToString(row["dataChamado"]);

                    listaTicket.Add(ticket);
                }
            }
            catch (Exception ex)
            {
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar chamdos do contato no banco de dados! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return listaTicket;
        }
    }
}
