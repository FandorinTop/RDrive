using System;
using System.Collections.Generic;
using System.Text;
using RDrive.Shared.Exceptions.BaseExceptions;

namespace RDrive.Shared.Exceptions.BusinessLogicExceptions
{
    public class AdminException : BaseException
    {
        public AdminException(string message) : base(message)
        {
        }
    }
}
