using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace THEREISLITERALLYNOSENSETODOIT
{
    public class ResultsPage
    {
        private readonly IWebDriver _driver;

        public ResultsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
       
        private const string Industries = "#main > div.content-container.parsys > div:nth-child(5) > section > div > div > div > div.detail-pages-filter__top-panel.pinned-filter > div > div > span:nth-child(1) > div > div.selected-params";
        private const string FinancialServices = "#main > div.content-container.parsys > div:nth-child(5) > section > div > div > div > div.detail-pages-filter__top-panel.pinned-filter > div > div > span:nth-child(1) > div > div.multi-select-dropdown-container > div > ul > li:nth-child(1) > label > span";
        private const string SelectedIndustries = "#main > div.content-container.parsys > div:nth-child(5) > section > div > div > div > ul > li";

        [FindsBy(How = How.CssSelector, Using = Industries)]
        private IWebElement industriesElement;
        [FindsBy(How = How.CssSelector, Using = FinancialServices)]
        private IWebElement financialServicesElement;
        [FindsBy(How = How.CssSelector, Using = SelectedIndustries)]
        private IWebElement selectedIndustriesElement;
        
      public string Filtering()
       {
           new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(industriesElement));
           industriesElement.Click();
           
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(financialServicesElement));
            financialServicesElement.Click();
            
            string res = selectedIndustriesElement.GetAttribute("innerHTML");
            return res;
       }
    }
}