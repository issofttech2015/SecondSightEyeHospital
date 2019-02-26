using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class CheifComplainList
    {
        [Key]
        public int Id { get; set; }

        public string CompalainName { get; set; }

    }

}
