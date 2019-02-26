using SecondSightSouthendEyeCentre.Models;
using SecondSightWeb.Models;
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
    public class SecondSightDbContext : DbContext
    {
        public SecondSightDbContext() : base("name=SecondSightDbContext")
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
        public virtual DbSet<OTCharges> OTCaharges { get; set; }
        public virtual DbSet<OTChargeCategory> OTCahrgeCategory { get; set; }
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
        public virtual DbSet<BillDetails> BillDetails { get; set; }
        public virtual DbSet<ExaminationDrops> ExaminationDrops { get; set; }
        public virtual DbSet<DossList> DossLists { get; set; }
        public virtual DbSet<MedicineList> MedicineList { get; set; }
        public virtual DbSet<SuggestedTests> SuggestedTests { get; set; }
        public virtual DbSet<TestMaster> TestMaster { get; set; }
        public virtual DbSet<MedicineTypeList> MedicineTypeList { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderDetails> PurchaseDetails { get; set; }
        public virtual DbSet<PaymentDetalis> PaymentDetalis { get; set; }
        public virtual DbSet<OperationSuggestion> OperationSuggestions { get; set; }
        public virtual DbSet<OtCheckList> OtCheckLists { get; set; }
        public virtual DbSet<OperationCheckListDetails> OtOperationCheckListDetails { get; set; }
        public virtual DbSet<Injectables> Injectables { get; set; }
        public virtual DbSet<Miscellaneous> Miscellaneous { get; set; }
        public virtual DbSet<Disposables> Disposables { get; set; }
        public virtual DbSet<Knives> Knives { get; set; }
        public virtual DbSet<Tablets> Tablets { get; set; }
        public virtual DbSet<SurgicalInjectableConsumptionList> SurgicalInjectableConsumptionList { get; set; }
        public virtual DbSet<SurgicalDropsConsumptionList> SurgicalDropsConsumptionList { get; set; }
        public virtual DbSet<SurgicalDisposablesConsumptionList> SurgicalDisposablesConsumptionList { get; set; }
        public virtual DbSet<SurgicalKnivesConsumptionList> SurgicalKnivesConsumptionList { get; set; }
        public virtual DbSet<SurgicalMiscellaneousConsumptionList> SurgicalMiscellaneousConsumptionList { get; set; }
        public virtual DbSet<SurgicalTabletsConsumptionList> SurgicalTabletsConsumptionList { get; set; }
        public virtual DbSet<DischargeDetails> DischargeDetails { get; set; }
        public virtual DbSet<ForgotPasswordDetails> ForgotPasswordDetails { get; set; }
        public virtual DbSet<DoctorExaminationPupil> DoctorExaminationPupil { get; set; }
        public virtual DbSet<DoctorExaminationLens> DoctorExaminationLens { get; set; }
        public virtual DbSet<DoctorExaminationIris> DoctorExaminationIris { get; set; }
        public virtual DbSet<DoctorExaminationGlassPrescription> DoctorExaminationGlassPrescription { get; set; }
        public virtual DbSet<DoctorExaminationFollowUp> DoctorExaminationFollowUp { get; set; }
        public virtual DbSet<DoctorExaminationDiagnosis> DoctorExaminationDiagnosis { get; set; }
        public virtual DbSet<DoctorExaminationConjuctiva> DoctorExaminationConjuctiva { get; set; }
        public virtual DbSet<DoctorExaminationCornea> DoctorExaminationCornea { get; set; }
        public virtual DbSet<DoctorExaminationIntraOcularPressure> DoctorExaminationIntraOcularPressure { get; set; }
        public virtual DbSet<DoctorExaminationCombine> DoctorExaminationCombine { get; set; }
        public virtual DbSet<PastMedicalHistory> PastMedicalHistory { get; set; }        
        public virtual DbSet<MainComplaints> MainComplaints { get; set; }
        public virtual DbSet<PastOcularHistory> PastOcularHistory { get; set; }
        public virtual DbSet<DoctorExaminationGonioscopy> DoctorExaminationGonioscopy { get; set; }
        public virtual DbSet<DoctorExaminationOcularAlignment> DoctorExaminationOcularAlignment { get; set; }
        public virtual DbSet<DoctorExaminationOculerMovement> DoctorExaminationOculerMovement { get; set; }
        public virtual DbSet<DoctorExaminationVitreous> DoctorExaminationVitreous { get; set; }
        public virtual DbSet<DoctorExaminationFundus> DoctorExaminationFundus { get; set; }
        public virtual DbSet<RefundBill> RefundBill { get; set; }
        public virtual DbSet<RefundBillDetails> RefundBillDetails { get; set; }
        public virtual DbSet<DossListSummary> DossListSummary { get; set; }
        public virtual DbSet<DiseasesByDoctor> DiseasesByDoctor { get; set; }
        public virtual DbSet<CheifComplainByDoctor> CheifComplainByDoctor { get; set; }
        
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
            Database.SetInitializer<SecondSightDbContext>(null);
            //modelBuilder.Entity<Institution>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);
        }

    }
}
