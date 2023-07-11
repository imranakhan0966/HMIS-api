using Dapper;
using HMIS.Common.BindingModels.Common;
using HMIS.Common.BindingModels.ControlPanel;
using HMIS.Common.ORM;
using HMIS.Data.Entities.ControlPanel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = HMIS.Common.BindingModels.ControlPanel.Module;

namespace HMIS.Services.ControlPanel
{
    public static class PermissionService
    {



        public async static Task<DataSet> GetPermissionDataSetByEmpIdandUserId(long empId, string username)
        {

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmpId", $"{empId}");
                param.Add("@UserId", $"{username}");




                DataSet dt = await DapperHelper.GetDataSetBySP("[dbo].[Sec_GetEmployeePermissionsByEmployeeId]", param);
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
       
            public async static Task<PermissionResponseModel> GetPermissionByEmpIdandUserId(long empId, string username,DataSet dataSet = null)
        {
            try
            {

               PermissionResponseModel response = new PermissionResponseModel();
                List<Module> module = new List<Module>();
                List<string> permisionsList = new List<string>();

                DynamicParameters param = new DynamicParameters();
                param.Add("@EmpId", $"{empId}");
                param.Add("@UserId", $"{username}");




                DataSet dt = dataSet==null?  await  DapperHelper.GetDataSetBySP("[dbo].[Sec_GetEmployeePermissionsByEmployeeId]", param):dataSet;

                DataTable permissions = new DataTable();
                if (dt.Tables.Count>0)
                {
                    permissions = dt.Tables[0];

                    var parseObj =  JArray.FromObject(permissions).ToObject<List<Permissions>>();
                   
                    if (parseObj!=null)
                    {

                        if (parseObj.Count>0)
                        {



                            //Get all unique modules
                            List<Module> modules = parseObj.DistinctBy(a => a.ModuleId).Select(a => new Module { Id = a.ModuleId, Name = a.ModuleName }).ToList();

                            List<Roles> roles = parseObj.DistinctBy(a => a.RoleId).Select(a => new Roles { Id=a.RoleId,Name = a.RoleName}).ToList();

                            //For each module fetch forms




                            foreach (var item in modules)
                            {
                                permisionsList.Add(item.Name);

                                //Get all distinct forms on particular module
                                List<Form> forms = parseObj.Where(a => a.ModuleId == item.Id).DistinctBy(k => k.FormId).Select(a => new Form { Id = a.FormId, FormName = a.FormName, FormPrivileges = new List<FormPrivilege>() }).ToList();



                                //Get privilges of each form
                                List<Form> _form = new List<Form>();
                                for (int p = 0; p < forms.Count; p++)
                                {

                                    permisionsList.Add($"{item.Name}:{forms[p].FormName}");


                                    List<FormPrivilege> privileges = parseObj.Where(a => a.FormId == forms[p].Id).Select(i => new FormPrivilege { Id = i.PrivilegeId, FormPrivilegeId = i.FormPrivilegeId, PrivilegeName = i.PrivilegeName }).ToList();
                                    if (privileges.Count > 0)
                                    {

                                        for (int i = 0; i < privileges.Count; i++)
                                        {
                                            permisionsList.Add($"{item.Name}:{forms[p].FormName}:{privileges[i].PrivilegeName}");

                                        }


                                        _form.Add(new Form() { Id = forms[p].Id, FormName = forms[p].FormName, FormPrivileges = privileges });

                                    }



                                }

                                module.Add(new Module() { Id = item.Id, Forms = _form, Name = item.Name ,Roles = roles });

                            }



                            return new PermissionResponseModel() { Modules = module, Roles = roles , Permissions = permisionsList };

                        }




                    }

                  
                }
                return new PermissionResponseModel();
                
            }
            catch (Exception ex)
            {
                return new PermissionResponseModel(); 

            }
        }



        public async static Task<List<PermissionTree>> GetPermissionTreeByEmpIdandUserId(long empId, string username)
        {

            try
            {
                List<PermissionTree> ptList = new List<PermissionTree>();

                DataTable permissions = new DataTable();

                DataSet dt = await  GetPermissionDataSetByEmpIdandUserId(empId, username);

                if (dt==null)
                {
                    return new List<PermissionTree>();
                }

                PermissionResponseModel permResponse = await GetPermissionByEmpIdandUserId(empId, username, dt);


                if (permResponse == null) { return new List<PermissionTree>(); }
                if (permResponse.Modules==null)
                {
                    return new List<PermissionTree>();
                }
                


                permissions = dt.Tables[0];

                var parseObj = JArray.FromObject(permissions).ToObject<List<Permissions>>();

                if (parseObj == null) { return new List<PermissionTree>(); }

                foreach (var item in permResponse.Modules)
                {

                    PermissionTree ptRoot = new PermissionTree();
                    ptRoot.label = item.Name;
                    ptRoot.data = item.Id.ToString();
                    ptRoot.expandedIcon = "pi pi-folder-open";
                    ptRoot.collapsedIcon = "pi pi-folder";

                    ptRoot.children = new List<Child>();


                    //Get all distinct forms on particular module
                    List<Form> forms = parseObj.Where(a => a.ModuleId == item.Id).DistinctBy(k => k.FormId).Select(a => new Form { Id = a.FormId, FormName = a.FormName, FormPrivileges = new List<FormPrivilege>() }).ToList();



                    //Get privilges of each form
                    List<Form> _form = new List<Form>();
                    for (int p = 0; p < forms.Count; p++)
                    {
                        Child ptModuleForms = new Child();


                        ptModuleForms.label = forms[p].FormName;
                        ptModuleForms.data = item.Id.ToString();
                        ptModuleForms.expandedIcon = "pi pi-folder-open";
                        ptModuleForms.collapsedIcon = "pi pi-folder";
                        ptRoot.children.Add(ptModuleForms);



                        ptModuleForms.children = new List<Child>();




                        List<FormPrivilege> privileges = parseObj.Where(a => a.FormId == forms[p].Id).Select(i => new FormPrivilege { Id = i.PrivilegeId, FormPrivilegeId = i.FormPrivilegeId, PrivilegeName = i.PrivilegeName }).ToList();
                        if (privileges.Count > 0)
                        {

                            for (int i = 0; i < privileges.Count; i++)
                            {
                                Child pFormPrivilege = new Child();
                                pFormPrivilege.label = privileges[i].PrivilegeName;
                                pFormPrivilege.data = privileges[i].Id.ToString();
                                pFormPrivilege.expandedIcon = "pi pi-folder-open";
                                pFormPrivilege.collapsedIcon = "pi pi-folder";
                                ptModuleForms.children.Add(pFormPrivilege);


                            }





                        }



                    }



                    ptList.Add(ptRoot);
                }

                return ptList;
            }
            catch (Exception ex)
            {

               
            }
            return new List<PermissionTree>();
        }

    }
}
