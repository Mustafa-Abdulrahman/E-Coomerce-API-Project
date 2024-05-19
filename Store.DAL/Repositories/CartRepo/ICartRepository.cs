using Store.DAL.Data.Entity;
using Store.DAL.Repositories.IGenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories.CartRepo
{
	public interface  ICartRepository:IGenericRepository<CartItems>
	{
		IEnumerable<CartItems> GetAllUserCart(string userId);
		CartItems GetCartById(int id, string userId);
		void DeleteCartItem(int id,string userid);
		void DeleteAllCart(string userid);
		void UpdateUserCart(int id, string userid,CartItems cart);

	}
}
