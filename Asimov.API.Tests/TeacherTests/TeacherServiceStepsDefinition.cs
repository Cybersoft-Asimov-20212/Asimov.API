using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Asimov.API.Teachers.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Asimov.API.Tests.TeacherTests
{
    [Binding]
    public class TeacherServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private TeacherResource Teacher { get; set; }
        
        public TeacherServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the Endpoint https://localhost:(.*)/auth/sign-up/teacher is available")]
        public void GivenTheEndpointHttpsLocalhostAuthSignUpTeacherIsAvailable(int port)
        {
            BaseUri = new Uri($"https://localhost:{port}/auth/sign-up/products");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [When(@"A Post Request is sent to Teacher")]
        public void WhenAPostRequestIsSentToTeacher(Table saveTeacherResource)
        {
            var resource = saveTeacherResource.CreateSet<SaveTeacherResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Response with Status (.*) is received in Teacher")]
        public void ThenAResponseWithStatusIsReceivedInTeacher(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Message of ""(.*)"" is included in Response Body of Teacher")]
        public async void ThenAMessageOfIsIncludedInResponseBodyOfTeacher(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonExpectedMessage = expectedMessage.ToJson();
            var jsonActualMessage = actualMessage.ToJson();
            Assert.Equal(jsonExpectedMessage, jsonActualMessage);
        }

        [Given(@"A Teacher is already stored")]
        public async void GivenATeacherIsAlreadyStored(Table existingTeacherResource)
        {
            var resource = existingTeacherResource.CreateSet<SaveTeacherResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var teacherResponse = Client.PostAsync(BaseUri, content);
            var teacherResponseData = await teacherResponse.Result.Content.ReadAsStringAsync();
            var existingTeacher = JsonConvert.DeserializeObject<TeacherResource>(teacherResponseData);
            Teacher = existingTeacher;
        }
    }
}