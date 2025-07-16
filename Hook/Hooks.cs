using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiProject.Hook
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;


        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("@restAPi")]
        public void BeforeScenario()
        {
            var apiService = new ApiService();
            _scenarioContext["ApiService"] = apiService;
        }

        [AfterScenario]
        public void AfterScenario()
        {

            if (_scenarioContext.TryGetValue("ApiService", out object? serviceObj)
                && serviceObj is ApiService apiService)
            {
                apiService.Dispose(); 
                Console.WriteLine("[AfterScenario] ApiService disposed.");
            }

            Console.WriteLine($"[AfterScenario] Tear down complete for: {_scenarioContext.ScenarioInfo.Title}");
        }
    }
}
