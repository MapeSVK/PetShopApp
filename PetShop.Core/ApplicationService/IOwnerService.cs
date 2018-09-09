using System;
using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService
{
	public interface IOwnerService
	{

		//NEW
		Owner NewOwner();

		//POST
		Owner CreateOwner(Owner order);

		//GET
		Owner FindOwnerById(int id);
		List<Owner> GetAllOwners();

		//PUT
		Owner UpdateOwner(Owner ownerUpdate);

		//DELETE
		Owner DeleteOwner(int id);
	}
}
