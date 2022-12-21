using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Bagiamasis_Darbas;
using System.Security.Cryptography.X509Certificates;

namespace Baigiamasis_darbas
{


    public class MainTests
    {
        BrowserController brContr = new BrowserController();

        Tax tax;

        private object actualResultText;
        public string TestName = "Default Test name";

        [SetUp]
        public void builUp()
        {
            tax = new Tax(brContr.driver);
            brContr.initBrowsers();
            brContr.Maximize();
            brContr.NavigateURL("https://www.tax.lt/");
        }

        [TearDown]
        public void tear()
        {
            //Screenshoto gavimas
            try
            {
                Screenshot TakeScreenshot = ((ITakesScreenshot)brContr.driver).GetScreenshot();
                //DateTime time = new DateTime();
                string time = "" + DateTime.Now.ToString("HH:mm");
                Console.WriteLine("_" + time);
                time = time.Replace(':', '_');
                TakeScreenshot.SaveAsFile("C:\\Users\\Gunit\\source\\repos\\Bagiamasis Darbas\\FailedTest\\" + TestName + time + ".png");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            brContr.driver.Quit();
        }
        

        [Test]

        public void CheckingIfInputIsCorrect()
        {
            //Check/Accept cookies:
            brContr.CheckElementExistByXpathWait("/ html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p");
            brContr.ClickElementByxPathWait("/ html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p");
            // Go to: ATLYGINIMO IR MOKESCIU SKAICIUOKLE:
            brContr.ClickElementByxPath("//*[@id=\"main_menu\"]/ul/li[3]/a");
            brContr.ClickElementByxPath("//*[@id=\"main_menu\"]/ul/li[3]/ul/li[1]/a");
            //Click on 2018 Metai:
            brContr.ClickElementByxPath("//*[@id=\"mokestiniai_metai\"]/option[6]");
            // Click "I RANKAS"
            brContr.ClickElementByxPath("//*[@id=\"tax_calculator_form\"]/div/div[1]/div[2]/div/label[2]");
            //Ivedam suma 1100:
            brContr.EnterTextByXpath("//*[@id=\"atlyginimas\"]", "1100");
        }

        [Test]

        public void CheckingPvmSkaiciuokleTypeBox()
        {
            //Check/Accept cookies:
            brContr.CheckElementExistByXpathWait("/ html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p");
            brContr.ClickElementByxPathWait("/ html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p");
            //Go to: PVM SKAICIUKLE
            brContr.ClickElementByxPath("//*[@id=\"main_menu\"]/ul/li[3]/a");
            brContr.ClickElementByxPath("//*[@id=\"main_menu\"]/ul/li[3]/ul/li[4]/a");
            //Tikrinam su 21%:
            brContr.ClickElementByxPath("//*[@id=\"vat_percent\"]");
            brContr.EnterTextByXpath("//*[@id=\"amount_wo_vat\"]", "+1Į0&L?");
            //Tikrinam su 9%:
            brContr.ClickElementByxPath("//*[@id=\"vat_percent\"]/option[2]");
        }

        [Test]

        public void CheckIfTaxLTElementIsPresent()
        {
            //Check/Accept cookies:
            brContr.CheckElementExistByXpathWait("/ html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p");
            brContr.ClickElementByxPathWait("/ html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p");

            //Checking If "Prisijungti" button is present:
            //Per kita CLASS
            brContr.NavigateURL("https://www.tax.lt/login");

            tax.CheckIfTaxLTElementIsPresent(brContr.driver);

        }

        [Test]
        public void CheckingFalseElementsFail()
        {
            TestName = "CheckingFalseElementsFail";

            //Check/Accept cookies:
            brContr.CheckElementExistByXpathWait("/ html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p");
            brContr.ClickElementByxPathWait("/ html/body/div[3]/div[2]/div[1]/div[2]/div[2]/button[1]/p");
            // Go to: Valiutu Skaiciuokle:
            brContr.ClickElementByxPath("//*[@id=\"main_menu\"]/ul/li[3]/a");
            brContr.ClickElementByxPath("//*[@id=\"main_menu\"]/ul/li[3]/ul/li[3]/a");
            // Checking If element (1) is present:
            brContr.CheckElementsExistByXpath("//*[@id=\"add_currency\"]/option[19]");
            // Checking If element (2) is present:
            brContr.CheckElementExistByXpathWait("//Labas");
        }
       

        
    }
}




