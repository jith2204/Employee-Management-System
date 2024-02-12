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





    }
}
