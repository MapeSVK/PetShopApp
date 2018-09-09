using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainService;
using Entities;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace Core.ApplicationService.Implementations
{
	public class PetService : IPetService
	{
		readonly IPetRepository _iPetRepository;
		private readonly IOwnerRepository _iOwnerRepository;

		public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository)
		{
			_iPetRepository = petRepository;
			_iOwnerRepository = ownerRepository;
		}


		// Get all pets - list of pets
		public List<Pet> GetPets()
		{
			var PetList = _iPetRepository.ReadAllPets().ToList();

			foreach (var pet in PetList)
			{
				pet.Owner = _iOwnerRepository.ReadById(pet.Owner.Id);
			}
			return PetList;


		}


		public Pet AddPet(Pet newPet)
		{
			_iPetRepository.Add(newPet);
			return newPet;
		}

		public Pet CreatePet(string Name, string Type, DateTime BirthDate, DateTime SoldDate, string Color, Owner Owner, double Price)
		{
			return new Pet()
			{
				Name = Name,
				Type = Type,
				BirthDate = BirthDate,
				SoldDate = SoldDate,
				Color = Color,
				Owner = Owner,
				Price = Price
			};
		}



		public Pet DeletePet(int id)
		{
			return _iPetRepository.RemovePet(id);

		}

		public Pet FindPetById(int id)
		{
			return _iPetRepository.GetPetById(id);
		}

		public Pet UpdatePet(Pet selectedPet)
		{
			return _iPetRepository.UpdatePet(selectedPet);
		}

		public List<Pet> GetPetsByType(string type)
		{
			List<Pet> petsWithType = new List<Pet>();
			foreach (Pet pet in _iPetRepository.ReadAllPets().ToList())
			{
				if (pet.Type.ToUpper() == type.ToUpper())
				{
					petsWithType.Add(pet);
				}
			}
			if (petsWithType.Count == 0)
			{
				return null;
			}
			return petsWithType;
		}

		public List<Pet> SortPetsByPrice(List<Pet> petList)
		{
			return petList.OrderBy(pet => pet.Price).ToList();
		}

		public List<Pet> GetFiveCheapestPets(List<Pet> petList)
		{
			int i = 0;
			List<Pet> cheapestPetsList = new List<Pet>();
			while (i < petList.Count() && i < 5)
			{
				cheapestPetsList.Add(petList[i++]);
			}
			return cheapestPetsList;
		}
	}
}
