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
    [Route("api/v1/mapping")]
    [ApiController]
    
    public class ProjectsEmployeeMappingController : BaseApiController
    {
        IProjectsMappingService _projectMappingService;
        ILogger<ProjectsEmployeeMappingController> _logger;
        public ProjectsEmployeeMappingController(IProjectsMappingService projectMappingService, ILogger<ProjectsEmployeeMappingController> logger) : base(logger)
        {
            _projectMappingService = projectMappingService;
            _logger = logger;
        }

        
        
        ///POST
        ///api/v1/mapping
        /// <summary>
        /// Add a mapping with all its details
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///        
        ///        {
        ///        "employeeId":Employee ID,
        ///        "projectId":Project ID
        ///        }
        /// </remarks>
        /// <param name="addMapping"></param>
        /// <returns>one mapping is returned</returns>
        ///  <response code ="200">Successfully Inserted the Mapping</response>
        ///  <response code ="400">BadRequest</response>
        ///  <response code ="404">Employee or Project Not Found</response>
        ///  <response code ="409">Mapping Already Exist</response>
        ///  <response code ="500">InternalServerError</response>



        [HttpPost]
        
        [SwaggerOperation(Summary = "Add a Employee Project Mapping")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]



        public IActionResult AddMapping([FromBody] ProjectsEmployeeMappingModel addMapping)
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Adding a Project Employee Mapping");
                return _projectMappingService.Add(addMapping);
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
        ///api/v1/mapping
        /// <summary>
        /// Get all Mapping with its details
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///   {
        ///       "status": true,
        ///       "message": "Success",
        ///       "result": [
        ///       {
        ///       "id": Mapping ID,
        ///       "employeeId": Employee ID,
        ///       "projectId": Project ID,
        ///       }
        ///     ] 
        ///   }     
        /// </remarks>
        /// <returns>Lists all Mappings</returns>
        ///  <response code ="200">Successfully Displayed All Mapping Details</response>

        ///  <response code ="204">No Mapping Found</response>

        ///  <response code ="500">InternalServerError</response>
        
        [HttpGet]
        
        [SwaggerOperation(Summary = "Get All Mapping Details")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
       
        public IActionResult ViewMappingss()
        {

            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Getting all Project Details");
                return _projectMappingService.GetAllMappingData();
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


        ///GET BY EMPLOYEE ID
        ///api/v1/mapping
        /// <summary>
        /// Get all Project details by Employee ID
        /// </summary>
        /// <remarks>
        ///     Sample Response:
        ///     {
        ///       "status": true,
        ///       "message": "Success",
        ///       "result": {
        ///        employeeId": Employee ID,
        ///       "projectId": Project ID,
        ///     }
        ///       
        /// </remarks>
        /// <returns>Lists all Projects</returns>
        ///  <response code ="200">Successfully Displayed All Projects</response>
        ///  <response code ="204">No Mapping Found</response>
        ///  <response code ="404">No Employee Found</response>
        ///  <response code ="500">InternalServerError</response>






        [HttpGet("{id}/Project Details")]
        
        [SwaggerOperation(Summary = "Get Project Details By Employee Id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]




        public IActionResult GetProjectsByEmployeeId(int id)
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Getting Project details By Employee Id");
                return _projectMappingService.EmployeeWorkingProjects(id);
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



        ///GET BY PROJECT ID
        ///api/v1/mapping
        /// <summary>
        /// Get all Employee details by Project ID
        /// </summary>
        /// <remarks>
        ///     Sample Response:
        ///     {
        ///       "status": true,
        ///       "message": "Success",
        ///       "result": {
        ///        employeeId": Employee ID,
        ///       "projectId": Project ID,
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Lists all Employees</returns>
        ///  <response code ="200">Successfully Got the Employees</response>
        ///  <response code ="204">No Mapping Found</response>
        ///  <response code ="404">Project Not Found</response>
        ///  <response code ="500">InternalServerError</response>





        [HttpGet("{id}/Employee Details")]
        
        [SwaggerOperation(Summary = "Get Employee Details By Project Id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]




        public IActionResult GetEmployeesByProjectId(int id)
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Getting Project details By Employee Id");
                return _projectMappingService.GetAssignedEmployees(id);
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
    }
}
