using Store.DAL.Data.Context;
using Store.DAL.Data.Entity;
using Store.DAL.Repositories.IGenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories.ProductRepo
{
	public class ProductRepository : GenericRepository<Product>,  IProductRepository
	{
		private readonly ApplicationDbContext _context;

		public ProductRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
