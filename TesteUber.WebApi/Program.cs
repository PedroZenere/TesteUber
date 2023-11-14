using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using TesteUber.Infra.EmailGateway.AmazonMailGateway.Extensions;
using TesteUber.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.BoostrapDependencyInjection(configuration);

ConfigureAWS(configuration);

builder.Services.AddServiceAmazonSES();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#region
void ConfigureAWS(IConfiguration configuration)
{
    Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", configuration["AWSSES:AWS_ACCESS_KEY_ID"]);
    Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", configuration["AWSSES:AWS_SECRET_ACCESS_KEY"]);
    Environment.SetEnvironmentVariable("AWS_SESSION_TOKEN", configuration["AWSSES:AWS_SESSION_TOKEN"]);
    Environment.SetEnvironmentVariable("AWS_REGION", configuration["AWSSES:AWS_REGION"]);
}
#endregion
