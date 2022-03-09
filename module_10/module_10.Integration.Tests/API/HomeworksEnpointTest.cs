using AuxiliaryServices.Tools;
using Domain.Models;
using M10_Web_API;
using Microsoft.AspNetCore.Mvc.Testing;
using module_10.MockData.API;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

//// Need to turn off test parallelization so we can validate the run order
//[assembly: CollectionBehavior(DisableTestParallelization = true)]
//[assembly: TestCollectionOrderer("module_10.Integration.Tests.DisplayNameOrderer", "module_10.Integration.Tests.API")]

namespace module_10.Integration.Tests.API
{
    public class HomeworksEnpointTest
    {
        WebApplicationFactory<Startup> _webClientFactory;

        public HomeworksEnpointTest()
        {
            _webClientFactory = new CustomWebApplicationFactory<Startup>(); 
        }

        [Theory]
        [InlineData("/api/homework")]
        public async Task A_Check_If_We_Got_All_Homeworks_Json_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce = await client.GetStringAsync(url);

            var receivedJson = JSONSerializer.JSONDeserialize<List<Homework>>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<List<Homework>>(HomeworksServiceData.Get_All_Homeworks());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }

        [Theory]
        [InlineData("/api/homework/2")]
        public async Task B_Check_If_One_Expected_Homework_Returned_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce = await client.GetStringAsync(url);

            var receivedJson = JSONSerializer.JSONDeserialize<Homework>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<Homework>(HomeworksServiceData.Get_Predefined_Homework_Json());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }

        [Theory]
        [InlineData("/api/homework/")]
        public async void C_Check_If_New_Homework_Added_Successfully_Test(string url_post)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var new_homework = new Homework()
            {
                Id = 0,
                Subject = "Homework added from Integration test",
                LectureId = 4
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Act
            var responce_post = await client.PostAsync(url_post, new StringContent(JsonSerializer.Serialize(new_homework), Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<Homework>(responce, options);

                // Assert
                Assert.Equal(new_homework.Subject, receivedJson.Subject);
                Assert.Equal(new_homework.LectureId, receivedJson.LectureId);
            }
        }

        [Theory]
        [InlineData("/api/homework/4")]
        public async void D_Check_If_Homework_2_Is_Modified_Successfully_Test(string url_put)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var edited_homework = new Homework()
            {
                Id = 4,
                Subject = "Homework added from Integration test",
                LectureId = 4
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Act
            var responce_post = await client.PutAsync(url_put, new StringContent(JsonSerializer.Serialize(edited_homework), Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<Homework>(responce, options);

                // Assert
                Assert.Equal(edited_homework.Subject, receivedJson.Subject);
                Assert.Equal(edited_homework.LectureId, receivedJson.LectureId);
            }
        }

        [Theory]
        [InlineData("/api/homework/3")]
        public async void E_Check_If_Homework_2_Deleted_Successfully_Test(string url_delete_check)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce_post = await client.DeleteAsync(url_delete_check);
            if (responce_post.IsSuccessStatusCode)
            {
                var responce = await client.GetAsync(url_delete_check);

                // Assert
                Assert.Equal(HttpStatusCode.NotFound, responce.StatusCode);
            }
        }
    }
}