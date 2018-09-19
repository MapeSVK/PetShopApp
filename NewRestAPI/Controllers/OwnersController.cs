using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;

namespace NewRestAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OwnersController : ControllerBase
	{
		private readonly IOwnerService _ownerService;

		public OwnersController(IOwnerService ownerService)
		{
			_ownerService = ownerService;
		}

		// GET api/owners -- READ All
		[HttpGet]
		public ActionResult<IEnumerable<Owner>> Get()
		{
			return _ownerService.GetAllOwners();
		}

		// GET api/owners/5 -- READ By Id
		[HttpGet("{id}")]
		public ActionResult<Owner> Get(int id)
		{
			if (id < 1) return BadRequest("Id must be greater then 0");
			return _ownerService.FindOwnerByIdIncludePets(id);
		}

		// POST api/owners -- CREATE
		[HttpPost]
		public ActionResult<Owner> Post([FromBody] Owner owner)
		{
			if (string.IsNullOrEmpty(owner.FirstName))
			{
				return BadRequest("You must set the Owner's name!");
			}
			if (string.IsNullOrEmpty(owner.LastName))
			{
				return BadRequest("You must set the Owner's last name!");
			}
			if (string.IsNullOrEmpty(owner.Address))
			{
				return BadRequest("You must set the Owner's address!");
			}
			return _ownerService.CreateOwner(owner);
		}

		// PUT api/owners/5 -- Update
		[HttpPut("{id}")]
		public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
		{
			if (id < 1 || id != owner.Id)
			{
				return BadRequest("The ID of the owner is not correct!");
			}

			return _ownerService.UpdateOwner(owner);
		}

		// DELETE api/owners/5
		[HttpDelete("{id}")]
		public ActionResult<Owner> Delete(int id)
		{
			var pet = _ownerService.DeleteOwner(id);

			if (pet == null)
			{
				return StatusCode(404, "Could not find the pet with this ID: " + id);
			}

			return Ok($"Order with Id: {id} is Deleted");

		}
	}
}
