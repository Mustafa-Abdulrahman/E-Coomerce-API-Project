using Store.DAL.Repositories.CartRepo;
using Store.DAL.Repositories.CategoryRepo;
using Store.DAL.Repositories.OrderPrductsRepo;
using Store.DAL.Repositories.OrderRepo;
using Store.DAL.Repositories.ProductRepo;
using Store.DAL.Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL
{
	public interface IUnitOfWork
	{
		 ICategoryRepository CategoryRepository { get; }
		 IProductRepository ProductRepository { get; }
		 IUserRepository UserRepository { get; }
		 ICartRepository CartRepository { get; }
		 IOrderRepository OrderRepository { get; }
		 IOrderProductsRepository OrderProductsRepository { get; }
		int SaveChanges();
	}
}
