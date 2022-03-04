using AuxiliaryServices.Tools;
using Domain.Models;
using M10_Web_API;
using Microsoft.AspNetCore.Mvc.Testing;
using module_10.MockData.API;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;


namespace module_10.Integration.Tests.API
{
    public class LecturesStudentsEnpointTest
    {
        WebApplicationFactory<Startup> _webClientFactory;

        public LecturesStudentsEnpointTest()
        {
            _webClientFactory = new CustomWebApplicationFactory<Startup>();
        }

        [Theory]
        [InlineData("/api/lecture-log")]
        public async Task A_Check_If_We_Got_All_LecturesStudents_Json_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce = await client.GetStringAsync(url);

            var receivedJson = JSONSerializer.JSONDeserialize<List<LecturesStudents>>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<List<LecturesStudents>>(LecturesStudentsServiceData.Get_All_LecturesStudents());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }

        [Theory]
        [InlineData("/api/lecture-log/2_3")]
        public async Task B_Check_If_One_Expected_LecturesStudents_Returned_Test(string url)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();

            // Act
            var responce = await client.GetStringAsync(url);

            var receivedJson = JSONSerializer.JSONDeserialize<LecturesStudents>(responce);
            var preparedJson = JSONSerializer.JSONDeserialize<LecturesStudents>(LecturesStudentsServiceData.Get_Predefined_LectureStudent_Json());

            // Assert
            Assert.Equal(preparedJson, receivedJson);
        }

        [Theory]
        [InlineData("/api/lecture-log/")]
        public async void C_Check_If_New_LecturesStudents_Added_Successfully_Test(string url_post)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var new_lecture_student = new LecturesStudents()
            {
                LectureId = 4,
                LectureName = "",
                StudentId = 5,
                StudentName = "",
                Grade = 5,
                IsStudentAttended = true,
                LectureDate = DateTime.Now,
                LectorName = ""
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Act
            var responce_post = await client.PostAsync(url_post, new StringContent(JsonSerializer.Serialize(new_lecture_student), 
                                                                                   Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<LecturesStudents>(responce, options);

                // Assert
                Assert.Equal(new_lecture_student.Grade, receivedJson.Grade);
                Assert.Equal(new_lecture_student.IsStudentAttended, receivedJson.IsStudentAttended);
            }
        }

        [Theory]
        [InlineData("/api/lecture-log/2_2")]
        public async void D_Check_If_LecturesStudents_2_2_Is_Modified_Successfully_Test(string url_put)
        {
            // Arrange
            using var client = _webClientFactory.CreateClient();
            var edited_lectures_students = new LecturesStudents()
            {
                LectureId = 4,
                LectureName = "Mathematics",
                StudentId = 5,
                StudentName = "Svatlana Vasileva",
                Grade = 5,
                IsStudentAttended = true,
                LectureDate = DateTime.Now,
                LectorName = ""
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Act
            var responce_post = await client.PutAsync(url_put, new StringContent(JsonSerializer.Serialize(edited_lectures_students),
                                                                                 Encoding.UTF8, "application/json"));
            if (responce_post.IsSuccessStatusCode)
            {
                var str = await responce_post.Content.ReadAsStringAsync();
                var responce = await client.GetStringAsync(str);

                var receivedJson = JsonSerializer.Deserialize<LecturesStudents>(responce, options);

                // Assert
                Assert.Equal(edited_lectures_students.Grade, receivedJson.Grade);
                Assert.Equal(edited_lectures_students.IsStudentAttended, receivedJson.IsStudentAttended);
            }
        }

        [Theory]
        [InlineData("/api/lecture-log/3_4")]
        public async void E_Check_If_LecturesStudents_3_4_Deleted_Successfully_Test(string url_delete_check)
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