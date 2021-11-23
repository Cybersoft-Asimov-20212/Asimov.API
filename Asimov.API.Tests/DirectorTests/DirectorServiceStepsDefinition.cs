using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Asimov.API.Directors.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Asimov.API.Tests
{
    [Binding]
    public class DirectorServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        
        private HttpClient Client { get; set; }
        
        private Uri BaseUri { get; set; }
        
        private Task<HttpResponseMessage> Response { get; set; }
        
        private DirectorResource Director { get; set; }

        private DirectorServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/auth/sign-up/director")]
        public void GivenTheEndpointHttpsLocalhostAuthSignUpDirector(int port)
        {
            BaseUri = new Uri($"https://localhost:{port}/auth/sign-up/director");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [When(@"A Post Request is sent")]
        public void WhenAPostRequestIsSent(Table saveDirectorResource)
        {
            var resource = saveDirectorResource.CreateSet<SaveDirectorResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Message of ""(.*)"" is included in Response Body")]
        public async void ThenAMessageOfIsIncludedInResponseBody(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonExpectedMessage = expectedMessage.ToJson();
            var jsonActualMessage = actualMessage.ToJson();
            Assert.Equal(jsonExpectedMessage, jsonActualMessage);
        }

        [Given(@"A Director is already stored")]
        public async void GivenADirectorIsAlreadyStored(Table existingDirectorResource)
        {
            var directorUri = new Uri("https://localhost:5001/api/v1/directors");
            var resource = existingDirectorResource.CreateSet<SaveDirectorResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var directorResponse = Client.PostAsync(directorUri, content);
            var directorResponseData = await directorResponse.Result.Content.ReadAsStringAsync();
            var existingDirector = JsonConvert.DeserializeObject<DirectorResource>(directorResponseData);
            Director = existingDirector;
        }
    }
}