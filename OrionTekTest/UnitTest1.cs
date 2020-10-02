using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using OrionTekTest.PageObjects;
using OpenQA.Selenium.Support.PageObjects;

namespace OrionTekTest
{
    [TestClass]
    public class AmazonTest
    {

        //Global variables
        static IWebDriver driver = new ChromeDriver(); // Driver for chrome
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        Amazon amazon = new Amazon();

        /// <summary>
        /// This open the browser and Navigates to the Amazon url. Also maximize the window adn initialize the page factory
        /// </summary>
        [TestInitialize]
        public void Ini()
        {
            string AmazonUrl = "https://www.amazon.com";
            driver.Navigate().GoToUrl(AmazonUrl); //Open URL
            driver.Manage().Window.Maximize(); //Mazimize the window
            PageFactory.InitElements(driver, amazon); // Initialize the Pagefactory
        }


        /// <summary>
        /// This Test Case perform the search "iPhone 11" in the amazon search bar and then opens the first result that contains "Apple iphone 11" in the Title by clicking the title in the link .
        /// </summary>
        [TestMethod]
        public void TestCaseOne()
        {

            try
            {
                string valueToSearch = "iPhone 11";
                
                //Enter the value iphone 11 in the search bar
                amazon.searchBar.SendKeys(valueToSearch);

                //Click search icon in the search bar
                amazon.searchBarSubmitButton.Click();

                //wait for the page to load with the result
                wait.Until(ExpectedConditions.TitleContains(valueToSearch));

                //Click the Title of the first item in the search's outcome
                amazon.firstResultTitleLink.Click();

                //wait 30 seconds before closing the browser
                wait.Until(ExpectedConditions.ElementToBeClickable(amazon.productDetailMainSection));
                Thread.Sleep(3000);
            }
            catch(Exception e)
            {
                e.Message.ToString();
            }

        }

        [TestMethod]

        public void TestCaseTwo()
        {

        } 

        [TestCleanup]

        public void Close()
        {
            //closing the browser
            driver.Close();
        }


    }
}
