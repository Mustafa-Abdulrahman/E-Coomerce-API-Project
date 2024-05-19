using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Data.Entity
{
	public class BaseEntity<T>
	{
		
		public T Id { get; set; }
	}
}
