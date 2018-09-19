using System;
using Entities;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Database
{
	public class DBInitializer
	{
		public static void SeedDB(PetShopAppContext psc)
		{
			psc.Database.EnsureDeleted();
			psc.Database.EnsureCreated();
			
			var owner1 = psc.Owners.Add(new Owner()
			{
				Address = "Tvoja mamka 55",
				FirstName = "Mi",
				LastName = "ttt"
			}).Entity;
                    
			var owner2 = psc.Owners.Add(new Owner()
			{
				Address = "Tvojdsadda mamka 55",
				FirstName = "Maaaai",
				LastName = "yyy"
			}).Entity;
                    
			psc.Pets.Add(new Pet()
			{
				Color = "black",
				Name = "Macka",
				Owner = owner1,
				Price = 122,
				Type = "dog",
				BirthDate = DateTime.Now,
				SoldDate = DateTime.Now
			});
			psc.Pets.Add(new Pet()
			{
				Color = "red",
				Name = "doggggggoo",
				Owner = owner1,
				Price = 12222,
				Type = "doddddg",
				BirthDate = DateTime.Now,
				SoldDate = DateTime.Now
			});
			psc.Pets.Add(new Pet()
			{
				Color = "blue",
				Name = "krava",
				Owner = owner2,
				Price = 122,
				Type = "cat",
				BirthDate = DateTime.Now,
				SoldDate = DateTime.Now
			});
			psc.SaveChanges();
		}
	}
}
