using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class Contato
    {        
        public string nmContato { get; set; } = string.Empty;
        public int cdContato { get; set; }
        public int cdCliente { get; set; }
        public string login { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    }
}
