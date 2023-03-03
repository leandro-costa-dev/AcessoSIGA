using System;

namespace AcessoSIGA
{
    public class Anexo
    {
        public int id { get; set; }
        public int cdChamado { get; set; }
        public int nrSequencia { get; set; }
        public string nmAnexo { get; set; } = string.Empty;
        public string dsAnexo { get; set; } = string.Empty;
        public string dtAnexo { get; set; } = string.Empty;
        public int cdUsuario { get; set; }
        public string nmUsuario { get; set; } = string.Empty;
        public string vlTamanho { get; set; } = string.Empty;
        public int cdSituacao { get; set; }
        public string idPrivado { get; set; } = string.Empty;
    }
}
