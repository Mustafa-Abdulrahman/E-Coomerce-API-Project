using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Dto
{
	public class CategoryGet
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

	}
	public class CategoryGetWithData
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public IEnumerable<ProductGet> Products { get; set; } 

	}
	public class CategorySet
	{
		public string Name { get; set; } = string.Empty;

	}
	public class CategoryUpdate
	{
		public string Name { get; set; } = string.Empty;

	}
	public class CategoryDelete
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

	}
}
