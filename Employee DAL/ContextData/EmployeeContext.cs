using Employee_DAL.Entities;
using Microsoft.EntityFrameworkCore;




namespace Employee_DAL.ContextData
{

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {

        }
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }
        public DbSet<Employees> Employee { get; set; }
        public DbSet<Projects> Project { get; set; }
        public DbSet<Departments> Department { get; set; }
        public DbSet<ProjectsEmployeeMapping> ProjectsEmployeeMappings { get; set; }
        public DbSet<UserRegister> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleMember> RoleMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employees>().HasKey(x => x.Id);
            builder.Entity<Employees>().ToTable("Employee");
            
            builder.Entity<Departments>().HasKey(x => x.Id);
            builder.Entity<Departments>().ToTable("Department");
           
            builder.Entity<Projects>().HasKey(x => x.Id);
            builder.Entity<Projects>().ToTable("Project");
           
            builder.Entity<ProjectsEmployeeMapping>().HasKey(x => x.Id);
            builder.Entity<ProjectsEmployeeMapping>().ToTable("ProjectsEmployeeMappings");

            builder.Entity<UserRegister>().HasKey(x => x.Id);
            builder.Entity<UserRegister>().ToTable("Users");

            builder.Entity<Role>().HasKey(x => x.Id);
            builder.Entity<Role>().ToTable("Roles");

            builder.Entity<RoleMember>().HasKey(x => x.Id);
            builder.Entity<RoleMember>().ToTable("RoleMembers");

            base.OnModelCreating(builder);
        }
    }
}
