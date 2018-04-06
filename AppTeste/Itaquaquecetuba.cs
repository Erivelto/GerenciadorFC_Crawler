using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTeste
{
    public class Itaquaquecetuba
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
            prestador.Usuario = "05.358.550/0001-09";
            prestador.Senha = "smd123";
            prestador.RazaoSocial = "CENTRO DE DIAGNOSTICOS RADIOLOGICOS ASSOCIADOS LTDA - EPP";
            prestador.Fantasia = "SMD";
            prestador.Endereco = "";
            prestador.Documento = "05.358.550/0001-09";
            prestador.InscricaoMunicipal = "";
            prestador.UF = "SP";
            prestador.Estado = "SAO PAULO";
            prestador.Tipo = "PJ";
            prestador.Cidade = "GUARULHOS";
            prestador.CodigoServico = "";
            prestador.Discriminacao = "Exames";
            prestador.UlrLogin = "http://186.233.223.100:8080/tbw/loginNFEContribuinte.jsp?execobj=NFERelacionados";
            prestador.Email = "fabioesimoes@gmail.com";

            return prestador;
        }
    }
}
