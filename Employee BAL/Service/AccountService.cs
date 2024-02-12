using AutoMapper;
using Employee_BAL.Exceptions;
using Employee_BAL.Interfaces;
using Employee_BAL.Model;
using Employee_DAL.Entities;
using Employee_DAL.Interfaces;
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
    public class AccountService : IAccountService
    {
        IUserRegisterRepository _userRegisterRepository;
        IAccountRepository _accountRepository;
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        IValidationService _validationService;
        IConfiguration _configuration;
        IRoleMemberRepository _roleMemberRepository;
        IRoleRepository _roleRepository;

        public AccountService(IRoleRepository roleRepository, IRoleMemberRepository roleMemberRepository, IUserRegisterRepository userRegisterRepository, IAccountRepository accountRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidationService validationService, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationService = validationService;
            _configuration = configuration;
            _userRegisterRepository = userRegisterRepository;
            _roleMemberRepository = roleMemberRepository;
            _roleRepository = roleRepository;
        }

        public string Login(AccountModel accountModel)
        {
            var email = _validationService.IsValidEmail(accountModel.Email);
            var password = ComputeSha256Hash(accountModel.Password);
            var existing = _userRegisterRepository.Get(email, password);
            if (existing == null)
            {
                throw new EntityNotFoundException("User doesn't exist");
            }
            else
            { 
                var roleMember = existing.RoleMembers.FirstOrDefault();
                var role = _roleRepository.GetRole(roleMember.RoleId);

                string token = CreateToken(accountModel, role.Roles);
                return token;
            }
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
        private string CreateToken(AccountModel accountModel, string role)
        {
            List<Claim> claims = new List<Claim>
            {
               new Claim(ClaimTypes.Email, accountModel.Email),
               new Claim(ClaimTypes.Role, role),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                audience: _configuration.GetSection("JWT:Audience").Value,
                issuer: _configuration.GetSection("JWT:Issuer").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}

