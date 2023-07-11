


using Microsoft.AspNetCore;

using HMIS.Common.Logger;

namespace HMIS
{
    public class Program
    {



        public static void Main(string[] args)
        {




           // //DB BASED
           //NLogHelper.WriteLog(new LogParameter() { Message = "App started", ActionDetails = "Main method", ActionId = 1, ActionTime = DateTime.Now, FormName = "N/A", ModuleName = "Program.cs", UserName = "Taha", TablesReadOrModified = 1, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, "App init", true);



           // //FILE BASED
           // NLogHelper.WriteLog(new LogParameter() { Message = "App started", ActionDetails = "Main method", ActionId = 1, ActionTime = DateTime.Now, FormName = "N/A", ModuleName = "Program.cs", UserName = "Taha", TablesReadOrModified = 0, UserLoginHistoryId = 17 }, (short)NLog.LogLevel.Info.Ordinal, "App init");



         

            //logger.Info("test init");

            BuildWebHost(args).Run();

              

          

        }



     
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                 
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .Build();



        }
    }
}


