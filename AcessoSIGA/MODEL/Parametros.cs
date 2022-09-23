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
        public Ticket Ticket { get; set; }
        public string servidor { get; set; } = string.Empty; //Caminho de acesso a base de dados
        public string banco { get; set; } = string.Empty; //Nome da base de dados
        public string usuario { get; set; } = string.Empty; //Usuario de acesso ao SQL
        public string senha { get; set; } = string.Empty; //Senha de acesso ao SQL

    }
}
