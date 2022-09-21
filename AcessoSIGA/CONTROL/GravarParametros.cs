﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoSIGA
{
    public class GravarParametros
    {
        public Cliente ConsultarEmpresa(Cliente cliente)
        {
            string operacao = "getCustomer";
            string wsdl_file = "WSGeneral.wsdl";

            //Gera o XML de envio para o webservice
            WSGeneral wSGeneral = new WSGeneral();
            string xml = wSGeneral.XML_getCustomer(cliente.cnpj);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("Consulta empresa ", "XML de retorno vazio ou nulo!");
            }
            else
            {               
                //Lê XML de retorno e devolve os dados
                cliente = RetornarXML.retornarEmpresa(wsRetorno);
            }
            return cliente;
        }

        public Contato BuscarContato(Cliente cliente, Contato contato)
        {
            string operacao = "getCustomerContact";
            string wsdl_file = "WSGeneral.wsdl";

            //Se login não for informado busca o contato pelo e-mail informado
            if (String.IsNullOrEmpty(contato.login))
            {
                //Gera o XML de envio para o webservice
                WSGeneral wSGeneral = new WSGeneral();
                string xml = wSGeneral.XML_getCustomerContactEmail(cliente.cdCliente, contato.email);

                //Instancia o webservice passando os dados
                WService wService = new WService(operacao, wsdl_file, xml);

                //Envia a requisição POST e faz a leitura do XML de retorno
                string wsRetorno = wService.RequisicaoPOST();

                //Lê XML de retorno e devolve os dados
                contato = RetornarXML.retornarContatoEmpresa(wsRetorno);
            }
            else
            {
                //Gera o XML de envio para o webservice
                WSGeneral wSGeneral = new WSGeneral();
                string xml = wSGeneral.XML_getCustomerContactLogin(cliente.cdCliente, contato.login);

                //Instancia o webservice passando os dados
                WService wService = new WService(operacao, wsdl_file, xml);

                //Envia a requisição POST e faz a leitura do XML de retorno
                string wsRetorno = wService.RequisicaoPOST();

                //Lê XML de retorno e devolve os dados
                contato = RetornarXML.retornarContatoEmpresa(wsRetorno);
            }
            return contato;
        }

        public Contato BuscarDadosContato(Cliente cliente, Contato contato)
        {
            string operacao = "getCustomerContactData";
            string wsdl_file = "WSGeneral.wsdl";

            //Gera o XML de envio para o webservice
            WSGeneral wSGeneral = new WSGeneral();
            string xml = wSGeneral.XML_getCustomerContactData(cliente.cdCliente, contato.cdContato);

            //Instancia o webservice passando os dados
            WService wService = new WService(operacao, wsdl_file, xml);

            //Envia a requisição POST e faz a leitura do XML de retorno
            string wsRetorno = wService.RequisicaoPOST();

            if (String.IsNullOrEmpty(wsRetorno))
            {
                Util.GravarLog("Consulta dados do contato ", "XML de retorno vazio ou nulo!");
            }
            else
            {
                //Lê XML de retorno e devolve os dados
                contato = RetornarXML.retornarDadosContato(wsRetorno);
            }

            return contato;
        }
    }
}