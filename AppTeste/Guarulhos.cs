using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTeste
{
    public class Guarulhos  
    {
        public static GerenciadorFC.Tomador.Tomador get_Tomador()
        {
            var tomador = new GerenciadorFC.Tomador.Tomador();
            tomador.Email = "fabioesimoes@gmail.com";
            tomador.Documento = "07986975000180";
            tomador.Cidade = "SAO PAULO";
            tomador.Endereco = "RUA HADDOCK LOBO";
            tomador.RazaoSocial = "TECH FOR PARTICIPAÇÕES & SISTEMAS EM TECNOLOGIA DA INFORMAÇÃO LTDA";
            tomador.Fantasia = "";
            tomador.TipoPessoa = "PJ";
            tomador.UF = "SP";
            tomador.Numero = "337";
            tomador.Bairro = "CERQUEIRA CÉSAR";
            tomador.CEP = "01414-001";

            return tomador;
        }
        public static GerenciadorFC.Prestador.Prestador get_Prestador()
        {
            var prestador = new GerenciadorFC.Prestador.Prestador();
            prestador.Valor = "100,10";
            prestador.Usuario = "293161";
            prestador.Senha = "293161DBN85553";
            prestador.RazaoSocial = "ERIVELTO SOLUCOES E TECNOLOGIAS EIRELI ME";
            prestador.Fantasia = "ERIVELTO SOLUCOES E TECNOLOGIAS";
            prestador.Endereco = "RUA GAGO COUTINHO ,354 - JARDIM VILA GALVÃO CEP: 07055-030";
            prestador.Documento = "27308027000100";
            prestador.InscricaoMunicipal = "293161";
            prestador.UF = "SP";
            prestador.Estado = "SAO PAULO";
            prestador.Tipo = "PJ";
            prestador.Cidade = "GUARULHOS";
            prestador.CodigoServico = "1.01 / 722900001";
            prestador.Discriminacao = "Serviço de desenvolvimento de software Valor de : R$ 100,00 ";
            prestador.UlrLogin = "http://guarulhos.ginfes.com.br/";
            prestador.Email = "fabioesimoes@gmail.com";

            return prestador;
        }
    }
}
