using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Exeptions
{
    public class BadRequestEception : ApplicationException
    {
        public BadRequestEception(string message) : base(message)
        {
            
        }
    }
}
