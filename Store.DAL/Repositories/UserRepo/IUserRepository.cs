using Store.DAL.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories.UserRepo
{
	public interface IUserRepository
	{
		AppUser? GetById(string id);
		void Update(AppUser user);
		void Delete(AppUser user);

	}
}
