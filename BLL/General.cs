using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public static class General
    {
        public static class Notify
        {
            public static int InsertSuccess = 1;
            public static int UpdateSuccess = 2;
            public static int DeleteSuccess = 3;
            public static int EmptyData = 4;
            public static int UpdateFail = 5;
            public static int InvalidPhoneNumber = 6;
        }

        public static class ProcessType
        {
            public static int View = 1;
        }
        public static bool IsPhoneNumber(int? number)
        {
            return Regex.Match(number.ToString(), @"^(\+[0-9]{9})$").Success;
        }
    }
}
