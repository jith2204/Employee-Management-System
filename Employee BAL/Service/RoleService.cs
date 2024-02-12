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
    public class RoleService : IRoleService
    {
        IRoleRepository _roleRepository;
        IMapper _mapper;
        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public List<RoleIdModel> GetAll()
        {
            var roleList = _roleRepository.GetAll();
            return _mapper.Map<List<RoleIdModel>>(roleList);
        }

    }
}
