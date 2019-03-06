// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample
{
    [TestClass]
    public class DemoValidatePhoneNumber
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void TestDemoValidatePhoneNumber()
        {
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);

                xrmBrowser.TakeWindowScreenShot("C:\\temp\\screenshot.jpg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
                xrmBrowser.Navigation.OpenSubArea("Sales", "Accounts");

                xrmBrowser.TakeWindowScreenShot("C:\\temp\\screenshot.jpg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
                xrmBrowser.Grid.Search("EasyRepro");

                xrmBrowser.TakeWindowScreenShot("C:\\temp\\screenshot.jpg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
                xrmBrowser.Grid.OpenRecord(0);         

                var phoneNumber = xrmBrowser.Entity.GetValue("telephone1").Value;

                Assert.AreEqual("(555) 555-5555", phoneNumber);

                xrmBrowser.TakeWindowScreenShot("C:\\temp\\screenshot.jpg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);

                //Pause for demo
                xrmBrowser.ThinkTime(5000);
            }
        }
    }
}