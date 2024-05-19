using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories.IGenericRepo
{
	public interface IGenericRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Add(T entity);
		void Update(int id, T entity);
		void Delete(int id);
		IEnumerable<T> GetAllWithData(params Expression<Func<T, object>>[] includes);
		T GetByIdWithData(int id, params Expression<Func<T, object>>[] includes);


	}
}
