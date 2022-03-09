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
    public class HomeworksStudentsEnpointTest
    {
        WebApplicationFactory<Startup> _webClientFactory;

        public HomeworksStudentsEnpointTest()
        {
            _webClientFactory = new CustomWebApplicationFactory<Startup>();
        }

        [Theory]
        [InlineData("/api/homework-define")]
        public async Task A_Check_If_We_Got_All_HomeworksStudents_Json_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce = await client.GetStringAsync(url);

            var receivedJson = JSONSerializer.JSONDeserialize<List<HomeworksStudents>>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<List<HomeworksStudents>>(HomeworkStudentsServiceData.Get_All_HomeworkStudents());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }

        [Theory]
        [InlineData("/api/homework-define/1_2")]
        public async Task B_Check_If_One_Expected_HomeworksStudents_Returned_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce = await client.GetStringAsync(url);

            var receivedJson = JSONSerializer.JSONDeserialize<HomeworksStudents>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<HomeworksStudents>(HomeworkStudentsServiceData.Get_Predefined_HomeworkStudents_Json());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }

        [Theory]
        [InlineData("/api/homework-define/")]
        public async void C_Check_If_New_HomeworksStudents_Added_Successfully_Test(string url_post)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var new_homework_students = new HomeworksStudents()
            {
                HomeworkId = 4,
                StudentId = 6
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Act
            var responce_post = await client.PostAsync(url_post, new StringContent(JsonSerializer.Serialize(new_homework_students), Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<HomeworksStudents>(responce, options);

                // Assert
                Assert.Equal(new_homework_students.HomeworkId, receivedJson.HomeworkId);
                Assert.Equal(new_homework_students.StudentId, receivedJson.StudentId);
            }
        }

        [Theory]
        [InlineData("/api/homework-define/2_2")]
        public async void D_Check_If_HomeworksStudents_2_2_Is_Modified_Successfully_Test(string url_put)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var edited_homework_students = new HomeworksStudents()
            {
                HomeworkId = 2,
                StudentId = 5
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Act
            var responce_post = await client.PutAsync(url_put, new StringContent(JsonSerializer.Serialize(edited_homework_students), Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<HomeworksStudents>(responce, options);

                // Assert
                Assert.Equal(edited_homework_students.HomeworkId, receivedJson.HomeworkId);
                Assert.Equal(edited_homework_students.StudentId, receivedJson.StudentId);
            }
        }

        [Theory]
        [InlineData("/api/homework-define/3_4")]
        public async void E_Check_If_HomeworksStudents_3_4_Deleted_Successfully_Test(string url_delete_check)
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