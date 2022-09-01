using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class Ticket
    {
        public int cdChamado { get; set; }
        public int idChamado { get; set; }
        public string titChamado { get; set; }
        public string dsChamado { get; set; }
        public int cdCliente { get; set; }
        public string nmCliente { get; set; }
        public int cdContato { get; set; }
        public string nmContato { get; set; }       
        public string sitChamado { get; set; }
        public int tipoChamado { get; set; }
        public int cdCategoria { get; set; }
        public string nmCategoria { get; set; }
        public int cdLocalidade { get; set; }
        public int severidade { get; set; }
        public int cdOrigem { get; set; }
        public string nmSituacao { get; set; }
        public int animo { get; set; }
        public DateTime dataChamado { get; set; }       
        public int idTIpoPeriodo { get; set; } //1-data de abertura, 2-data de término, 3-data de previsão de resposta, 4-data de previsão de término.
        public string dtPeriodo1 { get; set; } //YYYY-MM-DD
        public string dtPeriodo2 { get; set; } //YYYY-MM-DD     
    }
}
