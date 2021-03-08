using SocialNetworking_Kata.Data.Models;
using System.Collections.Generic;

namespace SocialNetworking_Kata.Data.Services
{
	public interface ISocialNetworkingKata_UserProfile
	{
		IEnumerable<UserProfile> GetAll();
		IEnumerable<UserProfile> GetAll(int id);
		UserProfile Get(int id);
		void Add(UserProfile userprofile);
		void Update(UserProfile userprofile);
		void Delete(int id);
	}
}
