using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carlist
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("C:\\driver");
            driver.Navigate().GoToUrl("http://carlist.my");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//div[contains(@class, 'selectize-input items input-readonly not-full has-options')]")).Click();

            driver.FindElement(By.XPath("//div[contains(@data-value, 'used')]")).Click();
            IWebElement carCondition = driver.FindElement(By.XPath("//div[contains(@class, 'search-button  one-whole')]"));
            carCondition.FindElement(By.XPath("//button[contains(@class, 'btn  btn--primary  one-whole')]")).Click();

            System.Threading.Thread.Sleep(4000);

            IWebElement car = driver.FindElement(By.XPath("//h2[contains(@class, 'listing__title  epsilon  flush')]"));
            car.FindElement(By.XPath("//a[contains(@class, 'ellipsize  js-ellipsize-text')]")).Click();

            IWebElement carValue = driver.FindElement(By.XPath("//div[contains(@class, 'grid__item  five-twelfths  lap-one-half  visuallyhidden--palm  text--right')]"));
            String actualCarValue = carValue.FindElement(By.XPath("//div[contains(@class, 'listing__price  delta  weight--bold')]")).Text;

            int val = int.Parse(actualCarValue.Remove(0, 3).Replace(",", ""));

            Assert.Greater(val, 1000);
            driver.Quit();
        }
    }
}
