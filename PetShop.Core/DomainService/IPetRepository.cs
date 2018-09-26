using System;
using System.Collections.Generic;
using Entities;
using PetShop.Core.Entities;

namespace Core.DomainService
{
	public interface IPetRepository
	{

		//Read Pets
		IEnumerable<Pet> ReadAllPets(Filter filter = null);

		//Update Pet
		Pet UpdatePet(Pet updatedPet);

		//Delete Pet
		Pet RemovePet(int id);

		//Add Pet
		Pet Add(Pet newPet);

		//get if of the pet
		Pet GetPetById(int id);
		
		int Count();
	}
}
