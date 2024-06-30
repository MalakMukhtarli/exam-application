using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExamApplication.Business.Installers;

public interface IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration);
}