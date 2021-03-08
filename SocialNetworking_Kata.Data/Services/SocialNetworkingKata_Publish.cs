using SocialNetworking_Kata.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworking_Kata.Data.Services
{
	public class SocialNetworkingKata_Publish : ISocialNetworkingKata_Publish, IDisposable
	{		
		private SocialNetworkingKata_UserProfileDbContext SocialNetworkingKata_PublishDbContext;

		public SocialNetworkingKata_Publish(SocialNetworkingKata_UserProfileDbContext socialNetworkingKata_PublishDbContext)
		{
			this.SocialNetworkingKata_PublishDbContext = socialNetworkingKata_PublishDbContext;
		}

		public void Add(Publish publish)
		{
			SocialNetworkingKata_PublishDbContext.Publish.Add(publish);
			SocialNetworkingKata_PublishDbContext.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// dispose resources when needed
			}
		}

		public IEnumerable<Publish> Get(int id)
		{			
			var test = SocialNetworkingKata_PublishDbContext.UserProfile.FirstOrDefault(username => username.UserId == id);
			return SocialNetworkingKata_PublishDbContext.Publish.Where(User => User.UserPublishId == id);			
		}

		public IEnumerable<Publish> GetAll()
		{
			return SocialNetworkingKata_PublishDbContext.Publish;
		}
	}
}
