using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Dto.Orders;
using Store.BL.Managers.Orders;
using Store.DAL.Data.Entity;

namespace Store.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class orderController : ControllerBase
	{
		private readonly IOrderManager _orderManager;
		private readonly UserManager<AppUser> _userManager;
        public orderController(IOrderManager orderManager, UserManager<AppUser> userManager)
        {
			_orderManager= orderManager;
			_userManager= userManager;

		}

		//
		[Authorize]
        [HttpGet("GetAllUserOrders")]
		public async Task<IActionResult> GetUserOrders()
		{
			AppUser CurrentUser = await _userManager.GetUserAsync(User);
			List<OrderGetDto> allOrders =  _orderManager.GetOrderNoData(CurrentUser.Id);
			if (allOrders is null || !allOrders.Any())
				return Ok("No Order");
			return Ok(allOrders);
		}

		//
		[Authorize]
		[HttpGet("GetOrderById/{id}")]
		public async Task<IActionResult> GetOrderById(int id)
		{
			AppUser CurrentUser = await _userManager.GetUserAsync(User);

			OrderGetDto selecedOrder = _orderManager.GetOrderById(id, CurrentUser.Id);
			if (selecedOrder is null)
				return Ok($"Order With {id} Not Found");
			return Ok(selecedOrder);
		}

		// 
		[Authorize]
		[HttpPost("AddOrder")]
		public async Task<IActionResult> addOrder()
		{
			AppUser CurrentUser = await _userManager.GetUserAsync(User);

			var result = _orderManager.AddOrder(CurrentUser.Id);
			if (!result)
				return BadRequest();
			return Ok("Order Added Successfuly");
		}
		//
		[Authorize]
		[HttpPut("updateOrder/{id}/{status}/{time}")]
		public async Task<IActionResult> updateorder(int id,int status, DateTime time)
		{
			AppUser CurrentUser = await _userManager.GetUserAsync(User);

			var result = _orderManager.UpdateOrder(id, CurrentUser.Id, status, time);
			if(!result)
				return BadRequest();
			return Ok("UpdatedSuccessfuly");
		}
		// get all procut in order by id
		[HttpGet("getAllProductInOrder/{id}")]
		public async Task<IActionResult> getAllProductInOrder(int id)
		{
			var result = _orderManager.allOrderProduct(id);
			if (result is null || !result.Any())
				return Ok("Order Is Empty");
			return Ok(result);

		}
		
	}
}
