using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project_Api.DTO
{
	public class QuantityDTO
	{
		/// <Summary>
		/// Quantity value
		/// </Summary>
		public double? Value { get; set; }

		/// <Summary>
		/// Quantity unit
		/// </Summary>
		public UnitDTO Unit { get; set; }
	}
}
