using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
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
			return _ownerService.FindOwnerById(id);
		}

		// POST api/owners -- CREATE
		[HttpPost]
		public ActionResult<Owner> Post([FromBody] Owner owner)
		{
			return _ownerService.CreateOwner(owner);
		}

		// PUT api/owners/5 -- Update
		[HttpPut("{id}")]
		public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
		{
			if (id < 1 || id != owner.Id)
			{
				return BadRequest("Parameter Id and order ID must be the same");
			}

			return _ownerService.UpdateOwner(owner);
		}

		// DELETE api/owners/5
		[HttpDelete("{id}")]
		public ActionResult<Owner> Delete(int id)
		{
			if (id < 1 )
			{
				return BadRequest("Parameter Id and order ID must be the same");
			}
			else 
			{
				_ownerService.DeleteOwner(id);
				return Ok($"Order with Id: {id} is Deleted");
			}
		}
	}
}
