using SocialNetworking_Kata.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworking_Kata.Data.Services
{
	public class InMemorySocialNetworkingKata_UserProfile : ISocialNetworkingKata_UserProfile
	{
		List<UserProfile> userprofiles;
		
		public InMemorySocialNetworkingKata_UserProfile()
		{
			userprofiles = new List<UserProfile>()
			{
				new UserProfile{UserId = 1, UserFirstName = "Alice", UserLastName = "Shivani" },
				new UserProfile{UserId = 2, UserFirstName = "Bob", UserLastName = "Ronaldo" },
				new UserProfile{UserId = 3, UserFirstName = "Charlie", UserLastName = "Cheplin"  }
			};
		}

		public void Add(UserProfile userprofile)
		{
			userprofiles.Add(userprofile);
		}

		public void Delete(int id)
		{
			var userprofile = Get(id);
			if (userprofile != null)
				userprofiles.Remove(userprofile);
		}

		public UserProfile Get(int id)
		{
			return userprofiles.FirstOrDefault(user => user.UserId == id);
		}

		public IEnumerable<UserProfile> GetAll()
		{
			return userprofiles.OrderBy(users => users.UserFirstName);
		}

		public IEnumerable<UserProfile> GetAll(int id)
		{
			yield return userprofiles.FirstOrDefault(user => user.UserId == id);
		}

		public void Update(UserProfile userprofile)
		{
			var update = Get(userprofile.UserId);
			if(update != null)
			{
				update.UserFirstName = userprofile.UserFirstName;
				update.UserLastName = userprofile.UserLastName;
			}
		}
	}
}
