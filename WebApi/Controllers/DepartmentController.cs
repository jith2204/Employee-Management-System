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
    [Route("api/v1/department")]
    [ApiController]
   
    public class DepartmentController : BaseApiController
    {
        IDepartmentService _departmentService;
        ILogger<DepartmentController> _logger;
        public DepartmentController(IDepartmentService department, ILogger<DepartmentController> logger) : base(logger)
        {
            _departmentService = department;
            _logger = logger;
        }



        ///POST
        ///api/v1/department
        /// <summary>
        /// Add a Department with all its details
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///        
        ///        {
        ///        "name":"Department Name",
        ///        "description":"Department Description"
        ///        }
        /// </remarks>
        /// <param name="addDepartment"></param>
        /// <returns>one department is returned</returns>
        ///  <response code ="200">Successfully Inserted the Department</response>
        ///  <response code ="400">BadRequest</response>
        ///  <response code ="409">Department Already Exist</response>
        ///  <response code ="500">InternalServerError</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Add a Department")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult AddDepartment([FromBody] DepartmentModel addDepartment)
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Adding a Department");
                return _departmentService.Add(addDepartment);
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
        ///api/v1/department
        /// <summary>
        /// Get all Departments its details
        /// </summary>
        ///<remarks>
        /// Sample response:
        ///     {
        ///         "status": true,
        ///         "message": "Success",
        ///         "result": [
        ///          {
        ///          "id": Department ID,
        ///          "name": "Department Name",
        ///          "description": "Department Description"
        ///          }
        ///        ]
        ///      }
        ///</remarks>
        /// <returns>Lists all Departments</returns>
        ///  <response code ="200">Successfully Displayed All Department Details</response>

        ///  <response code ="204">No Department Found</response>

        ///  <response code ="500">InternalServerError</response>

        [HttpGet]
        [SwaggerOperation(Summary = "Get All Department Details")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]


        public IActionResult ViewDepartments()
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Getting all Department Details");
                return _departmentService.GetAll();
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
        ///api/v1/department
        /// <summary>
        /// Update a Department with all  its details
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///        
        ///        {
        ///        
        ///        "name":"Department Name",
        ///        "description":"Department Description"
        ///        }
        /// </remarks>
        /// <param name="id" name="updateDepartment"></param>
        /// <returns> one Department is returnrd</returns>
        ///  <response code ="200">Successfully Updated the Department</response>
        ///  <response code ="400">BadRequest</response>
        ///  <response code ="404">Department Not Found</response>
        ///  <response code ="409">Department Already Exist</response>
        ///  <response code ="500">InternalServerError</response>



        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a Department By Id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
    
        public IActionResult UpdateDepartment(int id, [FromBody] DepartmentModel updateDepartment)
        {

            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Updating a Department");
                return _departmentService.Update(id, updateDepartment);
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
        ///api/v1/department
        /// <summary>
        /// Delete a Department with all  its details
        /// </summary>
        ///<remarks>
        /// Sample response:
        ///     {
        ///         "status": true,
        ///         "message": "Success",
        ///         "result": [
        ///          {
        ///          
        ///          "name": "Department Name",
        ///          "description": "Department Description"
        ///          }
        ///        ]
        ///      }
        ///</remarks>
        /// <param name="id"></param>
        /// <returns>returns an empty array</returns>
        ///  <response code ="200">Successfully Deleted the Department</response>

        ///  <response code ="404">Department Not Found</response>

        ///  <response code ="500">InternalServerError</response>



        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a Department By Id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult RemoveDepartment(int id)
        {
            return TryExecuteAndWrap(() =>

            {
                _logger.LogInformation("Deleting a Department");
                return _departmentService.Remove(id);
            },

            result => { return Ok(result); },

            e => { return e; },

            onError => { return Forbid(onError.Message); });

        }








    }
}
