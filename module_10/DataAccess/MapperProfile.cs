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

            CreateMap<LectorDb, LecturesStudents>().ReverseMap();

            CreateMap<LectureDb, LecturesStudents>().ReverseMap();

            CreateMap<StudentDb, LecturesStudents>().ReverseMap();

            CreateMap<LecturesStudentsDb, LecturesStudents>()
                .ForMember(d_l => d_l.LectureName, opt => opt.MapFrom(src => src.Lecture.LectureName))
                .ForMember(d_lr => d_lr.LectorName, opt => opt.MapFrom(src => src.Lecture.Lector.Name))
                .IncludeMembers(s => s.Student)
                .ReverseMap();

            CreateMap<HomeworksStudentsDb, HomeworksStudents>().ReverseMap();
        }
    }
}