using BookStore.DAO;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BUS
{
    public class CustomerBUS
    {
        CustomerDAO DAO = new CustomerDAO();

        /// <summary>
        /// Trả về id của khách hàng có số điện thoại
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public int IDofCustomerPhone(string phone)
        {
            return DAO.IDofCustomerPhone(phone);
        }

        /// <summary>
        /// Trả về thông tin chi tiết của khách hàng có ID
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public CCustomer InFoOfCustomer(int CustomerID)
        {
            return DAO.InFoOfCustomer(CustomerID);
        }

        /// <summary>
        /// Thêm vào khách hàng mới, trả về id khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public int addCustomer(CCustomer customer)
        {
            return DAO.addCustomer(customer);
        }

        /// <summary>
        /// Hàm trả về danh sách tất cả các khách hàng lọc theo tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<CCustomer> ListCustomerName(string name)
        {
            return DAO.ListCustomerName(name);
        }

        /// <summary>
        /// Hàm trả về danh sách tất cả các khách hàng lọc theo phone
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<CCustomer> ListCustomerPhone(string phone)
        {
            return DAO.ListCustomerPhone(phone);
        }

        /// <summary>
        /// Hàm lọc khách hàng theo số điện thoại
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CCustomer> ListCustomerPhone(string phone, int currentPage, int NumberPage)
        {
            return DAO.ListCustomerPhone(phone, currentPage, NumberPage);
        }

        /// <summary>
        /// Hàm lọc khách hàng theo tên
        /// </summary>
        /// <param name="name"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CCustomer> ListCustomerName(string name, int currentPage, int NumberPage)
        {
            return DAO.ListCustomerName(name, currentPage, NumberPage);
        }
    }
}
