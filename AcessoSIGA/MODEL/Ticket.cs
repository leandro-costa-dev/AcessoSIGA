using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class Ticket
    {
        public int cdChamado { get; set; } //Código do chamado
        public int idChamado { get; set; } //ID do chamado
        public string titChamado { get; set; } //Titulo do chamado
        public string dsChamado { get; set; } //Descrição do chamado
        public int cdCliente { get; set; } //Código do cliente
        public string nmCliente { get; set; } //Nome do cliente
        public int cdContato { get; set; } //Código do contato
        public string nmContato { get; set; } //Nome do contato     
        public string sitChamado { get; set; } //Situação do chamado
        public int tipoChamado { get; set; }
        public int cdCategoria { get; set; }
        public string nmCategoria { get; set; }
        public int cdLocalidade { get; set; }
        public int severidade { get; set; }
        public int cdOrigem { get; set; }
        public string nmSituacao { get; set; }
        public int animo { get; set; }
        public string dataChamado { get; set; }       
        public int idTIpoPeriodo { get; set; } //1-data de abertura, 2-data de término, 3-data de previsão de resposta, 4-data de previsão de término.
        public string dtPeriodo1 { get; set; } //YYYY-MM-DD
        public string dtPeriodo2 { get; set; } //YYYY-MM-DD     
        public string anexo { get; set; } //Anexo do chamado
        public string dsAnexo { get; set; } //Descrição do anexo
    }
}
