using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class HistoricoDAO
    {
        //Grava histórico do chamado no banco de dados
        public void GravarHistorico(List<Historico> listHistorico)
        {
            foreach (Historico h in listHistorico)
            {
                if (!ExisteHistorico(h.cdChamado, h.cdAcompanhamento))
                {
                    if (h.cdAcompanhamento == 1)
                    {
                        h.controle = 1; //Marca a flag de histórico como lida quando for rascunho
                    }
                    else
                    {
                        h.controle = 0; //Flag novo histórico não visualizado
                    }

                    var con = ConexaoSQL.ConectarBancoSQL(false);
                    var cmd = con.CreateCommand();

                    try
                    {
                        cmd.CommandText = "INSERT INTO HISTORICO(cdChamado, cdAcompanhamento, nmTipoacompanhamento, dsAcompanhamento, nmUsuario, dtAcompanhamento, idPrivado, controle)" +
                                           "VALUES(@cdChamado, @cdAcompanhamento, @nmTipoacompanhamento, @dsAcompanhamento, @nmUsuario, @dtAcompanhamento, @idPrivado, @controle)";

                        cmd.Parameters.AddWithValue("@cdChamado", h.cdChamado);
                        cmd.Parameters.AddWithValue("@cdAcompanhamento", h.cdAcompanhamento);
                        cmd.Parameters.AddWithValue("@nmTipoacompanhamento", h.nmTipoacompanhamento);
                        cmd.Parameters.AddWithValue("@dsAcompanhamento", h.dsAcompanhamento);
                        cmd.Parameters.AddWithValue("@nmUsuario", h.nmUsuario);
                        cmd.Parameters.AddWithValue("@dtAcompanhamento", h.dtAcompanhamento);
                        cmd.Parameters.AddWithValue("@idPrivado", h.idPrivado);
                        cmd.Parameters.AddWithValue("@controle", h.controle);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Histórico gravado com sucesso!");

                    }
                    catch (Exception ex)
                    {
                        Util.GravarLog("Banco de Dados ", "Ocorreu erro ao gravar o histórico do chamado no banco de dados! " + ex.Message);                        
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        //Atualiza o flag do histórico no banco de dados
        public void AtualizaHistorico(Historico h)
        {
            var con = ConexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            try
            {
                cmd.CommandText = "UPDATE HISTORICO SET " +
                                "controle=@controle " +
                                "WHERE cdChamado=@cdChamado " +
                                "AND cdAcompanhamento=@cdAcompanhamento";

                cmd.Parameters.AddWithValue("@cdChamado", h.cdChamado);
                cmd.Parameters.AddWithValue("@cdAcompanhamento", h.cdAcompanhamento);
                cmd.Parameters.AddWithValue("@controle", 1);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao atualizar o histórico do chamado no banco de dados! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //Verifica se existe histórico do chamado
        public bool ExisteHistorico(int cdChamado, int cdAcompanhamento)
        {
            bool resultado = false;

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var con = ConexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM HISTORICO WHERE cdChamado=" + cdChamado +
                " AND cdAcompanhamento=" + cdAcompanhamento;

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
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar o histórico de acompanhamento do chamado no banco de dados! " + ex.Message);                
            }
            finally
            {
                con.Close();
            }
            return resultado;
        }

        public List<Historico> ConsultaHistorico(int cdChamado)
        {
            List<Historico> lista = new List<Historico>();

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var con = ConexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM HISTORICO WHERE cdChamado=" + cdChamado;

                da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Historico historico = new Historico();

                    historico.cdChamado = Convert.ToInt32(row["cdChamado"]);
                    historico.cdAcompanhamento = Convert.ToInt32(row["cdAcompanhamento"]);
                    historico.nmTipoacompanhamento = Convert.ToString(row["nmTipoacompanhamento"]);
                    historico.dsAcompanhamento = Convert.ToString(row["dsAcompanhamento"]);
                    historico.nmUsuario = Convert.ToString(row["nmUsuario"]);
                    historico.dtAcompanhamento = Convert.ToString(row["dtAcompanhamento"]);
                    historico.idPrivado = Convert.ToString(row["idPrivado"]);
                    historico.controle = Convert.ToInt32(row["controle"]);

                    lista.Add(historico);
                }
            }
            catch (Exception ex)
            {
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar o histórico do chamado no banco de dados! " + ex.Message);                
            }
            finally
            {
                con.Close();
            }
            return lista;
        }
    }
}