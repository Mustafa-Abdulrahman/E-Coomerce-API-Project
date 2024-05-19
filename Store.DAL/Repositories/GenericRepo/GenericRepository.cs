using Microsoft.EntityFrameworkCore;
using Store.DAL.Data.Context;
using Store.DAL.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories.IGenericRepo
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity<int>
	{
		private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
			_context=context;

		}
        public void  Add(T entity)
		{
			 _context.Set<T>().AddAsync(entity);

		}

		public  void Delete(int id)
		{
			var item =  _context.Set<T>().FirstOrDefault(i=>i.Id==id);
			if (item is null)
				return;

			_context.Set<T>().Remove(item);

		}

		public IEnumerable<T> GetAll()
		{
			return  _context.Set<T>().AsNoTracking().ToList();
		}

		public  IEnumerable<T> GetAllWithData(params Expression<Func<T, object>>[] includes)
		{
			var query = _context.Set<T>().AsNoTracking().AsQueryable();
			foreach (var item in includes)
			{
				query = query.Include(item);
			}
			return  query.ToList();
		}

		public T GetById(int id)
		{
			var item =   _context.Set<T>().FirstOrDefault(i=>i.Id==id);

			if (item is null)
				return null;

			return item;
		}

		public T GetByIdWithData(int id, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = _context.Set<T>().Where(x => x.Id == id);
			foreach (var item in includes)
			{
				query = query.Include(item);
			}
			return  query.FirstOrDefault();
		}

		public void Update(int id, T entity)
		{
			var item =  _context.Set<T>().FirstOrDefault(i=>i.Id==id);
			if (entity is null)
				return ;

			_context.Set<T>().Update(item);
			
		}
	}
}
