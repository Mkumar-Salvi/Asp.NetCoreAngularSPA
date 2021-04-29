using Backend_Project_Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Project_Api.Repositories
{
	public interface IRepository
	{
		IEnumerable<FormDTO> GetAll();
		IEnumerable<FieldsDTO> GetAllFields();
		FormDTO Find(string key);
		void Update(FormDTO item);
	}
}
