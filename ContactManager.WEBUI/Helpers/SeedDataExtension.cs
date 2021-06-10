using ContactManager.Entitys.Core;
using ContactManager.Facade.Implmt;
using ContactManager.Facade.Interfaces;
using ContactManager.Repostory.Core;
using ContactManager.Services.Core;
using ContactManager.Services.Implmnt;
using ContactManager.Services.interfaces;
using ContactManager.UnitOf.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.WEBUI.Helpers
{
    public static class SeedDataExtension
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ContactManagerDbContext>();
            context.Database.Migrate();
            if (!context.CSVFilds.Any())
            {
                for (int i = 0; i < 100; i++)
                {
                    bool _isMarried = false;
                    if (i % 2 == 0)
                    {
                        _isMarried = true;
                    }
                    context.CSVFilds.Add(new Entitys.Data.CSVEntityFild
                    {
                        DateofBirth = System.DateTime.Now,
                        Married = _isMarried,
                        Name = "Stev Jobs",
                        Phone = $"123456768{i}",
                        Salary = 12 + i
                    });
                }
            }
            context.SaveChanges();
        }
      
    }
    public static class DataBaseInjectionExtension
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
