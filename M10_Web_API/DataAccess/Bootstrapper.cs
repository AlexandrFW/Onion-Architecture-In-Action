using DataAccess.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
        {
            return services
                .AddAutoMapper(typeof(MapperProfile))
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString))
                .AddScoped<IStudentsRepository, StudentsRepository>()
                .AddScoped<ILectorsRepository, LectorsRepository>()
                .AddScoped<IHomeworksRepository, HomeworksRepository>()
                .AddScoped<ILecturesRepository, LecturesRepository>()
                .AddScoped<ILecturesStudentsRepository, LecturesStudentsRepository>()
                .AddScoped<IHomeworksStudentsRepository, HomeworksStudentsRepository>();
        }
    }
}