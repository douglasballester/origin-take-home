using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Origin.Web;
using Origin.Web.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Origin.IntegrationTests.InsuranceRisk
{
    public class SimulateInsuranceRiskIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SimulateInsuranceRiskIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Should_Post_Simulate_Insurance_Risk_And_Succeed()
        {
            // Arrange
            var objectJson = new 
            { 
                age = 35 , 
                dependents = 2, 
                house = new { ownership_status = "owned"},
                income = 0,
                marital_status = "married",
                risk_questions = new List<byte> { 0, 1, 0},
                vehicle = new { year = 2018 } 
            };            

            var httpClient = _factory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(objectJson), Encoding.UTF8, "application/json");
            var url = "/api/insurance";

            //Act
            var response = await httpClient.PostAsync(url, content);
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<SimulateInsuranceRiskResponse>(responseJson);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("regular", responseObject.Auto);
            Assert.Equal("ineligible", responseObject.Disability);
            Assert.Equal("economic", responseObject.Home);
            Assert.Equal("regular", responseObject.Life);
        }

        [Fact]
        public async Task Should_Post_Simulate_Insurance_Risk_And_Fail()
        {
            // Arrange
            var objectJson = new
            {
                age = 35,
                dependents = 2,
                house = new { ownership_status = "owned" },
                income = 0,
                marital_status = "widow",
                risk_questions = new List<byte> { 0, 1, 0 },
                vehicle = new { year = 2018 }
            };

            var httpClient = _factory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(objectJson), Encoding.UTF8, "application/json");
            var url = "/api/insurance";

            //Act
            var response = await httpClient.PostAsync(url, content);
            var responseJson = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("[\"Field 'marital_status' needs to be valid\"]", responseJson);
        }
    }
}
