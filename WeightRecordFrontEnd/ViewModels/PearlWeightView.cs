using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeightRecordFrontEnd.ViewModels
{
	public class PearlWeightView
	{
		public string job { get; set; }
		public string suffix { get; set; }
		public string PartNo { get; set; }
		public decimal? weight { get; set; }
		
		public DateTime? RecordData { get; set; }
	}
}
