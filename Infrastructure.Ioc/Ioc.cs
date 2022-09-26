using Aplicacion.ApiManager.Services.Servicios;
using Dominio.ApiManager.Entidades.Entidades;
using Infraestructura.General.Crypto;
using Infrastructura.Data.DataAccess;
using Infrastructura.Data.DataAccess.UnitOfWork;
using Infrastructura.Data.DataAccess.UnitOfWork.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Ioc
{
  public static  class Ioc
    {

        public static IConfiguration Configuration { get; }
 
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
           
     
            //services.AddSingleton<IWebHostEnvironment>(_hostEnv);
            services.AddTransient<ICryptographyService, CryptographyService>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IBaseDataAccess, BaseDataAccess>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IMovimientoRepository, MovimientoRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICuentaService, CuentaService>();
            services.AddScoped<IMovimientoService, MovimientoService>();
            return services;
        }
    }
}
