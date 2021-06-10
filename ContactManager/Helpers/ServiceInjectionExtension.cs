using ContactManager.Facade.Implmt;
using ContactManager.Facade.Interfaces;
using ContactManager.Repostory.Core;
using ContactManager.Services.Core;
using ContactManager.Services.Implmnt;
using ContactManager.Services.interfaces;
using ContactManager.UnitOf.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Helpers
{
    public static class ServiceInjectionExtension
    {
        public static void InjectionDataBase(this IServiceCollection services)
        {

            services.AddScoped(typeof(IBaseRepstory<>), typeof(BaseRepstory<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            services.AddScoped<ICVSFacade, CVSFacade>();
            services.AddScoped<ICVSFildService, CVSFildService>();
        }
    }
}
