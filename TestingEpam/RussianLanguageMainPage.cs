using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace THEREISLITERALLYNOSENSETODOIT
{
    public class RussianLanguageMainPage
    {
        private readonly IWebDriver _driver;

        public RussianLanguageMainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        private const string SliderTitle = ".title-slider__slide-row";
        private const string LanguageSelector = ".location-selector__button";
        private const string EnglishLanguage = ".location-selector__item:nth-child(1) .location-selector__link";

        
        [FindsBy(How = How.CssSelector, Using = LanguageSelector)]
        private IWebElement langSelectorElement;

        [FindsBy(How = How.CssSelector, Using = EnglishLanguage)]
        private IWebElement englLangElement;

        [FindsBy(How = How.CssSelector, Using = SliderTitle)]
        private IWebElement CheckUrlForRussianHomesite;

        public string GetUrlRus()
        { 
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(CheckUrlForRussianHomesite));
            string res = _driver.Url;
            return res;
        }
        
      public MainPage ChangeLanguageBackToEngl()
       {
           new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(langSelectorElement));
           langSelectorElement.Click();
           
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(englLangElement));
            englLangElement.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam.com/");
            return new MainPage(_driver);
        }
    }
}