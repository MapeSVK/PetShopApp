using System;
using System.Collections.Generic;
using Entities;

namespace PetShop.Core.Entities
{
	public class Owner
	{


		public int Id
		{
			get;
			set;
		}
		public string FirstName
		{
			get;
			set;
		}
		public string LastName
		{
			get;
			set;
		}
		public string Address
		{
			get;
			set;
		}
		public List<Pet> Pets { get; set; }
	}
}
