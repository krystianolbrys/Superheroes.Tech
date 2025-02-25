using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Superheroes.Tech.Application.Infrastructure;

namespace Superheroes.Tech.Infrastructure.Extensions
{
    public static class MediatRLibararyExtensions
    {
        public static void RegisterMediatRWithImplementations(this IHostApplicationBuilder builder) =>
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyMarker>());
    }
}
