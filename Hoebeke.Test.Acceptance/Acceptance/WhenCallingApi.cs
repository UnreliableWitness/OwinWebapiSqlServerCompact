using System.Net.Http;
using System.Text;
using NUnit.Framework;

namespace Hoebeke.Test.Acceptance.Acceptance
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

         [Test]
         public void InsertCustomer_WithKnownValues_ReturnsCorrectId()
         {
            var json = "{Name:\"John Doe\"}";
            var response = HttpClient.PostAsync("",new StringContent(json,Encoding.UTF8,"application/json")).Result;

            var body = response.Content.ReadAsStringAsync().Result;

            Assert.That(response.IsSuccessStatusCode);

            int id;
            Assert.That(int.TryParse(body, out id));
            Assert.That(id > 0);
         }
    }
}
