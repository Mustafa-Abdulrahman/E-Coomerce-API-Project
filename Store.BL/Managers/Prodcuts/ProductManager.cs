using Store.BL.Dto;
using Store.DAL;
using Store.DAL.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.BL.Managers.Prodcuts
{
	public class ProductManager : IProductManager
	{
		private readonly IUnitOfWork _unitOfWork;
		public ProductManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

		}
		public bool AddProduct(ProductSet pro)
		{

			Product product = new Product()
			{
				
				Name = pro.Name,
				Description = pro.Description,
				Image = pro.Image,
				Price = pro.Price,
				Discount = pro.Discount,
				CategoryId = pro.CategoryId
			};
			_unitOfWork.ProductRepository.Add(product);
			return _unitOfWork.SaveChanges() > 0;
		}

		public bool DeleteProduct(int proId)
		{
			_unitOfWork.ProductRepository.Delete(proId);
			return _unitOfWork.SaveChanges() > 0;
		}

		public IEnumerable<ProductGet> GetAllProducts()
		{
			IEnumerable<Product> products = _unitOfWork.ProductRepository.GetAll();
			if (products is null)
				return null;
			var result = products.Select(pro => new ProductGet()
			{
				Id = pro.Id,
				Name = pro.Name,
				Description = pro.Description,
				Image = pro.Image,
				Price = pro.Price,
				Discount = pro.Discount,

			});
			return result;
		}

		public ProductGet GetProductById(int id)
		{
			Product pro = _unitOfWork.ProductRepository.GetById(id);
			if (pro is null)
				return null;
			ProductGet result = new ProductGet()
			{
				Id = pro.Id,
				Name = pro.Name,
				Description = pro.Description,
				Image = pro.Image,
				Price = pro.Price,
				Discount = pro.Discount,
			};
			return result;
		}

		public bool UpdateProduct(int proId, ProductUpdate pro)
		{
			Product product = _unitOfWork.ProductRepository.GetById(proId);
			if (product is null)
				return false;

			product.Name = pro.Name;
			product.Description = pro.Description;
			product.Image = pro.Image;
			product.Price = pro.Price;
			product.Discount = pro.Discount;
			product.CategoryId= pro.CategoryId;
			_unitOfWork.ProductRepository.Update( proId,product);
			return _unitOfWork.SaveChanges()>0;
		}
		
	}
}
