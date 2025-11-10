using EnvironmentRepository.Models.Dynamic;

namespace EnvironmentServices.ServiceResult
{
    public class ServiceResult<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; } = false;
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Error { get; set; }
    }

    public class ServiceResultData<T>
    {
        public T MainData { get; set; }
        public List<VeriListesi> FieldData { get; set; }
    }
}
