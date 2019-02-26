using SecondSightSouthendEyeCentre.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SecondSightSouthendEyeCentre.Data
{
    public class SecondSightDbContext: DbContext
    {
        public SecondSightDbContext(): base("name=SecondSightDbContext")
        {

        }
        public virtual DbSet<Alergy> Alergies { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<SecondSightSouthendEyeCentre.Models.CategoryMaster> CategoryMaster { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CheifComplainList> CheifComplainList { get; set; }
        public virtual DbSet<SecondSightSouthendEyeCentre.Models.ConsultantExamination1> ConsultantExamination1 { get; set; }
        public virtual DbSet<SecondSightSouthendEyeCentre.Models.ConsultantExamination2> ConsultantExamination2 { get; set; }
        public virtual DbSet<ConsultantExamination3> ConsultantExamination3 { get; set; }
        public virtual DbSet<Diseases> Diseases { get; set; }
        public virtual DbSet<SecondSightSouthendEyeCentre.Models.Medication> Medication { get; set; }
        public virtual DbSet<OTCaharges> OTCaharges { get; set; }
        public virtual DbSet<OTCahrgeCategory> OTCahrgeCategory { get; set; }
        public virtual DbSet<SecondSightSouthendEyeCentre.Models.ProcedureRate> ProcedureRate { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SystemicDisease> SystemicDisease { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<SecondSightSouthendEyeCentre.Models.Employee> Employee { get; set; }
        public virtual DbSet<EmployeeLog> EmployeeLog { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreHistory> StoreHistory { get; set; }
        public virtual DbSet<Treatement> Treatement { get; set; }
        public virtual DbSet<Sequence> Sequences { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<TreatmentDetails> TreatmentDetails { get; set; }
        public virtual DbSet<ConsultantExaminationCombine> ConsultantExaminationCombine { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<OperarionDetails> OperationDetails { get; set; }
        public virtual DbSet<BillSummery> BillSummery { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
         .Where(type => !String.IsNullOrEmpty(type.Namespace))
         .Where(type => type.BaseType != null && type.BaseType.IsGenericType
              && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            //modelBuilder.Entity<Institution>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);



        }
    }
}
