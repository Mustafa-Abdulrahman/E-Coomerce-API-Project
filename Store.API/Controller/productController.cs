using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Dto;
using Store.BL.Managers.Prodcuts;

namespace Store.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class productController : ControllerBase
	{
		private readonly IProductManager productManager;

		public productController(IProductManager productManager)
		{
			this.productManager = productManager;
		}
		[HttpGet("allProduct")]
		public IActionResult GetAllProduct() {
			IEnumerable<ProductGet> result = productManager.GetAllProducts();
			if (result is null)
				return NotFound("No Data Found");
			return Ok(result);

		}
		[HttpGet("getById/{id}")]
		public IActionResult GetProductById(int id ) {
			ProductGet product = productManager.GetProductById(id);
			if (product is null)
				return Ok($"Product With Id {id} Not Found");

			return Ok(product);
		}

		[HttpPost("addProduct")]
		public IActionResult AddProduct(ProductSet pro)
		{
			var result = productManager.AddProduct(pro);
			if(result is false)
				return BadRequest();
			return Ok(result);
		}
		[HttpPut("updateProduct/{id}")]
		public IActionResult UpdateProduct(int id, ProductUpdate pro)
		{
			var result = productManager.UpdateProduct(id,pro);
			return Ok(result);
		}
		[HttpDelete("deleteProduct/{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var result = productManager.DeleteProduct(id);
			return Ok(result);
		}
	}
}
