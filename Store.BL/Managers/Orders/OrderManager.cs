using Store.BL.Dto.Orders;
using Store.DAL;
using Store.DAL.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Managers.Orders
{
	public class OrderManager : IOrderManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public OrderManager(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}
        public bool AddOrder(string userid)
		{
			//Order recievedOrder = new Order()
			//{
			//	Status = 0,
			//	OrderDate = DateTime.Now,
			//	DeliverdDate = DateTime.Now.AddDays(3),
			//	UserId = userid,
			//	TotalPrice = 0,

			// };
			//_unitOfWork.OrderRepository.Add(recievedOrder);
			//_unitOfWork.SaveChanges();

			//int lastOrderId = _unitOfWork.OrderRepository.GetLastUserOrder(userid);
			//IEnumerable<CartItems> cartItems = _unitOfWork.CartRepository.GetAllUserCart(userid);

			//IEnumerable<OrderProductsDetails> orderProducts = cartItems.Select(x => new OrderProductsDetails()
			//{
			//	ProductId = x.ProductId,
			//	OrderId = lastOrderId,
			//	Quantity = x.Quantity,
			//	PriceAtThisItem = x.Price,

			//});
			////orderProducts.Select(x => x.Quantity * x.PriceAtThisItem).Sum();
			//decimal total = 0;
			//foreach(OrderProductsDetails item in orderProducts)
			//{
			//	total  += item.PriceAtThisItem * item.Quantity;
			//}
			////Order lastRecievedOrder = new Order()
			////{
			////	Status = 0,
			////	OrderDate = DateTime.Now,
			////	DeliverdDate = DateTime.Now.AddDays(3),
			////	UserId = userid,
			////	TotalPrice = total,
			////	OrdersProductsDetails = cartItems.Select(x => new OrderProductsDetails()
			////	{
			////		ProductId = x.ProductId,
			////		OrderId = lastOrderId,
			////		Quantity = x.Quantity,
			////		PriceAtThisItem = x.Price,

			////	})

			////};
			//foreach(OrderProductsDetails item in orderProducts)
			//{
			//	OrderProductsDetails newItem = item;
			//	_unitOfWork.OrderProductsRepository.Add(newItem);
			//}

			////_unitOfWork.OrderRepository.Update(lastOrderId, lastRecievedOrder);
			//return _unitOfWork.SaveChanges() > 0;

			// Create a new order
			Order recievedOrder = new Order()
			{
				Status = 0,
				OrderDate = DateTime.Now,
				DeliverdDate = DateTime.Now.AddDays(3),
				UserId = userid,
				TotalPrice = 0
			};

			// Add the order to the repository
			_unitOfWork.OrderRepository.Add(recievedOrder);
			_unitOfWork.SaveChanges();

			// Retrieve the last order ID for the user
			int lastOrderId = recievedOrder.Id; // Assuming the ID is auto-generated and updated

			// Get all cart items for the user
			IEnumerable<CartItems> cartItems = _unitOfWork.CartRepository.GetAllUserCart(userid);

			// Initialize total price
			decimal total = 0;

			// Create a list to hold valid order product details
			List<OrderProductsDetails> orderProducts = new List<OrderProductsDetails>();

			// Iterate over the cart items
			foreach (var cartItem in cartItems)
			{
				// Check if the ProductId exists in the Products table
				var product = _unitOfWork.ProductRepository.GetById(cartItem.ProductId);
				if (product != null)
				{
					// Add the order product detail
					OrderProductsDetails orderProduct = new OrderProductsDetails()
					{
						ProductId = cartItem.ProductId,
						OrderId = lastOrderId,
						Quantity = cartItem.Quantity,
						PriceAtThisItem = cartItem.Price
					};
					orderProducts.Add(orderProduct);

					// Calculate the total price
					total += cartItem.Price * cartItem.Quantity;
				}
			}

			// Add the order product details to the repository
			foreach (var orderProduct in orderProducts)
			{
				_unitOfWork.OrderProductsRepository.Add(orderProduct);
			}

			// Update the total price of the order
			recievedOrder.TotalPrice = total;
			_unitOfWork.OrderRepository.Update(recievedOrder.Id,recievedOrder);

			// Save changes to the database
			return _unitOfWork.SaveChanges() > 0;

		}
		//
		public List<OrderProductsDetails> allOrderProduct(int orderid)
		{
			return _unitOfWork.OrderProductsRepository.getAllOrderProducts(orderid).ToList();
		}
		//
		public OrderGetDto GetOrderById(int orderid, string userid)
		{
			Order FoundOrder =  _unitOfWork.OrderRepository.GetOrderById(orderid, userid);
			if (FoundOrder is null)
				return null;
			OrderGetDto order = new OrderGetDto()
			{
				Id = FoundOrder.Id,
				UserId = FoundOrder.UserId,
				TotalPrice = FoundOrder.TotalPrice,
				OrdersProductsDetails = FoundOrder.OrdersProductsDetails.Select(x => new OrderProductsGetDto() {
					Id = x.Id,
					ProductId = x.ProductId,
					OrderId = x.OrderId,
					Quantity = x.Quantity,


				}).ToList(),
				OrderDate = FoundOrder.OrderDate,
				Status = FoundOrder.Status,
				DeliverdDate = FoundOrder.DeliverdDate

			};
			return order;
		}

		public List<OrderGetDto> GetOrderNoData(string userid)
		{
			IEnumerable<Order> allOrder =  _unitOfWork.OrderRepository.GetAllUserOrederNoData(userid);
			if (allOrder is null || !allOrder.Any())
				return null;
			var result = allOrder.Select(x => new OrderGetDto() {
				Id = x.Id,
				UserId = x.UserId,
				TotalPrice = x.TotalPrice,
				OrdersProductsDetails =null,
				OrderDate = x.OrderDate,
				Status = x.Status,
				DeliverdDate = x.DeliverdDate

			});
			return result.ToList() ;
		}

		

		public bool UpdateOrder(int orderid, string userid, int status, DateTime deliverdata)
		{
			Order recievedOrder = _unitOfWork.OrderRepository.GetOrderById(orderid, userid);
			if (recievedOrder is null)
				return false;
			recievedOrder.Status = (OrderStatus)status;
			recievedOrder.DeliverdDate = deliverdata;

			return _unitOfWork.SaveChanges() > 0;
				
		}
	}
}
