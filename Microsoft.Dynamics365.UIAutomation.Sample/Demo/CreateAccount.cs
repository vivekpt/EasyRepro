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
    public class DemoCreateAccount
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void TestDemoCreateActiveAccount()
        {
            using (var xrmBrowser = new Api.Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                                
                xrmBrowser.Navigation.OpenSubArea("Sales", "Accounts");
                
                xrmBrowser.Grid.SwitchView("Active Accounts");

                xrmBrowser.Grid.OpenRecord(0);

                xrmBrowser.CommandBar.ClickCommand("New");
                
                xrmBrowser.Entity.SetValue("name", "EasyRepro Demo Account");
                xrmBrowser.Entity.SetValue("telephone1", "555-555-5555");
                xrmBrowser.Entity.SetValue("websiteurl", "https://easyrepro.crm.dynamics.com");
                xrmBrowser.Entity.SetValue(new OptionSet() { Name = "customertypecode", Value = "Customer" });

                xrmBrowser.Entity.Save();

                xrmBrowser.Entity.ope

                xrmBrowser.Dialogs.DuplicateDetection(true);

               

                xrmBrowser.ActivityFeed.AddPost("Added new Account for Customer Demo");
               
                //Validate Phone Number format
                var phoneNumber = xrmBrowser.Entity.GetValue("telephone1").Value;

                Assert.AreEqual("(555) 555-5555", phoneNumber);

                //Pause for demo
                xrmBrowser.ThinkTime(5000);
            }
        }
    }
}