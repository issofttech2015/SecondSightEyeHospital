using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Service.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        bool Delete(T entity);

    }
}
