using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Dto.User
{
	public class UserDto
	{
		[Required]
		public string email { get; set; }
		[Required]

		public string password { get; set; }
		[Required]

		public string firstName { get; set; }
		[Required]

		public string lastName { get; set; }

	}
	public class UserLoginDto
	{
		[Required]
		public string email { get; set; }
		[Required]

		public string password { get; set; }
	

	}
}
