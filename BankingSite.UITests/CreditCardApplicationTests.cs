using System;
using BankingSite.UITests.DemoStuff;
using NUnit.Framework;
using WatiN.Core;

namespace BankingSite.UITests
{

    /// <summary>
    ///  The tests in this class are simple scripts and don't use the POM or LFM styles.
    ///  As the number of tests grows, this simplistic style starts to create maintenance problems
    /// </summary>

    [TestFixture]    
    public class CreditCardApplicationTests
    {
        [Test]
        [STAThread]
        public void ShouldShowSuccessPageForValidApplication()
        {
            using (var browser =
                new IE("http://localhost:62727/Pages/ApplyForCreditCard.aspx"))
            {
                // Leave the browser open after the test completes
                // to see what's happened for demo purposes
                browser.AutoClose = false;
                BrowserDemoHelper.BringToFront(browser);

                browser.TextField(Find.ById("Name")).TypeText("Jason");
                browser.TextField(Find.ById("Age")).TypeText("30");
                browser.TextField(Find.ById("AirlineRewardNumber")).TypeText("A1234567");

                browser.Button(Find.ById("ApplyNow")).Click();

                Assert.That(browser.Url.Contains("ApplicationAccepted.aspx"));
            }
        }


        [Test]
        [STAThread]
        public void ShouldShowCorrectApplicantDetailsOnSuccessPage()
        {
            using (var browser =
                new IE("http://localhost:62727/Pages/ApplyForCreditCard.aspx"))
            {
                // Leave the browser open after the test completes
                // to see what's happened for demo purposes
                BrowserDemoHelper.BringToFront(browser);
                browser.AutoClose = false;

                browser.TextField(Find.ById("Name")).TypeText("Jason");
                browser.TextField(Find.ById("Age")).TypeText("30");
                browser.TextField(Find.ById("AirlineRewardNumber")).TypeText("A1234567");

                browser.Button(Find.ById("ApplyNow")).Click();

                var name = browser.Para(Find.ById("Name")).Text;

                Assert.That(name, Is.EqualTo("Jason"));
            }
        }

    }
}
