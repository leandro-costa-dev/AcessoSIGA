using System;

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
		public string idEmail { get; set; } = string.Empty;
		public string idSolucao { get; set; } = string.Empty;
		public string idPrivado { get; set; } = string.Empty;
		public string dtInicioacompanhamento { get; set; } = string.Empty;
		public string dtTerminoacompanhamento { get; set; } = string.Empty;
		public string nrDuracao { get; set; } = string.Empty;
		public int controle { get; set; } //Flag controle histórico 0-Novo 1-Visualizado
	}
}
