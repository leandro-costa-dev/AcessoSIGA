using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class CtrHistorico
    {
        //Atualiza o registro de históricos no banco de dados
        public void AtualizaHistoricoChamados()
        {
            List<Ticket> listaTicket_ret = new List<Ticket>();

            List<Ticket> listaTicket = new List<Ticket>();
            List<Historico> listaHistorico = new List<Historico>();

            CtrChamado ctrChamado = new CtrChamado();

            ChamadoDAO chamadoDAO = new ChamadoDAO();
            HistoricoDAO historicoDAO = new HistoricoDAO();

            listaTicket = chamadoDAO.ConsultaChamadosAtivos();

            Ticket ticket = new Ticket();

            foreach (Ticket t in listaTicket)
            {
                listaHistorico = ctrChamado.ConsultarHistoricoChamado(t.cdChamado);
                ticket = ctrChamado.ConsultarDadosChamado(t.cdChamado);

                //Atualiza informações do chamado
                chamadoDAO.GravarChamado(ticket);

                //Verifica se existe novo registro e grava histórico do chamado 
                historicoDAO.GravarHistorico(listaHistorico);
            }            
        }

        //Retorna o historico se acompanhamento for diferente de rascunho
        // e se o histórico ainda não foi visualizado 
        public List<Historico> ConsultaNovoHistorico()
        {
            List<Ticket> listaTicket = new List<Ticket>();          
            List<Historico> listaHistorico = new List<Historico>();

            ChamadoDAO chamadoDAO = new ChamadoDAO();            
            listaTicket = chamadoDAO.ConsultaChamadosAtivos();

            foreach (Ticket t in listaTicket)
            {
                HistoricoDAO historicoDAO = new HistoricoDAO();
                List<Historico> lista = historicoDAO.ConsultaHistorico(t.cdChamado);     

                foreach (Historico h in lista)
                {                    
                    if(h.cdAcompanhamento != 1 && h.controle == 0)
                    {
                        Ticket ticket = chamadoDAO.ConsultaChamado(h.cdChamado);
                        ParametrosDAO parametrosDAO = new ParametrosDAO();
                        Parametros parametros = parametrosDAO.ConsultarParametros();

                        //Verificar se o contato do chamado é igual ao gravado no parametro
                        if(ticket.cdContato == parametros.Contato.cdContato)
                        {
                            listaHistorico.Add(h);
                        }                                                
                    }
                }
            }
            return listaHistorico;
        }
    }
}
