using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project_Api.DTO
{
	public class ChildDTO
	{
		/// <Summary>
		/// Sampling time of the properties.
		/// </Summary>
		public DateTime SamplingTime { get; set; }

		/// <Summary>
		/// Collection of PropertyInfoDTO object.
		/// </Summary>
		public List<PropertiesDTO> Properties { get; set; }
	}
}
