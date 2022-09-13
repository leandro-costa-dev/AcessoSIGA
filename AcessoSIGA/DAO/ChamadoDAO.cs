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
        //-------------Gravar chamado no banco----------
        public void GravarChamado(Ticket t)
        {
            if (!ExisteChamado(t.cdChamado))
            {
                var con = ConexaoSQL.ConectarBancoSQL(false);
                var cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "INSERT INTO CHAMADO(cdChamado, idChamado, titChamado, dsChamado, cdCliente, cdContato, sitChamado, nmSituacao, dataChamado, anexo, dsAnexo)" +
                                       "VALUES(@cdChamado, @idChamado, @titChamado, @dsChamado, @cdCliente, @cdContato, @sitChamado, @nmSituacao, @dataChamado, @anexo, @dsAnexo)";

                    cmd.Parameters.AddWithValue("@cdChamado", t.cdChamado);
                    cmd.Parameters.AddWithValue("@idChamado", t.idChamado);
                    cmd.Parameters.AddWithValue("@titChamado", t.titChamado);
                    cmd.Parameters.AddWithValue("@dsChamado", t.dsChamado);
                    cmd.Parameters.AddWithValue("@cdCliente", t.cdCliente);
                    cmd.Parameters.AddWithValue("@cdContato", t.cdContato);           
                    cmd.Parameters.AddWithValue("@sitChamado", t.sitChamado);
                    cmd.Parameters.AddWithValue("@nmSituacao", t.nmSituacao);
                    cmd.Parameters.AddWithValue("@dataChamado", t.dataChamado);
                    cmd.Parameters.AddWithValue("@anexo", t.anexo);
                    cmd.Parameters.AddWithValue("@dsAnexo", t.dsAnexo);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Chamado gravado com sucesso!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu erro ao gravar o chamado no banco de dados! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        //Verifica se existe chamado
        public bool ExisteChamado(int idChamado)
        {
            bool resultado = false;

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var con = ConexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM CHAMADO WHERE cdChamado=" + idChamado;

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
                MessageBox.Show("Ocorreu erro consultar chamado! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            return resultado;
        }
    }
}
