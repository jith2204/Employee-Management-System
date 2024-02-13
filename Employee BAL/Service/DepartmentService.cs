

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
    public class DepartmentService : IDepartmentService
    {

        IDepartmentRepository _departmentRepository;
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        IValidationService _validationService;

        public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidationService validationService)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationService = validationService;
        }



        /// <summary>
        /// Add a Department with  its details
        /// </summary>
        /// <param name="departmentModel"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateException"></exception>

        public DepartmentModel Add(DepartmentModel departmentModel)
        {
            var department = _mapper.Map<Departments>(departmentModel);
            var name = _validationService.IsValidString(departmentModel.Name);
            var getName = _departmentRepository.Find(i => i.Name == name).FirstOrDefault();
            if (getName != null)
            {

                throw new DuplicateException("Department name exist");
            }
            else
            {
                department.Name = name;
            }
           
            department.Description = departmentModel.Description;
            department.CreatedOn = DateTime.Now;
           
            _departmentRepository.Add(department);
            _unitOfWork.Commit();
            
            return _mapper.Map<DepartmentModel>(department);
        }


        /// <summary>
        /// Displays All Department Details
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NoContentException"></exception>
        public List<DepartmentIdModel> GetAll()
        {
            var department = _departmentRepository.GetAll();
            
            var departmentList = _mapper.Map<List<DepartmentIdModel>>(department);
            
            if (departmentList?.Any() != true)
            {
                throw new NoContentException("No Department is added.");
            }
            return departmentList;
        }

       

        /// <summary>
        /// Removes a Department with  its details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        public DepartmentModel Remove(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                throw new EntityNotFoundException("The Departments cannot be found.");

            }
           
            department.DeletedOn = DateTime.Now;
            
            _departmentRepository.Remove(department);
            _unitOfWork.Commit();
            
            return _mapper.Map<DepartmentModel>(department);
        }



        /// <summary>
        /// Updates a Department
        /// </summary>
        /// <param name="id"></param>
        /// <param name="departmentModel"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <exception cref="DuplicateException"></exception>

        public DepartmentModel Update(int id, DepartmentModel departmentModel)
        {
            var department = _departmentRepository.GetById(id);
            
            if (department == null)
            {
                throw new EntityNotFoundException("The Department cannot be Found");
            }
           
            var name = _validationService.IsValidString(departmentModel.Name);

            var getName = _departmentRepository.Find(i => i.Name == name && i.Id != id).FirstOrDefault();
            
            if (getName != null)
            {
                throw new DuplicateException("Department name exist");
            }
           
            department.Name = departmentModel.Name;
            department.Description = departmentModel.Description;

            department.UpdatedOn = DateTime.Now;

            _departmentRepository.Update(department);
            _unitOfWork.Commit();
            
            return _mapper.Map<DepartmentModel>(department);
        }

       
    }
}