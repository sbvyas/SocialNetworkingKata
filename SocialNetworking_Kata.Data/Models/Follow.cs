using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworking_Kata.Data.Models
{
	public class Follow
	{
		[Key()]
		public int FollowId { get; set; }
		public int? UserFollowId { get; set; }
		[ForeignKey("UserFollowId")]
		public virtual UserProfile UserProfile { get; set; }
	}
}
