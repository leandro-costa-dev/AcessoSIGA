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
		public int cdAcompanhamento { get; set; }
		public string nmTipoacompanhamento { get; set; } = string.Empty;
		public string dsAcompanhamento { get; set; } = string.Empty;
		public string nmUsuario { get; set; } = string.Empty;
		public string dtAcompanhamento { get; set; } = string.Empty;
		public int cdUsuario { get; set; }
		public string idSolicitante { get; set; } = string.Empty;
		public string idSolucao { get; set; } = string.Empty;
		public string idPrivado { get; set; } = string.Empty;
		public string dtInicioacompanhamento { get; set; } = string.Empty;
		public string dtTerminoacompanhamento { get; set; } = string.Empty;
		public string nrDuracao { get; set; } = string.Empty;
	}
}
