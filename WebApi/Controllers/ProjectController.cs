using Employee_BAL.Interfaces;
using Employee_BAL.Model;
using Employee_DAL.Entities;
using Employee_DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace WebApi.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/v1/project")]
    [ApiController]
    
    public class ProjectController : BaseApiController
    {
        IProjectService _projectService;
        ILogger<ProjectController> _logger;
        public ProjectController(IProjectService projectService, ILogger<ProjectController> logger) : base(logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        ///POST
        ///api/v1/project
        /// <summary>
        /// Add a Project with all its details
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///        
        ///        {
        ///        "name":"Project Name",
        ///        "description":"Project Description"
        ///        }
        /// </remarks>
        /// <param name="addProject"></param>
        /// <returns>one project is returned</returns>
        ///  <response code ="200">Successfully Inserted the Project</response>
        ///  <response code ="400">BadRequest</response>
        ///  <response code ="409">Project Already Exist</response>
        ///  <response code ="500">InternalServerError</response>

        [HttpPost]
        
        [SwaggerOperation(Summary = "Add a Project")]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]

        public IActionResult AddProject([FromBody] ProjectModel addProject)
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Adding a Project");
                return _projectService.Add(addProject);
            }, result =>
            {
                return Ok(result);
            }, e =>
            {
                return e;
            },
                       onError =>
                       {
                           return Forbid(onError.Message);
                       });


        }



        ///GET
        ///api/v1/project
        /// <summary>
        /// Get all Projects its details
        /// </summary>
        ///   <remarks>
        /// Sample response:
        /// {
        ///         "status": true,
        ///         "message": "Success",
        ///         "result": [
        ///         {
        ///          "id": Project ID,
        ///          "name": "Project Name",
        ///          "description": "Project Description"
        ///         }
        ///      ]
        ///  }
        /// </remarks>
        /// <returns>Lists all Projects</returns>
        ///  <response code ="200">Successfully Displayed All Project Details</response>

        ///  <response code ="204">No Project Found</response>

        ///  <response code ="500">InternalServerError</response>

        [HttpGet]
        
        [SwaggerOperation(Summary = "Get All Project Details")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]

        [ProducesResponseType(500)] 
        
        public IActionResult ViewProjects()
        {

            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Getting all Project Details");
                return _projectService.GetAll();
            }, result =>
            {
                return Ok(result);
            }, e =>
            {
                return e;
            },
                       onError =>
                       {
                           return Forbid(onError.Message);
                       });
        }


        ///UPDATE
        ///api/v1/project
        /// <summary>
        /// Update a Project with all  its details
        /// </summary>
        /// Sample request:
        ///        
        ///        {
        ///        "name":"Project Name",
        ///        "description":"Project Description"
        ///        }
        /// <param name="id" name="updateProject"></param>
        /// <returns> one Project is returnrd</returns>
        ///  <response code ="200">Successfully Updated the Project</response>
        ///  <response code ="400">BadRequest</response>
        ///  <response code ="404">Project Not Found</response>
        ///  <response code ="409">Project Already Exist</response>
        ///  <response code ="500">InternalServerError</response>



        [HttpPut("{id}")]
       
        [SwaggerOperation(Summary = "Update a Project By Id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]


        public IActionResult UpdateProject(int id, [FromBody] ProjectModel updateProject)
        {

            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Updating a Department");
                return _projectService.Update(id, updateProject);
            }, result =>
            {
                return Ok(result);
            }, e =>
            {
                return e;
            },
                        onError =>
                        {
                            return Forbid(onError.Message);
                        });




        }


        ///DELETE
        ///api/v1/project
        /// <summary>
        /// Delete a Project with all  its details
        /// </summary>
        /// /// <remarks>
        /// Sample response:
        /// {
        ///         "status": true,
        ///         "message": "Success",
        ///         "result": [
        ///         {
        ///          
        ///          "name": "Project Name",
        ///          "description": "Project Description"
        ///         }
        ///      ]
        ///  }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>returns an empty array</returns>
        ///  <response code ="200">Successfully Deleted the Project</response>

        ///  <response code ="404">Project Not Found</response>

        ///  <response code ="500">InternalServerError</response>



        [HttpDelete("{id}")]
        
        [SwaggerOperation(Summary = "Delete a Project By Id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
      
        public IActionResult RemoveProject(int id)
        {
            return TryExecuteAndWrap(() =>

            {
                _logger.LogInformation("Deleting a Project");
                return _projectService.Remove(id);
            },

            result => { return Ok(result); },

            e => { return e; },

            onError => { return Forbid(onError.Message); });

        }

    }
}