using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using M10_Web_API;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;


namespace module_10.IntegrationTests.API
{
    public class HomeworksServiceTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public HomeworksServiceTest() //WebApplicationFactory<Startup> factory)
        {
            /*_factory = new WebApplicationFactory<Startup>();*/// factory;
        }

        [Fact]
        public async Task TestHomeworks()
        {
            var _factory = new WebApplicationFactory<Startup>();

            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/homework");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("/api/homework")]
        public async Task Check_If_Status_Code_200_When_Return_All_Data_Test(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //Assert.Equal("text/html; charset=utf-8",
            //    response.Content.Headers.ContentType.ToString());
        }
    }
}