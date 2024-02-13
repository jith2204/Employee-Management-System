
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
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        IValidationService _validationService;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidationService validationService)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationService = validationService;
        }

        /// <summary>
        /// Adds a Employee with its details
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateException"></exception>
        public EmployeeModel Add(EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<Employees>(employeeModel);

            var email = _validationService.IsValidEmail(employeeModel.Email);
            
            var getEmail = _employeeRepository.Find(i => i.Email == email).FirstOrDefault();
           
            if (getEmail != null)
            {

                throw new DuplicateException("email exist");
            }
            else
            {
                employee.Email = email;
            }

            var phone = _validationService.IsValidPhoneNumber(employeeModel.PhoneNo);
            
            var getPhone = _employeeRepository.Find(i => i.PhoneNo == phone).FirstOrDefault();
            
            if (getPhone != null)
            {

                throw new DuplicateException("phone number exist");
            }
            else
            {
                employee.PhoneNo = phone;
            }

            employee.Name = employeeModel.Name;
            employee.Address = employeeModel.Address;
            employee.Gender = employeeModel.Gender;
            employee.CreatedOn = DateTime.Now;
            employee.DOB = employeeModel.DOB;
            employee.Score = employeeModel.Score;
            employee.Salary = employeeModel.Salary;
            employee.DepartmentId = employeeModel.DepartmentId;
            
            _employeeRepository.Add(employee);
            _unitOfWork.Commit();
            
            return _mapper.Map<EmployeeModel>(employee);
        }

        /// <summary>
        /// Get All Employee Details
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NoContentException"></exception>

        public List<EmployeeIdModel> GetAll()
        {
            var employee = _employeeRepository.GetAll();
            var employeeList = _mapper.Map<List<EmployeeIdModel>>(employee);
            if (employeeList?.Any() != true)
            {
                throw new NoContentException("No Employee is added.");
            }

            return employeeList;
        }



        /// <summary>
        /// Removes a Employee with its details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>

        public EmployeeModel Remove(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                throw new EntityNotFoundException("The Employee cannot be found.");

            }
          
            employee.DeletedOn = DateTime.Now;
            _employeeRepository.Remove(employee);
            _unitOfWork.Commit();
            return _mapper.Map<EmployeeModel>(employee); 
        }


        /// <summary>
        /// Updates a Department
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <exception cref="DuplicateException"></exception>
        
        public EmployeeModel Update(int id, EmployeeModel employeeModel)
        {
            var employee = _employeeRepository.GetById(id);
          
            if(employee == null)
            {
                throw new EntityNotFoundException("The Employee cannot be Found");
            }
            
            var email = _validationService.IsValidEmail(employeeModel.Email);
            
            var phone = _validationService.IsValidPhoneNumber(employeeModel.PhoneNo);
            
            var existing = _employeeRepository.Find(i=>i.Email == email && i.PhoneNo == phone && i.Id != id).FirstOrDefault();
           
            if(existing != null)
            {
                throw new DuplicateException("Email or Phone Already Exists");
            }

            employee.Name = employeeModel.Name;
            employee.Score = employeeModel.Score;
            employee.Email = employeeModel.Email;
            employee.PhoneNo = employeeModel.PhoneNo;
            employee.DepartmentId = employeeModel.DepartmentId;
            employee.Salary = employeeModel.Salary;
            employee.DOB = employeeModel.DOB;
            employee.Gender = employeeModel.Gender;
            employee.Address = employeeModel.Address;
            employee.UpdatedOn = DateTime.Now;
             
            _employeeRepository.Update(employee);
            _unitOfWork.Commit();
            return _mapper.Map<EmployeeModel>(employee);

        }


        /// <summary>
        /// Get Employee Details By Employee Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        public EmployeeModel GetByEmployeeId(int id)
        {
            var employee = _employeeRepository.GetById(id);
            
            if (employee == null)
            {
                throw new EntityNotFoundException("The Employee cannot be found.");

            }
            return _mapper.Map<EmployeeModel>(employee);
        }
    }
}



