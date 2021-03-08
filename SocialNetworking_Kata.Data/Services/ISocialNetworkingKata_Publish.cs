using SocialNetworking_Kata.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworking_Kata.Data.Services
{
	public interface ISocialNetworkingKata_Publish
	{
		IEnumerable<Publish> GetAll();
		IEnumerable<Publish> Get(int id);
		void Add(Publish publish);
	}
}
