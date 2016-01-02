using BankingSite.Model.DomainEntities;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
    [TestFixture]
    public class CreditCardApplicationServiceTests
    {
        private const string ApplicantName = "Jason";

        [Test]
        public void ShouldSubmitValidApplication()
        {

            // Before running this test for the first time you should run the website to 
            // ensure IIS is running and the service is ready to receive requests


            var submissionResult = SubmitAValidApplication();

            Assert.That(submissionResult.ValidationErrors, Is.Empty);
            Assert.That(submissionResult.ReferenceNumber, Is.Not.Null);

            // We can test the workflow by executing the next logical service that a client would call...
            var applicantNameForReferenceNumber = GetApplicantName(submissionResult.ReferenceNumber.Value);
            
            // Here we are testing that the system has stored the correct applicant (name) against the reference number
            Assert.That(applicantNameForReferenceNumber, Is.EqualTo(ApplicantName));
        }

        private SubmissionResult SubmitAValidApplication()
        {
            var sut = new CreditCardApplicationServiceReference.CreditCardApplicationServiceClient();

            var a = new CreditCardApplication
            {
                ApplicantName = ApplicantName,
                ApplicantAgeInYears = 30,
                AirlineFrequentFlyerNumber = "A1234567"
            };

            return sut.SubmitApplication(a);
        }


        private string GetApplicantName(int refNumber)
        {
            var sut = new CreditCardApplicationServiceReference.CreditCardApplicationServiceClient();

            return sut.GetSuccesfulApplicantsName(refNumber);
        }

        // The below was the original test before being refactored

        //[Test]
        //public void ShouldSubmitValidApplication()
        //{            
        //    var sut = new CreditCardApplicationServiceReference.CreditCardApplicationServiceClient();

        //    var a = new CreditCardApplication
        //                {
        //                    ApplicantName = "Jason",
        //                    ApplicantAgeInYears = 30,
        //                    AirlineFrequentFlyerNumber = "A1234567"
        //                };

        //    var submissionResult = sut.SubmitApplication(a);

        //    Assert.That(submissionResult.ValidationErrors, Is.Empty);
        //    Assert.That(submissionResult.ReferenceNumber, Is.Not.Null);


        //    // We can test the workflow by executing the next logical service that a client would call...            
        //    // We call the GetSuccesfulApplicantsName service, feeding in the result of the last service
        //    var successfulApplicantsName = sut.GetSuccesfulApplicantsName(submissionResult.ReferenceNumber.Value);

        //    // Here we are testing that the system has stored the correct applicant (name) against the reference number
        //    Assert.That(successfulApplicantsName, Is.EqualTo("Jason"));            
        //}
    }
}
