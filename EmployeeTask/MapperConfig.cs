using AutoMapper;
using Employee_BAL.Model;
using Employee_DAL.Entities;

namespace EmployeeTask
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Employees, EmployeeModel>().ReverseMap();
            CreateMap<Employees, EmployeeIdModel>().ReverseMap();
            CreateMap<Departments, DepartmentModel>().ReverseMap();
            CreateMap<Departments, DepartmentIdModel>().ReverseMap();
            CreateMap<Projects, ProjectModel>().ReverseMap();
            CreateMap<Projects, ProjectIdModel>().ReverseMap();
            CreateMap<ProjectsEmployeeMapping, ProjectsEmployeeMappingModel>().ReverseMap();
            CreateMap<ProjectsEmployeeMapping, ProjectsEmployeeMappingIdModel>().ReverseMap();
            CreateMap<UserRegister, UserRegisterModel>().ReverseMap();
            CreateMap<UserRegister, UserRegisterIdModel>().ReverseMap();
            CreateMap<UserRegister, AccountModel>().ReverseMap();
            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<Role, RoleIdModel>().ReverseMap();
            CreateMap<RoleMember, RoleMemberModel>().ReverseMap();
        }
    }
}