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
builder.Services.AddFeatures(builder.Configuration);
builder.Services.AddIdentity(builder.Configuration.GetRequiredSection(AuthenticationOption.Section));
builder.Services.AddPersistence(builder.Configuration.GetRequiredSection(PersistenceOption.Section));
builder.Services.AddMail(builder.Configuration.GetRequiredSection(MailOption.Section));
builder.Services.AddFilePath(builder.Configuration.GetRequiredSection(UploadOption.Section));
builder.Services.AddControllers();
builder.Services.AddSwagger();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UsePersistence();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseSwagger(true);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Run();