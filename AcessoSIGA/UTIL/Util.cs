using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace AcessoSIGA
{
    public static class Util
    {       

        //Criar as pastas e retorna o diretório atual da aplicação
        public static string criarDiretorios()
        {
            string path = Directory.GetCurrentDirectory();

            try
            {
                if (Directory.Exists(path + @"\XML"))
                {
                    return path;
                }
                else
                {
                    Directory.CreateDirectory(path + @"\XML");
                    Directory.CreateDirectory(path + @"\XML\Envio");
                    Directory.CreateDirectory(path + @"\XML\Retorno");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao criar as pastas!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            return path;
        }

        //Limpar caracteres em uma string
        public static string limparString(string str)
		{
			string[] charsToRemove = new string[] { "\\"," ", "-", "/", "@", ",", ".", ";", ":", "'", "%", "&", "(", ")" };
			foreach (var c in charsToRemove)
			{
				str = str.Replace(c, string.Empty);
			}
			return str;
		}
     
        //Criar arquivo de LOG
        public static bool GravarLog(string operacao, string logMensagem, string nomeArquivo = "SIGA_Log")
        {
            string path = Directory.GetCurrentDirectory();
            string caminhoArquivo = Path.Combine(path, nomeArquivo + ".txt");

            try
            {               
                if (!File.Exists(caminhoArquivo))
                {
                    FileStream arquivo = File.Create(caminhoArquivo);
                    arquivo.Close();
                }

                using (StreamWriter stWriter = File.AppendText(caminhoArquivo))
                {                    
                    stWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                    stWriter.WriteLine("Operação: " + operacao);
                    stWriter.WriteLine($"Evento: " + logMensagem);
                    stWriter.WriteLine("--------------------------------------------------------------");
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar arquivo de LOG!" + ex.Message);
                return false;
            }
        }
    }
}
