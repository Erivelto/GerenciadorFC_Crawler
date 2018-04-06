using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Anticaptcha_example.Api;
using Anticaptcha_example.Helper;
using System.IO;
using System.Net.Mail;
using System.Net;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace GerenciadorFC.Robo.Receita.DAS
{
    public class ReceitaDAS
    {

        public void EmissorImpostos(GerenciadorFC.Contribuinte.Contribuinte contribuite)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\fabio\.nuget\packages\Selenium.Chrome.WebDriver\2.33.0\driver");
            driver.Navigate().GoToUrl(contribuite.Url);

            var cnpj = driver.FindElement(By.Id("ctl00_ContentPlaceHolder_txtCNPJ"));
            cnpj.SendKeys(contribuite.CNPJ); 

			var cpf = driver.FindElement(By.Id("ctl00_ContentPlaceHolder_txtCPFResponsavel"));
            cpf.SendKeys(contribuite.CPF);

            var codigo = driver.FindElement(By.Id("ctl00_ContentPlaceHolder_txtCodigoAcesso"));
            codigo.SendKeys(contribuite.CodigoContribuite);

            var captchaObject = driver.FindElement(By.Id("captcha-img"));
            var captchaSRC = captchaObject.GetAttribute("src");
            var directory = AppDomain.CurrentDomain.BaseDirectory;

            string[] imgsrcList = captchaSRC.Split(',');
            var filePath = string.Format("{0}\\captcha.png", directory);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var stream = new FileStream(filePath, FileMode.CreateNew))
            using (var binatyStream = new BinaryWriter(stream))
            {
                byte[] base64Array = Convert.FromBase64String(imgsrcList[1]);

                binatyStream.Write(base64Array);
            }

            var captchaText = ReadImage(filePath, contribuite.CodigoAntiCaptcha);

            var captchaInputText = driver.FindElement(By.Id("txtTexto_captcha_serpro_gov_br"));

            captchaInputText.SendKeys(captchaText);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder_btContinuar")).Click();

            driver.FindElement(By.XPath("//a[contains(.,'Declaração Mensal')]")).Click();
            driver.FindElement(By.XPath("//a[contains(.,'Declarar/Retificar')]")).Click();
            var dataApuracao = driver.FindElement(By.XPath("//*[@id='pa']"));
            string periodo = contribuite.mesApuracao + contribuite.anoApuracao;
            dataApuracao.SendKeys(periodo);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div/form/button")).Click();

            var gerada = IsElementPresent(By.XPath("//*[@id='jsMsgBoxConfirm']/a[2]"), driver);
            if(gerada == true)
            {
                driver.FindElement(By.XPath("//*[@id='jsMsgBoxConfirm']/a[2]")).Click();
            }
            var valor = driver.FindElement(By.Name("rpaCompInt"));
            valor.SendKeys(contribuite.ValorTributado);

            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[2]/div[2]/div/div/form/button")).Click();

            foreach (var item in contribuite.Anexo)
            {
                driver.FindElement(By.XPath("//a[contains(.,'"+ item.Anexo +"')]")).Click();
            }

            driver.FindElement(By.Id("btn-salvar")).Click();

            var mensagem = driver.FindElement(By.XPath("//div[contains(.,'MSG_E0062 - Nenhuma atividade selecionada. É necessário selecionar pelo menos uma atividade.')]"));
            if (mensagem != null)
            {
                driver.FindElement(By.XPath("//a[contains(.,'Declarar/Retificar')]")).Click();
                dataApuracao = driver.FindElement(By.XPath("//*[@id='pa']"));
                periodo = contribuite.mesApuracao + contribuite.anoApuracao;
                dataApuracao.SendKeys(periodo);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[2]/div[2]/div/div/form/button")).Click();

                valor = driver.FindElement(By.Name("rpaCompInt"));
                valor.SendKeys(contribuite.ValorTributado);

                driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[2]/div[2]/div/div/form/button")).Click();

                driver.FindElement(By.Id("btn-salvar")).Click();
            }

            var valorReceita = driver.FindElement(By.XPath("//*[@id='0001-14']/table/tbody/tr[3]/td[1]/input"));
            valorReceita.SendKeys(contribuite.ValorTributado);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[2]/div[2]/div/div/form/button")).Click();
            System.Threading.Thread.Sleep(3000);
            var icms = driver.FindElement(By.Name("icms"));
            icms.SendKeys("");
            driver.FindElement(By.XPath("//button[contains(.,'Calcular')]")).Click();
           
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[2]/div[2]/div/div/div/div/form/button[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div[2]/div/div/div/div/a[2]")).Click();
            driver.FindElement(By.XPath("//*[@id='botoes']/button[2]")).Click();
            
            string url = driver.Url.ToString();
            string[] divisor = url.Split('=');
            string arquivoDAS = "PGDASD-DAS-" + divisor[1].ToString() + ".pdf";
            
            System.Threading.Thread.Sleep(3000);
            driver.Quit();

            MailMessage mail = new MailMessage();
            
            mail.From = new MailAddress("fabioesimoes@outlook.com");
            mail.To.Add("fabioesimoes@gmail.com");
            
            //define o conteúdo
            mail.Subject = "Envio de DAS";
            mail.Body = "Teste de geração DAS automatico";
            Attachment attachment = new Attachment(@"C:\Users\fabio\Downloads\"  + arquivoDAS);
            mail.Attachments.Add(attachment);


            //envia a mensagem
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp-mail.outlook.com";
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Port = 587;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("fabioesimoes@outlook.com", "erivelto33");
            smtp.Send(mail);

        }
        private bool IsElementPresent(By by, IWebDriver driver)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public string ReadImage(string filepath, string apiKey)
        {
            string captchaText = string.Empty;

            var api = new ImageToText
            {
                ClientKey = apiKey,
                FilePath = filepath
            };

            if (!api.CreateTask())
            {
                Console.WriteLine("API v2 send failed. " + api.ErrorMessage ?? "", DebugHelper.Type.Error);
            }
            else if (!api.WaitForResult())
            {
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            }
            else
            {
                captchaText = api.GetTaskSolution();

                DebugHelper.Out("Result: " + captchaText, DebugHelper.Type.Success);
            }

            return captchaText;
        }
    }

}
