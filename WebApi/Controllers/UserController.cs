using Employee_BAL.Interfaces;
using Employee_BAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/v1/user")]
    [ApiController]

    public class UserController : BaseApiController
    {
        IUserRegisterService _userService;
        ILogger<UserController> _logger;
        IRoleService _roleService;
        public UserController(IRoleService roleService, IUserRegisterService userRegisterService, ILogger<UserController> logger) : base(logger)
        {
            _userService = userRegisterService;
            _logger = logger;
            _roleService = roleService;
        }

        ///REGISTER
        ///api/v1/user
        /// <summary>
        /// Create an Employee Account
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///        
        ///        {
        ///        "userName":"Register the Username",
        ///        "password":"Register the Password",
        ///       
        ///        }
        /// </remarks>
        /// <param name="addCredentials"></param>
        /// <returns>one employee credential is registered</returns>
        ///  <response code ="200">Successfully added a Employee Credential</response>
        ///  <response code ="400">BadRequest</response>
        ///  <response code ="409">Username Already Exist</response>
        ///  <response code ="500">InternalServerError</response>

        [HttpPost("register")]
        [SwaggerOperation(Summary = "Register an Account")]

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult RegisterCredentials([FromBody]UserRegisterModel addCredentials)
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Registering Account");
                return _userService.Register(addCredentials);
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

        [HttpGet("roles")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Get All Roles")]
        public IActionResult GetAllRole()
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Getting All Roles");
                return _roleService.GetAll();
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
