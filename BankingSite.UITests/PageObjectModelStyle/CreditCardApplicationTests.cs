using System;
using NUnit.Framework;
using WatiN.Core;

namespace BankingSite.UITests.PageObjectModelStyle
{
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
                DemoStuff.BrowserDemoHelper.BringToFront(browser);
                browser.AutoClose = false;
                

                var applyPage = browser.Page<ApplyForCreditCardPage>();
                
                applyPage.Name = "Jason";
                //browser.TextField(Find.ById("Name")).TypeText("Jason");
                applyPage.Age = "30";
                //browser.TextField(Find.ById("Age")).TypeText("30");
                applyPage.AirlineNumber = "A1234567";
                //browser.TextField(Find.ById("AirlineRewardNumber")).TypeText("A1234567");

                applyPage.ClickApplyButton();
                //browser.Button(Find.ById("ApplyNow")).Click();

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
                DemoStuff.BrowserDemoHelper.BringToFront(browser);
                browser.AutoClose = false;


                var applyPage = browser.Page<ApplyForCreditCardPage>();
                
                applyPage.Name = "Jason";
                applyPage.Age = "30";
                applyPage.AirlineNumber = "A1234567";
                applyPage.ClickApplyButton();

                var acceptedPage = browser.Page<AcceptedPage>();

                Assert.That(acceptedPage.Document.Url.Contains("ApplicationAccepted.aspx"));

                Assert.That(acceptedPage.Name, Is.EqualTo("Jason"));
            }
        }

    }
}
