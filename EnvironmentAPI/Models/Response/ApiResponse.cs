using EnvironmentServices.ServiceResult;

namespace EnvironmentAPI.Models.Response
{
    public class ApiResponse<T>
    {
        public ApiResponse() { }
        public ApiResponse(ServiceResult<T> serviceResult)
        {
            Data = serviceResult.Data;
            Succeeded = serviceResult.Succeeded;
            ErrorMessage = serviceResult.ErrorMessage;
        }

        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public static ApiResponse<T> Fail(string errorMessage)
        {
            return new ApiResponse<T> { Succeeded = false, ErrorMessage = errorMessage };
        }
        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T> { Succeeded = true, Data = data };
        }
    }
}
