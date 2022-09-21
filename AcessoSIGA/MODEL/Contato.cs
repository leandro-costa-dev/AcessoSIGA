using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class Contato
    {                
        public int cdContato { get; set; }
        public string nmContato { get; set; } = string.Empty;
        public int cdCliente { get; set; }
        public string nmCliente { get; set; } = string.Empty;
        public int cdLocalidade { get; set; }
        public string nmLocalidade { get; set; } = string.Empty;
        public string cpfCnpj { get; set; } = string.Empty;
        public string login { get; set; } = string.Empty;
        public string telefone { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    }
}
