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

namespace module_10.Integration.Tests.API
{
    public class LectorsEnpointTest
    {
        WebApplicationFactory<Startup> _webClientFactory;

        public LectorsEnpointTest()
        {
            _webClientFactory = new CustomWebApplicationFactory<Startup>();
        }

        [Theory]
        [InlineData("/api/lector")]
        public async Task A_Check_If_Got_All_Lectors_Json_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce = await client.GetStringAsync(url);

            var receivedJson = JSONSerializer.JSONDeserialize<List<Lector>>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<List<Lector>>(LectorsServiceData.Get_All_Lectors());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }

        [Theory]
        [InlineData("/api/lector/3")]
        public async Task B_Check_If_One_Expected_Lector_Returned_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce = await client.GetStringAsync(url);

            var receivedJson = JSONSerializer.JSONDeserialize<Lector>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<Lector>(LectorsServiceData.Get_Predefined_Lectors_Json());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }

        [Theory]
        [InlineData("/api/lector/")]
        public async void C_Check_If_One_New_Lector_Added_Successfully_Test(string url_post)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var new_lector = new Lector()
            {
                Id = 0,
                Name = "Test name",
                Age = 17,
                Email = "t.name@yandex.ru",
                Phone = "+79051234567"
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Act
            var responce_post = await client.PostAsync(url_post, new StringContent(JsonSerializer.Serialize(new_lector), 
                                                                                   Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<Lector>(responce, options);

                // Assert
                Assert.Equal(new_lector.Name, receivedJson.Name);
                Assert.Equal(new_lector.Age, receivedJson.Age);
                Assert.Equal(new_lector.Email, receivedJson.Email);
                Assert.Equal(new_lector.Phone, receivedJson.Phone);
            }
        }

        [Theory]
        [InlineData("/api/lector/4")]
        public async void D_Check_If_Lector_4_Is_Modified_Successfully_Test(string url_put)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var edited_lector = new Lector()
            {
                Id = 4,
                Name = "Test name",
                Age = 17,
                Email = "t.name@yandex.ru",
                Phone = "+79051234567"
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Act
            var responce_post = await client.PutAsync(url_put, new StringContent(JsonSerializer.Serialize(edited_lector), 
                                                                                 Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<Lector>(responce, options);

                // Assert
                Assert.Equal(edited_lector.Name, receivedJson.Name);
                Assert.Equal(edited_lector.Age, receivedJson.Age);
                Assert.Equal(edited_lector.Email, receivedJson.Email);
                Assert.Equal(edited_lector.Phone, receivedJson.Phone);
            }
        }

        [Theory]
        [InlineData("/api/lector/2")]
        public async void E_Check_If_Lector_2_Deleted_Successfully_Test(string url_delete_check)
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