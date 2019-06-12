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

        /// <summary>
        /// Hàm trả về danh sách khách hàng lọc theo tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<CCustomer> ListCustomerName(string name)
        {
            List<CCustomer> List = new List<CCustomer>();
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Customers.Where(x => x.Customer_Name.ToLower().Contains(name.ToLower()));
                    if (data.Count() > 0)
                    {
                        foreach(var item in data)
                        {
                            CCustomer customer = new CCustomer
                            {
                                ID = item.Customer_ID,
                                Name = item.Customer_Name,
                                Phone = item.Customer_Phone,
                                Address = item.Customer_Address,
                                Email = item.Customer_Email
                            };

                            List.Add(customer);
                        }
                    }
                }
            }
            catch
            {

            }

            return List;
        }

        /// <summary>
        /// Hàm trả về danh sách khách hàng lọc theo sdt
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<CCustomer> ListCustomerPhone(string phone)
        {
            List<CCustomer> List = new List<CCustomer>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Customers.Where(x => x.Customer_Phone.ToLower().Contains(phone.ToLower()));
                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            CCustomer customer = new CCustomer
                            {
                                ID = item.Customer_ID,
                                Name = item.Customer_Name,
                                Phone = item.Customer_Phone,
                                Address = item.Customer_Address,
                                Email = item.Customer_Email
                            };

                            List.Add(customer);
                        }
                    }
                }
            }
            catch
            {

            }

            return List;
        }

        /// <summary>
        /// Trả về thông tin của khách hàng lọc theo số điện thoại
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CCustomer> ListCustomerPhone(string phone,int currentPage,int NumberPage)
        {
            List<CCustomer> List = new List<CCustomer>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Customers.Where(x => x.Customer_Phone.ToLower().Contains(phone.ToLower()))
                        .ToList().Skip((currentPage - 1) * NumberPage).Take(NumberPage);
                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            int sumBook = DB.Bill_Detail.Where(x => x.Bill.Customer_ID == item.Customer_ID).Sum(x => x.Book_Count);
                            DateTime lastdate = DB.Bills.Where(x => x.Customer_ID == item.Customer_ID).OrderByDescending(x => x.Bill_Date)
                                .Select(x => x.Bill_Date).FirstOrDefault();

                            CCustomer customer = new CCustomer
                            {
                                ID = item.Customer_ID,
                                Name = item.Customer_Name,
                                Phone = item.Customer_Phone,
                                Address = item.Customer_Address,
                                Email = item.Customer_Email,
                                NumberBook = sumBook,
                                LastTransaction = lastdate,
                                MoneyPaid = (float)item.Bills.Sum(x => x.Total_Money)
                            };

                            List.Add(customer);
                        }
                    }
                }
            }
            catch
            {

            }

            return List;
        }

        /// <summary>
        /// Trả về thông tin của khách hàng lọc theo tên
        /// </summary>
        /// <param name="name"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CCustomer> ListCustomerName(string name, int currentPage, int NumberPage)
        {
            
            List<CCustomer> List = new List<CCustomer>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Customers.Where(x => x.Customer_Name.ToLower().Contains(name))
                        .ToList().Skip((currentPage - 1) * NumberPage).Take(NumberPage);
                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            int sumBook = DB.Bill_Detail.Where(x => x.Bill.Customer_ID == item.Customer_ID).Sum(x => x.Book_Count);
                            DateTime lastdate = DB.Bills.Where(x => x.Customer_ID == item.Customer_ID).OrderByDescending(x => x.Bill_Date)
                                .Select(x => x.Bill_Date).FirstOrDefault();

                            CCustomer customer = new CCustomer
                            {
                                ID = item.Customer_ID,
                                Name = item.Customer_Name,
                                Phone = item.Customer_Phone,
                                Address = item.Customer_Address,
                                Email = item.Customer_Email,
                                NumberBook = sumBook,
                                LastTransaction = lastdate,
                                MoneyPaid = (float)item.Bills.Sum(x => x.Total_Money)
                            };

                            List.Add(customer);
                        }
                    }
                }
            }
            catch
            {

            }

            return List;
        }
    }
}
