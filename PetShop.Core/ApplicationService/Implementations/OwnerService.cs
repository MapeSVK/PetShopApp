using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Core.ApplicationService.Implementations
{
	public class OwnerService:IOwnerService
	{
		private IOwnerRepository _ownerRepository;

		public OwnerService(IOwnerRepository ownerRepository)
		{
			_ownerRepository = ownerRepository;
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
