using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace THEREISLITERALLYNOSENSETODOIT
{
    public class MainPage
    {
        private readonly IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private const string Logo = ".header__logo-container";
        private const string SliderTitle = ".title-slider__slide-row";
        private const string ContactUs = ".cta-button__text";
        private const string CookieButton = ".cookie-disclaimer__button .button__content";
        private const string LocationButton = ".location-selector__button";
        private const string RussianLanguage = ".location-selector__item:nth-child(9) .location-selector__link";
        private const string CISOffices = "#id-d4f6ba92-c566-388d-9892-03fe1a33ce5b > div.js-tabs-controls > div > div:nth-child(4) > a";
        private const string CanadaButton = "#id-d4f6ba92-c566-388d-9892-03fe1a33ce5b > div.tabs__item.js-tabs-item.active > div > div > div.locations-viewer__carousel.owl-loaded.owl-drag > div.owl-stage-outer > div > div:nth-child(4) > div > button > div:nth-child(1)";
        private const string CanadaInfo = "#id-d4f6ba92-c566-388d-9892-03fe1a33ce5b > div.tabs__item.js-tabs-item.active > div > div > div.locations-viewer__country-list.active > div.locations-viewer__country-details.active > ul > li:nth-child(1) > h5";
        private const string TwitterButton = "#wrapper > div.footer-container.iparsys.parsys > div.footer.section > footer > div > div.footer__container > ul.footer__socials > li:nth-child(2) > a";
        private const string ResultsTab = "#main > div.content-container.parsys > div:nth-child(4) > section > div > div.column-control > div > div.colctrl__col.colctrl__col--width-30.colctrl__col--top-64.colctrl__col--right-43.colctrl__col--bottom-0.colctrl__col--left-0 > div > div.button > div > a > span.button__content.button__content--desktop";
        private const string About = "#wrapper > div.header-container.iparsys.parsys > div.header.parbase.section > header > div > nav > ul > li:nth-child(5) > span.top-navigation__item-text > a";

        
        [FindsBy(How = How.CssSelector, Using = Logo)]
        private IWebElement logo;
        [FindsBy(How = How.CssSelector, Using = SliderTitle)]
        private IWebElement homePageCheckerElement;
        [FindsBy(How = How.CssSelector, Using = ContactUs)]
        private IWebElement contactUsButton;
        [FindsBy(How = How.CssSelector, Using = CookieButton)]
        private IWebElement cookieButton;
        [FindsBy(How = How.CssSelector, Using = About)]
        private IWebElement stocksInfoElement;
        [FindsBy(How = How.CssSelector, Using = LocationButton)]
        private IWebElement locationElement;
        [FindsBy(How = How.CssSelector, Using = RussianLanguage)]
        private IWebElement russiaLangElement;
        [FindsBy(How = How.CssSelector, Using = CISOffices)]
        private IWebElement CIS;
        [FindsBy(How = How.CssSelector, Using = CanadaButton)]
        private IWebElement armeniaElement;
        [FindsBy(How = How.CssSelector, Using = CanadaInfo)]
        private IWebElement armeniaInfoElement;
        [FindsBy(How = How.CssSelector, Using = TwitterButton)]
        private IWebElement twitterElement;
        [FindsBy(How = How.CssSelector, Using = ResultsTab)]
        private IWebElement ourWork;

        public MainPage Cookies()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(cookieButton));
            cookieButton.Click();
            return new MainPage(_driver);
        }
        public MainPage OpenMainPageByLogo()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(logo));
            logo.Click();
            return new MainPage(_driver);
        }

        public string GetUrl()
        { 
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(homePageCheckerElement));
            string res = _driver.Url;
            return res;
        }

        public MainPage ContactUsSwitch()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(contactUsButton));
            contactUsButton.Click();
            return new MainPage(_driver);
        }
        public MainPage ChangeLanguageToRussian()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(locationElement));
            locationElement.Click();
            
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(russiaLangElement));
            russiaLangElement.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam-group.ru/");
            return new MainPage(_driver);
        }
        

        public string СhangeContinent()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(CIS));
            CIS.Click();
            string res = CIS.GetAttribute("innerHTML");
            return res;
        }
        

        public string СhangeCountries()
        {
  
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(armeniaElement));
            armeniaElement.Click();
            
            string res = armeniaInfoElement.GetAttribute("innerHTML");
            return res;
        }

        public string GoingTwitter()
       {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(twitterElement));
            string res = twitterElement.GetAttribute("href");
             return res;
        }
        
        public MainPage ResultsPage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(ourWork));
            ourWork.Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam.com/our-work");
            return new MainPage(_driver);
        }

        public MainPage GoingStocks()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(stocksInfoElement));
            stocksInfoElement.Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam.com/about");
            return new MainPage(_driver);
        }
  
        

    }
}