using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagiamasis_Darbas
{
    internal class Tax
    {
        IWebDriver driver = new ChromeDriver();

        public Tax(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CheckIfTaxLTElementIsPresent(IWebDriver driver)
        {
            Console.WriteLine(driver.FindElements(By.XPath("//*[@id=\"tab1\"]/form/div[4]/input")).Count);

        }

        }
   
}

