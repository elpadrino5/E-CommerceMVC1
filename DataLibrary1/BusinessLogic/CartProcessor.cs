using DataLibrary1.DataAccess;
using DataLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary1.BusinessLogic
{
    public class CartProcessor
    {
        public static int AddItemToCart(string email, int productId, string name, double price, string imgUrl)
        {
            CartItem data = new CartItem
            {
                Email = email,
                ProductId = productId,
                ProductName = name,
                Price = price,  
                ImgUrl = imgUrl
            };

            string sql = @"insert into dbo.CartItem (Email, ProductId, ProductName, Price, ImgUrl)
                        values (@Email, @ProductId, @ProductName, @Price, @ImgUrl);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<CartItem> LoadCart(string email)
        {
            CartItem data = new CartItem
            {
                Email = email
            };

            string sql = @"select CartItemId, Email, ProductId, ProductName, ImgUrl, Price, ImgUrl
                        from dbo.CartItem
                        where Email = @Email;";

            return SqlDataAccess.LoadListData<CartItem>(sql, data);
        }

        public static int DeleteCartItem(int cartItemId)
        {
            CartItem data = new CartItem
            {
                CartItemId = cartItemId
            };

            string sql = @"DELETE FROM dbo.CartItem                          
                           WHERE CartItemId = @CartItemId;";

            return SqlDataAccess.SaveData(sql, data);
        }

    }
}
