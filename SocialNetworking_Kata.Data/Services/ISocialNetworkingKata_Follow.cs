using SocialNetworking_Kata.Data.Models;
using System.Collections.Generic;

namespace SocialNetworking_Kata.Data.Services
{
	public interface ISocialNetworkingKata_Follow
	{
		IEnumerable<Follow> GetAll();
		Follow Get(int id);
		void Add(Follow follower);
		void Delete(int id);
	}
}
