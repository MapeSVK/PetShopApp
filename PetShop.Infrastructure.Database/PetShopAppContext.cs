using Entities;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entities;

namespace PetShop.Infrastructure.Database
{
	public class PetShopAppContext : DbContext
	{
		public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) 
			: base(opt) { }

		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Pet>()
				.HasOne(p => p.Owner)
				.WithMany(o => o.Pets)
				.OnDelete(DeleteBehavior.SetNull);
		}

		public DbSet<Pet> Pets { get; set; }
		public DbSet<Owner> Owners { get; set; }
	}
}
