using ExamApplication.Business.Services.Exams;
using ExamApplication.Business.Services.Grades;
using ExamApplication.Business.Services.Lessons;
using ExamApplication.Business.Services.Pupils;
using ExamApplication.Business.Services.Teachers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExamApplication.Business.Installers;

public class ServiceInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IGradeService, GradeManager>();
        services.AddScoped<ILessonService, LessonManager>();
        services.AddScoped<IPupilService, PupilManager>();
        services.AddScoped<ITeacherService, TeacherManager>();
        services.AddScoped<IExamService, ExamManager>();
    }
}