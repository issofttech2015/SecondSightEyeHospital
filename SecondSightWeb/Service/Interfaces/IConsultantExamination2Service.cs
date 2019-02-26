using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecondSightSouthendEyeCentre.Models;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Service.Interfaces
{
    public interface IConsultantExamination2Service : IBaseService<SecondSightSouthendEyeCentre.Models.ConsultantExamination2>, IBaseServiceext<SecondSightSouthendEyeCentre.Models.ConsultantExamination2>
    {
        Models.ConsultantExamination2 GetByPatientId(int id);
    }
}
