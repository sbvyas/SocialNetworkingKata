using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworking_Kata.Data.Models
{
	public class Publish
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
		public int PublishId { get; set; }
		public int? UserPublishId { get; set; }
		[ForeignKey("UserPublishId")]
		public virtual UserProfile UserProfile { get; set; }

		[Required]
		[MaxLength(150)]
		public string PublishContent { get; set; }
		public DateTime CreatedTime { get; set; }
	}
}
