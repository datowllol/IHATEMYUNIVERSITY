using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace THEREISLITERALLYNOSENSETODOIT
{
    public class DobkinProfile
    {
        private readonly IWebDriver _driver;

        public DobkinProfile(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
       
        private const string ArkadiiDobkin = "#main > div.content-container.parsys > div:nth-child(1) > section > div > div.person-info > article > header > h1";

        
        [FindsBy(How = How.CssSelector, Using = ArkadiiDobkin)]
        private IWebElement dobkinElement;

        
      public string ArkadiiDobkinFinalCheck()
       {

      
           string res = dobkinElement.GetAttribute("innerHTML");
           return res;
       }
    }
}