using SocialNetworking_Kata.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworking_Kata.Data.Services
{
	public class SocialNetworkingKata_UserProfileDbContext : DbContext
	{
		public DbSet<UserProfile> UserProfile { get; set; }
		public DbSet<Publish> Publish { get; set; }
		public DbSet<Follow> Follow { get; set; }
	}
}
