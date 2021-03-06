using System.Collections.Generic;
using System.Linq;
using Core.DomainService;
using Entities;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Database
{
	public class PetRepository : IPetRepository
	{
		readonly PetShopAppContext _psc;

		public PetRepository(PetShopAppContext psc)
		{
			_psc = psc;
		}

		public IEnumerable<Pet> ReadAllPets(Filter filter)
		{
			if (filter == null)
			{
				return _psc.Pets;
			}

			return _psc.Pets
				.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
				.Take(filter.ItemsPrPage)
				.OrderBy(p => p.Price);

		}

		public Pet UpdatePet(Pet updatedPet)
		{
			_psc.Attach(updatedPet).State = EntityState.Modified;
			_psc.Entry(updatedPet).Reference(p => p.Owner).IsModified = true;
			_psc.SaveChanges();

			return updatedPet;
		}

		public Pet RemovePet(int id)
		{
			var removed = _psc.Remove(new Pet {Id = id}).Entity;
			_psc.SaveChanges();
			return removed;
		}

		public Pet Add(Pet newPet)
		{
			_psc.Attach(newPet).State = EntityState.Added;
			_psc.SaveChanges();
			return newPet;

		}

		public Pet GetPetById(int id)
		{
			return _psc.Pets.Include(p => p.Owner).FirstOrDefault(p => p.Id == id);
		}

		public int Count()
		{
			return _psc.Pets.Count();
		}
	}
}
