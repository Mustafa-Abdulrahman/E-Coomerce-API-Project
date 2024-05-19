using Store.BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Managers.Categories
{
	public interface ICategoryManager
	{
		IEnumerable<CategoryGet> GetAllCategory();
		IEnumerable<CategoryGetWithData> GetAllCategoryWithData();
		CategoryGet GetCategoryById(int id);
		CategoryGetWithData GetCategoryByIdWithData(int id);
		bool AddCategory(CategorySet cate);
		bool DeleteCategory(int cateId);
		bool UpdateCategory(int cateId, CategoryUpdate cate);

	}
}
