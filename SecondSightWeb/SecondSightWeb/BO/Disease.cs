using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre
{
    public class Disease
    {
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
    }
    public class ChieifComplainList
    {
        public int ChieifComplainId { get; set; }
        public string ChieifComplainName { get; set; }
    }
    public class ProcedureRate
    {
        public int Id { get; set; }
        public string ProcedureName { get; set; }
        public decimal Rate { get; set; }

    }
    
}
