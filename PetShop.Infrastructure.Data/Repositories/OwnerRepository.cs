using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
	public class OwnerRepository: IOwnerRepository
	{
		private List<Owner> _owners = new List<Owner>();

		public Owner CreateOwner(Owner newOwner)
		{
			newOwner.Id = FakeDB.OwnerId++;
			var OwnersFromDB = FakeDB.Owners.ToList();
			OwnersFromDB.Add(newOwner);
			FakeDB.Owners = OwnersFromDB;
			//FakeDB.Owners.ToList().Add(newOwner);
			return newOwner;

		}

		public Owner DeleteOwner(int id)
		{
			var OwnerFound = ReadById(id);
			if (OwnerFound == null)
			{
				return null;
			}
			var OwnersFromDB = FakeDB.Owners.ToList();
			OwnersFromDB.Remove(OwnerFound);
			FakeDB.Owners = OwnersFromDB;
			//FakeDB.Owners.ToList().Remove(OwnerFound);

			return OwnerFound;
		}

		public IEnumerable<Owner> ReadAll()
		{
			return FakeDB.Owners;
		}

		public Owner ReadById(int id)
		{
			return FakeDB.Owners.FirstOrDefault(order => order.Id == id);
		}

		public Owner UpdateOwner(Owner UpdatedOwner)
		{
			var OwnerFromDB = ReadById(UpdatedOwner.Id);
			if (UpdatedOwner == null)
			{
				return null;
			}
			//OwnerFromDB.Id = UpdatedOwner.Id;
			OwnerFromDB.FirstName = UpdatedOwner.FirstName;
			OwnerFromDB.LastName = UpdatedOwner.LastName;
			OwnerFromDB.Address = UpdatedOwner.Address;

			return OwnerFromDB;
		}
	}
}
