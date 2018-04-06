using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;

namespace GerenciadorFC.Robo.Itaquaquecetuba
{
    public class ConsultaNfe
    {
        public string Consulta(string nfe, GerenciadorFC.Prestador.Prestador prestador)
        {

            IWebDriver driver = new ChromeDriver(@"C:\Users\fabio\Documents\ChromeDriver");
            driver.Navigate().GoToUrl(prestador.UlrLogin);

            var inscricao = driver.FindElement(By.Id("usuario"));
            inscricao.SendKeys(prestador.Usuario);
            var senha = driver.FindElement(By.Id("senha"));
            senha.SendKeys(prestador.Senha);

            driver.FindElement(By.Id("closebuttons1btOk")).Click();
            driver.FindElement(By.Id("td11")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            var frame = driver.FindElement(By.TagName("iframe"));
            ///driver.SwitchTo().DefaultContent();
            ///
            ///await Task.Delay(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            var _frame = driver.SwitchTo().Frame(frame);


            var frame2 = _frame.SwitchTo().Frame(_frame.FindElement(By.Id("inferior")));

            var pesquisa = _frame.FindElement(By.Id("_vlrCampo"));
            pesquisa.SendKeys(nfe);
            _frame.FindElement(By.XPath("//*[@id='_CBoTrOk']/td[2]")).Click();
            driver.SwitchTo().DefaultContent();
            System.Threading.Thread.Sleep(3000);

            driver.FindElement(By.Name("gridCheck")).Click();
            string currentHandle = driver.CurrentWindowHandle;
            ReadOnlyCollection<string> originalHandles = driver.WindowHandles;

            driver.FindElement(By.XPath("//*[@id='imagebutton1Imagem']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            string popupWindowHandle = wait.Until<string>((d) =>
            {
                string foundHandle = null;

                List<string> newHandles = driver.WindowHandles.Except(originalHandles).ToList();
                if (newHandles.Count > 0)
                {
                    foundHandle = newHandles[0];
                }

                return foundHandle;
            });

            var windows = driver.SwitchTo().Window(popupWindowHandle);

            var urlPDF = windows.Url.ToString();

            string fileNane = prestador.Documento.Replace("/", "").Replace(".", "").Replace("-", "") + "_" + nfe + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".pdf";
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string caminho = Path.Combine("E:\\Projeto\\GerenciadorFC\\GerenciadorFC.Robo.Itaquaquecetuba\\", "NfePDF");
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(urlPDF, caminho + "\\" + fileNane);
            }
            windows.Quit();
            driver.Quit();

            return fileNane;
        }
    }
}
