using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Data.Entity
{
	public class Product:BaseEntity<int>
	{
		public string Name { get; set; }= string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Image { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
