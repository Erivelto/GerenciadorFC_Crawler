using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTeste
{
    public class Aruja
    {
        public static GerenciadorFC.Tomador.Tomador get_Tomador()
        {
            var tomador = new GerenciadorFC.Tomador.Tomador();
            tomador.Email = "fabioesimoes@gmail.com";
            tomador.Documento = "27.308.027/0001-00";
            tomador.Cidade = "SAO PAULO";
            tomador.Endereco = "RUA DR NICOLINO MORENA";
            tomador.RazaoSocial = "ERIVELTO SOLUCOES E TECNOLOGIAS EIRELI - ME";
            tomador.Fantasia = "ERIVELTO SOLUCOES E TECNOLOGIAS";
            tomador.TipoPessoa = "PJ";
            tomador.UF = "SP";
            tomador.Numero = "283";
            tomador.Bairro = "VILA CONSTANCIA";
            tomador.CEP = "02257-000";
           
            return tomador;
        }
        public static GerenciadorFC.Prestador.Prestador get_Prestador()
        {
            var prestador = new GerenciadorFC.Prestador.Prestador();
            prestador.Valor = "10,10";
            prestador.Usuario = "08.965.739/0001-40";
            prestador.Senha = "UNN051";
            prestador.RazaoSocial = "ESCOLA DE EDUCACAO INFANTIL E FUNDAMENTAL LITTLE STAR LTDA - ME";
            prestador.Fantasia = "COLEGIO LITTLE STAR ";
            prestador.Endereco = "";
            prestador.Documento = "08.965.739/0001-40";
            prestador.InscricaoMunicipal = "";
            prestador.UF = "SP";
            prestador.Estado = "SAO PAULO";
            prestador.Tipo = "PJ";
            prestador.Cidade = "GUARULHOS";
            prestador.CodigoServico = "";
            prestador.Discriminacao = "Mensalidade mensal";
            prestador.UlrLogin = "http://servicos.prefeituradearuja.sp.gov.br:8080/tbw/loginNFEContribuinte.jsp?execobj=NFERelacionados";
            prestador.Email = "fabioesimoes@gmail.com";

            return prestador;
        }
    }
}
