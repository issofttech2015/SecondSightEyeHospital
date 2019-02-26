﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateofBirth { get; set; }

        public string Nationality { get; set; }

        public int? Age { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal Contact { get; set; }

        public string ResidanceAddress { get; set; }

        public string Email { get; set; }

        public string GuardianFirstName { get; set; }

        public string GuardianLastName { get; set; }

        public string GuardianContact { get; set; }

        public string GuardianRelateAs { get; set; }

        public string Ocupation { get; set; }
        public string PatCode { get; set; } = string.Empty;
        public Decimal Adhar { get; set; }
        public string Pat_Image { get; set; } = string.Empty;
        public int Month { get; set; } = 0;

    }


}