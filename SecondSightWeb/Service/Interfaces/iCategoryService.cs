using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecondSightSouthendEyeCentre.Models;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Service.Interfaces
{
    public interface ICategoryService : IBaseService<Category>, IBaseServiceext<Category>
    {
        IEnumerable<Category> GetCategoryByMaster(int id);
        IEnumerable<Category> GetCategoryByName(string name);

    }
}
