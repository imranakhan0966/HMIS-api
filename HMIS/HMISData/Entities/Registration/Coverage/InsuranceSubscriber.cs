using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.Registration.Coverage
{
    public class InsuranceSubscriber
    {
        public long SubscriberID { get; set; }
        public int CarrierId { get; set; }
        public string InsuredIDNo { get; set; }
        public string InsuranceTypeCode { get; set; }
        public string InsuredGroupOrPolicyNo { get; set; }
        public string InsuredGroupOrPolicyName { get; set; }
        public byte CompanyOrIndividual { get; set; }
        //public string EffectiveDate { get; set; }
        //public string TerminationDate { get; set; }
        public decimal Copay { get; set; }
        public string Suffix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
       // public string Weight { get; set; }
        public string InsuredPhone { get; set; }
        public string OtherPhone { get; set; }
       // public string SSN { get; set; }
       // public string EmployerOrSchoolName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public bool Inactive { get; set; }
        public string EnteredBy { get; set; }
     //   public string EntryDate { get; set; }
        public bool Verified { get; set; }
        public bool ChkDeductible { get; set; }
        public decimal? Deductibles { get; set; }
        public decimal? DNDeductible { get; set; }
        public decimal? OpCopay { get; set; }
        // public long PayerPackageId { get; set; }

        public string? MRNo { get; set; }
        public Byte? CoverageOrder { get; set; }
        public bool? IsSelected { get; set; }

        public bool? PackageId { get; set; }
        
        public List<InsurancePolicy>? regInsurancePolicy { get; set; }

        public List<Deduct>? regDeduct { get; set; }

        public byte[] Image { get; set; }


    }


}
