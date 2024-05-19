using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Data.Entity
{
	public enum userRole
	{
		Customer,
		Admin
	}
	public class AppUser:IdentityUser
	{
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public string Region { get; set; } = string.Empty;
		public string PostalCode { get; set; } = string.Empty;
		public string Country { get; set; }  = string.Empty;
		public userRole Role { get; set; }  = userRole.Customer;
		public IEnumerable<CartItems> CartItems { get; set; }=new HashSet<CartItems>();
	}
}
