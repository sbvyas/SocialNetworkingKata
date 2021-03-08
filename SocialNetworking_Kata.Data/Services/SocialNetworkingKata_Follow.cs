using SocialNetworking_Kata.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworking_Kata.Data.Services
{
	public class SocialNetworkingKata_Follow : ISocialNetworkingKata_Follow, IDisposable
	{
		private SocialNetworkingKata_UserProfileDbContext SocialNetworkingKata_FollowDbContext;

		public SocialNetworkingKata_Follow(SocialNetworkingKata_UserProfileDbContext socialNetworkingKata_FollowDbContext)
		{
			this.SocialNetworkingKata_FollowDbContext = socialNetworkingKata_FollowDbContext;
		}
		public void Add(Follow follower)
		{
			SocialNetworkingKata_FollowDbContext.Follow.Add(follower);
			SocialNetworkingKata_FollowDbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var removefollower = SocialNetworkingKata_FollowDbContext.Follow.Find(id);
			if (removefollower == null)
			{
				//throw new HttpRequestException("Record not found : " + HttpStatusCode.NotFound);
			}
			else
			{
				SocialNetworkingKata_FollowDbContext.Follow.Remove(removefollower);
				SocialNetworkingKata_FollowDbContext.SaveChanges();
			}
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

		public Follow Get(int id)
		{			
			return SocialNetworkingKata_FollowDbContext.Follow.FirstOrDefault(User => User.UserFollowId == id);
		}

		public IEnumerable<Follow> GetAll()
		{
			return SocialNetworkingKata_FollowDbContext.Follow;
		}
	}
}
