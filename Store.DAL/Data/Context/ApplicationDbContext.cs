using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Data.Context
{
	public class ApplicationDbContext:IdentityDbContext<AppUser>
	{
		public virtual DbSet<Product> Products => Set<Product>();
		public virtual DbSet<Category> Categories => Set<Category>();
		public virtual DbSet<CartItems> CartItems => Set<CartItems>();
		public virtual DbSet<Order> Order => Set<Order>();
		public virtual DbSet<OrderProductsDetails> OrderProductsDetails => Set<OrderProductsDetails>();

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			#region Product
			builder.Entity<Product>().HasKey(p => p.Id);
			builder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();
			builder.Entity<Product>().HasOne(p=>p.Category).WithMany(c=>c.Products).HasForeignKey(p=>p.CategoryId);
			builder.Entity<Product>().HasData(
				
				new Product {Id=7, Discount = 1, Name = "Sumsung Glaxy Young", Description = "Mobile Phone Sumsung, With 6inch Screen", Price = 10000m, CategoryId = 1, Image = "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1" },
				new Product {Id=1, Discount = 2, Name = "iPhone 13 Pro Max", Description = "Apple Flagship Phone with 6.7-inch Super Retina XDR Display", Price = 1099m, CategoryId = 1, Image = "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1" },
				new Product {Id=2, Discount = 3, Name = "Google Pixel 6 Pro", Description = "Google's Premium Android Phone with 6.7-inch LTPO OLED Display", Price = 899m, CategoryId = 1, Image = "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1" },
				new Product {Id=3, Discount = 4, Name = "OnePlus 10 Pro", Description = "High-End Android Phone by OnePlus with 6.7-inch Fluid AMOLED Display", Price = 899m, CategoryId = 1, Image = "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1" },
				new Product {Id=4, Discount = 5, Name = "Xiaomi Mi 12 Ultra", Description = "Xiaomi's Feature-Packed Phone with 6.8-inch AMOLED Display and Snapdragon 8 Gen 1 CPU", Price = 999m, CategoryId = 1, Image = "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1" },
				new Product {Id=5, Discount = 6, Name = "Sony Xperia 1 III", Description = "Sony's Premium Phone with 6.5-inch 4K HDR OLED Display and Snapdragon 888 CPU", Price = 1299m, CategoryId = 1, Image = "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1" },
				new Product {Id=6, Discount = 7, Name = "LG OLED C1", Description = "LG's Premium OLED TV with 65-inch 4K Display and Dolby Vision IQ", Price = 2499m, CategoryId = 2, Image = "https://sun6-21.userapi.com/s/v1/if1/YI03YQOyd2Y6rdAIsKyO6MaBqJSgq_-3PGuzDsdrvTKnpTDhadKeP7CfPDrpR00PKn4NYgFM.jpg?size=1696x1699&quality=96&crop=398,0,1696,1700&ava=1" }
			);
			#endregion
			#region Category
			builder.Entity<Category>().HasKey(c => c.Id);
			builder.Entity<Category>().Property(c => c.Id).ValueGeneratedOnAdd();

			builder.Entity<Category>().HasData(
				new { Id = 1,Name ="Phone"},
				new { Id = 2,Name ="Tv"},
				new { Id = 3, Name ="Labtop"}
				);
			#endregion

		}
	}
}
