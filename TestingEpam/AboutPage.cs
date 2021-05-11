using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace THEREISLITERALLYNOSENSETODOIT
{
    public class AboutPage
    {
        private readonly IWebDriver _driver;

        public AboutPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
       
        private const string ArkadiiDobkin = "#main > div.content-container.parsys > div:nth-child(3) > section > div > div > div > div.colctrl__col.colctrl__col--width-40.colctrl__col--top-0.colctrl__col--right-0.colctrl__col--bottom-0.colctrl__col--left-43 > div > div.layout-box.container.responsivegrid > div > div > div > div > div:nth-child(3) > div > p > span > b > span > span > a";

        
        [FindsBy(How = How.CssSelector, Using = ArkadiiDobkin)]
        private IWebElement dobkinElement;

        
      public MainPage ArkadiiDobkinCheck()
       {
           new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(dobkinElement));
           dobkinElement.Click();
           new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam.com/about/who-we-are/leadership/board-of-directors/arkadiy-dobkin");
           return new MainPage(_driver);
       }
    }
}