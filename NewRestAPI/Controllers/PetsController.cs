using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationService;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace NewRestAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PetsController : ControllerBase
	{

		private readonly IPetService _petService;

		public PetsController(IPetService petService)
		{
			_petService = petService;
		}


		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<Pet>> Get()
		{
			return _petService.GetPets();
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<Pet> Get(int id)
		{
			if (id < 1) return BadRequest("Id must be greater then 0");
			return _petService.FindPetById(id);
		}

		// POST api/values
		[HttpPost]
		public ActionResult<Pet> Post([FromBody] Pet pet)
		{
			if (string.IsNullOrEmpty(pet.Name))
			{
				return BadRequest("You must set pet name!");
			}

			if (string.IsNullOrEmpty(pet.Type))
			{
				return BadRequest("You need to set the type of the pet!");
			}
			if (string.IsNullOrEmpty(pet.Color))
			{
				return BadRequest("You need to set the colour of the pet!");
			}
			if (double.IsPositiveInfinity(pet.Price) == true)
			{
				return BadRequest("Price needs to be more then 0!");
			}

			return _petService.AddPet(pet);
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
		{
			if (id < 1 || id != pet.Id)
			{
				return BadRequest("The ID of the pet is not correct!");
			}
			return Ok(_petService.UpdatePet(pet));
		}


		// DELETE api/values/5
		[HttpDelete("{id}")]
		public ActionResult<Pet> Delete(int id)
		{
			var pet = _petService.DeletePet(id);
		
			if (pet == null)
			{
				return StatusCode(404, "Could not find the pet with this ID: " + id);
			}

			return Ok($"Customer with Id: {id} is deleted");
		}
	}
}
