using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainService;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Implementations
{
	public class OwnerService:IOwnerService
	{
		readonly IOwnerRepository _ownerRepository;
		readonly IPetRepository _petRepository;


		public OwnerService(IOwnerRepository ownerRepository,
			IPetRepository petRepository)
		{
			_ownerRepository = ownerRepository;
			_petRepository = petRepository;
		}

		public Owner CreateOwner(Owner owner)
		{
			return _ownerRepository.CreateOwner(owner);
		}
	

		public Owner DeleteOwner(int id)
		{
			return _ownerRepository.DeleteOwner(id);
		}

		public Owner FindOwnerById(int id)
		{
			return _ownerRepository.ReadById(id);
		}

		public Owner FindOwnerByIdIncludePets(int id)
		{
			var customer = _ownerRepository.ReadyByIdIncludePets(id);
			return customer;
		}

		public List<Owner> GetAllOwners()
		{
			return _ownerRepository.ReadAll().ToList();
		}

		public Owner NewOwner()
		{
			return new Owner();
		}

		public Owner UpdateOwner(Owner ownerUpdate)
		{
			return _ownerRepository.UpdateOwner(ownerUpdate);
		}
	}
}
