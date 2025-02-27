using Superheroes.Tech.API.Http.Models;
using Superheroes.Tech.Domain.Strategies;
using Superheroes.Tech.Domain.Strategies.Implementations;
using Superheroes.Tech.Domain.Validators;
using Superheroes.Tech.Infrastructure.DataSource.Configurations;
using Superheroes.Tech.Infrastructure.DataSource.Implementations;
using Superheroes.Tech.Infrastructure.DataSource.Interfaces;
using Superheroes.Tech.Infrastructure.DataSource.Projectors;
using Superheroes.Tech.Infrastructure.Extensions;

namespace Superheroes.Tech.API.Http
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IJsonCharacterReadDtosToDomainModelsProjector, JsonCharacterReadDtosToDomainModelsProjector>();
            builder.Services.AddSingleton(new CharactersJsonStaticFileConfiguration("../data.source.json"));
            builder.Services.AddScoped<ICharactersDataProvider, CharastersJsonStaticFileDataProvider>();

            builder.Services.AddSingleton<IWeaknessValidator, WeaknessValidator>();
            builder.Services.AddSingleton<IBattleStrategy, SameTypeBattleStrategy>();
            builder.Services.AddSingleton<IBattleStrategy, StandardBattleWithNoWekanessStrategy>();
            builder.Services.AddSingleton<IBattleStrategy, StandardBattleWithOneSideWeaknessStrategy>();

            // Add services to the container.
            builder.RegisterMediatRWithImplementations();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Battle API 0.0.1");
                options.RoutePrefix = "docs";
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
