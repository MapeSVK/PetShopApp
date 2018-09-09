using System;
using System.Collections.Generic;
using PetShop.Core.Entities;

namespace PetShop.Core.DomainService
{
	public interface IOwnerRepository
	{
		Owner CreateOwner(Owner newOwner);

		Owner ReadById(int id);
		IEnumerable<Owner> ReadAll();

		Owner UpdateOwner(Owner UpdatedOwner);

		Owner DeleteOwner(int id);


	}
}
