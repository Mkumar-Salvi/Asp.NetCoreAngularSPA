using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project_Api.DTO
{
	public class RootDTO
	{
		/// <Summary>
		/// Identifier property.
		/// </Summary>
		public long Id { get; set; }

		/// <Summary>
		/// Name of the parent object.
		/// </Summary>
		public string Name { get; set; }

		/// <Summary>
		/// Collection of SamplingInfoDTO object.
		/// </Summary>
		public List<ChildDTO> Datas { get; set; }
	}
}
