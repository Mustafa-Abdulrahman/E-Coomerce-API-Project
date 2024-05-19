using Store.BL.Dto.Orders;
using Store.DAL.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Managers.Orders
{
	public interface IOrderManager
	{
		List<OrderGetDto> GetOrderNoData(string userid);
		OrderGetDto GetOrderById(int orderid, string userid);
		bool AddOrder( string userid);
		bool UpdateOrder(int orderid, string userid, int status, DateTime deliverdata);
		List<OrderProductsDetails> allOrderProduct(int orderid);
	}
}
