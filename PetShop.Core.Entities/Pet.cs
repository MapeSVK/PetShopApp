using System;
using PetShop.Core.Entities;

namespace Entities
{
	public class Pet
	{

		public int Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public DateTime BirthDate { get; set; }
		public DateTime SoldDate { get; set; }
		public string Color { get; set; }
		public Owner Owner { get; set; }
		public double Price { get; set; }

        
   	}
}
