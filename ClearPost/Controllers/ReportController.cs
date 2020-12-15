using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ClearPost.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClearPost.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult ShowReport()
		{
			ServerConfig serverConfig = new ServerConfig
			{
                ServerUrl = "http://koninlord/ReportServer_SSRS?",
				Username = "lord",
				Password = "hey@#me$123"
			};
            byte[] fileBytes = GetReportData(serverConfig, "/Clearance/clearance/FeesCleared");
            
            ViewBag.Document = fileBytes;

        return View();
        //return File(fileBytes, "application/pdf", "FileDownloadName.pdf");
		}
        public IActionResult ShowClearedReport()
        {
            ServerConfig serverConfig = new ServerConfig
            {
                ServerUrl = "http://koninlord/ReportServer_SSRS?",
                Username = "lord",
                Password = "hey@#me$123"
            };
            byte[] fileBytes = GetReportData(serverConfig, "/Clearance/clearance/FeesUncleared");

            ViewBag.Document = fileBytes;

            return View();
            //return File(fileBytes, "application/pdf", "FileDownloadName.pdf");
        }
        public IActionResult ShowSportClearedReport()
        {
            ServerConfig serverConfig = new ServerConfig
            {
                ServerUrl = "http://koninlord/ReportServer_SSRS?",
                Username = "lord",
                Password = "hey@#me$123"
            };
            byte[] fileBytes = GetReportData(serverConfig, "/Clearance/clearance/SportCleared");

            ViewBag.Document = fileBytes;

            return View();
            //return File(fileBytes, "application/pdf", "FileDownloadName.pdf");
        }
        public IActionResult ShowSportUnClearedReport()
        {
            ServerConfig serverConfig = new ServerConfig
            {
                ServerUrl = "http://koninlord/ReportServer_SSRS?",
                Username = "lord",
                Password = "hey@#me$123"
            };
            byte[] fileBytes = GetReportData(serverConfig, "/Clearance/clearance/SportUncleared");

            ViewBag.Document = fileBytes;

            return View();
            //return File(fileBytes, "application/pdf", "FileDownloadName.pdf");
        }
        public byte[] GetReportData(ServerConfig serverConfig, string reportUrl)
        {
            try
            {
                string outputFormat = "PDF";
                string extension =  "&rs:Format=" + outputFormat;
                var completeUrl = serverConfig.ServerUrl + reportUrl + extension;
                var reportUri = new Uri(completeUrl);
                var networkCredential = new NetworkCredential(serverConfig.Username, serverConfig.Password);
                var credCache = new CredentialCache { { new Uri(serverConfig.ServerUrl), "NTLM", networkCredential } };

                var client = new WebClient { Credentials = credCache };
                var response = client.DownloadData(reportUri);

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}