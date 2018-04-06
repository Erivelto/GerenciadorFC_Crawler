using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;

namespace GerenciadorFC.Robo.Aruja
{
    public class GeradorNfe
    {
        public string Emissor(GerenciadorFC.Prestador.Prestador prestador, GerenciadorFC.Tomador.Tomador tomador)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\fabio\.nuget\packages\Selenium.Chrome.WebDriver\2.33.0\driver");
            driver.Navigate().GoToUrl(prestador.UlrLogin);

            var inscricao = driver.FindElement(By.Id("usuario"));
            inscricao.SendKeys(prestador.Usuario);
            var senha = driver.FindElement(By.Id("senha"));
            senha.SendKeys(prestador.Senha);

            driver.FindElement(By.Id("closebuttons1btOk")).Click();
            driver.FindElement(By.Id("img1")).Click();

            var documento = driver.FindElement(By.Id("qycnpjcpf"));
            documento.SendKeys(tomador.Documento);
            var nome = driver.FindElement(By.Id("qynome"));
            nome.SendKeys(tomador.RazaoSocial);
            if (tomador.TipoPessoa == "PF")
            {
                var checkPF = driver.FindElement(By.Id("qytppessoaradioFisica"));
                checkPF.Click();
            }
            var cep = driver.FindElement(By.Id("input8"));
            cep.SendKeys(tomador.CEP);

            var endereco = driver.FindElement(By.Id("input6"));
            endereco.SendKeys(tomador.Endereco + " "+ tomador.Numero);

            var bairro = driver.FindElement(By.Id("input4"));
            bairro.SendKeys(tomador.Bairro);

            var cidade = driver.FindElement(By.Id("input2"));
            cidade.SendKeys(tomador.Cidade);

            var uf = driver.FindElement(By.Id("input3"));
            uf.SendKeys(tomador.UF);

            var email = driver.FindElement(By.Id("input10"));
            email.SendKeys(tomador.Email);

            var codigo = driver.FindElement(By.Id("icodigo"));
            codigo.SendKeys("0");

            var discriminacao = driver.FindElement(By.Id("qynfitensdescritem"));
            discriminacao.SendKeys(prestador.Discriminacao);

            var qtde = driver.FindElement(By.Id("qynfitensqtd"));
            qtde.SendKeys("1");

            var valor_uni = driver.FindElement(By.Id("qynfitensvlrunitario"));
            valor_uni.Clear();
            valor_uni.SendKeys(prestador.Valor.Replace(",", "."));

            var valor = driver.FindElement(By.Id("qynfitensvlrtotal"));
            valor.Clear();
            valor.SendKeys(prestador.Valor.Replace(",","."));


            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("imagebutton1Imagem")).Click();


            var imposto = driver.FindElement(By.Id("qytotalimpostoaprox"));
            imposto.SendKeys("0,00");

            var aliquota = driver.FindElement(By.Id("qyaliquotaimpostoaprox"));
            aliquota.SendKeys("0");
            
            System.Threading.Thread.Sleep(2000);             
            driver.FindElement(By.Id("imagebutton4Imagem")).Click();

            System.Threading.Thread.Sleep(2000);
            IWebElement tabela = driver.FindElement(By.Id("table7"));
            var nfe = "";
            List<IWebElement> listTD = new List<IWebElement>(tabela.FindElements(By.TagName("td")));
            foreach (var item in listTD)
            {
                if (item.Text.Contains("A nota fiscal número"))
                {
                    nfe = item.Text.ToString();
                    nfe = Regex.Replace(nfe, @"[^\d]", "");
                }
            }

            System.Threading.Thread.Sleep(2000);            
            driver.Quit();

            return nfe;
        }
    }
}
