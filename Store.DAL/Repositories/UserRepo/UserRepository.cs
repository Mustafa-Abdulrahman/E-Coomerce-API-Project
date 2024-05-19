using Store.DAL.Data.Context;
using Store.DAL.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories.UserRepo
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
			_context=context;

		}
        public void Delete(AppUser user)
		{
		_context.Set<AppUser>().Remove(user);
		}

		public AppUser GetById(string id)
		{
			return _context.Set<AppUser>().FirstOrDefault(x => x.Id==id);

		}

		public void Update(AppUser user)
		{
			_context.Set<AppUser>().Update(user);
		}
	}
}
