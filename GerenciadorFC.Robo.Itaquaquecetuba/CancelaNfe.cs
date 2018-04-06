using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

namespace GerenciadorFC.Robo.Itaquaquecetuba
{
    public class CancelaNfe
    {
        public bool Cancelar(string nfe, GerenciadorFC.Prestador.Prestador prestador)
        {
            bool cancela = false;

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

            if (driver.PageSource.ToString().Contains(">Normal</span>"))
            {
                driver.FindElement(By.Id("img1")).Click();
                List<IWebElement> lisframe = new List<IWebElement>(driver.FindElements(By.TagName("iframe")));
                var frameTeste = lisframe[1];
                var frameC = frameTeste;
                var _frameC = driver.SwitchTo().Frame(frameC);
                var frame2C = _frameC.SwitchTo().Frame(_frameC.FindElement(By.Id("inferior")));
                var textArea = _frameC.FindElement(By.Id("textarea1"));
                textArea.SendKeys("Cancelada");
                _frameC.FindElement(By.Id("_CBobtOk")).Click();
                cancela = true;
                driver.Quit();
            }


            return cancela;
        }

    }
}
