using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Store.BL.Dto;
using Store.BL.Dto.Cart;
using Store.DAL;
using Store.DAL.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Managers
{
	public class CartManager : ICartManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<AppUser> _userManager;
		public CartManager(IUnitOfWork unitOfWork,UserManager<AppUser> userManager)
		{
			_unitOfWork = unitOfWork;
			_userManager= userManager;

		}

		public bool AddCartItem(string userId, ProductGet product, int quantity)
		{
			if(product is null)
			{
				return false;
			}
			//check if item already exist
			CartItems checkIfItemExist = _unitOfWork.CartRepository.GetCartById(product.Id, userId);
			if(checkIfItemExist is not null)
			{
				CartItems updateItem = new CartItems()
				{
					UserId = checkIfItemExist.UserId,
					ProductId = checkIfItemExist.Id,
					ProductName = checkIfItemExist.ProductName,
					Quantity = checkIfItemExist.Quantity++,
					ProductImage = checkIfItemExist.ProductImage,
					Price = checkIfItemExist.Price,
					Discount = checkIfItemExist.Discount,
				};
				_unitOfWork.CartRepository.UpdateUserCart(updateItem.Id, userId, updateItem);
				
				return _unitOfWork.SaveChanges() > 0;
			}

			//
			CartItems cartItems = new CartItems()
			{
				UserId=userId,
				ProductId=product.Id,
				ProductName=product.Name,
				Quantity =quantity,
				ProductImage=product.Image,
				Price=product.Price,
				Discount=product.Discount,
			};
			_unitOfWork.CartRepository.Add(cartItems);
			return _unitOfWork.SaveChanges()>0;
		}

		public bool DeleteAllCartItem(string userid)
		{
			_unitOfWork.CartRepository.DeleteAllCart(userid);
			return _unitOfWork.SaveChanges() > 0;
		}

		public bool DeleteCartItem(int cartid, string userid)
		{
			
			_unitOfWork.CartRepository.DeleteCartItem(cartid, userid);
			return _unitOfWork.SaveChanges()>0;
		}

		public IEnumerable<CartItemGetDto> GetAll(string userid)
		{
			IEnumerable<CartItems> allCartItems = _unitOfWork.CartRepository.GetAllUserCart(userid);
			if (allCartItems is null)
				return null;

			var result = allCartItems.Select(cart => new CartItemGetDto()
			{
				Id = cart.Id,
				ProductId = cart.ProductId,
				ProductName = cart.ProductName,
				Quantity = cart.Quantity,
				Price = cart.Price,
				Discount = cart.Discount,
				ProductImage = cart.ProductImage,
				UserId = userid
			});	
			return result;
		}

		public bool UpdateMyCart(int proId, string userid, int quantity)
		{
			CartItems checkIfItemExist = _unitOfWork.CartRepository.GetCartById(proId, userid);
			if (checkIfItemExist is not null)
			{

				checkIfItemExist.UserId = checkIfItemExist.UserId;
				checkIfItemExist.Id = checkIfItemExist.Id;
				checkIfItemExist.ProductName = checkIfItemExist.ProductName;
				checkIfItemExist.Quantity = quantity;
				checkIfItemExist.ProductImage = checkIfItemExist.ProductImage;
				checkIfItemExist.Price = checkIfItemExist.Price;
				checkIfItemExist.Discount = checkIfItemExist.Discount;
				
				_unitOfWork.CartRepository.UpdateUserCart(proId, userid, checkIfItemExist);
				return _unitOfWork.SaveChanges() > 0;
			}
			return false;
		}
	}
}
