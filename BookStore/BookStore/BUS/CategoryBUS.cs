using BookStore.DAO;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BUS
{
    public class CategoryBUS
    {
        CategoryDAO DAO = new CategoryDAO();

        /// <summary>
        /// Hàm trả về danh sách tất cả các thể loại
        /// </summary>
        /// <returns></returns>
        public List<CCategory> ListCategory()
        {
            return DAO.ListCategory();
        }
    }
}
