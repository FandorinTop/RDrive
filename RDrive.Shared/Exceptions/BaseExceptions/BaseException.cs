using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.Shared.Exceptions.BaseExceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message) : base(message)
        {
        }
    }
}
