using Superheroes.Tech.Infrastructure.DataSource.Configurations;
using Superheroes.Tech.Infrastructure.DataSource.Implementations;
using Superheroes.Tech.Infrastructure.DataSource.Interfaces;
using Superheroes.Tech.Infrastructure.Extensions;

namespace Superheroes.Tech.API.Http
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton(new CharactersJsonStaticFileConfiguration("../data.source.json"));
            builder.Services.AddScoped<ICharactersDataProvider, CharastersJsonStaticFileDataProvider>();

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
