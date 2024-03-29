﻿using System;

namespace AcessoSIGA
{
    public class Ticket
    {
        public int cdChamado { get; set; } //Código do chamado
        public int idChamado { get; set; } //1 – Chamado por solicitante, 2 – Chamado por equipamento, 3 – Chamado por produto, 4 – Chamado por IC.
        public string titChamado { get; set; } = string.Empty; //Titulo do chamado
        public string dsChamado { get; set; } = string.Empty; //Descrição do chamado
        public int cdCliente { get; set; } //Código do cliente
        public string nmCliente { get; set; } = string.Empty; //Nome do cliente
        public int cdContato { get; set; } //Código do contato
        public string nmContato { get; set; } = string.Empty; //Nome do contato     
        public int cdSituacao { get; set; } //1-Rascunho 2-Aguardando Atendimento 3-Em Atendimento 5-Suspenso 7-Encerrado 10-Enc. Terceiros
        public string nmSituacao { get; set; } = string.Empty; //Nome da situação
        public int tipoChamado { get; set; } //Tipo de chamado definido na tabela do SIGA
        public int cdCategoria { get; set; }//Tipo de categoria definido na tabela do SIGA
        public string nmCategoria { get; set; } = string.Empty; //Nome da categoria
        public string nmResponsavel { get; set; } = string.Empty; //Nome do responsável
        public int cdLocalidade { get; set; } //Localidade do CRC do cliente
        public int cdSeveridade { get; set; } //Severidade definido na tabela do SIGA
        public int cdOrigem { get; set; } //Tipo de origem definido na tabela do SIGA
        public int cdAnimo { get; set; } //Animo do solicitante definido no SIGA
        public string dataChamado { get; set; } = string.Empty; //Data abertura do chamado        
    }
}
