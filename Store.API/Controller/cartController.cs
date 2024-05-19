using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Dto;
using Store.BL.Dto.Cart;
using Store.BL.Managers;
using Store.DAL.Data.Entity;
using System.Security.Claims;

namespace Store.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class cartController : ControllerBase
	{
		private readonly ICartManager _cartManager;
		private readonly UserManager<AppUser> _userManager;

		public cartController(ICartManager cartManager,UserManager<AppUser> userManager)
        {
			_cartManager = cartManager;
			_userManager = userManager;
		}

		[HttpGet("getAllCart")]
		public async Task<IActionResult> GetAllCart()
		{
			var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
			var User = await _userManager.FindByEmailAsync(email);
			if (User == null)
				return BadRequest("Please Login");
			IEnumerable<CartItemGetDto> result = _cartManager.GetAll(User.Id);
			if (result is null || !result.Any())
				return Ok("Cart Is Empty");
			return Ok(result);

		}
		//
		[Authorize]
		[HttpPost("addItem/{quantity}")]
		public async Task<IActionResult> addItem(ProductGet product, int quantity)
		{
			var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
			var User = await _userManager.FindByEmailAsync(email);
			if (User == null)
				return BadRequest("Please Login");
			_cartManager.AddCartItem(User.Id, product, quantity);
			return Ok("Item Added Successfuly");
		}

		[HttpDelete("deleteAllCart")]
		public async Task<IActionResult> DeleteAll()
		{
			var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
			var User = await _userManager.FindByEmailAsync(email);
			if (User == null)
				return BadRequest("Please Login");

			_cartManager.DeleteAllCartItem(User.Id);
			return Ok("Cart Deleted Successfully");
		}

		[HttpDelete("deleteCartById/{id}")]
		public async Task<IActionResult> RemoveItemFromCart(int id)
		{

			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return BadRequest("Please Login");
			_cartManager.DeleteCartItem(id, user.Id);
			return Ok("Item With Id {id} Deleted Successfuly");
		}

		//Update
		[HttpPut("updateCartItem/{quantity}")]

		public IActionResult updateCartItem(CartItemGetDto product, int quantity)
		{
			bool reslut = _cartManager.UpdateMyCart(product.ProductId, product.UserId, quantity);
			if (reslut is false)
				return BadRequest();
			return Ok("Updated Successfuly");
		}
	}
}
