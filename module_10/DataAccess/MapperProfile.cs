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
                .IncludeMembers(s => s.Student);
            //.ReverseMap();

            CreateMap<LecturesStudents, LecturesStudentsDb>()
                .ForMember(l_s => l_s.LectureId, opt => opt.MapFrom(src => src.LectureId))
                .ForMember(d_l => d_l.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(d_lr => d_lr.Grade, opt => opt.MapFrom(src => src.Grade))
                .ForMember(d_ln => d_ln.IsStudentAttended, opt => opt.MapFrom(src => src.IsStudentAttended));
                //.ReverseMap();

            CreateMap<HomeworksStudentsDb, HomeworksStudents>().ReverseMap();
        }
    }
}