using AuxiliaryServices.Tools;
using Domain.Models;
using M10_Web_API;
using Microsoft.AspNetCore.Mvc.Testing;
using module_10.MockData.API;
using System.Threading.Tasks;
using Xunit;

namespace module_10.Integration.Tests.API
{
    public class HomeworksEnpointTest
    {
        WebApplicationFactory<Startup> _webClientFactory;

        public HomeworksEnpointTest()
        {
            _webClientFactory = new WebApplicationFactory<Startup>();
        }

        [Theory]
        [InlineData("/api/homework")]
        public async Task Check_If_We_Got_All_Homeworks_Json_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

            // Act
            var responce = await client.GetStringAsync(url);
            var receivedJson = JSONSerializer.JSONDeserialize<Homework>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<Homework>(HomeworksServiceData.Get_All_Homeworks());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }
    }
}