using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Backend_Project_Api.Entity.EntityProperty;

namespace Backend_Project_Api.DTO
{
	public class PropertiesDTO
	{
		///<Summary>
		/// Identifier property
		///</Summary>
		public long Id { get; set; }

		///<Summary>
		/// Holds the value for current property. Based on the PropertyType this holds the information.
		/// Say for example, If it is StringProperty, this holds the string value.
		///</Summary>
		public object Value { get; set; }

		///<Summary>
		/// A string value which indicates the label for the input field in the UI.
		///</Summary>
		public string Label { get; set; }

		///<Summary>
		/// Indicates the current property type. Also, this is used to decide input field in the UI.
		/// Refer EntityPropertyDataType enum section for more information.
		///</Summary>
		public EntityPropertyDataType PropertyType { get; set; }
	}
}
