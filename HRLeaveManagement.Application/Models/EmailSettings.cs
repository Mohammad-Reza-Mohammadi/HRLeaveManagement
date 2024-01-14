using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Models
{
    public class EmailSettings
    {
        public EmilNetworkCredential MyProperty { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSl { get; set; }
    }
    
    public class EmilNetworkCredential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
