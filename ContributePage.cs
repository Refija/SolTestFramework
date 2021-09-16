using OpenQA.Selenium;
using System;
using System.IO;

namespace SolentroFrame.Pages
{
   public class ContributePage : Base
    {
        #region Web elements and locators

        public static IWebElement InviteUrlKey => Browser.FindElement(By.XPath("//pre"));
        public static IWebElement ContrTitle => Browser.FindElement(By.Id("contribute_title"));
        public static IWebElement ContrText => Browser.FindElement(By.Id("contribute_text"));
        public static IWebElement ContrUploadBtn => Browser.FindElement(By.Id("upload"));
        public static IWebElement ContrUploadInfoMsg => Browser.FindElement(By.Id("upload-info-msg"));
        public static IWebElement ContrUploadSuccessMsg => Browser.FindElement(By.XPath("//div[@class='success-msg']"));
        public static IWebElement ContrSendBtn => Browser.FindElement(By.Id("send_button"));
        public static IWebElement ContrAlertMessBox => Browser.FindElement(By.Id("alert-message-box"));
        public static IWebElement ContrErrorMess => Browser.FindElement(By.XPath("//p[contains(text(),'Please fill in both text fields.')]"));
        public static IWebElement ContrSuccessMess => Browser.FindElement(By.XPath("//p[contains(text(),'Thank you for your contribution!')]"));
        public static IWebElement ContrExitBtn => Browser.FindElement(By.Id("exitBtn"));

        #endregion

        #region Validation methods

        /// <summary>
        /// Verify that user can get session key and open contribute page
        /// </summary>
        public static void ContributeKey()
        {
            string InviteOthersUrlKey = "http://solentro:sol@dev.solentro.com/_json/Project.sendInvitation.php";
            Browser.Navigate().GoToUrl(InviteOthersUrlKey);
            var confirm_win = Browser.SwitchTo().Alert();
            confirm_win.Accept();
            string urlKey = InviteUrlKey.Text;
            string inviteOthersUrl = "https://dev.solentro.com/write/" + urlKey;
            Browser.Navigate().GoToUrl(inviteOthersUrl);
            log.Info($"Contribute session key ({urlKey}) acquired, browser is redirected to {inviteOthersUrl}");
        }

        /// <summary>
        /// Verify that invited user can contribute on the project
        /// Verify that invited user must fill the all fields in order to upload images
        /// </summary>
        /// <param name="image"> String representing name of image, as well as image extension </param>
        /// <param name="input1"> String representing the name of contributor </param>
        /// <param name="input2"> String representing the message </param>
        public static void Contribute(string image= "test.jpg", string input1= "Test", string input2= "Test")
        {
            ContrUploadBtn.Click();
            string ContrInputRootPath = AppDomain.CurrentDomain.BaseDirectory;
            string ContrInputFile = ContrInputRootPath + @"TestData/" + image;
            string ContrInputFilePath = Path.Combine(ContrInputRootPath, ContrInputFile);
            FileUpload.SendKeys(Path.GetFullPath(ContrInputFilePath));
            ContrUploadInfoMsg.WaitForVisible();
            ContrUploadSuccessMsg.WaitForVisible();
            ContrSendBtn.Click();
            ContrAlertMessBox.WaitForVisible();
            ContrErrorMess.WaitForVisible();
            ContrExitBtn.Click();
            log.Info($"Image {image} is not sent for contribution since required fields were empty");
            ContrTitle.SendKeys(input1);
            ContrText.SendKeys(input2);
            ContrSendBtn.Click();
            ContrAlertMessBox.WaitForVisible();
            ContrSuccessMess.WaitForVisible();
            ContrExitBtn.Click();
            log.Info($"Contributed image {image} and input data ({input1}; {input2}) are sent");
        }

        #endregion
    }
}
