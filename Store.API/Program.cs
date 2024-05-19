
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Store.API.Extentions;
using Store.BL;
using Store.DAL;
namespace Store.API
{
	public class Program
	{
		public static void Main(string[] args)
		{

			var builder = WebApplication.CreateBuilder(args);
			#region CORS Policy
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAllDomains", policy =>
				{
					policy.AllowAnyOrigin()
						  .AllowAnyHeader()
						  .AllowAnyMethod();
				});
			});
			#endregion
			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddBLServices();
			builder.Services.AddDALService(builder.Configuration);
			builder.Services.AddCustomJwtAuth(builder.Configuration);
			
			//
			
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			var folderPath = Path.Combine(builder.Environment.ContentRootPath, "Assets");
			Directory.CreateDirectory(folderPath);

			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(folderPath),
				RequestPath = "/Assets"
			});
			app.UseHttpsRedirection();
			app.UseCors("AllowAllDomains");
			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
