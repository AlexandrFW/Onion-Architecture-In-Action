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
    public class LecturesEnpointTest
    {
        WebApplicationFactory<Startup> _webClientFactory;

        public LecturesEnpointTest()
        {
            _webClientFactory = new CustomWebApplicationFactory<Startup>();
        }

        [Theory]
        [InlineData("/api/lecture")]
        public async Task A_Check_If_Got_All_Lectures_Json_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce = await client.GetStringAsync(url);

            var receivedJson = JSONSerializer.JSONDeserialize<List<Lecture>>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<List<Lecture>>(LecturesServiceData.Get_All_Lectures());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }

        [Theory]
        [InlineData("/api/lecture/3")]
        public async Task B_Check_If_One_Expected_Lecture_Returned_Test(string url)
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
        [InlineData("/api/lecture/")]
        public async void C_Check_If_One_New_Lecture_Added_Successfully_Test(string url_post)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var new_lecture = new Lecture()
            {
                Id = 0,
                LectureName = "Test name",
                LectorId = 4
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Act
            var responce_post = await client.PostAsync(url_post, new StringContent(JsonSerializer.Serialize(new_lecture), 
                                                                                   Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<Lecture>(responce, options);

                // Assert
                Assert.Equal(new_lecture.LectureName, receivedJson.LectureName);
                Assert.Equal(new_lecture.LectorId, receivedJson.LectorId);
            }
        }

        [Theory]
        [InlineData("/api/lecture/4")]
        public async void D_Check_If_Lecture_4_Is_Modified_Successfully_Test(string url_put)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var edited_lecture = new Lecture()
            {
                Id = 4,
                LectureName = "Test name",
                LectorId = 4
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Act
            var responce_post = await client.PutAsync(url_put, new StringContent(JsonSerializer.Serialize(edited_lecture), 
                                                                                 Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<Lecture>(responce, options);

                // Assert
                Assert.Equal(edited_lecture.LectureName, receivedJson.LectureName);
                Assert.Equal(edited_lecture.LectorId, receivedJson.LectorId);
            }
        }

        [Theory]
        [InlineData("/api/lecture/2")]
        public async void E_Check_If_Lecture_2_Deleted_Successfully_Test(string url_delete_check)
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