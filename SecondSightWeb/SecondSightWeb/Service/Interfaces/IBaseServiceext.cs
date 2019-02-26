using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Service.Interfaces
{
    public interface IBaseServiceext<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

    }
}
