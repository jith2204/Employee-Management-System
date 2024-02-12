using AutoMapper;
using Employee_BAL.Exceptions;
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
    [Authorize(Roles = "Employee,Manager")]
    [Route("api/v1/employee")]
    [ApiController]
    
    public class EmployeeController : BaseApiController
    {

        IEmployeeService _employeeService;
        ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger) : base(logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }


        ///POST
        ///api/v1/employee
        /// <summary>
        /// Add a Employee with all its details
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///        
        ///        {
        ///        "name":"Employee Name",
        ///        "phoneNo":"Employee Phone Number",
        ///        "email":"Employee Email",
        ///        "score":"Employee Score",
        ///        "departmentId":"Employee Department ID"
        ///        }
        /// </remarks>
        /// <param name="addEmployee"></param>
        /// <returns>one employee is returned</returns>
        ///  <response code ="200">Successfully Inserted the Employee</response>
        ///  <response code ="400">BadRequest</response>
        ///  <response code ="409">Employee Already Exist</response>
        ///  <response code ="500">InternalServerError</response>

        [HttpPost]
        [SwaggerOperation(Summary = "Add a Employee")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]

        public IActionResult AddEmployee([FromBody] EmployeeModel addEmployee)
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Adding a Employee");
               return _employeeService.Add(addEmployee);
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
        ///api/v1/employee
        /// <summary>
        /// Get all Employees its details
        /// </summary>
        ///  <remarks>
        /// Sample response:
        /// {
        ///         "status": true,
        ///         "message": "Success",
        ///         "result": [
        ///         {
        ///         "id": Employee ID,
        ///         "phoneNo":"Employee Phone Number",
        ///         "email":"Employee Email",
        ///         "score":"Employee Score",
        ///         "departmentId":"Employee Department ID"
        ///         }
        ///      ]
        ///  }
        /// </remarks>
        /// <returns>Lists all Employees</returns>
        ///  <response code ="200">Successfully Displayed All Employee Details</response>

        ///  <response code ="204">No Employee Found</response>

        ///  <response code ="500">InternalServerError</response>



        [HttpGet]
        
        [SwaggerOperation(Summary = "Get All Employee Details")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
       
        [ProducesResponseType(500)]

        public IActionResult ViewEmployees()
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Getting all Employee Details");
                return _employeeService.GetAll();
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
        ///api/v1/employee
        /// <summary>
        /// Update a Employee with all  its details
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///        
        ///        {
        ///        "name":"Employee Name",
        ///        "phoneNo":"Employee Phone Number",
        ///        "email":"Employee Email",
        ///        "score":"Employee Score",
        ///        "departmentId":"Employee Department ID"
        ///        }
        /// </remarks>
        /// <param name="id" name="updateEmployee"></param>
        /// <returns>Lists a Employee</returns>
        ///  <response code ="200">Successfully Updated the Employee</response>
        ///  <response code ="400">BadRequest</response>
        ///  <response code ="404">Employee Not Found</response>
        ///  <response code ="409">Employee Already Exist</response>
        ///  <response code ="500">InternalServerError</response>



        [HttpPut("{id}")]
       
        [SwaggerOperation(Summary = "Update a Employee By Id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
    
        
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeModel updateEmployee)
        {

            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Updating a Employee");
                return _employeeService.Update(id, updateEmployee);
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
        ///api/v1/employee
        /// <summary>
        /// Delete a Employee with all  its details
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// {
        ///         "status": true,
        ///         "message": "Success",
        ///         "result": [
        ///         {
        ///         
        ///         "phoneNo":"Employee Phone Number",
        ///         "email":"Employee Email",
        ///         "score":"Employee Score",
        ///         "departmentId":"Employee Department ID"
        ///         }
        ///      ]
        ///  }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>returns an empty array</returns>
        ///  <response code ="200">Successfully Deleted the Employee</response>

        ///  <response code ="404">Employee Not Found</response>

        ///  <response code ="500">InternalServerError</response>



        [HttpDelete("{id}")]
        
        [SwaggerOperation(Summary = "Delete a Employee By Id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
     
        public IActionResult RemoveEmployee(int id)
        {
            return TryExecuteAndWrap(() =>

            {
                _logger.LogInformation("Deleting a Employee");
                return _employeeService.Remove(id); },

            result => { return Ok(result); },

            e => { return e; },

            onError => { return Forbid(onError.Message); });

        }




        ///GET BY ID
        ///api/v1/employee
        /// <summary>
        /// Getll a Employee by Id with all  its details
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///        GET BY ID
        ///        {
        ///         "name":"Employee Name",
        ///        "phoneNo":"Employee Phone Number",
        ///        "email":"Employee Email",
        ///        "score":"Employee Score",
        ///        "departmentId":"Employee Department ID"
        ///        }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Lists a Employee</returns>
        ///  <response code ="200">Successfully Got the Employee</response>

        ///  <response code ="404">Employee Not Found</response>

        ///  <response code ="500">InternalServerError</response>

        [HttpGet("{id}")]
        
        [SwaggerOperation(Summary = "Get a Employee By Id")]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        
        public IActionResult GetEmployeeById(int id)
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Getting a Employee By Id");
                return _employeeService.GetByEmployeeId(id);
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