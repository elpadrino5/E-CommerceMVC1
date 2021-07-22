using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary1.DataAccess;
using DataLibrary1.Models;

namespace DataLibrary1.BusinessLogic
{
    public static class AddressProcessor
    {
        public static int CreateAddress(string email, string firstName, string lastName, string street, string city, string state, int zip)
        {
            Address data = new Address
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Street = street,
                City = city,
                State = state,
                Zip = zip
            };

            string sql = @"insert into dbo.Address ( Email, FirstName, LastName, Street, City, State, Zip)
                        values ( @Email, @FirstName, @LastName, @Street, @City, @State, @Zip);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static Address LoadAddress(string email)
        {
            Address data = new Address
            {
                Email = email
            };

            string sql = @"select FirstName, LastName, Street, City, State, Zip
                        from dbo.Address
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

        public static int UpdateAddress(string email, string firstName, string lastName, string street, string city, string state, int zip)
        {
            Address data = new Address
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Street = street,
                City = city,
                State = state,
                Zip = zip
            };

            string sql = @"UPDATE dbo.Address 
                           SET FirstName = @FirstName, LastName = @LastName, Street = @Street , City = @City, State = @State, Zip = @Zip
                           WHERE Email = @Email;";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
