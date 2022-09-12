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
        public int idChamado { get; set; } //1 – Chamado por solicitante, 2 – Chamado por equipamento, 3 – Chamado por produto, 4 – Chamado por IC.
        public string titChamado { get; set; } //Titulo do chamado
        public string dsChamado { get; set; } //Descrição do chamado
        public int cdCliente { get; set; } //Código do cliente
        public string nmCliente { get; set; } //Nome do cliente
        public int cdContato { get; set; } //Código do contato
        public string nmContato { get; set; } //Nome do contato     
        public string sitChamado { get; set; } //Situação do chamado
        public string nmSituacao { get; set; } //Nome da situação
        public int tipoChamado { get; set; } //Tipo de chamado definido na tabela do SIGA
        public int cdCategoria { get; set; }//Tipo de categoria definido na tabela do SIGA
        public string nmCategoria { get; set; } //Nome da categoria
        public int cdLocalidade { get; set; } //Localidade do CRC do cliente
        public int severidade { get; set; } //Severidade definido na tabela do SIGA
        public int cdOrigem { get; set; } //Tipo de origem definido na tabela do SIGA
        public int animo { get; set; } //Animo do solicitante definido no SIGA
        public string dataChamado { get; set; } //Data abertura do chamado
        public int idTIpoPeriodo { get; set; } //1-data de abertura, 2-data de término, 3-data de previsão de resposta, 4-data de previsão de término.
        public string dtPeriodo1 { get; set; } //YYYY-MM-DD
        public string dtPeriodo2 { get; set; } //YYYY-MM-DD     
        public string anexo { get; set; } //Anexo do chamado
        public string dsAnexo { get; set; } //Descrição do anexo
    }
}
