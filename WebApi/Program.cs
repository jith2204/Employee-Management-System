using AspNet.Security.OAuth.Validation;
using Employee_BAL.Interfaces;
using Employee_BAL.Service;
using Employee_DAL.ContextData;
using Employee_DAL.Interfaces;
using Employee_DAL.Repositories;
using Employee_DAL.UnitOfWork;
using EmployeeTask;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.Swagger;
using System.Text;
using WebApi;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperConfig).Assembly);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
    c.EnableAnnotations();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    });

#region Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IProjectsEmployeeMappingRepository, ProjectsEmployeeMappingRepository>();
builder.Services.AddTransient<IUserRegisterRepository, UserRegisterRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IRoleMemberRepository, RoleMemberRepository>();
#endregion 
#region Services
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IProjectsMappingService, ProjectsMappingService>();
builder.Services.AddTransient<IValidationService, ValidationService>();
builder.Services.AddTransient<IUserRegisterService, UserRegisterService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IRoleMemberService, RoleMemberService>();
#endregion


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<EmployeeContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(EmployeeContext).Assembly.FullName)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();