using System.Data;
using System.Data.SqlClient;

namespace AcessoSIGA
{
    public class AnexoDAO
    {
        public void GravarAnexo(Anexo anexo)
        {
            if (!ExisteAnexo(anexo))
            {
                //-------------INSERT-----------------
                ConexaoSQL conexaoSQL = new ConexaoSQL();

                var con = conexaoSQL.ConectarBancoSQL(false);
                var cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "INSERT INTO ANEXO (cdChamado, nrSequencia, nmAnexo, dsAnexo, dtAnexo, cdUsuario, nmUsuario, vlTamanho, cdSituacao, idPrivado)" +
                                       "VALUES(@cdChamado, @nrSequencia, @nmAnexo, @dsAnexo, @dtAnexo, @cdUsuario, @nmUsuario, @vlTamanho, @cdSituacao, @idPrivado)";

                    cmd.Parameters.AddWithValue("@cdChamado", anexo.cdChamado);
                    cmd.Parameters.AddWithValue("@nrSequencia", anexo.nrSequencia);
                    cmd.Parameters.AddWithValue("@nmAnexo", anexo.nmAnexo);
                    cmd.Parameters.AddWithValue("@dsAnexo", anexo.dsAnexo);
                    cmd.Parameters.AddWithValue("@dtAnexo", anexo.dtAnexo);
                    cmd.Parameters.AddWithValue("@cdUsuario", anexo.cdUsuario);
                    cmd.Parameters.AddWithValue("@nmUsuario", anexo.nmUsuario);
                    cmd.Parameters.AddWithValue("@vlTamanho", anexo.vlTamanho);
                    cmd.Parameters.AddWithValue("@cdSituacao", anexo.cdSituacao);
                    cmd.Parameters.AddWithValue("@idPrivado", anexo.idPrivado);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Chamado gravado com sucesso!");

                }
                catch (Exception ex)
                {
                    Util.GravarLog("Banco de Dados ", "Ocorreu erro ao gravar o anexo no banco de dados! " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        //Consulta de anexos no banco de dados
        public List<Anexo> ConsultaGeralAnexos(int cdChamado)
        {
            List<Anexo> listaAnexos = new List<Anexo>();

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            ConexaoSQL conexaoSQL = new ConexaoSQL();

            var con = conexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            try
            {
                Anexo anexo = new Anexo();

                cmd.CommandText = "SELECT * FROM ANEXO WHERE cdChamado=" + cdChamado;

                da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    anexo.cdChamado = Convert.ToInt32(row["cdChamado"]);
                    anexo.nrSequencia = Convert.ToInt32(row["nrSequencia"]);
                    anexo.nmAnexo = Convert.ToString(row["nmAnexo"]);
                    anexo.dsAnexo = Convert.ToString(row["dsAnexo"]);
                    anexo.dtAnexo = Convert.ToString(row["dtAnexo"]);
                    anexo.cdUsuario = Convert.ToInt32(row["cdUsuario"]);
                    anexo.nmUsuario = Convert.ToString(row["nmUsuario"]);
                    anexo.vlTamanho = Convert.ToString(row["vlTamanho"]);
                    anexo.cdSituacao = Convert.ToInt32(row["cdSituacao"]);
                    anexo.idPrivado = Convert.ToString(row["idPrivado"]);

                    listaAnexos.Add(anexo);
                }
            }
            catch (Exception ex)
            {
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar informações dos anexos no banco de dados! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return listaAnexos;
        }

        //Consulta anexo no banco de dados
        public Anexo ConsultaAnexo(int cdChamado, int nrSequencia)
        {
            Anexo anexo = new Anexo();

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            ConexaoSQL conexaoSQL = new ConexaoSQL();

            var con = conexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            try
            {                
                cmd.CommandText = "SELECT * FROM ANEXO WHERE cdChamado=" + cdChamado + " AND nrSequencia=" + nrSequencia;

                da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    anexo.cdChamado = Convert.ToInt32(row["cdChamado"]);
                    anexo.nrSequencia = Convert.ToInt32(row["nrSequencia"]);
                    anexo.nmAnexo = Convert.ToString(row["nmAnexo"]);
                    anexo.dsAnexo = Convert.ToString(row["dsAnexo"]);
                    anexo.dtAnexo = Convert.ToString(row["dtAnexo"]);
                    anexo.cdUsuario = Convert.ToInt32(row["cdUsuario"]);
                    anexo.nmUsuario = Convert.ToString(row["nmUsuario"]);
                    anexo.vlTamanho = Convert.ToString(row["vlTamanho"]);
                    anexo.cdSituacao = Convert.ToInt32(row["cdSituacao"]);
                    anexo.idPrivado = Convert.ToString(row["idPrivado"]);                    
                }
            }
            catch (Exception ex)
            {
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar o anexo no banco de dados! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return anexo;
        }

        //Verifica se existe o anexo no banco de dados
        public bool ExisteAnexo(Anexo anexo)
        {
            bool resultado = false;

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            ConexaoSQL conexaoSQL = new ConexaoSQL();

            var con = conexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM ANEXO WHERE cdChamado=" 
                + anexo.cdChamado + " AND nrSequencia=" + anexo.nrSequencia;

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
                Util.GravarLog("Banco de Dados ", "Ocorreu erro ao consultar os anexos no banco de dados! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return resultado;
        }
    }
}
