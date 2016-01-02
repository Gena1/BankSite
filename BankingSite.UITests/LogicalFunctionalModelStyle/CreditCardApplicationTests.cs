using System;
using NUnit.Framework;
using WatiN.Core;

namespace BankingSite.UITests.LogicalFunctionalModelStyle
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

                applyPage.ApplyForCreditCard(name: "Jason",
                                             age: "30",
                                             airlineNumber: "A1234567");

                //applyPage.Name = "Jason"; // POM
                //applyPage.Age = "30";  // POM
                //applyPage.AirlineNumber = "A1234567";  // POM                
                //applyPage.ClickApplyButton();  // POM

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

                applyPage.ApplyForCreditCard(name: "Jason",
                                age: "30",
                                airlineNumber: "A1234567");

                Assert.That(browser.Url.Contains("ApplicationAccepted.aspx"));

                var acceptedPage = browser.Page<AcceptedPage>();

                Assert.That(acceptedPage.Document.Url.Contains("ApplicationAccepted.aspx"));

                Assert.That(acceptedPage.Name, Is.EqualTo("Jason"));
            }
        }

    }
}
