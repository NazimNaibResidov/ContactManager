using ContactManager.Entitys.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ContactManager.Entitys.Core
{
    public class ContactManagerDbContext : DbContext
    {
        public ContactManagerDbContext(DbContextOptions<ContactManagerDbContext> options)
            : base(options)
        { }

        public DbSet<CSVEntityFild> CSVFilds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}