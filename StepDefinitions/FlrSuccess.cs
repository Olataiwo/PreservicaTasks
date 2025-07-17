using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiProject.StepDefinitions
{
    [Binding]
    public class FlrSuccess
    {
       
        private readonly ApiService _apiService;
        public FlrSuccess(ScenarioContext context)
        {
            _apiService = (ApiService)context["ApiService"];
        }

        [Given(@"the NASA FLR endpoint with valid startDate, endDate, and API key")]
        public void GivenTheNASAFLREndpointWithValidStartDateEndDateAndAPIKey()
        {
            _apiService.InitializeCmeClient("2023-01-01", "2023-01-07", "DEMO_KEY");
        }

        [When(@"the request is sent")]
        public async Task WhenTheRequestIsSent()
        {
            await _apiService.SendRequestAsync();
        }


        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)_apiService.GetStatusCode());
        }
       

        [Then(@"the response should contain flare data")]
        public void ThenTheResponseShouldContainFlareData()
        {
            Assert.IsTrue(_apiService.HasNonEmptyResults());
        }

        

    }
}
