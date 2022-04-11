using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidationException: Exception
    {
        public int? Code { get; set; }
        public ValidationException(string message, int? code = null): base(message)
        {
            Code = code;
        }
    }
}
