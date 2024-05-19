using Store.BL.Dto;
using Store.BL.Dto.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Managers
{
	public interface ICartManager
	{
		IEnumerable<CartItemGetDto> GetAll(string userid);
		
		bool AddCartItem(string userId, ProductGet product,int quantity);
		bool DeleteCartItem(int cartid, string userid);
		bool DeleteAllCartItem( string userid);
		bool UpdateMyCart(int cartid, string userid, int quantity);
	}
}
