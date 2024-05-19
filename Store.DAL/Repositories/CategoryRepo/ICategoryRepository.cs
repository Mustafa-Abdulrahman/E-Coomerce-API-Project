using Store.DAL.Data.Entity;
using Store.DAL.Repositories.IGenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories.CategoryRepo
{
	public interface ICategoryRepository : IGenericRepository<Category>
	{
	}
}
