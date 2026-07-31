using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Common.Models
{
    public class ResultT<T> : Result
    {
        public T? Data { get; }

        private ResultT(bool success, string message, T? data)
            : base(success, message)
        {
            Data = data;
        }

        public static ResultT<T> Success(T data, string message = "Operation completed successfully.")
        {
            return new ResultT<T>(true, message, data);
        }

        public static new ResultT<T> Failure(string message)
        {
            return new ResultT<T>(false, message, default);
        }
    }
}
