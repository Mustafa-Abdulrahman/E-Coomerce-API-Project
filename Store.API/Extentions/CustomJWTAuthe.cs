﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Store.API.Extentions
{
	public static class CustomJWTAuthe
	{
		public static void AddCustomJwtAuth(this IServiceCollection services, IConfiguration _config)
		{

			services.AddAuthentication(option =>
			{
				option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(
					op =>
					{
						op.RequireHttpsMetadata = false;
						op.SaveToken = true;
						op.TokenValidationParameters = new TokenValidationParameters()
						{

							IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"])),
							ValidateIssuer = false,
							ValidateAudience = false,
						};
					}
					);

			services.AddAuthorization(options =>
			{
				options.AddPolicy("ForCustomer", policy =>
				{
					policy.RequireClaim(ClaimTypes.Role, "Customer");
				});

				options.AddPolicy("ForAdmin", policy =>
				{
					policy.RequireClaim(ClaimTypes.Role, "Admin");
				});
			});

		}



	}
}
