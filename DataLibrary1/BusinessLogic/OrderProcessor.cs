using DataLibrary1.DataAccess;
using DataLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary1.BusinessLogic
{
    public class OrderProcessor
    {
        public static int CreateOrder(int orderId, string email, string date, int itemQty, double total)
        {
            Order data = new Order
            {
                OrderId = orderId,
                Email = email,
                Date = date,
                ItemQty = itemQty,
                Total = total
            };

            string sql = @"insert into dbo.Orders (OrderId, Email, Date, ItemQty, Total)
                        values (@OrderId, @Email, @Date, @ItemQty, @Total);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int AddItemToOrder(int productId, string name, double price, string imgUrl, int orderId)
        {
            OrderItem data = new OrderItem
            {
                ProductId = productId,
                ProductName = name,
                Price = price,  
                ImgUrl = imgUrl,
                OrderId = orderId
            };

            string sql = @"insert into dbo.OrderItem (ProductId, ProductName, Price, ImgUrl, OrderId)
                        values (@ProductId, @ProductName, @Price, @ImgUrl, @OrderId);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<Order> LoadOrder()
        {
            string sql = @"SELECT * FROM Orders
                            ORDER BY Date DESC;";

            return SqlDataAccess.LoadData<Order>(sql);
        }

        public static List<Order> LoadOrder(string email)
        {
            Order data = new Order
            {
                Email = email
            };

            string sql = @"SELECT * FROM Orders
                           WHERE Email= @Email
                           ORDER BY Date DESC;";

            return SqlDataAccess.LoadListData<Order>(sql, data);
        }

        public static Order LoadOrder(int id)
        {
            Order data = new Order
            {
                OrderId = id
            };

            string sql = @"SELECT * FROM Orders
                           WHERE OrderId= @OrderId;";

            return SqlDataAccess.LoadData(sql, data);
        }

        public static List<OrderItem> LoadOrderItems(int orderId)
        {
            OrderItem data = new OrderItem
            {
                OrderId = orderId
            };

            string sql = @"SELECT * FROM OrderItem
                           WHERE OrderId= @OrderId;";

            return SqlDataAccess.LoadListData<OrderItem>(sql, data);
        }
    }
}
