using System;

namespace SecondSightSouthendEyeCentre
{
    public class Patitent
    {
        public int PatitentId { get; set; }
        public string FirstName { get; set; }
        public string MiddeleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Natationality { get; set; }
        public int Age { get; set; }
        public decimal Contact { get; set; }
        public string ResidanceAddress { get; set; }
        public string Email { get; set; }
        public string GuardianFirstName { get; set; }
        public string GuardianLastName { get; set; }
        public string GuardianContact { get; set; }
        public string  GuardianRelateAs { get; set; }
        public string  Ocupation { get; set; }
        public string PatCode { get; set; }
        public string Adhar { get; set; }
        public string Pat_Image { get; set; } = string.Empty;
        public int Month { get; set; } = 0;
    }
    public class PatientShortInfo
    {
        public int PatitentId { get; set; }
        public string FirstName { get; set; }
        public string MiddeleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Age { get; set; }
        public decimal Contact { get; set; }

    }
}