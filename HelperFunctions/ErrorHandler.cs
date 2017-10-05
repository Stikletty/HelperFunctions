using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace HelperFunctions
{
    public class ErrorHandler
    {
        public string ErrorHandlerByNumber(int pErrorNumber)
        {

            string errorMessage = new Win32Exception(pErrorNumber).Message;
            return errorMessage;
        }

        public string GetLastErrorHandler()
        {
            string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
            return errorMessage;
        }
    }
}
