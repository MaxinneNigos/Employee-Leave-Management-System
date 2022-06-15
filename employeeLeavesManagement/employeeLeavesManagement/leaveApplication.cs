using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeLeaveManagement
{
    internal class leaveApplication
    {
        public string name { get; set; }
        public string EmployeeIDNumber { get; set; }
        public string Birthday { get; set; }
        public string LeaveDay { get; set; }
        public string Reason { get; set; }

        public static List<string> LeaveType = new List<string>()
        {"Sick Leave", "Vacation Leave"};
    }
}