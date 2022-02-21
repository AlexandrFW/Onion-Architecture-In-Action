using BusinessLogic.BusinessServices;
using Domain.Interfaces.BusinessLogicServices;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            return services
                .AddScoped<IStudentsService, StudentsService>()
                .AddScoped<ILectorsService, LectorsService>()
                .AddScoped<IHomeworksService, HomeworksService>()
                .AddScoped<ILecturesService, LectureService>()
                .AddScoped<ILecturesStudentsService, LecturesStudentsService>()
                .AddScoped<IHomeworksStudentsService, HomeworksStudentsService>();
        }
    }
}