using NUnit.Framework;

namespace Hoebeke.Test.Acceptance
{
    [TestFixture]
    public class WhenCallingApi : InMemoryTest
    {
         [Test]
         public void GetValues_WithKnownValue_ReturnsCorrectBody()
         {
             var response = HttpClient.GetAsync("/customer/1").Result;
             var body = response.Content.ReadAsStringAsync().Result;

             Assert.That(body, Is.StringContaining("john doe"));
         }

        public void InsertCustomer_WithKnownValues_InsertsIntoDb()
         {
            
         }
    }
}
