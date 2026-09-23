using InterviewPratice.Models.Request;
using InterviewPratice.Models.RequestDto;
using InterviewPratice.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace InterviewPratice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaveReponse>().HasNoKey();
        }


        // Define your DbSets for your entities here
        // Example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
