using ContactManager.Entitys.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ContactManager.Helpers
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
}