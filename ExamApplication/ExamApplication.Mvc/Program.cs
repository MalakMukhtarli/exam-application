using ExamApplication.Business.Extensions;
using ExamApplication.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var config = builder.Configuration;
services.InstallServicesInAssembly(config);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
    {
        options.Filters.Add<ExceptionFilter>();
        options.MaxModelBindingCollectionSize = int.MaxValue;
    })
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();