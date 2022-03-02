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
    public class StudentsEnpointTest
    {
        WebApplicationFactory<Startup> _webClientFactory;

        public StudentsEnpointTest()
        {
            _webClientFactory = new CustomWebApplicationFactory<Startup>();
        }

        [Theory]
        [InlineData("/api/student")]
        public async Task A_Check_If_Got_All_Students_Json_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce = await client.GetStringAsync(url);

            var receivedJson = JSONSerializer.JSONDeserialize<List<Student>>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<List<Student>>(StudentsServiceData.Get_All_Students());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }

        [Theory]
        [InlineData("/api/student/3")]
        public async Task B_Check_If_One_Expected_Student_Returned_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce = await client.GetStringAsync(url);

            var receivedJson = JSONSerializer.JSONDeserialize<Student>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<Student>(StudentsServiceData.Get_Predefined_Student_Json());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }

        [Theory]
        [InlineData("/api/student/")]
        public async void C_Check_If_One_New_Student_Added_Successfully_Test(string url_post)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var new_student = new Student()
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
            var responce_post = await client.PostAsync(url_post, new StringContent(JsonSerializer.Serialize(new_student), 
                                                                                   Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<Student>(responce, options);

                // Assert
                Assert.Equal(new_student.Name, receivedJson.Name);
                Assert.Equal(new_student.Age, receivedJson.Age);
                Assert.Equal(new_student.Email, receivedJson.Email);
                Assert.Equal(new_student.Phone, receivedJson.Phone);
            }
        }

        [Theory]
        [InlineData("/api/student/4")]
        public async void D_Check_If_Student_4_Is_Modified_Successfully_Test(string url_put)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var edited_student = new Student()
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
            var responce_post = await client.PutAsync(url_put, new StringContent(JsonSerializer.Serialize(edited_student), 
                                                                                 Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<Student>(responce, options);

                // Assert
                Assert.Equal(edited_student.Name, receivedJson.Name);
                Assert.Equal(edited_student.Age, receivedJson.Age);
                Assert.Equal(edited_student.Email, receivedJson.Email);
                Assert.Equal(edited_student.Phone, receivedJson.Phone);
            }
        }

        [Theory]
        [InlineData("/api/student/2")]
        public async void E_Check_If_Student_2_Deleted_Successfully_Test(string url_delete_check)
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