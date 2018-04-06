using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;
using System.IO;
using Anticaptcha_example.Api;
using Anticaptcha_example.Helper;

namespace GerenciadorFC.Robo.SaoPaulo
{
    public class GeradorNfe
    {
        public void Emissor(GerenciadorFC.Prestador.Prestador prestador, GerenciadorFC.Tomador.Tomador tomador)
        {
            //IWebDriver driver = new ChromeDriver(@"C:\Users\fabio\.nuget\packages\Selenium.Chrome.WebDriver\2.33.0\driver");
            //driver.Navigate().GoToUrl(prestador.UlrLogin);

            //foreach (System.Net.Cookie cook in response.Cookies)
            //{
            //    driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cook.Name, cook.Value));
            //}


            //return "";
        }

        public async Task AcessarReceita()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Financeiro\Documents\Alex"); // new RemoteWebDriver(new  Uri( "http://localhost:9515"), DesiredCapabilities.Chrome());#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            driver.Navigate().GoToUrl("https://www8.receita.fazenda.gov.br/SimplesNacional/controleAcesso/Autentica.aspx?id=6");
            await Task.Delay(1000);

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

            var captchaText = ReadImage(filePath, "PEGAR API KEY NO EMAIL");

            var captchaInputText = driver.FindElement(By.Id("txtTexto_captcha_serpro_gov_br"));

            captchaInputText.SendKeys(captchaText);
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
