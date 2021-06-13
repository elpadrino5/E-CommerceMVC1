using DataLibrary1.DataAccess;
using DataLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary1.BusinessLogic
{
    public static class ProductProcessor
    {
        public static List<Product> LoadProduct()
        {
            string sql = @"select ProductId, Name, Price, Description, ImgUrl
                        from dbo.Product;";
            
            return SqlDataAccess.LoadData<Product>(sql);
        }

        public static Product LoadProduct(int id)
        {
            Product data = new Product
            {
                ProductId = id
            };

            string sql = @"select ProductId, Name, Price, Description, ImgUrl
                        from dbo.Product
                        where ProductId = @ProductId;";

            return SqlDataAccess.LoadData(sql, data);
        }

        public static int CreateProduct(/*int productId,*/ string name, double price, string description, string imgUrl)
        {
            Product data = new Product
            {
                /*ProductId = productId,*/
                Name = name,
                Price = price,
                Description = description,
                ImgUrl = imgUrl
            };

            string sql = @"insert into dbo.Product ( Name, Price, Description, ImgUrl)
                        values ( @Name, @Price, @Description, @ImgUrl);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int UpdateProduct(int productId, string name, double price, string description, string imgUrl)
        {
            Product data = new Product
            {
                ProductId = productId,
                Name = name,
                Price = price,
                Description = description,
                ImgUrl = imgUrl
            };

            string sql = @"UPDATE dbo.Product
                           SET Name = @Name, Price = @Price, Description = @Description, ImgUrl = @ImgUrl
                           WHERE ProductId = @ProductId;";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteProduct(int productId)
        {
            Product data = new Product
            {
                ProductId = productId,
            };

            string sql = @"DELETE FROM dbo.Product                          
                           WHERE ProductId = @ProductId;";

            return SqlDataAccess.SaveData(sql, data);
        }

        ///////////////////////////////
        ///Cart
        ///////////////////////////////


    }
}
