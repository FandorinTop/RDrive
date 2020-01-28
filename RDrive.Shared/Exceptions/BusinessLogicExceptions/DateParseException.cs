using System;
using System.Collections.Generic;
using System.Text;
using RDrive.Shared.Exceptions.BaseExceptions;

namespace RDrive.Shared.Exceptions.BusinessLogicExceptions
{
    
    public class DateParseException : BaseException
    {
        public DateParseException(string message) : base(message)
        {
        }
    }
}
