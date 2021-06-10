using ContactManager.Entitys.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Extensions
{
  public static  class DataBaseExtension
    {
        public static void DataBase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ContactManagerDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("ContactManager"), b => b.MigrationsAssembly("ContactManager")));
        }
    }
}
