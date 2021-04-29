using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Backend_Project_Api.Entity.EntityProperty;

namespace Backend_Project_Api.DTO
{
	public class FieldsDTO
	{
		/// <Summary>
		/// Sampling time of the properties.
		/// </Summary>
		public String SamplingTime { get; set; }

		/// <Summary>
		/// Collection of PropertyInfoDTO object.
		/// </Summary>
		public List<Fields> Properties { get; set; }
	}
}
