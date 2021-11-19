using DesafioConfitec.Contracts;
using DesafioConfitec.Infra.Data.Context;
using DesafioConfitec.Infra.Data.Repositories;
using DesafioConfitec.Services.Dtos;
using DesafioConfitec.Services.Interfaces;
using DesafioConfitec.Services.Mappings;
using DesafioConfitec.Services.Services;
using DesafioConfitec.Services.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioConfitec.Infra.Ioc
{
    public static class DependencyInjectionContainer
    {
        public static void AddContainerDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("connectiondb")));
            services.AddAutoMapper(typeof(DtoToEntityMapper), typeof(EntityToDtoMapper));

        

            //Repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepositorio>();

            //Services
            services.AddScoped<IUsuarioService, UsuarioService>();

            //Validations
            services.AddScoped<IValidator<UsuarioDto>, UserValidator>();
        }
    }
}
