using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTeste
{
    public class SaoPaulo
    {
        public static GerenciadorFC.Tomador.Tomador get_Tomador()
        {
            var tomador = new GerenciadorFC.Tomador.Tomador();
            tomador.Email = "fabioesimoes@gmail.com";
            tomador.Documento = "26.100.426/0001-00";
            tomador.Cidade = "GUARULHOS";
            tomador.Endereco = "R GAGO COUTINHO";
            tomador.RazaoSocial = "DENISE VIANA BRENHA SIMOES 30839502842 ";
            tomador.Fantasia = "ATELIER ENCENADA ARTES E MIMOS ";
            tomador.TipoPessoa = "PJ";
            tomador.UF = "SP";
            tomador.Numero = "283";
            tomador.Bairro = "R GAGO COUTINHO";
            tomador.CEP = "07055-030";

            return tomador;
        }
        public static GerenciadorFC.Prestador.Prestador get_Prestador()
        {
            var prestador = new GerenciadorFC.Prestador.Prestador();
            prestador.Valor = "10,10";
            prestador.Usuario = "27.308.027/0001-00";
            prestador.Senha = "Fabio27308027";
            prestador.RazaoSocial = "ERIVELTO SOLUCOES E TECNOLOGIAS EIRELI - ME";
            prestador.Fantasia = "ERIVELTO SOLUCOES E TECNOLOGIAS";
            prestador.Endereco = "";
            prestador.Documento = "27.308.027/0001-00";
            prestador.InscricaoMunicipal = "";
            prestador.UF = "SP";
            prestador.Estado = "SAO PAULO";
            prestador.Tipo = "PJ";
            prestador.Cidade = "SAO PAULO";
            prestador.CodigoServico = "";
            prestador.Discriminacao = "Trabalho de ti";
            prestador.UlrLogin = "https://nfe.prefeitura.sp.gov.br/login.aspx?ReturnUrl=%2fcontribuinte%2fnota.aspx";
            prestador.Email = "fabioesimoes@gmail.com";

            return prestador;
        }

    }
}
