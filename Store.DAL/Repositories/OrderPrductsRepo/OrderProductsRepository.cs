using Store.DAL.Data.Context;
using Store.DAL.Data.Entity;
using Store.DAL.Repositories.IGenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories.OrderPrductsRepo
{
	internal class OrderProductsRepository : GenericRepository<OrderProductsDetails>, IOrderProductsRepository
	{
		private readonly ApplicationDbContext _context;
		public OrderProductsRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public IEnumerable<OrderProductsDetails> getAllOrderProducts(int orderId)
		{
			return _context.Set<OrderProductsDetails>().Where(x=>x.OrderId==orderId );
		}
	}
}
