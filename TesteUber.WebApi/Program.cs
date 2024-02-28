using TesteUber.Infra.IoC;
using TesteUber.Infra.EmailGateway.AmazonMailGateway.Extensions;
using TesteUber.Application.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddServiceMediatr();
builder.Services.AddServiceAutoMapper();

builder.Services.AddServiceAmazonSES(configuration);

builder.Services.BoostrapDependencyInjection();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
