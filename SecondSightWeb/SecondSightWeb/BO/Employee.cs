using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddeleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Natationality { get; set; }
        public int Age { get; set; }
        public decimal Contact { get; set; }
        public string  Qualification { get; set; }
        public int DepartmentId { get; set; }
        public string Designation { get; set; }
        public string ResidanceAddress { get; set; }
        public DateTime DateofJoin { get; set; }
        public string Email { get; set; }
        public string RefrenceName { get; set; }
        public decimal RefrenceContact { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public int RoleId { get; set; }
    }
    public class EmployeeShortInfo
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
