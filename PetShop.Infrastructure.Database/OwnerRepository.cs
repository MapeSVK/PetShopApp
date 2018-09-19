using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Database
{
	public class OwnerRepository : IOwnerRepository

	{
		readonly PetShopAppContext _psc;

		public OwnerRepository(PetShopAppContext psc)
		{
			_psc = psc;
		}

		public Owner CreateOwner(Owner newOwner)
		{
			var own = _psc.Owners.Add(newOwner).Entity;
			_psc.SaveChanges();
			return own;
		}

		public Owner ReadById(int id)
		{
			return _psc.Owners
				.FirstOrDefault(o => o.Id == id);
		}
		

		public IEnumerable<Owner> ReadAll()
		{
			return _psc.Owners;
		}

		public Owner UpdateOwner(Owner UpdatedOwner)
		{
			throw new System.NotImplementedException();
		}

		public Owner DeleteOwner(int id)
		{
			var PetsToRemove = _psc.Pets.Where(p => p.Owner.Id == id);
			_psc.RemoveRange(PetsToRemove);
			var OwnerRemoved = _psc.Remove(new Owner {Id = id}).Entity;
			_psc.SaveChanges();
			return OwnerRemoved;
		}

		public Owner ReadyByIdIncludePets(int id)
		{
			return _psc.Owners
				.Include(o => o.Pets)
				.FirstOrDefault(o => o.Id == id);
		}
	}
}
