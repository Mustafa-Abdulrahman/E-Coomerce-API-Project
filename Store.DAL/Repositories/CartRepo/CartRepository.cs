using Microsoft.EntityFrameworkCore;
using Store.DAL.Data.Context;
using Store.DAL.Data.Entity;
using Store.DAL.Repositories.IGenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.DAL.Repositories.CartRepo
{
	public class CartRepository : GenericRepository<CartItems>,ICartRepository
	{
		private readonly ApplicationDbContext _context;

		public CartRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void DeleteAllCart(string userid)
		{
			var items = _context.Set<CartItems>().Where(c=>c.UserId == userid).ToList();
            foreach (var item in items)
            {
				_context.Set<CartItems>().Remove(item);
            }
        }

		public void DeleteCartItem(int id, string userid)
		{
			CartItems item =  _context.Set<CartItems>().FirstOrDefault(c => c.Id == id && c.UserId == userid);
			_context.Set<CartItems>().Remove(item);
		}

		public IEnumerable<CartItems> GetAllUserCart(string userId)
		{
			return _context.Set<CartItems>().Where(ci=>ci.UserId==userId).ToList();
		}

		public CartItems GetCartById(int id, string userId)
		{
			return _context.Set<CartItems>().FirstOrDefault(c => c.ProductId == id && c.UserId == userId);
			
		}

		public void UpdateUserCart(int id, string userid, CartItems cart)
		{
			CartItems item =_context.Set<CartItems>().FirstOrDefault(c => c.ProductId == id && c.UserId == userid);
			_context.Set<CartItems>().Update(item);
		}
	}
}
