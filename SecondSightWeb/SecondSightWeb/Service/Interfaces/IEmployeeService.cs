using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondSightSouthendEyeCentre.Models;

namespace SecondSightSouthendEyeCentre.Service.Interfaces
{
    public interface IEmployeeService : IBaseService<SecondSightSouthendEyeCentre.Models.Employee>, IBaseServiceext<SecondSightSouthendEyeCentre.Models.Employee>
    {
    }
}
