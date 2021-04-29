using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project_Api.DTO
{
	public class UnitDTO
	{
		/// <Summary>
		/// Quantity value
		/// </Summary>
		public long Id { get; set; }

		/// <Summary>
		/// Quantity unit
		/// </Summary>
		public string Symbol { get; set; }
	}
}
