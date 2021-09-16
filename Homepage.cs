using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace SolentroFrame.Pages
{
    public class Homepage : Base
    {
        #region Web elements and locators

        public static IWebElement BookAndPricesButton => Browser.FindElement(By.Id("menu_1"));
        public static IWebElement BookFormatsButton => Browser.FindElement(By.Id("menu_1_2"));
        public static IWebElement BindingButton => Browser.FindElement(By.Id("menu_1_3"));
        public static IWebElement PricesButton => Browser.FindElement(By.Id("menu_1_9"));
        public static IWebElement ShippingBtn => Browser.FindElement(By.Id("menu_2"));
        public static IWebElement TermsAndConditionsBtn => Browser.FindElement(By.Id("menu_2_2"));
        public static IWebElement AboutSolentroBtn => Browser.FindElement(By.Id("menu_3"));
        public static IWebElement FAQBtn => Browser.FindElement(By.Id("menu_3_1"));
        public static IWebElement NewHereBtn => Browser.FindElement(By.Id("begin-here"));
        public static IWebElement FirstEmailField => Browser.FindElement(By.Id("create_username"));
        public static IWebElement SecondEmailField => Browser.FindElement(By.Id("create_username_verify"));
        public static IWebElement CreatePasswordField => Browser.FindElement(By.Id("create_password"));
        public static IWebElement CreateAccountBtn => Browser.FindElement(By.Id("create_button"));
        public static IWebElement LoginDropdown => Browser.FindElement(By.Id("signin_dropdown"));
        public static IWebElement EmailField => Browser.FindElement(By.XPath("(//input[@name='email'])[1]"));
        public static IWebElement PasswordField => Browser.FindElement(By.XPath("(//input[@name='password'])[1]"));
        public static IWebElement LoginButton => Browser.FindElement(By.Id("btn-signin"));
        public static IWebElement LogInMessageBox => Browser.FindElement(By.Id("alert-message-box"));
        public static IWebElement MessageExitBtn => Browser.FindElement(By.XPath("//button[@class='exitBtn exit-from-messageBox']"));
        public static IWebElement InvalidEmailMessage => Browser.FindElement(By.XPath("//small[@data-bv-validator='emailAddress']"));
        public static IWebElement HoveredImage => Browser.FindElement(By.XPath("//img[@aria-describedby]"));
        public static IList<IWebElement> BookImages => Browser.FindElements(By.XPath("//img[@data-toggle='popover']"));
        public static IList<IWebElement> BooksInfo => Browser.FindElements(By.XPath("//div[@class='book-format-text']/p"));
        public static IList<IWebElement> BindingDots => Browser.FindElements(By.ClassName("binding-dot"));
        public static IWebElement BindingImage => Browser.FindElement(By.ClassName("hover_image_preview"));
        public static IWebElement BannerCloseButton => Browser.FindElement(By.XPath("//img[@alt='bottom-banner-close']"));
        public static IList<IWebElement> Questions => Browser.FindElements(By.ClassName("question"));
        public static IList<IWebElement> Answers => Browser.FindElements(By.ClassName("answer"));
        public static IList<IWebElement> Prices => Browser.FindElements(By.XPath("//div[@class='col-xs-12 site-generic site-prices']//span"));
        public static void CloseBanner() => Browser.FindElement(By.Id("sticky_close_button")).CloseBannerInSecond();
        #endregion

        #region Public methods

        /// <summary>
        /// Login into Production
        /// </summary>
        /// <param name="emailEnum"> Enum representing email with default value of General email from Emails enum </param>
        /// <param name="passwordEnum"> Enum representing password with default value of Correct password from PasswordType enum </param>
        public static void LoginSolentro(Emails emailEnum = Emails.General, PasswordType passwordEnum = PasswordType.Correct)
        {
            string bookFormatEmail;
            string password;
            Actions action = new Actions(Browser);
            LoginDropdown.WaitForVisible();
            action.MoveToElement(LoginDropdown).Click().Perform();
            if (emailEnum == Emails.Random) emailEnum = (Emails)GetRandomEmail();
            var email = Enum.GetName(typeof(Emails), emailEnum);
            bookFormatEmail = TestData.emails[email];
            EmailField.WaitForVisible();
            if (emailEnum == Emails.Invalid)
            {
                EmailField.Clear();
            }
            EmailField.SendKeys(bookFormatEmail);
            PasswordField.WaitForVisible();
            if (passwordEnum == PasswordType.Incorect)
            {
                password = TestData.passwordType.Incorect;
            }
            else
            {
                password = TestData.general_password;
            }
            PasswordField.SendKeys(password);
            LoginButton.ClickWait();
            log.Info($"Login credentials, ({bookFormatEmail}) have been input");
        }

        /// <summary>
        /// Verify that user is not able to login with incorrect or invalid email
        /// </summary>
        public static void TryLoginWithWrongOrInvalidEmail()
        {
            LoginSolentro(Emails.Wrong);
            MessageExitBtn.ClickWait();
            LoginSolentro(Emails.Invalid);
            InvalidEmailMessage.WaitForVisible();
            InvalidEmailMessage.Displayed.Should().BeTrue((String)AssertionData.InvalidEmail);
            log.Info("Invalid login credentials have been input");
        }

        /// <summary>
        /// Verify that user is not able to log in with incorrect password
        /// </summary>
        public static void TryLoginWithIncorrectPassword()
        {
            LoginSolentro(Emails.General, PasswordType.Incorect);
            MessageExitBtn.ClickWait();
            log.Info("User was not able to login, because password is incorrect");
        }

        /// <summary>
        /// Registration on Solentro page
        /// </summary>
        /// <param name="email"> Enum representing email with default value of GeneratedEmail from Emails enum </param>
        public static void RegistrateSolentro(Emails email = Emails.GeneratedEmail)
        {
            Actions action = new Actions(Browser);
            string emailToEnter;
            if (email == Emails.GeneratedEmail)
            {
                emailToEnter = CreateRandomEmail();
            }
            else
            {
                var emailType = Enum.GetName(typeof(Emails), email);
                emailToEnter = TestData.emails[emailType];
            }
            string password = TestData.general_password;
            LoginDropdown.Hover();
            NewHereBtn.ClickWait();
            FirstEmailField.WaitForVisible();
            FirstEmailField.SendKeys(emailToEnter);
            action.MoveToElement(SecondEmailField);
            if (email == Emails.Wrong)
            {
                emailToEnter = CreateRandomEmail();
            }
            SecondEmailField.WaitForVisible();
            SecondEmailField.SendKeys(emailToEnter);
            action.MoveToElement(CreatePasswordField);
            CreatePasswordField.WaitForVisible();
            CreatePasswordField.SendKeys(password);
            CloseBanner();
            CreateAccountBtn.ClickWait();
            log.Info($"Registration credentials, ({emailToEnter}) is sent as an input");
        }

        /// <summary>
        /// Get random email
        /// </summary>
        /// <returns> Created random email </returns>
        public static string CreateRandomEmail()
        {
            var numberOfRandomEmails = 100;
            var randomInt = GetRandomNumber(numberOfRandomEmails);
            var email = "test" + randomInt + "@test.com";
            TestData.emails.GeneratedEmail = email;
            log.Info($"Random email address, {email}, is generated");
            return email;
        }

        /// <summary>
        /// Coverts json objects into list of integers
        /// </summary>
        /// <param name="jsonList"> Dynamic object that contains integer values in json </param>
        /// <returns> List of integers </returns>
        public static List<int> ConvertJsonToList(dynamic jsonList)
        {
            return jsonList.ToObject<List<int>>();
        }

        /// <summary>
        /// Extracts book pages data for specific book type and returns it as a list
        /// </summary>
        /// <param name="bookData"> String paragraph that contains book pages data </param>
        /// <returns> Integer list of book pages </returns>
        public static List<int> BookPages(String bookData)
        {
            var list = new List<int>();
            var separatorIndex = bookData.IndexOf("\n");
            bookData = bookData.Substring(separatorIndex);
            var pages = Regex.Matches(bookData, "[0-9]+");
            foreach (var numOfPages in pages)
            {
                Int32.TryParse(numOfPages.ToString(), out var test);
                list.Add(test);
            }
            return list;
        }

        /// <summary>
        /// Extracts book sizes data for specific book type and returns it as a list
        /// </summary>
        /// <param name="bookData"> String paragraph that contains book size data </param>
        /// <returns> Integer list of book sizes </returns>
        public static List<int> BookSize(String bookData)
        {
            var list = new List<int>();
            var separatorIndex = bookData.IndexOf("\n");
            bookData = bookData.Substring(0, separatorIndex);
            var pages = Regex.Matches(bookData, "[0-9]+");
            foreach (var numOfPages in pages)
            {
                Int32.TryParse(numOfPages.ToString(), out var test);
                list.Add(test);
            }
            return list;
        }

        #endregion

        #region Validation methods

        /// <summary>
        /// Verify that user is not logged in
        /// </summary>
        public static void VerifyUserNotLoggedIn()
        {
            LoginDropdown.Displayed.Should().BeTrue((String)AssertionData.LoginInvalid);
            log.Info("User is not logged in");
        }

        /// <summary>
        /// Verify user is unable to register on Solentro page
        /// </summary>
        public static void VerifyUnableToRegisterWithWrongOrInvalidEmail()
        {
            RegistrateSolentro(Emails.Wrong);
            Thread.Sleep(1000);
            MessageExitBtn.WaitForVisible();
            MessageExitBtn.Displayed.Should().BeTrue((String)AssertionData.UnmatchingEmails);
            MessageExitBtn.Click();
            FirstEmailField.ClickWait();
            SecondEmailField.Clear();
            CreatePasswordField.Clear();
            RegistrateSolentro(Emails.Invalid);
            log.Info("User is not registered because of wrong/invalid email");
            CreateAccountBtn.Displayed.Should().BeTrue((String)AssertionData.InvalidRegistration);
        }

        /// <summary>
        /// Verify that account is deleted
        /// </summary>
        /// <param name="email"> Enum representing email with default value of GeneratedEmail from Emails enum </param>
        public static void VerifyAccountDeletion(Emails email = Emails.GeneratedEmail)
        {
            Homepage.LoginSolentro(email);
            LogInMessageBox.WaitForVisible();
            LogInMessageBox.Displayed.Should().BeTrue((String)AssertionData.AccountDeletion);
            log.Info($"Account {email} is deleted");
        }

        /// <summary>
        /// Verify home page opening on all domains
        /// </summary>
        public static void VerifyHomePageForAllDomains()
        {
            Array Domains = Enum.GetValues(typeof(Domains));
            int numberOfCountries = Domains.Length - 1;
            for (int i = 0; i < numberOfCountries; i++)
            {
                Domains domain = (Domains)Domains.GetValue(i);
                string url = GetDomain(domain);
                Browser.Navigate().GoToUrl(url);
                LoginDropdown.WaitForVisible();
                BookAndPricesButton.WaitForVisible();
            }
            log.Info("Homepage is visible for all domains");
        }

        // <summary>
        /// Compare book pages data displayed on the homepage with data in the database
        /// </summary> 
        public static void VerifyBookPages()
        { 
            BookAndPricesButton.ClickWait(); 
            BookFormatsButton.ClickWait();
            var size = Enum.GetNames(typeof(SizesOfBook));
            List<String> IncorrectBookPagesData = new List<String>();
            for (int i = 0; i < BooksInfo.Count; i++)
            {
                try
                {
                    if(!Enumerable.SequenceEqual(BookPages(BooksInfo[i].Text), ConvertJsonToList(TestData.bookPages[i])))
                    {
                        throw new Exception($"On domain {Browser.Url}, {size[i]} book pages data is not correct.");
                    } 
                }
                catch (Exception e)
                {
                    IncorrectBookPagesData.Add(e.Message);
                }
            }
            if(IncorrectBookPagesData.Count > 0)
            {
                IncorrectBookPagesData.ForEach(i => log.Error($"{i}"));
                IncorrectBookPagesData.Count.Equals(0).Should().BeTrue((String)AssertionData.BookPages);
            }
            else
            {
                log.Info("All book pages are in correct order");
            }      
        }

        /// <summary>
        /// Compare book sizes data displayed on the homepage with data in the database
        /// </summary> 
        public static void VerifyBookSizes()
        {
            BookAndPricesButton.ClickWait();
            BookFormatsButton.ClickWait();
            var size = Enum.GetNames(typeof(SizesOfBook));
            List<String> BookSizesExceptions = new List<String>();
            for (int i = 0; i < BooksInfo.Count; i++)
            {                               
                var bookSizes = BookSize(BooksInfo[i].Text);
                try 
                { 
                    if (bookSizes.Count < 4)
                    {
                        if (!Enumerable.SequenceEqual(bookSizes.Take(2), ConvertJsonToList(TestData.bookSizesMM[i])))
                            throw new Exception($"On domain {Browser.Url}, {size[i]} book size data is not correct.");
                    }
                    else
                    {
                        if (!Enumerable.SequenceEqual(bookSizes.Take(2), ConvertJsonToList(TestData.bookSizesInches[i])) ||
                        !Enumerable.SequenceEqual(bookSizes.Skip(2).Take(2), ConvertJsonToList(TestData.bookSizesMM[i])))
                            throw new Exception($"On domain {Browser.Url}, {size[i]} book size data is not correct.");
                    }                           
                }
                catch (Exception e)
                {
                    BookSizesExceptions.Add(e.Message);
                }       
            }
            if(BookSizesExceptions.Count > 0)
            {
                BookSizesExceptions.ForEach(i => log.Error($"{i}"));
                BookSizesExceptions.Count.Equals(0).Should().BeTrue((String)AssertionData.BookSizes);
            }
            else
            {
                log.Info("All book sizes are in correct order");
            }
        }

        /// <summary>
        /// Check if new images appear after hovering over book images
        /// </summary> 
        public static void VerifyBookImages()
        {
            BookAndPricesButton.ClickWait();
            BookFormatsButton.ClickWait();
            var size = Enum.GetNames(typeof(SizesOfBook));
            List<string> listOfNotDisplayedImages = new List<string>();
            for (int i = 0; i < BookImages.Count; i++)
            {
                try
                {
                    BookImages[i].Hover();
                    if (!HoveredImage.Displayed)
                        throw new Exception($"After hovering over the image of {size[i]} book, image is not shown.");
                }
                catch (Exception e)
                {
                    listOfNotDisplayedImages.Add(e.Message);
                } 
            }
            if (listOfNotDisplayedImages.Count > 0)
            {
                listOfNotDisplayedImages.ForEach(i => log.Error($"{i}"));
                listOfNotDisplayedImages.Count.Equals(0).Should().BeTrue((String)AssertionData.BookImagesGeneral);
            }
            else
            {
                log.Info("All book images are visible");
            }
        }

        /// <summary>
        /// Verify that images are shown after hover on all dots for images
        /// </summary>
        public static void VerifyBookBindingsDisplayed()
        {
            Actions action = new Actions(Browser);
            BookAndPricesButton.ClickWait();
            BindingButton.ClickWait();
            List<string> listOfNotDisplayedImages = new List<string>();
            var numberOfDots = BindingDots.Count;
            CloseBanner();     
            action.MoveToElement(BindingDots[0]).Perform();
            for (int i = 0; i < numberOfDots; i++)
            {
                IWebElement currentDot = BindingDots[i];
                currentDot.Hover();
                try
                {
                    BindingImage.Displayed.Should().BeTrue((String)AssertionData.BindingImages);
                }
                catch
                {
                    listOfNotDisplayedImages.Add($"Image is not visible on dot { i + 1}.");
                }
            }
            if (listOfNotDisplayedImages.Count > 0)
            {
                listOfNotDisplayedImages.ForEach(i => log.Error($"{i}"));
                listOfNotDisplayedImages.Count.Equals(0).Should().BeTrue((String)AssertionData.BookBindings);
            }
            else
            {
                log.Info("All binding images are visible");
            }
        }

        /// <summary>
        /// Verify that all questions in FAQ are displayed
        /// </summary>
        public static void VerifyFAQ()
        {
            AboutSolentroBtn.Click();
            FAQBtn.Click();
            var numberOfQuestions = Questions.Count;
            List<string> listOfNotDisplayedAnswers = new List<string>();
            CloseBanner();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Actions movement1 = new Actions(Browser);
                IWebElement currentQuestion = Questions[i];
                IWebElement currentAnswer = Answers[i];
                movement1.MoveToElement(currentQuestion).Perform();
                currentQuestion.ClickWait();
                Actions movement2 = new Actions(Browser);
                currentAnswer.WaitForVisible();
                movement2.MoveToElement(currentAnswer).Perform();
                try
                {
                    currentAnswer.Displayed.Should().BeTrue((String)AssertionData.FAQ);
                }
                catch
                {
                    listOfNotDisplayedAnswers.Add($"On domain {Browser.Url} answer is not visible on question {i + 1}.");
                }
            }
            if (listOfNotDisplayedAnswers.Count > 0)
            {
                listOfNotDisplayedAnswers.ForEach(i => log.Error($"{i}\n"));
                listOfNotDisplayedAnswers.Count.Equals(0).Should().BeTrue((String)AssertionData.FAQGeneral);
            }
            else
            {
                log.Info("All answers or are visible");
            }
        }

        /// <summary>
        /// Verify book prices for all book types and on all domains
        /// </summary>
        public static void VerifyBookPrices()
        {
            Array Domains = Enum.GetValues(typeof(Domains));
            List<string> IncorrectBookPricesData = new List<string>();
            for (int i = 0; i < Domains.Length-1; i++)
            {
                Domains domain = (Domains)Domains.GetValue(i);
                string country = Enum.GetName(typeof(Domains), domain);
                string domainPart = TestData.domains[country];
                var url = GetDomain(domain);
                Browser.Navigate().GoToUrl(url);
                BookAndPricesButton.ClickWait();
                PricesButton.ClickWait();
                CloseBanner();
                Thread.Sleep(500);
                for (int k = 0; k < Prices.Count; k++)
                {
                    string currency = TestData.domainFromUrl[domainPart];
                    if (k != 26 && k != 19 && k != 12 && k != 5)
                    {
                        string priceOnPage = Prices[k].Text;
                        string typeOfBook = Prices[k].GetAttribute("class");
                        string expectedPrice = TestData.prices[typeOfBook][currency];
                        
                        try
                        {
                            if (expectedPrice != priceOnPage)
                            {
                                throw new Exception($"On domain '{domainPart}' price {priceOnPage} for {typeOfBook} is not the same as the price {expectedPrice} in the database.");
                            }
                        }
                        catch (Exception e)
                        {
                            IncorrectBookPricesData.Add(e.Message);
                        }
                    }
                }
            }
            if (IncorrectBookPricesData.Count > 0)
            {
                IncorrectBookPricesData.ForEach(i => log.Error($"{i}\n"));
                IncorrectBookPricesData.Count.Equals(0).Should().BeTrue((String)AssertionData.BookPrices);
            }
            else
            {
                log.Info("Book prices on all domains match prices in the database.");
            }
        }

        /// <summary>
        /// Verify that all questions at Terms and Conditions page are displayed
        /// </summary>
        public static void VerifyTermsAndConditions()
        {
                ShippingBtn.Click();
                TermsAndConditionsBtn.Click();
                var numberOfQuestions = Questions.Count;
                List<string> listOfNotDisplayedAnswers = new List<string>();
                CloseBanner();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Actions movement1 = new Actions(Browser);
                IWebElement currentQuestion = Questions[i];
                IWebElement currentAnswer = Answers[i];
                movement1.MoveToElement(currentQuestion).Perform();
                currentQuestion.ClickWait();
                currentAnswer.WaitForVisible();
                try
                {
                    currentAnswer.Displayed.Should().BeTrue((String)AssertionData.TaC);
                }
                catch
                {
                    listOfNotDisplayedAnswers.Add($"On domain {Browser.Url} answer is not visible on question {i + 1}.");
                }
            }
            if (listOfNotDisplayedAnswers.Count > 0)
            {
                listOfNotDisplayedAnswers.ForEach(i => log.Error($"{i}\n"));
                listOfNotDisplayedAnswers.Count.Equals(0).Should().BeTrue((String)AssertionData.TaCGeneral);
            }
            else
            { 
                log.Info("All answers or are visible");
            }
            
        }

        #endregion

        #region Get methods

        /// <summary>
        /// Get random email
        /// </summary>
        /// <returns> Random email from enum </returns>
        public static Enum GetRandomEmail()
        {
            var values = Enum.GetValues(typeof(Emails));
            var randomEmail = values.GetValue(GetRandomNumber(values.Length - 4));
            return (Emails)randomEmail;
        }

        #endregion
    }
}

