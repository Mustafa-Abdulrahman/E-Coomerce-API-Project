using Store.BL.Dto;
using Store.DAL;
using Store.DAL.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Managers.Categories
{
	public class CategoryManager : ICategoryManager
	{
		private readonly IUnitOfWork _unitOfWork;
        public CategoryManager(IUnitOfWork unitOfWork)
        {
			_unitOfWork=unitOfWork;

		}
        public bool AddCategory(CategorySet cate)
		{
			Category category = new Category()
			{
				Name = cate.Name,
			};
			_unitOfWork.CategoryRepository.Add(category);
			return _unitOfWork.SaveChanges()>0;


		}

		public bool DeleteCategory(int cateId)
		{
			_unitOfWork.CategoryRepository.Delete(cateId);
			return _unitOfWork.SaveChanges()>0;
		}

		public IEnumerable<CategoryGet> GetAllCategory()
		{
			IEnumerable<Category> categories = _unitOfWork.CategoryRepository.GetAll();
			var categoryGetDto = categories.Select(c => new CategoryGet() {
			Id = c.Id,
			Name = c.Name,

			});
			return categoryGetDto;
		}

		public IEnumerable<CategoryGetWithData> GetAllCategoryWithData()
		{
			IEnumerable<Category> categories = _unitOfWork.CategoryRepository.GetAllWithData(d=>d.Products);
			IEnumerable<CategoryGetWithData> categoryGetDto = categories.Select(c => new CategoryGetWithData()
			{
				Id = c.Id,
				Name = c.Name,
				Products = c.Products.Select(p=>new ProductGet()
				{
					Id = p.Id,
					Name = p.Name,
					Description = p.Description,
					Image = p.Image,
					Price = p.Price,
					Discount = p.Discount,
				})

			});
			return categoryGetDto;
		}

		public CategoryGet GetCategoryById(int id)
		{
			Category cate = _unitOfWork.CategoryRepository.GetById(id);
			if(cate is null)
			{
				return null;
			}
			CategoryGet result = new CategoryGet()
			{
				Id = cate.Id,
				Name = cate.Name

			}
			; return result;
		}

		public CategoryGetWithData GetCategoryByIdWithData(int id)
		{
			Category cate = _unitOfWork.CategoryRepository.GetById(id);
			if (cate is null)
			{
				return null;
			}
			CategoryGetWithData result = new CategoryGetWithData()
			{
				Id = cate.Id,
				Name = cate.Name,
				Products = cate.Products.Select(p=>new ProductGet() {
					Id = p.Id,
					Name = p.Name,
					Description = p.Description,
					Image = p.Image,
					Price = p.Price,
					Discount = p.Discount,
				})
				

			}
			; return result;
		}

		public bool UpdateCategory(int cateId, CategoryUpdate cate)
		{
			Category category = _unitOfWork.CategoryRepository.GetById(cateId);
            if (category is null)
            {
				return false;
            }
            category.Name = cate.Name;
			_unitOfWork.CategoryRepository.Update(cateId, category);
			return _unitOfWork.SaveChanges() > 0;
		}

		
	}
}
