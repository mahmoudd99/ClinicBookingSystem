using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Common.Models
{

    public class Result
    {
        public bool Success { get; }

        public string Message { get; }

        protected Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static Result SuccessResult(string message = "Operation completed successfully.")
        {
            return new Result(true, message);
        }

        public static Result Failure(string message)
        {
            return new Result(false, message);
        }
    }




}
