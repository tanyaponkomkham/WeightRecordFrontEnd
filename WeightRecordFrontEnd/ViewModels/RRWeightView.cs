using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeightRecordFrontEnd.ViewModels
{
	public class RRWeightView
	{
		public string partNo { get; set; }
		public string serialBatch { get; set; }
		public string batchNo { get; set; }
		public string serialNo { get; set; }
		public decimal? weight { get; set; }
		public DateTime? data { get; set; }
	}
}
