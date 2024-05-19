using Store.DAL.Data.Entity;
using Store.DAL.Repositories.IGenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories.OrderRepo
{
	public interface IOrderRepository:IGenericRepository<Order>
	{
		 IEnumerable<Order> GetAllUserOrederWithData(string userid);
		 IEnumerable<Order> GetAllUserOrederNoData(string userid);
		Order GetOrderById(int orderid, string userid); 
		int GetLastUserOrder(string userid);

		
	}
}
