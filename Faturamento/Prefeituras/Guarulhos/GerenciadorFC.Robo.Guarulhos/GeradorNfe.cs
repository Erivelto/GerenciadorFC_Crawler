using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace GerenciadorFC.Robo.Guarulhos
{
    public class GeradorNfe
    {
        public async Task<bool> Emissor(GerenciadorFC.Prestador.Prestador prestador, GerenciadorFC.Tomador.Tomador tomador)
        {
            bool emissor = false;
            IWebDriver driver = new ChromeDriver(@"C:\Users\fabio\.nuget\packages\Selenium.Chrome.WebDriver\2.33.0\driver");
            driver.Navigate().GoToUrl(prestador.UlrLogin);

            await Task.Delay(4000);
            
            driver.FindElement(By.Id("ext-gen18")).Click();
            await Task.Delay(4000);
            driver.FindElement(By.ClassName("x-btn-text")).Click();
            await Task.Delay(4000);
            driver.FindElement(By.ClassName("imagem1")).Click();

            var inscr = driver.FindElement(By.Id("gwt-uid-3"));
            inscr.Click();
            await Task.Delay(4000);
            var incricao = driver.FindElement(By.Id("ext-gen108"));
            incricao.SendKeys(prestador.Usuario);
            var senha = driver.FindElement(By.Id("ext-gen110"));
            senha.SendKeys(prestador.Senha);
            driver.FindElement(By.Id("ext-gen119")).Click();
            await Task.Delay(4000);
            var imagem = driver.FindElement(By.XPath("//img[@src='imgs/icon_nfse3.gif']"));
             
            if(imagem != null)
            {
                imagem.Click();
            }
            var cssSELECTOR = "input[class='x-form-field-wrap x-trigger-wrap-focus']";

            try
            {
                driver.FindElement(By.CssSelector(cssSELECTOR));
            }
            catch (Exception ex)
            {
                
            }
            var comboTipoPessoa = driver.FindElement(By.CssSelector(cssSELECTOR));

            if(comboTipoPessoa != null)
            {
                //comboTipoPessoa.Click();
                //var select_tipo = new SelectElement(tipo);
                if (prestador.Tipo == "PJ")
                {
                    //select_tipo.SelectByText("");

                    var pessoaJuridica = driver.FindElement(By.ClassName("x-combo-selected"));

                    if (pessoaJuridica != null)
                    {
                        pessoaJuridica.Click();

                    }
                }
                else
                {
                    driver.FindElement(By.Id("ext-gen1126")).Click();
                }
            }
            
           
            ///select_tipo.SelectByText("");
            // tipo.Click();
            await Task.Delay(4000);
            var razao = driver.FindElement(By.Id("ext-gen413"));
            razao.SendKeys(prestador.RazaoSocial);
            var cnpj = driver.FindElement(By.Id("ext-gen453"));
            cnpj.SendKeys(prestador.Documento);
            var inscricao = driver.FindElement(By.Id("ext-gen457"));
            incricao.SendKeys(prestador.InscricaoMunicipal);
            var cep = driver.FindElement(By.Id("ext-gen459"));
            cep.SendKeys(prestador.CEP);
            var estado = driver.FindElement(By.Id("ext-gen485"));
            estado.SendKeys(prestador.Estado.ToUpper());
            var cidade = driver.FindElement(By.Id("ext-gen487"));
            cidade.SendKeys(prestador.Cidade.ToUpper());
            var logradouro = driver.FindElement(By.Id("ext-gen469"));
            logradouro.SendKeys(prestador.Endereco);
            var numero = driver.FindElement(By.Id("ext-gen471"));
            numero.SendKeys(prestador.Numero);
            var bairro = driver.FindElement(By.Id("ext-gen473"));
            bairro.SendKeys(prestador.Bairro);
            var complemento = driver.FindElement(By.Id("ext-gen475"));
            complemento.SendKeys(prestador.Complemento);
            var email = driver.FindElement(By.Id("ext-gen477"));
            email.SendKeys(prestador.Email);
            driver.FindElement(By.Id("ext-gen440")).Click();


            return emissor;
        }
    }
}
