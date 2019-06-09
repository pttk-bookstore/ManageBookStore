using BookStore.DAO;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BUS
{
    public class SubCategoryBUS
    {
        SubCategoryDAO DAO = new SubCategoryDAO();

        /// <summary>
        /// Hàm trả về danh sách tất cả chủ đề theo thể loại
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public List<CSubCategory> ListSubCategory(int CategoryID)
        {
            return DAO.ListSubCategory(CategoryID);
        }

    }
}
