using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Project_Api.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Backend_Project_Api.Repositories;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace Backend_Project_Api.Controllers
{
	[EnableCors("AllowAll")]
	[Route("api/[controller]")]
	[ApiController]
	public class DataController : ControllerBase
	{
		public IRepository _repository { get; set; }
		public DataController(IRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IEnumerable<FormDTO> Get()
		{
			return _repository.GetAll();
		}

		[HttpGet("GetFields")]
		public IEnumerable<FieldsDTO> GetAll()
		{
			return _repository.GetAllFields();
		}

		[HttpGet("{key}", Name = "GetData")]
		public IActionResult GetById(string key)
		{
			var item = _repository.Find(key);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPut]
		public IActionResult Put([FromBody] dynamic item)
		{
			var summary = JsonConvert.DeserializeObject<FormDTO>(item.ToString());
			_repository.Update(summary);

			return CreatedAtAction(nameof(GetById), new { key = summary.SamplingTime }, item);
		}
	}
}
