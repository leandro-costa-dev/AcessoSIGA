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
        //-------------Gravar parâmetros do Sistema----------
        public void GravarParametros(Parametros p)
        {
            if (ConexaoSQL.ExisteInformacoes("PARAMETROS"))
            {
                //--------UPDATE---------
                var con = ConexaoSQL.ConectarBancoSQL(false);
                var cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "UPDATE PARAMETROS SET " +
                        "cdCliente = @cdCliente, " +
                        "nmCliente = @nmCliente, " +
                        "cnpj = @cnpj, " +
                        "cdContato = @cdContato, " +
                        "nmContato = @nmContato, " +
                        "email = @email, " +
                        "login = @login, " +
                        "servidor = @servidor, " +
                        "banco = @banco, " +
                        "usuario = @usuario, " +
                        "senha = @senha";

                    cmd.Parameters.AddWithValue("@cdCliente", p.Cliente.cdCliente);
                    cmd.Parameters.AddWithValue("@nmCliente", p.Cliente.nmCliente);
                    cmd.Parameters.AddWithValue("@cnpj", p.Cliente.cnpj);
                    cmd.Parameters.AddWithValue("@cdContato", p.Contato.cdContato);
                    cmd.Parameters.AddWithValue("@nmContato", p.Contato.nmContato);
                    cmd.Parameters.AddWithValue("@email", p.Contato.email);
                    cmd.Parameters.AddWithValue("@login", p.Contato.login);
                    cmd.Parameters.AddWithValue("@servidor", p.servidor);
                    cmd.Parameters.AddWithValue("@banco", p.banco);
                    cmd.Parameters.AddWithValue("@usuario", p.usuario);
                    cmd.Parameters.AddWithValue("@senha", p.senha);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Configurações gravadas com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao gravar as configurações " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {
                //--------INSERT--------
                var con = ConexaoSQL.ConectarBancoSQL(false);
                var cmd = con.CreateCommand();

                try
                {
                    cmd.CommandText = "INSERT INTO PARAMETROS(cdCliente, nmCliente, cnpj, cdContato, nmContato, email, login, servidor, banco, usuario, senha) " +
                                                    "VALUES (@cdCliente, @nmCliente, @cnpj, @cdContato, @nmContato, @email, @login, @servidor, @banco, @usuario, @senha)";

                    cmd.Parameters.AddWithValue("@cdCliente", p.Cliente.cdCliente);
                    cmd.Parameters.AddWithValue("@nmCliente", p.Cliente.nmCliente);
                    cmd.Parameters.AddWithValue("@cnpj", p.Cliente.cnpj);
                    cmd.Parameters.AddWithValue("@cdContato", p.Contato.cdContato);
                    cmd.Parameters.AddWithValue("@nmContato", p.Contato.nmContato);
                    cmd.Parameters.AddWithValue("@email", p.Contato.email);
                    cmd.Parameters.AddWithValue("@login", p.Contato.login);
                    cmd.Parameters.AddWithValue("@servidor", p.servidor);
                    cmd.Parameters.AddWithValue("@banco", p.banco);
                    cmd.Parameters.AddWithValue("@usuario", p.usuario);
                    cmd.Parameters.AddWithValue("@senha", p.senha);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Configurações gravadas com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao gravar as configurações " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public Parametros consultarParametros()
        {
            Parametros parametros = new Parametros();

            SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            var con = ConexaoSQL.ConectarBancoSQL(false);
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT * FROM PARAMETROS";

            try
            {
                Cliente cliente = new Cliente();
                Contato contato = new Contato();

                da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    cliente.cdCliente = Convert.ToInt32(row["cdCliente"]);
                    cliente.nmCliente = Convert.ToString(row["nmCliente"]);
                    cliente.cnpj = Convert.ToString(row["cnpj"]);

                    contato.cdContato = Convert.ToInt32(row["cdContato"]);
                    contato.nmContato = Convert.ToString(row["nmContato"]);
                    contato.email = Convert.ToString(row["email"]);
                    contato.login = Convert.ToString(row["login"]);

                    parametros.servidor = Convert.ToString(row["servidor"]);
                    parametros.banco = Convert.ToString(row["banco"]);
                    parametros.usuario = Convert.ToString(row["usuario"]);
                    parametros.senha = Convert.ToString(row["senha"]);

                    parametros.Cliente = cliente;
                    parametros.Contato = contato;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao consultar os dados! " + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return parametros;
        }
    }
}
