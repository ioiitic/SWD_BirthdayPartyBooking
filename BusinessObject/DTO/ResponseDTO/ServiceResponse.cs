using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.ResponseDTO
{
    public class ServiceResponse<T> where T : class
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
        public T Data { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public ServiceResponse() {}
        public ServiceResponse(T data)
        {
            Data = data;
        }

        public ServiceResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ServiceResponse(bool success, string message, Dictionary<string, List<string>> errors)
        {
            Success = success;
            Message = message;
            Errors = errors;
        }
    }
}
