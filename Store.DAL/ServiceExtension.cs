using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.DAL.Data.Context;
using Store.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Repositories.ProductRepo;
using Store.DAL.Repositories.CategoryRepo;
using Store.DAL.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Store.DAL.Repositories.UserRepo;
using Store.DAL.Repositories.CartRepo;
using Store.DAL.Repositories.OrderRepo;
using Store.DAL.Repositories.OrderPrductsRepo;

namespace Store.DAL
{
	public static class ServiceExtension
	{
		public static void AddDALService(this IServiceCollection service, IConfiguration config)
		{
			var connectionString = config.GetConnectionString("cs");
			service.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));
			service.AddScoped<IProductRepository, ProductRepository>();
			service.AddScoped<ICategoryRepository, CategoryRepository>();
			service.AddScoped<IUserRepository, UserRepository>();
			service.AddScoped<ICartRepository, CartRepository>();
			service.AddScoped<IUnitOfWork, UnitOfWork>();
			service.AddScoped<IOrderRepository, OrderRepository>();
			service.AddScoped<IOrderProductsRepository, OrderProductsRepository>();
			service.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
		}
	}
}
