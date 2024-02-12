namespace WebApi
{
    public class ApiResult<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public static ApiResult<T> SuccessResult(T result, string message = "Success")
        {
            var apiResult = new ApiResult<T>();
            apiResult.Message = message;
            apiResult.Result = result;
            apiResult.Status = true;
            return apiResult;
        }
        public static ApiResult<string> ErrorResult(Exception ex)
        {
            var apiResult = new ApiResult<string>();
            apiResult.Message = ex.Message;
            apiResult.Result = null;
            apiResult.Status = false;
            return apiResult;
        }
        public static ApiResult<string> ModelStateError(string error)
        {
            var apiResult = new ApiResult<string>();
            apiResult.Message = error;
            apiResult.Result = null;
            apiResult.Status = false;
            return apiResult;
        }
    }
}


