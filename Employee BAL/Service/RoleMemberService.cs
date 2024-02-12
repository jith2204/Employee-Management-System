using AutoMapper;
using Employee_BAL.Exceptions;
using Employee_BAL.Interfaces;
using Employee_BAL.Model;
using Employee_DAL.Entities;
using Employee_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Service
{
    public class RoleMemberService : IRoleMemberService
    {
        IRoleMemberRepository _roleMemberRepository;
        IRoleRepository _roleRepository;
        IUserRegisterRepository _userRegisterRepository;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        IValidationService _validationService;

        public RoleMemberService(IUserRegisterRepository userRegisterRepository, IRoleMemberRepository roleMemberRepository, IRoleRepository roleRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidationService validationService)
        {
            _roleMemberRepository = roleMemberRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationService = validationService;
            _roleRepository = roleRepository;
            _userRegisterRepository = userRegisterRepository;

        }

        public RoleMemberModel Add(RoleMemberModel roleMemberModel)
        {

            var userRoleMapping = _mapper.Map<RoleMember>(roleMemberModel);
            var userId = roleMemberModel.UserId;
            var roleId = roleMemberModel.RoleId;
            var findUserId = _userRegisterRepository.Find(i => i.Id == userId).FirstOrDefault();

            if (findUserId == null)
            {

                throw new EntityNotFoundException("The User cannot be Found");
            }

            var findRoleId = _roleRepository.Find(i => i.Id == roleId).FirstOrDefault();
            if (findRoleId == null)
            {

                throw new EntityNotFoundException("The Role cannot be Found");
            }
            var existingMapping = _roleMemberRepository.Find(i => i.UserId == userId && i.RoleId == roleId).FirstOrDefault();
            if (existingMapping != null)
            {
                throw new DuplicateException("Mapping Already Exists");

            }
            else
            {
                userRoleMapping.UserId = userId;
                userRoleMapping.RoleId = roleId;
            }


            _roleMemberRepository.Add(userRoleMapping);
            _unitOfWork.Commit();
            return _mapper.Map<RoleMemberModel>(userRoleMapping);

        }
    }
}

