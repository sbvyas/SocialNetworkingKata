using SocialNetworking_Kata.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SocialNetworking_Kata.Data.Services
{
	public class SocialNetworkingKata_UserProfile : ISocialNetworkingKata_UserProfile, IDisposable
	{
		private SocialNetworkingKata_UserProfileDbContext SocialNetworkingKata_UserProfileDbContext;

		public SocialNetworkingKata_UserProfile(SocialNetworkingKata_UserProfileDbContext socialNetworkingKata_UserProfileDbContext)
		{
			this.SocialNetworkingKata_UserProfileDbContext = socialNetworkingKata_UserProfileDbContext;
		}

		public void Add(UserProfile userprofile)
		{
			SocialNetworkingKata_UserProfileDbContext.UserProfile.Add(userprofile);
			SocialNetworkingKata_UserProfileDbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var removeuserprofile = SocialNetworkingKata_UserProfileDbContext.UserProfile.Find(id);
			if (removeuserprofile == null)
			{
				//throw new HttpRequestException("Record not found : " + HttpStatusCode.NotFound);
			}
			else
			{
				SocialNetworkingKata_UserProfileDbContext.UserProfile.Remove(removeuserprofile);
				SocialNetworkingKata_UserProfileDbContext.SaveChanges();
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

		public UserProfile Get(int id)
		{
			return SocialNetworkingKata_UserProfileDbContext.UserProfile.FirstOrDefault(User => User.UserId == id);
		}

		public IEnumerable<UserProfile> GetAll()
		{
			return SocialNetworkingKata_UserProfileDbContext.UserProfile; 
		}

		public IEnumerable<UserProfile> GetAll(int id)
		{
			yield return SocialNetworkingKata_UserProfileDbContext.UserProfile.FirstOrDefault(User => User.UserId == id);
		}

		public void Update(UserProfile userprofile)
		{
			var updateuserprofile = SocialNetworkingKata_UserProfileDbContext.Entry(userprofile);
			updateuserprofile.State = EntityState.Modified;
			SocialNetworkingKata_UserProfileDbContext.SaveChanges();
		}
	}
}
