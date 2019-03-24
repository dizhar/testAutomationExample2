using Microsoft.VisualStudio.TestTools.UnitTesting;
using NugetCalculator;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace testAutomationExample2
{
    [TestClass]
    public class UnitTest1
    {



        [TestMethod]
        public void SearchReults_Success()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver();

            //ACT
            driver.Navigate().GoToUrl("http://google.com");
            Thread.Sleep(1000); 
            var inputField = driver.FindElement(By.CssSelector("#tsf > div:nth-child(2) > div > div.RNNXgb > div > div.a4bIc > input"));
            Thread.Sleep(1000);
            inputField.SendKeys("סלע מובילים בהייטק");
            inputField.SendKeys(Keys.Return);
            var results = driver.FindElements(By.PartialLinkText("סלע מובילים בהייטק"));
            Assert.IsTrue(results.Count > 0);
            driver.Quit();
        }



        [TestMethod]
        public void SearchResults_Failuer()
        {

           //ACT
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://google.com");
            Thread.Sleep(1000);

            //ACT
            var inputField = driver.FindElement(By.CssSelector("#tsf > div:nth-child(2) > div > div.RNNXgb > div > div.a4bIc > input"));
            Thread.Sleep(1000);
            inputField.SendKeys("סלע מובילים בהייטק");
            inputField.SendKeys(Keys.Return);
            Thread.Sleep(1000);
            var results = driver.FindElements(By.PartialLinkText("סלע מובילים בהייטק777777"));

            //Assert
            Assert.IsFalse(results.Count > 0);
            driver.Quit();
        }



        [TestMethod]
        public void AddTwoNumber_Success()
        {
            //Arrange
            const int firstNumber = 1;
            const int secondNumber = 2;
            var calculator =  new Calculator();

            //ACT
            var result = calculator.add(firstNumber, secondNumber);


            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddTwoNumber_Faliuer()
        {
            //Arrange
            const int firstNumber = 1;
            const int secondNumber = 2;
            var calculator = new Calculator();

            //ACT
            var result = calculator.add(firstNumber, secondNumber);

            //Assert
            Assert.AreNotEqual(4, result);
        }





    }
}
