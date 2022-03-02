using M10_Web_API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace module_10.Integration.Tests.API
{
    public class CommonServicesTest
    {
        WebApplicationFactory<Startup> _webClientFactory;

        public CommonServicesTest()
        {
            _webClientFactory = new CustomWebApplicationFactory<Startup>();
        }

        [Theory]
        [InlineData("/api/homework")]
        [InlineData("/api/homework-define")]
        [InlineData("/api/lector")]
        [InlineData("/api/lecture")]
        [InlineData("/api/lecture-log")]
        [InlineData("/api/student")]
        public async Task Check_If_Status_Code_200_When_Check_Endpoints_Availability_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}