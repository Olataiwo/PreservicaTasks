using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestApiProject.StepDefinitions
{
    [Binding]
    public class CmeSuccess
    {
        private readonly ApiService _apiService;
        public CmeSuccess(ScenarioContext context)
        {
            _apiService = (ApiService)context["ApiService"];
        }

        [Given(@"the NASA Coronal Mass Ejection Endpoint with startDate, endDate,  and valid API Key")]
        public void GivenTheNASACoronalMassEjectionEndpointWithStartDateEndDateAndValidAPIKey()
        {
            _apiService.InitializeCmeClient("2023-01-01", "2023-01-07", "DEMO_KEY");
        }

        [When(@"a GET request is sent")]
        public async Task WhenAGETRequestIsSent()
        {
            await _apiService.SendRequestAsync();
        }

        [Then(@"the response status code should be correct")]
        public void ThenTheResponseStatusCodeShouldBeCorrect()
        {
            Assert.AreEqual(HttpStatusCode.OK, _apiService.GetStatusCode());
        }

        [Then(@"the response should contain a valid data of CME events")]
        public void ThenTheResponseShouldContainAValidDataOfCMEEvents()
        {
            Assert.IsTrue(_apiService.HasNonEmptyResults());
        }


    }


}
