using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class Historico
	{
		public int cdchamado { get; set; }
		public int cdacompanhamento { get; set; }
		public string nmtipoacompanhamento { get; set; }
		public string dsacompanhamento { get; set; }	
		public string nmusuario { get; set; }
		public string dtacompanhamento { get; set; }
		public int cdusuario { get; set; }
		public string idsolicitante { get; set; }
		public string idsolucao { get; set; }
		public string idprivado { get; set; }
		public string dtinicioacompanhamento { get; set; }
		public string dtterminoacompanhamento { get; set; }
		public string nrduracao { get; set; }
    }
}
