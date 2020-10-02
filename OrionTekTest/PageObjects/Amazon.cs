using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OrionTekTest.PageObjects
{

    /// <summary>
    /// USING THE PAGE FACTORY in the PAGE OBJECT Design Pattern. This is the Amazon Page Object. 
    /// </summary>
    public class Amazon
    {
        private IWebDriver driver;

        // Search bar element on the DOM
        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        public IWebElement searchBar { get; set; }

        //submit button on the DOM
        [FindsBy(How = How.Id, Using = "nav-search-submit-text")]
        public IWebElement searchBarSubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Apple iPhone 11')]/parent::a")]
        public IWebElement firstResultTitleLink { get; set; }

        [FindsBy(How = How.Id, Using = "root")]
        public IWebElement productDetailMainSection { get; set; }




    }
}
