using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project_Api.DTO
{
	public class FormDTO
	{
		public string SamplingTime { get; set; }

		public string ProjectName { get; set; }

		public long? ConstructionCount { get; set; }

		public bool IsConstructionCompleted { get; set; }

		public double? LengthOfTheRoad { get; set; }

		public string Unit { get; set; }
	}
}
