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
		public string item { get; set; }
		public string batch { get; set; }
		public string serial { get; set; }
		public decimal? weight { get; set; }

		public DateTime? createdAt { get; set; }
		public DateTime? shipdate { get; set; }

		

	
	}
}
