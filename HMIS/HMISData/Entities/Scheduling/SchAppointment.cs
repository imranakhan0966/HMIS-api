using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.Scheduling
{
    public class SchAppointment
    {
        public long? AppId { get; set; }
        public long ProviderId { get; set; }
        public string MRNo { get; set; }
        public DateTime AppDateTime { get; set; }
        public int Duration { get; set; }
        public string? AppNote { get; set; }
        public int SiteId { get; set; }
        public int LocationId { get; set; }
        public int? AppTypeId { get; set; }
        public int? AppCriteriaId { get; set; }
        public int AppStatusId { get; set; }
        public int PatientStatusId { get; set; }
        public long? ReferredProviderId { get; set; }
        public bool IsPatientNotified { get; set; }
        public bool IsActive { get; set; }
        public string? EnteredBy { get; set; }

        public int? VisitTypeId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime? DateTimeNotYetArrived { get; set; }
        public DateTime? DateTimeCheckIn { get; set; }
        public DateTime?  DateTimeReady { get; set; }
        public DateTime? DateTimeSeen { get; set; }
        public DateTime? DateTimeBilled { get; set; }
        public DateTime? DateTimeCheckOut { get; set; }
        public string? UserNotYetArrived { get; set; }
        public string? UserCheckIn { get; set; }
        public string? UserReady { get; set; }
        public string? UserSeen { get; set; }
        public string? UserBilled { get; set; }
        public string? UserCheckOut { get; set; }
        public string? PurposeOfVisit { get; set; }
        public bool UpdateServerTime { get; set; }
        public int? PatientNotifiedID { get; set; }
        public int?  RescheduledID { get; set; }
        public bool? ByProvider { get; set; }
        public int? SpecialtyID { get; set; }

        public long? PayerId { get; set; }
        
        public bool VisitStatusEnabled { get; set; }
        public long? Anesthesiologist { get; set; }
        public long? CPTGroupId { get; set; }
        public int? AppointmentClassification { get; set; }
        public long? OrderReferralId { get; set; } = -1;
        public string? TelemedicineURL { get; set; }
        public int? FacilityId { get; set; }
    }
}
