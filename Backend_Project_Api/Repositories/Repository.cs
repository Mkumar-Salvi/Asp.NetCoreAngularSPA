using Backend_Project_Api.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Backend_Project_Api.Entity.EntityProperty;

namespace Backend_Project_Api.Repositories
{
	public class Repository:IRepository		
	{
		private static IList<FormDTO> jsonData;
		private static IList<ChildDTO> fieldsData;

		public Repository()
		{
			jsonData = GetDataFromJson();
		}

		private List<FormDTO> GetDataFromJson()
		{
			var _jsonData = new List<FormDTO>();
			var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"{"Data\\data.json"}");
			var JSON = System.IO.File.ReadAllText(folderDetails);
			var consInfo = JsonConvert.DeserializeObject<RootDTO>(JSON);
			fieldsData = consInfo.Datas;
			foreach (var prop in consInfo.Datas)
			{
				FormDTO item = new FormDTO();
				item.SamplingTime = prop.SamplingTime.ToString("dd-MM-yyyy hh:mm:ss tt");
				item.ProjectName = prop.Properties.Where(i => i.Label.ToLower() == "project name").FirstOrDefault().Value.ToString();
				var count = prop.Properties.Where(i => i.Label.ToLower() == "construction count").FirstOrDefault();
				if (count != null) { item.ConstructionCount = int.Parse(count.Value.ToString()); }
				item.IsConstructionCompleted = bool.Parse(prop.Properties.Where(i => i.Label.ToLower() == "is construction completed").FirstOrDefault()?.Value.ToString());
				var length = prop.Properties.Where(i => i.Label.ToLower() == "length of the road").FirstOrDefault();
				if (length != null)
				{
					var json = JsonConvert.DeserializeObject<QuantityDTO>(length.Value.ToString());
					item.LengthOfTheRoad = json.Value;
					item.Unit = json.Unit.Symbol;
				}
				_jsonData.Add(item);
			}

			return _jsonData;
		}

		public FormDTO Find(string key)
		{
			return jsonData.Where(x => x.SamplingTime.ToString() == key).FirstOrDefault();
		}

		public IEnumerable<FormDTO> GetAll()
		{
			return jsonData;
		}

		public IEnumerable<FieldsDTO> GetAllFields()
		{
			IList<FieldsDTO> allFields = new List<FieldsDTO>();
			foreach (var field in fieldsData)
			{
				int count = 0;
				int order = 0;
				var item = new FieldsDTO();
				item.SamplingTime = field.SamplingTime.ToString("dd-MM-yyyy hh:mm:ss tt");
				IList<Fields> fields = new List<Fields>();
				foreach (var prop in field.Properties)
				{
					var fd = new Fields();
					fd.DynamicFieldId = count++;
					fd.ControlType = "text";
					fd.Type = (prop.PropertyType.ToString() == "quantity") ? "number" : prop.PropertyType.ToString();
					if (prop.Label.ToLower() == "project name")
					{
						fd.FieldKey = prop.Label.Replace(" ", "").ToLower();
						fd.FieldLabel = prop.Label;
						fd.Value = prop.Value.ToString();
					}
					else if (prop.Label.ToLower() == "construction count")
					{
						fd.FieldKey = prop.Label.Replace(" ", "").ToLower();
						fd.FieldLabel = prop.Label;
						fd.Value = prop.Value.ToString();
					}
					else if (prop.Label.ToLower() == "is construction completed")
					{
						fd.FieldKey = prop.Label.Replace(" ", "").ToLower();
						fd.FieldLabel = prop.Label;
						fd.Value = prop.Value.ToString();
					}
					else if (prop.Label.ToLower() == "length of the road")
					{
						fd.FieldKey = prop.Label.Replace(" ", "").ToLower();
						fd.FieldLabel = prop.Label;
						var qty = JsonConvert.DeserializeObject<QuantityDTO>(prop.Value.ToString());
						fd.Value = qty.Value.ToString();
						fd.Unit = qty.Unit.Symbol;
					}
					fd.Required = false;
					fd.FieldOrder = order++;
					fd.ControlSize = 1;
					fd.ControlGroup = string.Empty;
					fd.GroupSize = 0;
					fields.Add(fd);
				}
				item.Properties = fields.ToList();
				allFields.Add(item);
			}
			return allFields;
		}

		public void Update(FormDTO item)
		{
			var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"{"Data\\data.json"}");
			var json = File.ReadAllText(folderDetails);
			var jObject = JObject.Parse(json);
			JArray datasArray = (JArray)jObject["Datas"];
			var data = datasArray.Where(x => (DateTime.Parse(x["SamplingTime"].ToString()).ToString("dd-MM-yyyy hh:mm:ss tt") == item.SamplingTime)).FirstOrDefault();
			if(data != null)
			{
				JArray propArray = (JArray)data["Properties"];
				if(propArray!=null)
				{
					if(propArray.Any(x=>x["Label"] != null && x["Label"].ToString().ToLower() == "project name"))
					{
						var label = propArray.Where(i => i["Label"].ToString().ToLower() == "project name").FirstOrDefault();
						label["Value"] = item.ProjectName;
					}
					if (propArray.Any(x => x["Label"] != null && x["Label"].ToString().ToLower() == "construction count"))
					{
						var label = propArray.Where(i => i["Label"].ToString().ToLower() == "construction count").FirstOrDefault();
						label["Value"] = item.ConstructionCount;
					}
					if (propArray.Any(x => x["Label"] != null && x["Label"].ToString().ToLower() == "is construction completed"))
					{
						var label = propArray.Where(i => i["Label"].ToString().ToLower() == "is construction completed").FirstOrDefault();
						label["Value"] = item.IsConstructionCompleted;
					}
					if (propArray.Any(x => x["Label"] != null && x["Label"].ToString().ToLower() == "length of the road"))
					{
						var label = propArray.Where(i => i["Label"].ToString().ToLower() == "length of the road").FirstOrDefault();
						label["Value"]["Value"] = item.LengthOfTheRoad;
					}
					jObject["Properties"] = propArray;
				}
				jObject["Datas"] = datasArray;
			}
			string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(folderDetails, string.Empty);
			File.WriteAllText(folderDetails, output);
		}
	}
}
