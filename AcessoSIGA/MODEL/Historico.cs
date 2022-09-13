using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class Historico
	{
		public int cdChamado { get; set; }
		public int cdaCompanhamento { get; set; }
		public string nmtipoacompanhamento { get; set; }
		public string dsAcompanhamento { get; set; }	
		public string nmUsuario { get; set; }
		public string dtAcompanhamento { get; set; }
		public int cdUsuario { get; set; }
		public string idSolicitante { get; set; }
		public string idSolucao { get; set; }
		public string idPrivado { get; set; }
		public string dtInicioacompanhamento { get; set; }
		public string dtTerminoacompanhamento { get; set; }
		public string nrDuracao { get; set; }
    }
}
