using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class BussinessException : Exception
    {
        public int ExceptionId;
        public string ExceptionDetails { get; set; }

        public ApplicationMessage AppMessage { get; set; }
    
        public BussinessException()
        {

        }

        public BussinessException(int exceptionId)
        {
            ExceptionId = exceptionId;
        }

        public BussinessException(int exceptionId, Exception innerException)
        {
            ExceptionId = exceptionId;
            ExceptionDetails = innerException.Message;
        }
    }
}
