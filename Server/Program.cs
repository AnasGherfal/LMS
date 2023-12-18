using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Server.Extensions;
using Server.Middlewares;
using Server.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, config) =>
{
    config.ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext();
});
// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddCustomControllers();
builder.Services.AddFeatures(builder.Configuration);
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddMail(builder.Configuration.GetRequiredSection(MailOption.Section));
builder.Services.AddFilePath(builder.Configuration.GetRequiredSection(FilePaths.Section));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseMiddleware<ExceptionMiddleware>();
app.UseDefaultFiles();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
