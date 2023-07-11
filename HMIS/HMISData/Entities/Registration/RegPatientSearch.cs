using HMIS.Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.Registration
{
    public class RegPatientSearch : ServerPaginationModel
    {

        public string? MRNo { get; set; }
        public string? FName { get; set; }
        public string? MName { get; set; }
        public string? LName { get; set; }
        public string? Address { get; set; }
        public int? Nationality { get; set; }
        public int? PersonEthnicityTypeId { get; set; }
        public string? Mobile { get; set; }
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        public int? Country { get; set; }
        public int? State { get; set; }
        public int? City { get; set; }
        public string? ZipCode { get; set; }
        public bool? IsVIPPatient { get; set; }
        public int? InsuredId { get; set; }
        public int? MediaId { get; set; }
        public int? ItemId { get; set; }
        public int? CarrierId { get; set; }















        //public int? PatientId { get; set; }

        //public string?? MRNo { get; set; }

        //public string?? PersonFirstName { get; set; }    

        //public string?? PersonLastName { get; set;}

        //public string?? PersonMiddleName { get; set; }

        //public bool?? PersonTitleId { get; set; }

        //public string?? PersonSocialSecurityNo { get; set; }

        //public string?? PersonPassportNo { get; set; }   

        //public string?? PersonSex { get; set; }

        //public string?? PersonMaritalStatus { get; set;}

        //public string?? PersonEthnicityTypeId { get; set; }

        //public DateTime? PersonBirthDate { get; set; }  

        //public string?? PersonDriversLicenseNo { get; set; }

        //public string?? PersonAddress1 { get; set; }

        //public string?? PersonAddress2 { get; set; }

        //public string?? PersonZipCode { get; set; }

        //public int?? PersonCityId { get; set;}

        //public int?? PersonStateId { get; set; }

        //public int?? PersonCountyId { get; set;}

        //public int?? PersonCountryId { get;set; }

        //public string?? PersonHomePhone1 { get; set; }

        //public string?? PersonHomePhone2 { get; set; }

        //public string?? PersonCellPhone { get; set; }

        //public string?? PersonWorkPhone1 { get; set;}

        //public string?? PersonWorkPhone2 { get;set; }

        //public string?? PersonOtherPhone { get; set; }
        //public string?? PersonFax { get; set; }
        //public string?? PersonEmail { get; set; }
        //public string?? PatientBCDCode { get; set; }
        //public DateTime PatientFirstVisitDate { get; set; }
        //public int? PatientSpecialId { get; set; }
        //public DateTime PatientSpecialDate { get; set; }
        //public DateTime PatientDeathDate { get; set; }
        //public byte? PatientBloodGroupId { get; set; }
        //public byte? PatientPicture { get; set; }
        //public bool?? ParentType { get; set; }
        //public string?? ParentFirstName { get; set; }
        //public string?? ParentMiddleName { get; set; }
        //public string?? ParentLastName { get; set; }
        //public string?? NOKFirstName { get; set; }
        //public string?? NOKMiddleName { get; set; }
        //public string?? NOKLastName { get; set; }
        //public byte? NOKRelationshipId { get; set; }
        //public string?? NOKHomePhone { get; set; }
        //public string?? NOKWorkPhone { get; set; }
        //public string?? NOKCellNo { get; set; }
        //public string?? NOKSocialSecurityNo { get; set; }
        //public string?? NOKAddress1 { get; set; }
        //public string?? NOKAddress2 { get; set; }
        //public string?? NOKZipCode { get; set; }
        //public int? NOKCityId { get; set; }
        //public int? NOKStateId { get; set; }
        //public int? NOKCountyId { get; set; }
        //public int? NOKCountryId { get; set; }
        //public string?? SpouseFirstName { get; set; }
        //public string?? SpouseMiddleName { get; set; }
        //public string?? SpouseLastName { get; set; }
        //public string?? SpouseSex { get; set; }
        //public string?? EContactFirstName { get; set; }
        //public string?? EContactMiddleName { get; set; }
        //public string?? EContactLastName { get; set; }
        //public string?? EContactRelationship { get; set; }
        //public string?? EContactHomePhone { get; set; }
        //public string?? EContactWorkPhone { get; set; }
        //public string?? EContactCellPhone { get; set; }
        //public string?? EContactSocialSecurityNo { get; set; }
        //public string?? EContactAddress1 { get; set; }
        //public string?? EContactAddress2 { get; set; }
        //public string?? EContactZipCode { get; set; }
        //public int? EContactCityId { get; set; }
        //public int? EContactStateId { get; set; }
        //public int? EContactCountyId { get; set; }
        //public int? EContactCountryId { get; set; }
        //public bool?? StudyStatus { get; set; }
        //public string?? StudyInstitution { get; set; }
        //public string?? StudyProgram { get; set; }
        //public string?? EmploymentOccupation { get; set; }
        //public byte EmploymentTypeId { get; set; }
        //public byte EmploymentStatusId { get; set; }
        //public DateTime EmploymentRetirementDate { get; set; }
        //public string?? EmploymentCompanyName { get; set; }
        //public bool?? Inactive { get; set; }
        //public string?? PersonHeight { get; set; }
        //public string?? PersonWeight { get; set; }
        //public string?? UpdatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public string?? PassportNo { get; set; }
        //public string?? ResidenceVisaNo { get; set; }
        //public string?? LaborCardNo { get; set; }
        //public DateTime PatientDeathDateandTime { get; set; }
        //public int? Religion { get; set; }
        //public int? PrimaryLanguage { get; set; }
        //public int? Nationality { get; set; }
        //public string?? OldMRNo { get; set; }
        //public string?? EMPI { get; set; }
        //public bool?? IsReport { get; set; }
        //public string?? MotherEmailAddress { get; set; }
        //public string?? FatherHomePhone { get; set; }
        //public string?? FatherCellPhone { get; set; }
        //public string?? FatherEmailAddress { get; set; }
        //public string?? MotherFirstName { get; set; }
        //public string?? MotherMiddleName { get; set; }
        //public string?? MotherLastName { get; set; }
        //public string?? MotherHomePhone { get; set; }
        //public string?? MotherCellPhone { get; set; }
        //public string?? PersonTempAddress1 { get; set; }
        //public string?? PersonTempAddress2 { get; set; }
        //public string?? PersonTempZipCode { get; set; }
        //public int? PersonTempCityId { get; set; }
        //public int? PersonTempStateId { get; set; }
        //public int? PersonTempCountryId { get; set; }
        //public string?? PersonOtherAddress1 { get; set; }
        //public string?? PersonOtherAddress2 { get; set; }
        //public string?? PersonOtherZipCode { get; set; }
        //public int? PersonOtherCityId { get; set; }
        //public int? PersonOtherStateId { get; set; }
        //public int? PersonOtherCountryId { get; set; }
        //public long CampaignId { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public long MediaChannelID { get; set; }
        //public long MediaItemID { get; set; }
        //public DateTime SignedDate { get; set; }
        //public DateTime ExpiryDate { get; set; }
        //public bool?? VIPPatient { get; set; }
        //public long TempId { get; set; }
        //public string?? AuthorizationCode { get; set; }
        //public int? MergedStatus { get; set; }
        //public string?? EmiratesIDN { get; set; }
        //public string?? FacilityName { get; set; }
        //public string?? PersonTempHomePhone { get; set; }bool??
        //public string?? PersonTempWorkPhone { get; set; }
        //public string?? PersonTempFax { get; set; }
        //public string?? PersonTempCellPhone { get; set; }
        //public string?? PersonOtherHomePhone { get; set; }
        //public string?? PersonOtherWorkPhone { get; set; }
        //public string?? PersonOtherFax { get; set; }
        //public string?? PersonOtherCellPhone { get; set; }
        //public bool?? isGPPosted { get; set; }
        //public string?? PersonNameArabic { get; set; }
        //public bool?? ExcludeFromSMSCampaign { get; set; }
        //public bool?? TempDAECampaign { get; set; }
        //public bool?? RegisteredToHIE { get; set; }
        //public bool?? TestingRegisteredToHIE { get; set; }


    }
}
