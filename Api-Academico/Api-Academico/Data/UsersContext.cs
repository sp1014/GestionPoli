using Api_Academico.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiUsers.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<AllocationLoad> AllocationLoads { get; set; }
        public DbSet<Califications> Califications { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Follow_upCourse> Follow_up_courses { get; set; }
        public DbSet<Grade> Grades { get; set; }    
        public DbSet<Lounge> Lounges { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

    }
}
