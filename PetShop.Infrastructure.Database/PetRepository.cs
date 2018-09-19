using System.Collections.Generic;
using Core.DomainService;
using Entities;

namespace PetShop.Infrastructure.Database
{
	public class PetRepository : IPetRepository
	{
		readonly PetShopAppContext _psc;

		public PetRepository(PetShopAppContext psc)
		{
			_psc = psc;
		}

		public IEnumerable<Pet> ReadAllPets()
		{
			return _psc.Pets;
		}

		public Pet UpdatePet(Pet updatedPet)
		{
			throw new System.NotImplementedException();
		}

		public Pet RemovePet(int id)
		{
			throw new System.NotImplementedException();
		}

		public Pet Add(Pet newPet)
		{
//			var pet = _psc.Pets.Add(newPet).Entity;
//			_psc.SaveChanges();
//			return pet;		
			throw new System.NotImplementedException();

		}

		public Pet GetPetById(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}
