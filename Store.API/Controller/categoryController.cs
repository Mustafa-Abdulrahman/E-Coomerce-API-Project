using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BL.Dto;
using Store.BL.Managers.Categories;

namespace Store.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class categoryController : ControllerBase
	{
		private readonly ICategoryManager cateManager;

		public categoryController(ICategoryManager cateManager)
        {
			this.cateManager = cateManager;
		}

		[HttpGet("allCategoryNoData")]
		public IActionResult GetAllCategory() { 
		
			IEnumerable< CategoryGet> result = cateManager.GetAllCategory();
			if (result is null)
				return NotFound("No Data Found");
			return Ok(result);
		}
		[HttpGet("allCategoryWithData")]
		public IActionResult GetAllCategoryWithData() {
			IEnumerable<CategoryGetWithData> result = cateManager.GetAllCategoryWithData();
			if (result is null)
				return NotFound("No Data Found");
			return Ok(result);
		}

		[HttpGet("CategiryByIdNoData/{id}")]
		public IActionResult GetCategoryById(int id) {

			CategoryGet result = cateManager.GetCategoryById(id);
			if (result is null)
				return NotFound($"Category With Id {id} Not Found");
			return Ok(result);
		
		}

		[HttpGet("CategiryByIdWithData/{id}")]
		public IActionResult GetCategoryByIdWithData(int id)
		{

			CategoryGetWithData result = cateManager.GetCategoryByIdWithData(id);
			if (result is null)
				return NotFound($"Category With Id {id} Not Found");
			return Ok(result);

		}

		[HttpPost("addCategory")]
		public IActionResult AddCategory(CategorySet cate)
		{
				var result = cateManager.AddCategory(cate);
			if(result is false)
				return BadRequest("Error In Add Category Happend");
			return Ok(result);
		}

		[HttpDelete("updateCategory/{id}")]
		public IActionResult DeleteCategory(int id)
		{

			var result = cateManager.DeleteCategory(id);
			if(result is false)
				return BadRequest()
					; return Ok(result);
		}
		[HttpPut("deleteCategory/{id}")]
		public IActionResult UpdateCategory(int id, CategoryUpdate cate)
		{

			var result = cateManager.UpdateCategory(id,cate);
			if (result is false)
				return BadRequest()
					; return Ok(result);
		}
	}
}
