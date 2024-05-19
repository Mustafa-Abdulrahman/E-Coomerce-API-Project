using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Store.BL.Managers;
using Store.BL.Managers.Categories;
using Store.BL.Managers.Orders;
using Store.BL.Managers.Prodcuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL
{
	public static class ServiceExtention
	{
		public static void AddBLServices(this IServiceCollection services)
		{
			services.AddScoped<IProductManager, ProductManager>();
			services.AddScoped<ICategoryManager, CategoryManager>();
			services.AddScoped<ICartManager, CartManager>();
			services.AddScoped<IOrderManager, OrderManager>();
		}
	}
}
