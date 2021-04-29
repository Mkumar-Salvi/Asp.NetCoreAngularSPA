using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project_Api.Entity
{
	public class EntityProperty
	{
		public enum EntityPropertyDataType : byte
		{
			/// <Summary>
			/// If this is set on PropertyType of PropertyInfoDTO, UI should render the input (type=text) field and place the value.
			/// </Summary>
			text = 0,

			/// <Summary>
			/// If this is set on PropertyType of PropertyInfoDTO, UI should render the input (type=number) field and place the value.Also, display unit after the input field.
			/// </Summary>
			number = 1,

			/// <Summary>
			/// If this is set on PropertyType of PropertyInfoDTO, UI should render the input (type= number) field and place the value.
			/// </Summary>
			quantity = 2,

			/// <Summary>
			/// If this is set on PropertyType of PropertyInfoDTO, UI should render a checkbox field and assign the value
			/// </Summary>
			checkbox = 3,

			GeometryProperty = 4
		}

		public class Fields
		{
			[Key]
			public int DynamicFieldId { get; set; }
			public string Value { get; set; }
			public string FieldKey { get; set; }
			public string FieldLabel { get; set; }
			public bool Required { get; set; }
			public int FieldOrder { get; set; }
			public string ControlType { get; set; }
			public string Type { get; set; }
			public int ControlSize { get; set; }
			public string ControlGroup { get; set; }
			public int GroupSize { get; set; }
			public string Unit { get; set; }
		}
	}
}
