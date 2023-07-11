using Dapper;
using HMIS.Common.ORM;
using HMIS.Data.Entities.ControlPanel;
using HMIS.Data.Entities.Scheduling;
using HMISCommon.Helpers;
using HMISData.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Services.Scheduling
{
    public class AppointmentManager
    {


        public async Task<DataSet> SearchAppointmentDB(DateTime FromDate, DateTime ToDate, int? ProviderID, int? LocationID, int? SpecialityID, int? SiteID, int? FacilityID, int? ReferredProviderId, long? PurposeOfVisitId, int? AppTypeId, int? VisitTypeId, string? LastUpdatedBy, List<int> AppStatusId, int? Page, int? Size)
        {
            try
            {





                //DataTable AppStatusIdDT = new DataTable();
                //AppStatusIdDT.Columns.Add("ID", typeof(int));

                //// Populate the DataTable with the list values
                //foreach (int id in AppStatusId)
                //{
                //    AppStatusIdDT.Rows.Add(id);
                //}


                DynamicParameters param = new DynamicParameters();
                param.Add("@FromDate", FromDate, DbType.DateTime);
                param.Add("@ToDate", ToDate, DbType.DateTime);
                param.Add("@ProviderId", ProviderID, DbType.Int64);
                param.Add("@LocationId", LocationID, DbType.Int64);
                param.Add("@SpecialityId", SpecialityID, DbType.Int64);
                param.Add("@SiteId", SiteID, DbType.Int64);
                param.Add("@FacilityID", FacilityID, DbType.Int64);

                param.Add("@ReferredProviderId", ReferredProviderId, DbType.Int64);
                param.Add("@PurposeOfVisitId", PurposeOfVisitId, DbType.Int64);
                param.Add("@AppTypeId", AppTypeId, DbType.Int64);
                param.Add("@VisitTypeId", VisitTypeId, DbType.Int64);
                param.Add("@AppTypeId", AppTypeId, DbType.Int64);
                param.Add("@LastUpdatedBy", LastUpdatedBy, DbType.String);
                //param.Add("@AppStatusIdTypeVar", AppStatusIdDT.AsTableValuedParameter("dbo.AppStatusIdTableType"));
                param.Add("@PageSize", Size, DbType.Int64);
                param.Add("@PageNumber", Page, DbType.Int64);
                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("SchAppointmentsLoad", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data found");
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }

        }

        public async Task<DataSet> GetAppointmentDetailsDB(long VisitAccountNo)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@VisitAccountNo", VisitAccountNo, DbType.Int64);


                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("PatientVisitStatusGet", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data found");
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }

        }

        public async Task<bool> InsertAppointmentDB(SchAppointment schApp)
        {

            try
            {



                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("VisitTypeId ", schApp.VisitTypeId, DbType.Int32);

                parameters.Add("AppId", schApp.AppId, DbType.Int64);


                parameters.Add("ProviderId", schApp.ProviderId, DbType.Int64);
                parameters.Add("MRNo", schApp.MRNo, DbType.String);
                parameters.Add("AppDateTime", schApp.AppDateTime, DbType.DateTime);
                parameters.Add("Duration", schApp.Duration, DbType.Int32);
                parameters.Add("AppNote", schApp.AppNote, DbType.String);
                parameters.Add("SiteId", schApp.SiteId, DbType.Int32);
                parameters.Add("LocationId", schApp.LocationId, DbType.Int32);
                parameters.Add("AppTypeId", schApp.AppTypeId, DbType.Int32);
                parameters.Add("AppCriteriaId", schApp.AppCriteriaId, DbType.Int32);
                parameters.Add("AppStatusId", schApp.AppStatusId, DbType.Int32);
                parameters.Add("PatientStatusId", schApp.PatientStatusId, DbType.Int32);
                parameters.Add("ReferredProviderId", schApp.ReferredProviderId, DbType.Int64);
                parameters.Add("IsPatientNotified", schApp.IsPatientNotified, DbType.Boolean);
                parameters.Add("IsActive", schApp.IsActive, DbType.Boolean);
                parameters.Add("EnteredBy", schApp.EnteredBy, DbType.String);
                parameters.Add("EntryDateTime", schApp.EntryDateTime, DbType.DateTime);
                parameters.Add("DateTimeNotYetArrived", schApp.DateTimeNotYetArrived, DbType.DateTime);
                parameters.Add("DateTimeCheckIn", schApp.DateTimeCheckIn, DbType.DateTime);
                parameters.Add("DateTimeReady", schApp.DateTimeReady, DbType.DateTime);
                parameters.Add("DateTimeSeen", schApp.DateTimeSeen, DbType.DateTime);
                parameters.Add("DateTimeBilled", schApp.DateTimeBilled, DbType.DateTime);
                parameters.Add("DateTimeCheckOut", schApp.DateTimeCheckOut, DbType.DateTime);
                parameters.Add("UserNotYetArrived", schApp.UserNotYetArrived, DbType.String);
                parameters.Add("UserCheckIn", schApp.UserCheckIn, DbType.String);
                parameters.Add("UserReady", schApp.UserReady, DbType.String);
                parameters.Add("UserSeen", schApp.UserSeen, DbType.String);
                parameters.Add("UserBilled", schApp.UserBilled, DbType.String);
                parameters.Add("UserCheckOut", schApp.UserCheckOut, DbType.String);
                parameters.Add("PurposeOfVisit", schApp.PurposeOfVisit, DbType.String);
                parameters.Add("UpdateServerTime", schApp.UpdateServerTime, DbType.Boolean);
                parameters.Add("PatientNotifiedID", schApp.PatientNotifiedID, DbType.Int32);
                parameters.Add("RescheduledID", schApp.RescheduledID, DbType.Int32);
                parameters.Add("ByProvider", schApp.ByProvider, DbType.Boolean);
                parameters.Add("SpecialtyID", schApp.SpecialtyID, DbType.Int32);
                parameters.Add("VisitStatusEnabled", schApp.VisitStatusEnabled, DbType.Boolean);
                parameters.Add("Anesthesiologist", schApp.Anesthesiologist, DbType.Int64);
                parameters.Add("CPTGroupId", schApp.CPTGroupId, DbType.Int64);
                parameters.Add("AppointmentClassification", schApp.AppointmentClassification, DbType.Int32);
                parameters.Add("OrderReferralId", schApp.OrderReferralId, DbType.Int64);
                parameters.Add("TelemedicineURL", schApp.TelemedicineURL, DbType.String);
                parameters.Add("FacilityId", schApp.FacilityId, DbType.Int32);
                


                bool res = await DapperHelper.ExcecuteSPByParams("[SchAppointmentInsert]", parameters);

                if (res)
                {
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return false;
        }

        public async Task<bool> UpdateAppointmentDB(SchAppointment schApp)
        {

            try
            {
              

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("AppId", schApp.AppId, DbType.Int64);
                parameters.Add("ProviderId", schApp.ProviderId, DbType.Int64);
                parameters.Add("MRNo", schApp.MRNo, DbType.String);
                parameters.Add("AppDateTime", schApp.AppDateTime, DbType.DateTime);
                parameters.Add("Duration", schApp.Duration, DbType.Int32);
                parameters.Add("AppNote", schApp.AppNote, DbType.String);
                parameters.Add("SiteId", schApp.SiteId, DbType.Int32);
                parameters.Add("LocationId", schApp.LocationId, DbType.Int32);
                parameters.Add("AppTypeId", schApp.AppTypeId, DbType.Int32);
                parameters.Add("AppCriteriaId", schApp.AppCriteriaId, DbType.Int32);
                parameters.Add("AppStatusId", schApp.AppStatusId, DbType.Int32);
                parameters.Add("PatientStatusId", schApp.PatientStatusId, DbType.Int32);
                parameters.Add("ReferredProviderId", schApp.ReferredProviderId, DbType.Int64);
                parameters.Add("IsPatientNotified", schApp.IsPatientNotified, DbType.Boolean);
                parameters.Add("IsActive", schApp.IsActive, DbType.Boolean);
                parameters.Add("EnteredBy", schApp.EnteredBy, DbType.String);
                parameters.Add("EntryDateTime", schApp.EntryDateTime, DbType.DateTime);
                parameters.Add("DateTimeNotYetArrived", schApp.DateTimeNotYetArrived, DbType.DateTime);
                parameters.Add("DateTimeCheckIn", schApp.DateTimeCheckIn, DbType.DateTime);
                parameters.Add("DateTimeReady", schApp.DateTimeReady, DbType.DateTime);
                parameters.Add("DateTimeSeen", schApp.DateTimeSeen, DbType.DateTime);
                parameters.Add("DateTimeBilled", schApp.DateTimeBilled, DbType.DateTime);
                parameters.Add("DateTimeCheckOut", schApp.DateTimeCheckOut, DbType.DateTime);
                parameters.Add("UserNotYetArrived", schApp.UserNotYetArrived, DbType.String);
                parameters.Add("UserCheckIn", schApp.UserCheckIn, DbType.String);
                parameters.Add("UserReady", schApp.UserReady, DbType.String);
                parameters.Add("UserSeen", schApp.UserSeen, DbType.String);
                parameters.Add("UserBilled", schApp.UserBilled, DbType.String);
                parameters.Add("UserCheckOut", schApp.UserCheckOut, DbType.String);
                parameters.Add("PurposeOfVisit", schApp.PurposeOfVisit, DbType.String);
                parameters.Add("UpdateServerTime", schApp.UpdateServerTime, DbType.Boolean);
                parameters.Add("PatientNotifiedID", schApp.PatientNotifiedID, DbType.Int32);
                parameters.Add("RescheduledID", schApp.RescheduledID, DbType.Int32);
                parameters.Add("ByProvider", schApp.ByProvider, DbType.Boolean);
                parameters.Add("SpecialtyID", schApp.SpecialtyID, DbType.Int32);
                parameters.Add("CPTGroupId", schApp.CPTGroupId, DbType.Int64);
                parameters.Add("TelemedicineURL", schApp.TelemedicineURL, DbType.String);

                bool res = await DapperHelper.ExcecuteSPByParams("SchAppointmentUpdate", parameters);

                if (res == true)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }




        }



        public async Task<DataSet> SearchAppointmentHistoryDB (string MRNo, int? ProviderId, int? PatientStatusId, int? AppStatusId, int? Page, int? Size, string? SortColumn, string? SortOrder)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MRNo", MRNo, DbType.String);
                param.Add("@ProviderId", ProviderId, DbType.Int64);
                param.Add("@PatientStatusId", PatientStatusId, DbType.Int64);
                param.Add("@AppStatusId", AppStatusId, DbType.Int64);
                param.Add("@Page", Page, DbType.Int64);
                param.Add("@Size", Size, DbType.Int64);
                param.Add("@SortColumn", SortColumn, DbType.String);
                param.Add("@SortOrder", SortOrder, DbType.String);


                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("[SchAppointmentHistoryMain]", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data found");
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }

        }

        public async Task<bool> CancelOrRescheduleAppointmentDB(long AppId, int AppStatusId, bool ByProvider, int RescheduledId)
        {
            try

            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@AppId", AppId, DbType.Int64);
                param.Add("@AppStatusId", AppStatusId, DbType.Int64);
                param.Add("@ByProvider", ByProvider, DbType.Boolean);
                param.Add("@RescheduledId", RescheduledId, DbType.Int64);
               


              //  DataSet ds = await DapperHelper.GetDataSetBySPWithParams("[SchAppointmentUpdateAppStatus]", param);
                bool res = await DapperHelper.ExcecuteSPByParams("SchAppointmentUpdateAppStatus", param);

                if (res == true)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<DataSet> ValidateAppointmentDB(SchAppointment sa)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@AppDateTime", sa.AppDateTime, DbType.DateTime);
                param.Add("@ProviderId", sa.ProviderId, DbType.Int64);
                param.Add("@SiteId", sa.SiteId, DbType.Int32);
                param.Add("@PayerID", sa.PayerId, DbType.Int64);
                param.Add("@MRNo", sa.MRNo, DbType.String);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("SCH_ValidateAppointmentInsertion", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("No data found");
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }

        }


    }
}
