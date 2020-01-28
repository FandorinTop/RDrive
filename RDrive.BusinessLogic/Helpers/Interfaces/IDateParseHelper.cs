using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.BusinessLogic.Helpers.Interfaces
{
    public interface IDateParseHelper
    {
        DateTime? ParseStringToOnlyYearDatetime(string stringDate);
        string ParseDateToString(DateTime dateTimeValue);
        DateTime ParseStringToDatetime(string stringDate);
        string ParseStringToDatetimeToString(string dateForParsing);
    }
}
