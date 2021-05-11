using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace THEREISLITERALLYNOSENSETODOIT
{
    public class Lab2Tests
    { 
        [TestFixture]
        public class Test
        {
            private IWebDriver _driver;
            private const string Url = "https://www.epam.com/";
            private MainPage mainPage;
            private RussianLanguageMainPage mainPageRussianLanguage;
            private ResultsPage _resultsPage;
            private AboutPage _aboutPage;
            private DobkinProfile _dobkinPage;


            [SetUp]
            public void TestInitialize()
            {
                var options = new ChromeOptions();
                options.AddArgument("start-maximized");

                _driver = new ChromeDriver( @"C:\Users\Fedorov.toxa\Downloads\selenium-testing-master\", options);
                _driver.Navigate().GoToUrl(Url);

                new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == Url);

                mainPage = new MainPage(_driver);
                mainPageRussianLanguage = new RussianLanguageMainPage(_driver);
                _resultsPage = new ResultsPage(_driver);
                _aboutPage = new AboutPage(_driver);
                _dobkinPage = new DobkinProfile(_driver);
                _driver.SwitchTo().Window(_driver.WindowHandles.First());
            }

            [TearDown]
            public void TestFinalize()
            {
                _driver.Quit();
            }


            [Test]
            public void MainPageAccessByLogo()
            {
                mainPage.ContactUsSwitch();//switching to different page to check if HomePage is accessible 
                mainPage.OpenMainPageByLogo();
                string res = mainPage.GetUrl();

                Assert.AreEqual(Url, res);
            }

            [Test]
            public void AccessLanguageDropdownMenu()
            {
                mainPage.Cookies();
                mainPage.ChangeLanguageToRussian();
                mainPageRussianLanguage.ChangeLanguageBackToEngl();
                
                string res = mainPage.GetUrl();

                Assert.AreEqual(Url, res);
            }
            
            [Test]
            public void ChangeSwitchToRussian()
            {
                mainPage.Cookies();
                mainPage.ChangeLanguageToRussian();
                
                string res = mainPageRussianLanguage.GetUrlRus();

                Assert.AreEqual("https://www.epam-group.ru/", res);
            }

            [Test]
            public void CheckDifferentContinents()
            {
                mainPage.Cookies();
                string res = mainPage.СhangeContinent();

                Assert.AreEqual("CIS", res);
            }
            
            [Test]
            public void CheckCounryOffices()
            {
                mainPage.Cookies();
                string res = mainPage.СhangeCountries();

                Assert.AreEqual("Ottawa", res);
            }
            
            
            [Test]
             public void TwitterCheck()
             {
                 mainPage.Cookies();
                 string res = mainPage.GoingTwitter();
                  Assert.AreEqual("https://twitter.com/EPAMSYSTEMS", res);
               }
             

            [Test]
            public void FilteringResults()
            {
                mainPage.Cookies();
                mainPage.ResultsPage();
                string res = _resultsPage.Filtering();

               Assert.AreNotEqual("Financial Services", res);
            }
            
            [Test]
            public void ArkdaiiCheck()
            {
                mainPage.Cookies();
                mainPage.GoingStocks();
                _aboutPage.ArkadiiDobkinCheck();
                string res = _dobkinPage.ArkadiiDobkinFinalCheck();
                
                Assert.AreEqual("Arkadiy Dobkin", res);
            }
        }
    }
}