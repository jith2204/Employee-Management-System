using AutoMapper;
using Employee_BAL.Exceptions;
using Employee_BAL.Interfaces;
using Employee_BAL.Model;
using Employee_DAL.Entities;
using Employee_DAL.Interfaces;
using Employee_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Service
{
    public class ProjectService : IProjectService
    {
        IProjectRepository _projectRepository;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        IValidationService _validationService;
        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidationService validationService)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationService = validationService;
        }

        /// <summary>
        /// Adds a Project details
        /// </summary>
        /// <param name="projectModel"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateException"></exception>

        public ProjectModel Add(ProjectModel projectModel)
        {

            {
                var project = _mapper.Map<Projects>(projectModel);
                var name = _validationService.IsValidString(projectModel.Name);
                var getName = _projectRepository.Find(i => i.Name == name).FirstOrDefault();
                
                if (getName != null)
                {

                    throw new DuplicateException("Project Name exist");
                }
                else
                {
                    project.Name = name;
                }

                project.EndDate = projectModel.EndDate;
                project.StartDate = projectModel.StartDate;
                project.CreatedOn = DateTime.Now;
                _projectRepository.Add(project);
                _unitOfWork.Commit();
                return _mapper.Map<ProjectModel>(project);
            }

        }


        /// <summary>
        /// Get All Projects with Details
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NoContentException"></exception>
        public List<ProjectIdModel> GetAll()
        {
            var project = _projectRepository.GetAll();
            
            var projectList = _mapper.Map<List<ProjectIdModel>>(project);
           
            if (projectList?.Any() != true)
            {
                throw new NoContentException("No Project is added.");
            }
            
            return projectList;
        }

        public ProjectModel GetById(int id)
        {
            var project = _projectRepository.GetById(id);

            if (project == null)
            {
                throw new EntityNotFoundException("The Employee cannot be found.");
            }
            return _mapper.Map<ProjectModel>(project);
        }


        /// <summary>
        /// Deletes a Project details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>

        public ProjectModel Remove(int id)
        {
            var project = _projectRepository.GetById(id);
           
            if (project == null)
            {
                throw new EntityNotFoundException("The Project cannot be found.");

            }
            project.DeletedOn = DateTime.Now;
           
            _projectRepository.Remove(project);
            _unitOfWork.Commit();
          
            return _mapper.Map<ProjectModel>(project);
        }

        
        /// <summary>
        /// Updates a Project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectModel"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <exception cref="DuplicateException"></exception>
        public ProjectModel Update(int id, ProjectModel projectModel)
        {
            var project = _projectRepository.GetById(id);
           
            if (project == null)
            {
                throw new EntityNotFoundException("The Project cannot be Found");
            }
          
            var name = _validationService.IsValidString(projectModel.Name);

            var getName = _projectRepository.Find(i => i.Name == name && i.Id != id).FirstOrDefault();
            
            if (getName != null)
            {
                throw new DuplicateException("Project name exist");
            }
          
            project.Name = projectModel.Name;
            project.Description = projectModel.Description;
            project.StartDate = projectModel.StartDate;
            project.EndDate = projectModel.EndDate;
            
            project.UpdatedOn = DateTime.Now;

            _projectRepository.Update(project);
            _unitOfWork.Commit();
            
            return _mapper.Map<ProjectModel>(project);
        }
    }
}