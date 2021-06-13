using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary1.DataAccess;
using DataLibrary1.Models;

namespace DataLibrary1.BusinessLogic
{
    public static class PaymentProcessor
    {
        public static int CreatePayment(string email, string nameOnCard, long cardNumber, int expiration, int cvv)
        {
            Payment data = new Payment
            {
                Email = email,
                NameOnCard = nameOnCard,
                CardNumber = cardNumber,                
                Expiration = expiration,
                CVV = cvv
            };

            string sql = @"insert into dbo.Payment (Email, NameOnCard, CardNumber, Expiration, CVV)
                        values (@Email, @NameOnCard, @CardNumber, @Expiration, @CVV);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static Payment LoadPayment(string email)
        {
            Payment data = new Payment
            {
                Email = email
            };

            string sql = @"select NameOnCard, CardNumber, Expiration, CVV
                        from dbo.Payment
                        where Email = @Email;";

            if (SqlDataAccess.CheckData(sql, data))
            {
                return SqlDataAccess.LoadData(sql, data);
            }
            else
            { 
                return null;
            }            
        }
    }
}
