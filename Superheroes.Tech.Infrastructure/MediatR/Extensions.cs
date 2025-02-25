using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Superheroes.Tech.Application;

namespace Superheroes.Tech.Infrastructure.MediatR
{
    public static class Extensions
    {
        public static void RegisterMediatRWithImplementations(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<SampleCommand>());
        }
    }
}
