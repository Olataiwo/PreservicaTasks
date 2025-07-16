using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiProject.StepDefinitions
{
    [Binding]
    public class FlrError
    {
        private readonly ApiService _apiService;
        public FlrError(ScenarioContext context) 
        {
            _apiService = (ApiService)context["ApiService"];
        }

        [Given(@"the NASA Solar Flare endpoint with the NASA Solar Flare endpoint with a missing start date")]
        public void GivenTheNASASolarFlareEndpointWithTheNASASolarFlareEndpointWithAMissingStartDate()
        {
            _apiService.InitializeCmeClient("", "2023-01-07", "DEMO_KEY");
        }


        [Then(@"the FLR response status code should be (.*)")]
        public void ThenTheFLRResponseStatusCodeShouldBe(int errorStatusCode)
        {
            Assert.AreEqual(errorStatusCode, (int)_apiService.GetStatusCode());
        }



    }
}
