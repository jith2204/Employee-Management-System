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
    public class ProjectsMappingService : IProjectsMappingService
    {
        IProjectsEmployeeMappingRepository _employeeProjectMappingRepository;
        IEmployeeRepository _employeeRepository;
        IProjectRepository _projectRepository;

        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        IValidationService _validationService;

        public ProjectsMappingService(IProjectsEmployeeMappingRepository empprojmappingRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidationService validationService, IEmployeeRepository employeeRepository, IProjectRepository projectRepository)
        {
            _employeeProjectMappingRepository = empprojmappingRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationService = validationService;
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;

        }


        /// <summary>
        /// Adds a Project Employee Mapping
        /// </summary>
        /// <param name="mappingModel"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <exception cref="DuplicateException"></exception>
        public ProjectsEmployeeMappingModel Add(ProjectsEmployeeMappingModel mappingModel)
        {

            var employeeProjectMapping = _mapper.Map<ProjectsEmployeeMapping>(mappingModel);
            var employeeId = mappingModel.EmployeeId;
            var projectId = mappingModel.ProjectId;
            var findEmployeeId = _employeeRepository.Find(i => i.Id == employeeId).FirstOrDefault();

            if (findEmployeeId == null)
            {

                throw new EntityNotFoundException("The Employee cannot be Found");
            }

            var findProjectId = _projectRepository.Find(i => i.Id == projectId).FirstOrDefault();
            if (findProjectId == null)
            {

                throw new EntityNotFoundException("The Project cannot be Found");
            }
            var existingMapping = _employeeProjectMappingRepository.Find(i => i.EmployeeId == employeeId && i.ProjectId == projectId).FirstOrDefault();
            if (existingMapping != null)
            {
                throw new DuplicateException("Mapping Already Exists");

            }
            else
            {
                employeeProjectMapping.EmployeeId = employeeId;
                employeeProjectMapping.ProjectId = projectId;
            }

            employeeProjectMapping.CreatedOn = DateTime.Now;
            _employeeProjectMappingRepository.Add(employeeProjectMapping);
            _unitOfWork.Commit();
            return _mapper.Map<ProjectsEmployeeMappingModel>(employeeProjectMapping);

        }



        /// <summary>
        /// Get Employee Working Projects By Employee ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        public List<ProjectsEmployeeMappingModel> EmployeeWorkingProjects(int employeeId)
        {
            var findEmployeeId = _employeeRepository.Find(i => i.Id == employeeId).FirstOrDefault();

            if (findEmployeeId == null)
            {

                throw new EntityNotFoundException("The Employee cannot be Found");
            }


            var getEmployeeId = _employeeProjectMappingRepository.EmployeeWorkingProjects(employeeId);
            return _mapper.Map<List<ProjectsEmployeeMappingModel>>(getEmployeeId);
        }



        /// <summary>
        /// Get All Project Employee Mappings
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NoContentException"></exception>
        public List<ProjectsEmployeeMappingIdModel> GetAllMappingData()
        {
            var project = _employeeProjectMappingRepository.GetAll();
            var projectList = _mapper.Map<List<ProjectsEmployeeMappingIdModel>>(project);
            if (projectList?.Any() != true)
            {
                throw new NoContentException("No Mapping is added.");
            }

            return projectList;
        }



        /// <summary>
        /// Get Assigned Employees of a Project By Project ID
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        public List<ProjectsEmployeeMappingModel> GetAssignedEmployees(int projectId)
        {
            var findProjectId = _projectRepository.Find(i => i.Id == projectId).FirstOrDefault();
            if (findProjectId == null)
            {

                throw new EntityNotFoundException("The Project cannot be Found");
            }

            var getProjectId = _employeeProjectMappingRepository.GetAssignedEmployees(projectId);
            return _mapper.Map<List<ProjectsEmployeeMappingModel>>(getProjectId);
        }
    }
}