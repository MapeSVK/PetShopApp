using System;
using System.Collections.Generic;
using Entities;
using PetShop.Core.Entities;

namespace Data
{
	public class FakeDB
	{

		public static IEnumerable<Pet> Pets;
		public static IEnumerable<Owner> Owners;
		public static int OwnerId = 1;

		public static void InitData()
		{
			var FirstOwner = new Owner()
			{
				Id = OwnerId++,
				FirstName = "Daniel",
				LastName = "Henten",
				Address = "hehe2"

			};

			var SecondOwner = new Owner()
			{
				Id = OwnerId++,
				FirstName = "Daniel",
				LastName = "Henten",
				Address = "hehe2"

			};

			Owners = new List<Owner> { FirstOwner, SecondOwner};


			var pet1 = new Pet()
			{
				Id = 1,
				Name = "Tomek",
				Type = "Dog",
				BirthDate = DateTime.Parse("07/09/2017"),
				SoldDate = DateTime.Parse("07/11/2017"),
				Color = "Black",
				Owner = new Owner() { Id = 1 },
				Price = 1000

			};

			var pet2 = new Pet()
			{
				Id = 2,
				Name = "My Little Ponny",
				Type = "Ponny",
				BirthDate = DateTime.Parse("08/04/2016"),
				SoldDate = DateTime.Parse("08/12/2016"),
				Color = "Pink",
				Owner = new Owner() { Id = 2 },
				Price = 666

			};
			var pet3 = new Pet()
			{
				Id = 3,
				Name = "Doggi",
				Type = "Dog",
				BirthDate = DateTime.Parse("08/04/2014"),
				SoldDate = DateTime.Parse("08/12/2016"),
				Color = "Brown",
				Owner = new Owner() { Id = 1 },
				Price = 10

			};
			var pet4 = new Pet()
			{
				Id = 4,
				Name = "Fify",
				Type = "Cat",
				BirthDate = DateTime.Parse("08/04/2013"),
				SoldDate = DateTime.Parse("08/12/2015"),
				Color = "White",
				Owner = new Owner() { Id = 1 },
				Price = 25

			};
			var pet5 = new Pet()
			{
				Id = 5,
				Name = "Pipi",
				Type = "Ponny",
				BirthDate = DateTime.Parse("08/04/2015"),
				SoldDate = DateTime.Parse("08/12/2015"),
				Color = "Blue With Green Dots",
				Owner = new Owner() { Id = 2 },
				Price = 160000

			};
			var pet6 = new Pet()
			{
				Id = 6,
				Name = "Marin",
				Type = "Horse",
				BirthDate = DateTime.Parse("08/04/1997"),
				SoldDate = DateTime.Parse("08/12/2005"),
				Color = "Black",
				Owner = new Owner() { Id = 2 },
				Price = 2

			};
			Pets = new List<Pet> { pet1, pet2, pet3, pet4, pet5,pet6 };
		}
	}
}