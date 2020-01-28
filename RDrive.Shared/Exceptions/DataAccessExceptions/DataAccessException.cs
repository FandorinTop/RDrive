using RDrive.Shared.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.Shared.Exceptions.DataAccessExceptions
{
    public class DataAccessException : BaseException
    {
        public DataAccessException(string message) : base(message)
        {
        }
    }
}
