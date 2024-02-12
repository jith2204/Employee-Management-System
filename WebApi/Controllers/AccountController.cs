using Employee_BAL.Interfaces;
using Employee_BAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/v1/account")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        IAccountService _accountService;
        ILogger<AccountController> _logger;
        public AccountController(IAccountService accountService, ILogger<AccountController> logger) : base(logger)
        {
            _logger = logger;
            _accountService = accountService;
        }

        ///LOGIN
        ///api/v1/account
        /// <summary>
        /// Login into Account
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///        
        ///        {
        ///        "userName":"Registered Username",
        ///        "password":"Registered Password",
        ///       
        ///        }
        /// </remarks>
        /// <param name="loginCredentials"></param>
        /// <returns>one credential account is logged in</returns>
        ///  <response code ="200"> Successfully logged in </response>
        ///  <response code ="400"> BadRequest </response>
        ///  <response code ="404"> Email or Password Not Found </response>
        ///  <response code ="500"> InternalServerError </response>
        [HttpPost("login")]
        [SwaggerOperation(Summary = "Login in Different Role Accounts")]
        public IActionResult LogIn([FromBody] AccountModel loginCredentials)
        {
            return TryExecuteAndWrap(() =>
            {
                _logger.LogInformation("Logging in Credentials");
                return _accountService.Login(loginCredentials);
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
