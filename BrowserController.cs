using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Support.UI;

public class BrowserController
{

    public IWebDriver driver;

    public string TestName = "Default Test name";
  
    public void initBrowsers()
    {
        driver = new ChromeDriver();
    }
    public void Maximize()
    {
        driver.Manage().Window.Maximize();
    }
    public void NavigateURL(string newURL)
    {
        driver.Url = newURL;
    }

    // Wait commant for clicking
    public void ClickElementByxPathWait(string xPath)
    {
        DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        fluentWait.Timeout = TimeSpan.FromSeconds(5);
        fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        fluentWait.Message = "Element to be searched not found";
        By by = By.XPath(xPath);
        IWebElement element = fluentWait.Until(x => x.FindElement(by));
        element.Click();
    }
    // Click Method
    public void ClickElementByxPath(string xPath)
    {
        By element = By.XPath(xPath);

        driver.FindElement(element).Click();
    }
    // To check elements
    public void CheckElementExistByXpath(string xPath)
    {
        By element = By.XPath(xPath);

        driver.FindElement(element).Click();
    }

    public void CheckElementsExistByXpath(string xPath)
    {

        if (!isElementPresent(By.XPath(xPath)))
        {
            Assert.Fail("Element does not exist. XPATH: \"" + xPath + "\"");
        }
    }

    public bool isElementPresent(By locator)
    {
        return driver.FindElements(locator).Any();

    }

    // To type text
    public void EnterTextByXpath(string xPath, string text)
    {
        By element = By.XPath(xPath);
        driver.FindElement(element).SendKeys(text);
    }
    // Wait commant for Check Elements
    public void CheckElementExistByXpathWait(string xPath)
    {
        DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        fluentWait.Timeout = TimeSpan.FromSeconds(5);
        fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        fluentWait.Message = "Element to be searched not found";
        By by = By.XPath(xPath);
        IWebElement element = fluentWait.Until(x => x.FindElement(by));

    }

}
