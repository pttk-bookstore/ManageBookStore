using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAO
{
    public class CustomerDAO
    {
        /// <summary>
        /// Hàm thêm mới một khách hàng, trả về ID của khách hàng vừa thêm nếu không thêm được trả về -1
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public int addCustomer(CCustomer customer)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    Customer newCustomer = new Customer
                    {
                        Customer_Name = customer.Name,
                        Customer_Phone = customer.Phone,
                        Customer_Address = customer.Address,
                        Customer_Email = customer.Email
                    };

                    DB.Customers.Add(newCustomer);
                    DB.SaveChanges();

                    return newCustomer.Customer_ID;
                }
            }
            catch
            {

            }
            return -1;
        }

        /// <summary>
        /// Trả về ID của khách hàng có sdt nếu như đã tồn tại không có trả về -1
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public int IDofCustomerPhone(string phone)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Customers.Where(x => x.Customer_Phone.Equals(phone)).FirstOrDefault();
                    if (find != null)
                    {
                        return find.Customer_ID;
                    }
                }
            }
            catch
            {

            }
            return -1;
        }

        /// <summary>
        /// Trả về thông tin chi tiết của khách hàng theo ID
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public CCustomer InFoOfCustomer(int CustomerID)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Customers.Find(CustomerID);

                    if (find != null)
                    {
                        CCustomer customer = new CCustomer
                        {
                            ID = find.Customer_ID,
                            Name = find.Customer_Name,
                            Phone = find.Customer_Phone,
                            Email = find.Customer_Email,
                            Address = find.Customer_Address
                        };

                        return customer;
                    }
                }
            }
            catch
            {

            }
            return null;
        }
    }
}
