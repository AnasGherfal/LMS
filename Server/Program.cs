using Common.Options;
using Serilog;
using Server.Extensions;
using Server.Middlewares;

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
builder.Services.AddPersistence(builder.Configuration.GetRequiredSection(PersistenceOption.Section));
builder.Services.AddMail(builder.Configuration.GetRequiredSection(MailOption.Section));
builder.Services.AddFilePath(builder.Configuration.GetRequiredSection(UploadOption.Section));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UsePersistence();
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