using Dapper;
using HMIS.Common.ORM;
using HMIS.Data.Entities.Registration;
using HMIS.Data.Entities.Registration.Coverage;
using HMISCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using GdPicture14;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HMIS.Services.Registration
{
    public class CoveragesManager
    {
        public async Task<DataSet> GetSearchDB(Byte? CompanyOrIndividual, string? LastName, string? SSN, string? InsuredIDNo, string? MRNo, int PageNumber, int PageSize)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CompanyOrIndividual", CompanyOrIndividual, DbType.Int16);
                param.Add("@LastName", LastName, DbType.String);
                param.Add("@SSN", SSN, DbType.String);
                param.Add("@InsuredIDNo", InsuredIDNo, DbType.String);
                param.Add("@MRNo", MRNo, DbType.String);
                param.Add("@PageNumber", PageNumber, DbType.Int32);
                param.Add("@PageSize", PageSize, DbType.Int32);


                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("REG_InsuredSubscriberGet", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return new DataSet();
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }
        }

        public async Task<DataSet> GetBLEligibilityLogsDB(string? MRNo, long? VisitAccountNo, int? EligibilityId, int? ELStatusId, string? MessageRequestDate, string? MessageResponseDate)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MRNo", MRNo);
                param.Add("@VisitAccountNo", VisitAccountNo);
                param.Add("@EligibilityId", EligibilityId);
                param.Add("@ELStatusId", ELStatusId);
                param.Add("@MessageRequestDate", MessageRequestDate);
                param.Add("@MessageResponseDate", MessageResponseDate);



                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("REG_GetBLEligibilityLogs", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return new DataSet();
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }
        }

        public async Task<DataSet> GetSubcriberDetailsDB(string InsuredIDNo)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@InsuredIDNo", InsuredIDNo, DbType.String);
                param.Add("@SubscriberId", SqlDbType.BigInt, (DbType?)ParameterDirection.Output);



                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("REG_GetInsuredSubscriberDetail", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return new DataSet();
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }
        }

        public async Task<DataSet> GetCoverageDB(string MRNo)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@MRNo", MRNo, DbType.String);

                DataSet ds = await DapperHelper.GetDataSetBySPWithParams("REG_InsuredCoverageGet", param);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return new DataSet();
                }

                return ds;
            }
            catch (Exception ex)
            {
                return new DataSet();
            }
        }

        public async Task<string> InsertSubscriberDB(InsuranceSubscriber regInsert)
        {
            try

            {
                DataTable RegInsurancePolicyDT = ConversionHelper.ToDataTable(regInsert.regInsurancePolicy);

                DataTable RegDeductDT = ConversionHelper.ToDataTable(regInsert.regDeduct);


                DynamicParameters parameters = new DynamicParameters();

             //   parameters.Add("@SubscriberId", SqlDbType.BigInt, (DbType?)ParameterDirection.Output);

                parameters.Add("@CarrierId", regInsert.CarrierId, DbType.Int32);
                parameters.Add("@InsuredIDNo", regInsert.InsuredIDNo, DbType.String);
                parameters.Add("@InsuredGroupOrPolicyNo", regInsert.InsuredGroupOrPolicyNo, DbType.String);
                parameters.Add("@InsuredGroupOrPolicyName", regInsert.InsuredGroupOrPolicyName, DbType.String);
                parameters.Add("@CompanyOrIndividual", regInsert.CompanyOrIndividual, DbType.Byte);
                parameters.Add("@Copay", regInsert.Copay, DbType.Decimal);
                parameters.Add("@Suffix", regInsert.Suffix, DbType.String);
                parameters.Add("@FirstName", regInsert.FirstName, DbType.String);
                parameters.Add("@MiddleName", regInsert.MiddleName, DbType.String);
                parameters.Add("@LastName", regInsert.LastName, DbType.String);
                parameters.Add("@BirthDate", regInsert.BirthDate, DbType.DateTime);
                parameters.Add("@Sex", regInsert.Sex, DbType.String);
                parameters.Add("@InsuredPhone", regInsert.InsuredPhone, DbType.String);
                parameters.Add("@OtherPhone", regInsert.OtherPhone, DbType.String);
                parameters.Add("@Address1", regInsert.Address1, DbType.String);
                parameters.Add("@Address2", regInsert.Address2, DbType.String);
                parameters.Add("@ZipCode", regInsert.ZipCode, DbType.String);
                parameters.Add("@CityId", regInsert.CityId, DbType.Int32);
                parameters.Add("@StateId", regInsert.StateId, DbType.Int32);
                parameters.Add("@CountryId", regInsert.CountryId, DbType.Int32);
                parameters.Add("@Inactive", regInsert.Inactive, DbType.Boolean);
                parameters.Add("@EnteredBy", regInsert.EnteredBy, DbType.String);
                parameters.Add("@Verified", regInsert.Verified, DbType.Boolean);
                parameters.Add("@ChkDeductible", regInsert.ChkDeductible, DbType.Boolean);
                parameters.Add("@Deductibles", regInsert.Deductibles, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("@DNDeductible", regInsert.DNDeductible, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("@OpCopay", regInsert.OpCopay, DbType.Decimal, ParameterDirection.Input);

                parameters.Add("@MRNo", regInsert.MRNo, DbType.String);
                parameters.Add("@CoverageOrder", regInsert.CoverageOrder, DbType.Byte);
                parameters.Add("@IsSelected", regInsert.IsSelected, DbType.Boolean);


                parameters.Add("@RegInsurancePolicyTypeVar", RegInsurancePolicyDT, DbType.Object);
                parameters.Add("@RegDeductTypeVar", RegDeductDT, DbType.Object);




                bool res = await DapperHelper.ExcecuteSPByParams("REG_InsuredSubscriberInsert", parameters);


                try
                {
                    string connectionString = "Server=51.79.209.55;Initial Catalog=CohrentUpgrade;user id=cohrentupgrade;password=cohrentupgrade;Encrypt=True;TrustServerCertificate=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string insertQuery = "INSERT INTO InsuranceEligibility (VisitAccountNo, PatientName,InsuranceMemberID, EffectiveDate, ExpiryDate, Image,PolicyNumber, BlPayerId,PackageName,PackageID,CreatedBy,CreatedOn) " +
                         "VALUES (@VisitAccountNo, @PatientName, @InsuranceMemberID, @EffectiveDate, @ExpiryDate, @Image,@PolicyNumber, @BlPayerId,@PackageName,@PackageID,@CreatedBy,@CreatedOn)";

                        int VisitAccountNo = 0;
                        if (regInsert.MRNo == "1006")
                        {
                            VisitAccountNo = 92638;

                        }
                        if (regInsert.MRNo == "1703")
                        {
                            VisitAccountNo = 103827;
                        }
                        if (regInsert.MRNo == "1016")
                        {
                            VisitAccountNo = 92432;
                        }

                        
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@VisitAccountNo", VisitAccountNo);
                            command.Parameters.AddWithValue("@PatientName", ((object)regInsert.FirstName) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@InsuranceMemberID", ((object)regInsert.InsuredIDNo) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@EffectiveDate", ((object)regInsert.regInsurancePolicy[0].EffectiveDate) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@ExpiryDate", ((object)regInsert.regInsurancePolicy[0].TerminationDate) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Image", ((object)regInsert.Image) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@PolicyNumber", ((object)regInsert.InsuredGroupOrPolicyNo) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@BlPayerId", ((object)regInsert.CarrierId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@PackageName", ((object)regInsert.InsuredGroupOrPolicyName) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@PackageID", ((object)regInsert.PackageId) ?? DBNull.Value);
                            command.Parameters.AddWithValue("@CreatedBy", regInsert.EnteredBy);
                            command.Parameters.AddWithValue("@CreatedOn", DateTime.Now.ToString());
                            int rowsAffected = await command.ExecuteNonQueryAsync();


                            //if (rowsAffected == 1)
                            //{
                            //    gdpictureImaging.ReleaseGdPictureImage(imageId);
                            //    gdpictureOCR.ReleaseOCRResults();
                            //    return model;
                            //}
                            //else
                            //{
                            //    model.Message = "Not Inserted";
                            //    return model;
                            //}
                        }
                        connection.Close();


                    }

                }
                catch (Exception ex)
                {
                    // Handle the exception
                    var exception = ex;
                    throw ex;
                }



                if (res == true)
                {
                    return "OK";
                }

                return string.Empty;
            }
            catch (Exception ex)
            {

                return (ex.Message);
            }
        }

        public async Task<string> UpdateSubscriberDB(InsuranceSubscriber regUpdate)
        {
            try

            {
                DataTable RegInsurancePolicyDT = ConversionHelper.ToDataTable(regUpdate.regInsurancePolicy);

                DataTable RegDeductDT = ConversionHelper.ToDataTable(regUpdate.regDeduct);


                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@SubscriberId", regUpdate.SubscriberID, DbType.Int64);

                parameters.Add("@CarrierId", regUpdate.CarrierId, DbType.Int32);
                parameters.Add("@InsuredIDNo", regUpdate.InsuredIDNo, DbType.String);
                parameters.Add("@InsuredGroupOrPolicyNo", regUpdate.InsuredGroupOrPolicyNo, DbType.String);
                parameters.Add("@InsuredGroupOrPolicyName", regUpdate.InsuredGroupOrPolicyName, DbType.String);
                parameters.Add("@CompanyOrIndividual", regUpdate.CompanyOrIndividual, DbType.Byte);
                parameters.Add("@Copay", regUpdate.Copay, DbType.Decimal);
                parameters.Add("@Suffix", regUpdate.Suffix, DbType.String);
                parameters.Add("@FirstName", regUpdate.FirstName, DbType.String);
                parameters.Add("@MiddleName", regUpdate.MiddleName, DbType.String);
                parameters.Add("@LastName", regUpdate.LastName, DbType.String);
                parameters.Add("@BirthDate", regUpdate.BirthDate, DbType.DateTime);
                parameters.Add("@Sex", regUpdate.Sex, DbType.String);
                parameters.Add("@InsuredPhone", regUpdate.InsuredPhone, DbType.String);
                parameters.Add("@OtherPhone", regUpdate.OtherPhone, DbType.String);
                parameters.Add("@Address1", regUpdate.Address1, DbType.String);
                parameters.Add("@Address2", regUpdate.Address2, DbType.String);
                parameters.Add("@ZipCode", regUpdate.ZipCode, DbType.String);
                parameters.Add("@CityId", regUpdate.CityId, DbType.Int32);
                parameters.Add("@StateId", regUpdate.StateId, DbType.Int32);
                parameters.Add("@CountryId", regUpdate.CountryId, DbType.Int32);
                parameters.Add("@Inactive", regUpdate.Inactive, DbType.Boolean);
                parameters.Add("@EnteredBy", regUpdate.EnteredBy, DbType.String);
                parameters.Add("@Verified", regUpdate.Verified, DbType.Boolean);
                parameters.Add("@ChkDeductible", regUpdate.ChkDeductible, DbType.Boolean);
                parameters.Add("@Deductibles", regUpdate.Deductibles, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("@DNDeductible", regUpdate.DNDeductible, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("@OpCopay", regUpdate.OpCopay, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("@MRNo", regUpdate.MRNo, DbType.String);
                parameters.Add("@CoverageOrder", regUpdate.CoverageOrder, DbType.Byte);
                parameters.Add("@IsSelected", regUpdate.IsSelected, DbType.Boolean);

                parameters.Add("@RegInsurancePolicyTypeVar", RegInsurancePolicyDT, DbType.Object);
                parameters.Add("@RegDeductTypeVar", RegDeductDT, DbType.Object);




                bool res = await DapperHelper.ExcecuteSPByParams("REG_InsuredSubscriberUpdate", parameters);

                if (res == true)
                {
                    return "OK";
                }

                return string.Empty;
            }
            catch (Exception ex)
            {

                return (ex.Message);
            }
        }

        public async Task<InsurenceEligibility> ReadImage(IFormFile imageFile, long PayerId)
        {
            try

            {

                string connectionString = "Server=51.79.209.55;Initial Catalog=CohrentUpgrade;user id=cohrentupgrade;password=cohrentupgrade;Encrypt=True;TrustServerCertificate=True;";
                var tempFilePath = Path.GetTempFileName();
                using (var fileStream = new FileStream(tempFilePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
                byte[] imageData;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    imageData = memoryStream.ToArray();
                }
                using (GdPictureOCR gdpictureOCR = new GdPictureOCR())
                using (GdPictureImaging gdpictureImaging = new GdPictureImaging())
                {
                    int imageId = gdpictureImaging.CreateGdPictureImageFromFile(tempFilePath);
                    gdpictureOCR.ResourceFolder = @"C:\GdPicture.NET 14\Redist\OCR";
                    gdpictureOCR.AddLanguage(OCRLanguage.English);
                    gdpictureOCR.SetImage(imageId);
                    string ocrResultId = gdpictureOCR.RunOCR();
                    Dictionary<string, string> keyValueData = new Dictionary<string, string>();
                    for (int pairIndex = 0; pairIndex < gdpictureOCR.GetKeyValuePairCount(ocrResultId); pairIndex++)
                    {
                        string key = gdpictureOCR.GetKeyValuePairKeyString(ocrResultId, pairIndex);
                        string value = gdpictureOCR.GetKeyValuePairValueString(ocrResultId, pairIndex);

                        keyValueData[key] = value;
                    }

                    InsurenceEligibility model = new InsurenceEligibility();

                    List<string> ColumnsValues = new List<string>();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        await connection.OpenAsync();
                        ColumnsValues = await GetColumnsValuesAsync(connection);
                        await connection.CloseAsync();
                    }
                    foreach (var item in keyValueData)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            var chkCardFieldName = await Task.Run(() => GetInternalFieldName(connection, PayerId, item.Key));
                            if (chkCardFieldName != null)
                            {
                                bool InsuranceMemberID = ColumnsValues.Any(x => x.Contains("InsuranceMemberID") && x == chkCardFieldName);
                                bool ExpiryDate = ColumnsValues.Any(x => x.Contains("ExpiryDate") && x == chkCardFieldName);
                                bool PatientName = ColumnsValues.Any(x => x.Contains("PatientName") && x == chkCardFieldName);
                                bool EffectiveDate = ColumnsValues.Any(x => x.Contains("EffectiveDate") && x == chkCardFieldName);
                                bool PackageName = ColumnsValues.Any(x => x.Contains("PackageName") && x == chkCardFieldName);
                                bool PolicyNumber = ColumnsValues.Any(x => x.Contains("PolicyNumber") && x == chkCardFieldName);
                                bool PackageID = ColumnsValues.Any(x => x.Contains("PackageID") && x == chkCardFieldName);

                                if (InsuranceMemberID)
                                {
                                    model.InsuranceMemberID = item.Value;
                                    model.VisitAccountNo = 92638;
                                    model.Image = imageData;
                                    model.CreatedOn = DateTime.Now.ToString("yyyyMMddHHmmss");

                                    model.CreatedBy = "System";

                                }
                                else if (ExpiryDate)
                                {
                                    model.ExpiryDate = Convert.ToDateTime(item.Value);
                                }
                                else if (PatientName)
                                {
                                    model.PatientName = item.Value;
                                }
                                else if (EffectiveDate)
                                {
                                    model.EffectiveDate = Convert.ToDateTime(item.Value);
                                }
                                else if (PackageName)
                                {
                                    model.PackageName = item.Value;
                                }
                                else if (PolicyNumber)
                                {
                                    model.PolicyNumber = item.Value;
                                }
                                else if (PackageID)
                                {
                                    model.PackageId = Convert.ToInt32(item.Value);
                                }

                            }

                            //else
                            //{
                            //    model.Message = "Mapping Not Found";
                            //    return model;
                            //}
                        }

                    }
                    model.BlPayerId = Convert.ToInt32(PayerId);



                    //try
                    //{
                    //    using (SqlConnection connection = new SqlConnection(connectionString))
                    //    {
                    //        connection.Open();

                    //    string insertQuery = "INSERT INTO InsuranceEligibility (VisitAccountNo, PatientName,InsuranceMemberID, EffectiveDate, ExpiryDate, Image,PolicyNumber, BlPayerId,PackageName,PackageID,CreatedBy,CreatedOn) " +
                    //     "VALUES (@VisitAccountNo, @PatientName, @InsuranceMemberID, @EffectiveDate, @ExpiryDate, @Image,@PolicyNumber, @BlPayerId,@PackageName,@PackageID,@CreatedBy,@CreatedOn)";
                    //        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    //        {
                    //            command.Parameters.AddWithValue("@VisitAccountNo", 92638);
                    //            command.Parameters.AddWithValue("@PatientName", ((object)model.PatientName) ?? DBNull.Value);
                    //            command.Parameters.AddWithValue("@InsuranceMemberID", ((object)model.InsuranceMemberID) ?? DBNull.Value);
                    //            command.Parameters.AddWithValue("@EffectiveDate", ((object)model.EffectiveDate) ?? DBNull.Value);
                    //            command.Parameters.AddWithValue("@ExpiryDate", ((object)model.ExpiryDate) ?? DBNull.Value);
                    //            command.Parameters.AddWithValue("@Image", ((object)model.Image) ?? DBNull.Value);
                    //            command.Parameters.AddWithValue("@PolicyNumber", ((object)model.PolicyNumber) ?? DBNull.Value);
                    //            command.Parameters.AddWithValue("@BlPayerId", ((object)model.BlPayerId) ?? DBNull.Value);
                    //            command.Parameters.AddWithValue("@PackageName", ((object)model.PackageName) ?? DBNull.Value);
                    //            command.Parameters.AddWithValue("@PackageID", ((object)model.PackageId) ?? DBNull.Value);
                    //            command.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                    //            command.Parameters.AddWithValue("@CreatedOn", model.CreatedOn);
                    //            int rowsAffected = await command.ExecuteNonQueryAsync();


                    //            if (rowsAffected == 1)
                    //            {
                    //                gdpictureImaging.ReleaseGdPictureImage(imageId);
                    //                gdpictureOCR.ReleaseOCRResults();
                    //                return model;
                    //            }
                    //            else
                    //            {
                    //                model.Message = "Not Inserted";
                    //                return model;
                    //            }
                    //        }
                    //        connection.Close();


                    //    }

                    //}
                    //catch (Exception ex)
                    //{
                    //    // Handle the exception
                    //    var exception = ex;
                    //    throw ex ;
                    //}


                    if (model.EffectiveDate!=null)
                    {
                        gdpictureImaging.ReleaseGdPictureImage(imageId);
                        gdpictureOCR.ReleaseOCRResults();
                        return model;
                    }
                    else
                    {
                        model.Message = "Not Inserted";
                        return model;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string GetInternalFieldName(SqlConnection connection, long PayerId, string cardFieldName)
        {
            string internalFieldName = null;
            connection.Open();
            using (var command = new SqlCommand("SELECT TOP 1 InternalFieldName FROM InsuranceCompanyFieldMapping WHERE BlPayerId = @PayerId AND CardFieldName = @CardFieldName", connection))
            {
                command.Parameters.AddWithValue("@PayerId", PayerId);
                command.Parameters.AddWithValue("@CardFieldName", cardFieldName);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    internalFieldName = result.ToString();
                }
            }


            return internalFieldName;
        }

        private async Task<List<string>> GetColumnsValuesAsync(SqlConnection connection)
        {
            List<string> emptyColumns = new List<string>();

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'InsuranceEligibility';";

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        string columnName = reader.GetString(0);
                        emptyColumns.Add(columnName);
                    }
                }
            }

            return emptyColumns;
        }

    }
}
