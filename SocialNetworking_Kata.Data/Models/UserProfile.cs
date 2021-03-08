using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetworking_Kata.Data.Models
{
	public class UserProfile
	{
      [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
      public int UserId { get; set; }

      [Required]
      [MaxLength(50)]
      public string UserFirstName { get; set; }

      [Required]
      [MaxLength(50)]
		public string UserLastName { get; set; }
	}
}
