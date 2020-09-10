using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Logstore.Pedidos.Infrastructure.Shared.Helpers
{
    public class SeleniumHelper
    {
        public WebDriverWait Wait;
        public ChromeDriver driver;
        //public IWebDriver WebDriver;
        public SeleniumHelper(string directoryTemp)
        {
            //WebDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, "C:\\WebDriver", true);
            //WebDriver.Manage().Window.Maximize();
            //Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--disable-notifications");
            chromeOptions.AddUserProfilePreference("download.default_directory", directoryTemp);
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            driver = new ChromeDriver(@"C:\WebDriver", chromeOptions);
            driver.Manage().Window.Maximize();            
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        public void acessarUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public string obterUrl()
        {
            return driver.Url;
        }

        public string waitElementInvisible(string path)
        {
            try
            {
                do
                {
                }
                while (driver.WindowHandles.Count < 2);
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                var url = driver.Url;
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);
                Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(path)));
                return url;
            }
            catch(Exception err)
            {
                return "";
            }
            
        }

        public void ClicarBotaoPorName(string botaoName)
        {
            var botao = Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(botaoName)));
            botao.Click();
        }


        public void PreencherTextBoxPorId(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCampo)));
            System.Threading.Thread.Sleep(1000);
            campo.SendKeys(valorCampo);
        }

        public void PreencherTextBoxPorName(string nameCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(nameCampo)));            
            campo.SendKeys(valorCampo);
        }
        public void PreencherTextBoxPorXPath(string xPath, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            campo.Clear();
            campo.SendKeys(valorCampo);
        }
        
        public void ClicarPorXPath(string xPath)
        {
            var elemento = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            elemento.Click();
        }
        public IWebElement ObterElementoPorClasse(string classeCss)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(classeCss)));
        }

        public void AguardaBotaoHabilitar(string classButton)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(classButton)));

        }
        public void ClicarPorXPath2(string xPath)
        {
            var elemento = driver.FindElement(By.XPath(xPath));
            elemento.Click();
        }
        public IWebElement ObterElementoPorId(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        }
        public IWebElement ObterElementoPorName(string name)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(name)));
        }

        public ReadOnlyCollection<IWebElement> ObterElementosPorName(string nameFind, string nameElementWait)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(nameElementWait)));
            return driver.FindElementsByName(nameFind);
        }
        public List<string> finElementByRoot(string idRoot, string idElement, string valorCampo, string XPath)
        {
            List<string> result = new List<string>();
            ReadOnlyCollection<IWebElement> columns;
            IWebElement divNf;
            int nf = 0;
            try
            {
                var formElement = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idRoot)));
                var element = formElement.FindElement(By.Id(idElement));
                var button = Wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("img")));
                element.SendKeys(valorCampo);
                button.Click();
                //500 - Erro de servidor interno.
                if (driver.FindElementByTagName("title").GetAttribute("innerText").Contains("500")) return new List<string>() { "500" };

                var divAux = driver.FindElement(By.Id("aux"));
                var tableRoot = divAux.FindElement(By.TagName("table"));
                var table = tableRoot.FindElements(By.TagName("table"))?[1];
                var rows = table.FindElements(By.TagName("tr"));
                var contRow = 0;
                foreach (var item in rows)
                {
                    if (item.FindElements(By.TagName("td"))?[0].FindElements(By.TagName("p")).Count > 0
                        && item.FindElements(By.LinkText("Link Comprovante")).Count <= 0)
                    {
                        columns = item.FindElements(By.TagName("td"));
                        divNf = columns[1].FindElement(By.TagName("div"));
                        nf = Convert.ToInt32(divNf.FindElements(By.TagName("p"))?[1].GetAttribute("innerText").ToString().Split("/")?[0]);

                    }

                    if (item.FindElements(By.LinkText("Link Comprovante")).Count > 0)
                    {
                        if (nf.ToString() != valorCampo) continue;
                        var comprovantes = item.FindElements(By.LinkText("Link Comprovante"));
                        foreach (var itemLink in comprovantes)
                        {
                            result.Add(itemLink.GetAttribute("href"));
                        }
                        contRow++;
                    }

                }


                //var comprovantes = driver.FindElementsByLinkText("Link Comprovante");
                //if (comprovantes == null) return new List<string>() { "404" };

                //foreach (var item in comprovantes)
                //{
                //    result.Add(item.GetAttribute("href"));
                //}

            }
            catch (Exception err)
            {
                new List<string>() { "500" };
            }

            return result.Count <= 0 ? new List<string>() { "404" } : result;
        }

        public int getAbas()
        {
            return driver.WindowHandles.Count;
        }
        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
