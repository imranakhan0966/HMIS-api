﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.Registration
{
    public class RegTempPatient
    {
    
            public long TempId { get; set; }
            public byte? PersonTitleId { get; set; }
            public int? PersonNationalityId { get; set; }
            public string PersonFirstName { get; set; }
            public string PersonMiddleName { get; set; }
            public string PersonLastName { get; set; }
            public string PersonSex { get; set; }
            public int? PersonAge { get; set; }
            public string PersonCellPhone { get; set; }
            public string PersonAddress1 { get; set; }
            public string PersonAddress2 { get; set; }
            public int? PersonCountryId { get; set; }
            public int? PersonStateId { get; set; }
            public int? PersonCityId { get; set; }
            public string PersonZipCode { get; set; }
            public string PersonHomePhone1 { get; set; }
            public string PersonWorkPhone1 { get; set; }
            public string PersonEmail { get; set; }
            public string NOKFirstName { get; set; }
            public string NOKMiddleName { get; set; }
            public string NOKLastName { get; set; }
            public byte? NOKRelationshipId { get; set; }
            public string NOKHomePhone { get; set; }
            public string NOKWorkPhone { get; set; }
            public string NOKCellNo { get; set; }
            public string NOKSocialSecurityNo { get; set; }
            public string NOKAddress1 { get; set; }
            public string NOKAddress2 { get; set; }
            public int? NOKCountryId { get; set; }
            public int? NOKStateId { get; set; }
            public int? NOKCityId { get; set; }
            public string NOKZipCode { get; set; }
            public string Comments { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
            public bool? Active { get; set; }
            public DateTime PatientBirthDate { get; set; }


    }
}
