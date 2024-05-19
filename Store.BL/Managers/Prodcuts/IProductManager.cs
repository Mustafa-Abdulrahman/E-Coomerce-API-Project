using Store.BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Managers.Prodcuts
{
	public interface IProductManager
	{
		IEnumerable<ProductGet> GetAllProducts();

		ProductGet GetProductById(int id);

		bool AddProduct(ProductSet pro);
		bool DeleteProduct(int proId);
		bool UpdateProduct(int proId, ProductUpdate pro);
	}
}
