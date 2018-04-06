using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTeste
{
    public class ReceitaDAS
    {
        public static GerenciadorFC.Contribuinte.Contribuinte get_contribuite()
        {
            var contribuite = new GerenciadorFC.Contribuinte.Contribuinte();
            contribuite.CNPJ = "27308027000100";
            contribuite.CPF = "27952666878";
            contribuite.CodigoContribuite = "918126119242";
            contribuite.Url = "https://www8.receita.fazenda.gov.br/SimplesNacional/controleAcesso/Autentica.aspx?id=60";
            contribuite.CodigoAntiCaptcha = "00104610857095f5ae8953b5ee208d11";
            contribuite.mesApuracao = "01";
            contribuite.anoApuracao = "2018";
            contribuite.ValorTributado = "8.500,00";

            var anexo = new GerenciadorFC.Contribuinte.AnexoContribuinte();

            List<GerenciadorFC.Contribuinte.AnexoContribuinte> listaAnexo = new List<GerenciadorFC.Contribuinte.AnexoContribuinte>();

            anexo.Anexo = "Não sujeitos ao fator “r” e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento";

            listaAnexo.Add(anexo);

            contribuite.Anexo = listaAnexo;
            
            return contribuite;
        }
    }
}
