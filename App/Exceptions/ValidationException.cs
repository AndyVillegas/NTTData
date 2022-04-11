using System;

namespace App.Exceptions
{
    public class ValidationException : Exception
    {
        public int Code { get; set; }
        public ValidationException(string message, int code = 0) : base(message) 
        {
            Code = code;
        }
    }
}
