using Store.DAL.Data.Context;
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
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		public ICategoryRepository CategoryRepository { get; }

		public IProductRepository ProductRepository { get; }
		public IUserRepository UserRepository { get; }
		public ICartRepository CartRepository { get; }
		public IOrderRepository OrderRepository { get; }
		public IOrderProductsRepository OrderProductsRepository { get; }

		public UnitOfWork(ApplicationDbContext context,ICategoryRepository categoryRepository, IProductRepository productRepository, IUserRepository userRepository, ICartRepository cartRepository,IOrderRepository orderRepository, IOrderProductsRepository orderProductsRepository)
        {
			_context=context;
			CategoryRepository=categoryRepository;
			ProductRepository=productRepository;
			UserRepository= userRepository;
			CartRepository=cartRepository;
			OrderRepository=orderRepository;
			OrderProductsRepository=orderProductsRepository;
		}

		public int SaveChanges()
		{
			return _context.SaveChanges();
		}
	}
}
