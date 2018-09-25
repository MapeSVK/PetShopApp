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
			_psc.Attach(UpdatedOwner).State = EntityState.Modified;
			_psc.Entry(UpdatedOwner).Collection(o => o.Pets).IsModified = true;
			_psc.SaveChanges();

			return UpdatedOwner;
		}

		public Owner DeleteOwner(int id)
		{
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
