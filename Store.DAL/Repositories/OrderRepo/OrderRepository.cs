using Microsoft.EntityFrameworkCore;
using Store.DAL.Data.Context;
using Store.DAL.Data.Entity;
using Store.DAL.Repositories.IGenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories.OrderRepo
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		private readonly ApplicationDbContext _context;

		public OrderRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public IEnumerable<Order> GetAllUserOrederNoData(string userid)
		{
			return _context.Set<Order>().Where(o=>o.UserId== userid).ToList();
		}

		public IEnumerable<Order> GetAllUserOrederWithData(string userid)
		{
			return _context.Set<Order>().Include(x => x.OrdersProductsDetails).Where(o => o.UserId == userid).ToList();

		}

		public int GetLastUserOrder(string userid)
		{
			return _context.Set<Order>()
						.Where(o => o.UserId == userid)
						.OrderByDescending(o => o.OrderDate)
						.First().Id;
		}

		public Order GetOrderById(int orderid, string userid)
		{
			return _context.Set<Order>().Include(x=>x.OrdersProductsDetails).FirstOrDefault(x=>x.Id==orderid && x.UserId==userid);
		}
	}
}
