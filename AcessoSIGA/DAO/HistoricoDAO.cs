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
        //-------------Gravar histórico do chamado no banco----------
        public bool GravarHistorico(List<Historico> listHistorico)
        {
            bool resultado = false;

            foreach (Historico h in listHistorico)
            {
                if (!ExisteHistorico(h.cdChamado, h.cdAcompanhamento))
                {
                    var con = ConexaoSQL.ConectarBancoSQL(false);
                    var cmd = con.CreateCommand();

                    try
                    {
                        cmd.CommandText = "INSERT INTO HISTORICO(cdChamado, cdAcompanhamento, nmTipoacompanhamento, dsAcompanhamento, nmUsuario, dtAcompanhamento)" +
                                           "VALUES(@cdChamado, @cdAcompanhamento, @nmTipoacompanhamento, @dsAcompanhamento, @nmUsuario, @dtAcompanhamento)";

                        cmd.Parameters.AddWithValue("@cdChamado", h.cdChamado);
                        cmd.Parameters.AddWithValue("@cdAcompanhamento", h.cdAcompanhamento);
                        cmd.Parameters.AddWithValue("@nmTipoacompanhamento", h.nmTipoacompanhamento);
                        cmd.Parameters.AddWithValue("@dsAcompanhamento", h.dsAcompanhamento);
                        cmd.Parameters.AddWithValue("@nmUsuario", h.nmUsuario);
                        cmd.Parameters.AddWithValue("@dtAcompanhamento", h.dtAcompanhamento);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Histórico gravado com sucesso!");

                        //Retorna true se um novo histórico for adicionado e diferente de rascunho
                        if (h.cdAcompanhamento != 1)
                        {
                            resultado = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu erro ao gravar o histórico no banco de dados! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return resultado;
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
                MessageBox.Show("Ocorreu erro consultar historico! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    lista.Add(historico);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu erro consultar o histórico! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            return lista;
        }
    }
}