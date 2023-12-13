using AutoMapper;
using CatalogService.BusinessLogic;
using CatalogService.BusinessLogic.Mapper;
using CatalogService.WebApi.Mapper;

namespace CatalogService.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = SetupSettingsJson();
            builder.Services.AddSingleton<IConfiguration>(configuration);

            builder.Services.AddBusinessLogicServices(configuration.GetConnectionString("Database"));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BusinessLogicMappingProfile());
                mc.AddProfile(new WebApiMappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        protected static IConfiguration SetupSettingsJson()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}