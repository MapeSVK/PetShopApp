using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationService;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
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
			return _petService.FindPetById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
			return _petService.AddPet(pet);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
		public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
			if (id < 1 || id != pet.Id)
			{
				return BadRequest("Id is not good.");
			}
			return Ok(_petService.UpdatePet(pet));
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
		public ActionResult<Pet> Delete(int id)
        {
			var pet = _petService.DeletePet(id);
			return Ok($"Customer with Id: {id} is deleted");
        }
    }
}
