using AutoMapper;
using DataAccess.ModelsDb;
using Domain.Models;

namespace DataAccess
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            
            CreateMap<StudentDb, Student>().ReverseMap();

            CreateMap<LectorDb, Lector>().ReverseMap();

            CreateMap<HomeworkDb, Homework>().ReverseMap(); 

            CreateMap<LectureDb, Lecture>().ReverseMap();

            CreateMap<LecturesStudentsDb, LecturesStudents>().ReverseMap();

            CreateMap<HomeworksStudentsDb, HomeworksStudents>().ReverseMap();
        }
    }
}