using BookStore.DAO;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BUS
{
    public class CompanyBUS
    {
        CompanyDAO DAO = new CompanyDAO();

        /// <summary>
        /// Hàm trả về danh sách tất cả các nhà xuất bản
        /// </summary>
        /// <returns></returns>
        public List<CCompany> ListCompany()
        {
            return DAO.ListCompany();
        }
    }
}
