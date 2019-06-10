﻿using BookStore.DAO;
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
    }
}
