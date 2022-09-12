using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class Parametros
    {
        public Cliente Cliente { get; set; }
        public Contato Contato { get; set; }
        public string servidor { get; set; } //Caminho de acesso a base de dados
        public string banco { get; set; } //Nome da base de dados
        public string usuario { get; set; } //Usuario de acesso ao SQL
        public string senha { get; set; } //Senha de acesso ao SQL

    }
}
