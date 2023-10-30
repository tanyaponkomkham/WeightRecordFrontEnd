using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeightRecordFrontEnd.Models;
using WeightRecordFrontEnd.ViewModels;

namespace WeightRecordFrontEnd.Controllers
{
	

	public class HomeController : Controller
	{
		public IActionResult Privacy()
		{
			return View();
		}
		public class ValuePearl
		{
			public string project { get; set; }
			public string partNo { get; set; }
			public string sBatch { get; set; }
			public string eBatch { get; set; }
			public string sDate { get; set; }
			public string eDate { get; set; }

		}
		

		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		public IActionResult Index()
		{
			return View();
		}

		[AcceptVerbs("Get", "Post")]
		public async Task<JsonResult> GetPearlPartNo()
		{
			List<GetPartNo> partNo = new List<GetPartNo>();
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync("https://localhost:44340/api/Pearl/pearlPartNo"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					partNo = JsonConvert.DeserializeObject<List<GetPartNo>>(apiResponse).ToList();
				}
			}
			return Json(partNo);
		}

		[AcceptVerbs("Get", "Post")]
		public async Task<JsonResult> GetRRPartNo()
		{
			List<GetPartNo> partNo = new List<GetPartNo>();
			using (var httpClient = new HttpClient())
			{
				using (var response = await httpClient.GetAsync("https://localhost:44340/api/Weight/weightPartNo"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					partNo = JsonConvert.DeserializeObject<List<GetPartNo>>(apiResponse).ToList();
				}
			}
			return Json(partNo);
		}


		//string partNo, string sBatch, string eBatch, string sDate, string eDate
	
		public async Task<ActionResult> IndexSearchTable(ValuePearl dataPearl)
		{
			List<RRWeightView> rrData = new List<RRWeightView>();
			List<PearlWeightView> pearlData = new List<PearlWeightView>();
			using (var httpClient = new HttpClient())
			{
			
				using (var response = await httpClient.GetAsync("https://localhost:44340/api/weight?partNo=" + dataPearl.partNo + "&sBatchNo=" + dataPearl.sBatch + "&eBatchNo=" + dataPearl.eBatch + "&sDate=" + dataPearl.sDate + "&eDate=" + dataPearl.eDate))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
						rrData = JsonConvert.DeserializeObject<List<RRWeightView>>(apiResponse).ToList();
				}
			}

			return PartialView(rrData);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
