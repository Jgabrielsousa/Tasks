using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Context
{
    public class MyTasksDbContext : DbContext
    {
        public MyTasksDbContext(DbContextOptions opt):base(opt)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        
        public virtual DbSet<TaskEntity> Tasks { get; set; }
    
    }
}
