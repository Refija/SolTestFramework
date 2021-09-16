using log4net;
using OpenQA.Selenium;
using SolentroFrame.TestData;
using System;

namespace SolentroFrame.Pages
{
    public class Base
    {
        #region Properties

        public static dynamic TestData => Json.GetData.JsonData;
        public static dynamic AssertionData => Json.GetData.AssertionData;
        public static IWebDriver Browser => Driver.GetDriver;
        public static IWebElement FileUpload => Browser.FindElement(By.CssSelector("input[type='file']"));
        public static IWebElement CookieOkButton => Browser.FindElement(By.Id("cb_enable"));
        public static readonly ILog log = LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Public methods

        /// <summary>
        /// 'GetDomain' method creates domain
        /// </summary>
        /// <param name="domain"> Enum representing domain from Domains enum </param>
        /// <returns> Full url </returns>
        public static string GetDomain(Domains domain)
        {
            string country;
            string url;
            if (domain == Domains.Random)
            {
                Array Domains = Enum.GetValues(typeof(Domains));
                int numberOfCountries = Domains.Length - 2;
                var randomDomain = GetRandomNumber(numberOfCountries);
                country = Enum.GetName(typeof(Domains), Domains.GetValue(randomDomain));
            }
            else
            {
                country = Enum.GetName(typeof(Domains), domain);
            }
            url = GeneralTestData.UrlMainPart + TestData.domains[country];
            return url;
        }

        /// <summary>
        /// 'OpenSolentro' method Opens Solentro page
        /// </summary>
        /// <param name="domain"> Enum representing domain with default value of International domain from Domains enum </param>
        public static void OpenSolentro(Domains domain = Domains.International)
        {
            string url = GetDomain(domain);
            Browser.Navigate().GoToUrl(url);     
            if(CookieOkButton.Displayed)
            {
                CookieOkButton.Click();
            }            
        }

        /// <summary>
        /// 'GetRandomNumber' method for creating random number with upper limit
        /// </summary>
        /// <param name="upperLimit"> Integer value representing upper limit for creating random number </param>
        /// <param name="lowerLimit"> Integer value representing lower limit for creating random number, with default value of 0 </param>
        /// <returns> Created random number </returns>
        public static int GetRandomNumber(int upperLimit, int lowerLimit = 0)
        {
            Random random = new Random();
            return random.Next(lowerLimit, upperLimit);
        }

        #endregion
    }
}
