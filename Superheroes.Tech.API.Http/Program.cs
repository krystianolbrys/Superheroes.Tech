using Superheroes.Tech.Domain.Strategies;
using Superheroes.Tech.Domain.Strategies.Implementations;
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

            builder.Services.AddSingleton<IBattleStrategy, SameTypeBattleStrategy>();
            builder.Services.AddSingleton<IBattleStrategy, StandardBattleWithNoWekanessStrategy>();
            builder.Services.AddSingleton<IBattleStrategy, StandardBattleWithOneSideWeaknessStrategy>();

            // Add services to the container.
            builder.RegisterMediatRWithImplementations();
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
