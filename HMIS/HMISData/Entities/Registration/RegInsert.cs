using HMIS.Data.Entities.ControlPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.Registration
{
    public class RegInsert
    {
            public string? MRno { get; set; }
            public string? PersonFirstName { get; set; }
            public string? PersonMiddleName { get; set; }
            public string? PersonLastName { get; set; }
            public byte? PersonTitleId { get; set; }
            public string? PersonSocialSecurityNo { get; set; }
            public bool? VIPPatient { get; set; }
            public string? PersonSex { get; set; }
            public byte? PersonMaritalStatus { get; set; }
            public int? PersonEthnicityTypeId { get; set; }
            public DateTime? PatientBirthDate { get; set; }
            public string? PersonDriversLicenseNo { get; set; }
            public string? PersonAddress1 { get; set; }
            public string? PersonAddress2 { get; set; }
            public string? PersonZipCode { get; set; }
            public int? PersonCityId { get; set; }
            public int? PersonStateId { get; set; }
            public int? PersonCountryId { get; set; }
            public string? PersonHomePhone1 { get; set; }
            public string? PersonCellPhone { get; set; }
            public string? PersonWorkPhone1 { get; set; }
            public string? PersonFax { get; set; }
            public string? PersonEmail { get; set; }
            public byte? PatientBloodGroupId { get; set; }
            public byte[]? PatientPicture { get; set; }
            public bool? ParentType { get; set; }
            public string? ParentFirstName { get; set; }
            public string? ParentMiddleName { get; set; }
            public string? ParentLastName { get; set; }
            public string? FatherHomePhone { get; set; }
            public string? FatherCellPhone { get; set; }
            public string? FatherEmailAddress { get; set; }
            public string? MotherFirstName { get; set; }
            public string? MotherMiddleName { get; set; }
            public string? MotherLastName { get; set; }
            public string? MotherHomePhone { get; set; }
            public string? MotherCellPhone { get; set; }
            public string? MotherEmailAddress { get; set; }
            public string? NOKFirstName { get; set; }
            public string? NOKMiddleName { get; set; }
            public string? NOKLastName { get; set; }
            public byte? NOKRelationshipId { get; set; }
            public string? NOKHomePhone { get; set; }
            public string? NOKWorkPhone { get; set; }
            public string? NOKCellNo { get; set; }
            public string? NOKSocialSecurityNo { get; set; }
            public string? NOKAddress1 { get; set; }
            public string? NOKAddress2 { get; set; }
            public string? NOKZipCode { get; set; }
            public int? NOKCityId { get; set; }
            public int? NOKStateId { get; set; }
            public int? NOKCountryId { get; set; }
            public string? SpouseFirstName { get; set; }
            public string? SpouseMiddleName { get; set; }
            public string? SpouseLastName { get; set; }
            public string? SpouseSex { get; set; }
            public string? EContactFirstName { get; set; }
            public string? EContactMiddleName { get; set; }
            public string? EContactLastName { get; set; }
            public string? EContactRelationship { get; set; }
            public string? EContactHomePhone { get; set; }
            public string? EContactWorkPhone { get; set; }
            public string? EContactCellPhone { get; set; }
            public string? EContactSocialSecurityNo { get; set; }
            public string? EContactAddress1 { get; set; }
            public string? EContactAddress2 { get; set; }
            public string? EContactZipCode { get; set; }
            public int? EContactCityId { get; set; }
            public int? EContactStateId { get; set; }
            public int? EContactCountryId { get; set; }
            public DateTime? SignedDate { get; set; }
            public DateTime? ExpiryDate { get; set; }            
            public bool? IsNewPatient { get; set; }
            public string? UpdatedBy { get; set; }
            public string? PassportNo { get; set; }
            public string? PersonTempAddress1 { get; set; }
            public string? PersonTempAddress2 { get; set; }
            public string? PersonTempZipCode { get; set; }
            public int? PersonTempCityId { get; set; }
            public int? PersonTempStateId { get; set; }
            public int? PersonTempCountryId { get; set; }
            public string? PersonTempWorkPhone { get; set; }
            public string? PersonTempCellPhone { get; set; }
            public string? PersonTempFax { get; set; }
            public string? PersonTempHomePhone { get; set; }
            public string? PersonOtherAddress1 { get; set; }
            public string? PersonOtherAddress2 { get; set; }
            public string? PersonOtherZipCode { get; set; }
            public int? PersonOtherCityId { get; set; }
            public int? PersonOtherStateId { get; set; }
            public int? PersonOtherCountryId { get; set; }
            public string? PersonOtherHomePhone { get; set; }
            public string? PersonOtherCellPhone { get; set; }
            public string? PersonOtherWorkPhone { get; set; }
            public string? PersonOtherFax { get; set; }
            public string? ResidenceVisaNo { get; set; }
            public string? LaborCardNo { get; set; }
            public int? Religion { get; set; }
            public int? PrimaryLanguage { get; set; }
            public int? Nationality { get; set; }
            public string? EMPI { get; set; }
            public bool? IsReport { get; set; }
            public long? MediaChannelId { get; set; }
            public long? MediaItemId { get; set; }
            public long? TempId { get; set; }
            public string? EmiratesIDN { get; set; }
            public string? FacilityName { get; set; }
            public string? PersonNameArabic { get; set; }

        public List<RegPatientEmployer>? regPatientEmployer { get; set; }

        public List<RegAccount>? regAccount { get; set; }
        public List<RegAssignments>? regAssignments { get; set; }
    }
}
