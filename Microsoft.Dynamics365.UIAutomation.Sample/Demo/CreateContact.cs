using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.Demo
{
    [TestClass]
    public class CreateContact
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void CreateContactTest()
        {
            using (var browser = new Api.Browser(TestSettings.Options))
            {
                browser.LoginPage.Login(_xrmUri, _username, _password);

                browser.Navigation.OpenSubArea("Sales", "Contacts");

                browser.CommandBar.ClickCommand("New");

                browser.Entity.SetValue("firstname", "Daren");

                browser.Entity.Save();





            }
        }
    }
}
