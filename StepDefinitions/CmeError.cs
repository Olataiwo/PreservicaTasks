using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestApiProject.StepDefinitions
{
    [Binding]
    public class CmeError
    {
        private readonly ApiService _apiService;
        public CmeError(ScenarioContext context) 
        {
            _apiService = (ApiService)context["ApiService"];
        }

        [Given(@"the NASA endpoint with Incorrect date format")]
        public void GivenTheNASAEndpointWithIncorrectDateFormat()
        {
            _apiService.InitializeCmeClient("01/01/2023", "2023-01-07", "DEMO_KEY");
        }

        [When(@"a Get request is sent")]
        public async Task WhenAGetRequestIsSent()
        {
            await _apiService.SendRequestAsync();
        }

        [Then(@"the response should contain a correspondin error message")]
        public void ThenTheResponseShouldContainACorrespondinErrorMessage()
        {
            throw new PendingStepException();
        }


    }
}
