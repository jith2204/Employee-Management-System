using AutoMapper;
using Employee_BAL.Exceptions;
using Employee_BAL.Interfaces;
using Employee_BAL.Model;
using Employee_DAL.ContextData;
using Employee_DAL.Entities;
using Employee_DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Service
{
    public class UserRegisterService : IUserRegisterService
    {
        IMapper _mapper;
        IUserRegisterRepository _userRepository;
        IRoleMemberRepository _roleMemberRepository;
        IValidationService _validationService;
        IUnitOfWork _unitOfWork;
        IConfiguration _configuration;
        EmployeeContext _context;
        public UserRegisterService(IMapper mapper,
            IUserRegisterRepository userRepository,
            IValidationService validationService,
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            IRoleMemberRepository roleMemberRepository,
            EmployeeContext context)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _validationService = validationService;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _roleMemberRepository = roleMemberRepository;
            _context = context;
        }



        /// <summary>
        /// Registering an Employee Credential
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateException"></exception>
        public UserRegisterModel Register(UserRegisterModel userModel)
        {
            RoleMemberModel roleMemberModel = new();
            var userRegister = _mapper.Map<UserRegister>(userModel);
            var userRole = _mapper.Map<RoleMember>(roleMemberModel);
            var password = ComputeSha256Hash(userModel.Password);

            var email = _validationService.IsValidEmail(userModel.Email);

            var getEmail = _userRepository.Find(i => i.Email == email).FirstOrDefault();
            using (var transaction = _context.Database.BeginTransaction())
            {
                if (getEmail != null)
                {
                    throw new DuplicateException("Email exist");
                }
                else
                {
                    userRegister.Email = email;
                    userRegister.Password = password;
                    userRegister.RegisteredOn = DateTime.Now;
                }
                _userRepository.Add(userRegister);
                userRole.UserId = userRegister.Id;
                userRole.RoleId = userModel.RoleId;
                _roleMemberRepository.Add(userRole);
                transaction.Commit();

                return _mapper.Map<UserRegisterModel>(userModel);
            }

            static string ComputeSha256Hash(string rawData)
            {
                // Create a SHA256   
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }
    }
}
