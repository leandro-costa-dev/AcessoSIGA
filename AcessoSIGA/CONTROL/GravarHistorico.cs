using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class GravarHistorico
    {
        //Atualiza o registro de históricos no banco de dados
        public List<Ticket> AtualizaHistoricoChamados()
        {
            List<Ticket> listaTicket_ret = new List<Ticket>();

            List<Ticket> listaTicket = new List<Ticket>();
            List<Historico> listaHistorico = new List<Historico>();

            GravarChamado gravarChamado = new GravarChamado();

            ChamadoDAO chamadoDAO = new ChamadoDAO();
            HistoricoDAO historicoDAO = new HistoricoDAO();

            listaTicket = chamadoDAO.ConsultaChamadosAtivos();

            Ticket ticket = new Ticket();

            foreach (Ticket t in listaTicket)
            {
                listaHistorico = gravarChamado.consultarHistoricoChamado(t.cdChamado);
                ticket = gravarChamado.consultarDadosChamado(t.cdChamado);

                //Atualiza informações do chamado
                chamadoDAO.GravarChamado(ticket);

                //Verifica se existe novo registro e grava histórico do chamado 
                if (historicoDAO.GravarHistorico(listaHistorico))
                {

                    listaTicket_ret.Add(t);
                }
            }
            return listaTicket_ret;
        }
    }
}
