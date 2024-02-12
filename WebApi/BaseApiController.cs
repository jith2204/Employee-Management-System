using Employee_BAL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase 
    {
       
            ILogger<BaseApiController> _logger;
            public BaseApiController(ILogger<BaseApiController> logger)
            {
                _logger = logger;
            }
            public IActionResult TryExecuteAndWrap<T>(Func<T> operation, Func<ApiResult<T>, IActionResult> OnSuccess, Func<Exception, Exception> transformExceptions, Func<Exception, IActionResult> onError)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        var errors = "";
                        foreach (var modelStateKey in ModelState.Keys)
                        {
                            var modelStateVal = ModelState[modelStateKey];
                            if (modelStateVal.Errors.Count > 0)
                            {
                                errors = errors + modelStateKey + "is not valid" + "\n";
                            }
                        }
                        var errorResult = ApiResult<string>.ModelStateError(errors);
                        return BadRequest(errorResult);
                    }
                    var result = operation();
                    var apiResult = ApiResult<T>.SuccessResult(result);
                    return OnSuccess(apiResult);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error:{ex}");
                    var transformException = transformExceptions(ex);
                    var apiErrorResult = ApiResult<string>.ErrorResult(transformException);
                    if (transformException is BadInputException)
                        return BadRequest(apiErrorResult);
                    else if (transformException is DuplicateException)
                        return Conflict(apiErrorResult);
                    else if (transformException is EntityNotFoundException)
                        return NotFound(apiErrorResult);
                    else if (transformException is NoContentException)
                        return NotFound(apiErrorResult);
                    else
                        return onError(ex);
                }
            }
        }
    }


       