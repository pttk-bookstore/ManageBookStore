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

        /// <summary>
        /// Hàm trả về danh sách tất cả các thể loại kèm theo số lượng sách tương ứng
        /// </summary>
        /// <returns></returns>
        public List<CCategory> ListFullCategory()
        {
            return DAO.ListFullCategory();
        }

        /// <summary>
        /// Hàm trả về số lượng sách trong kho tương ứng với từng Category
        /// </summary>
        /// <returns></returns>
        public List<CCategory> ListCatergoryBook()
        {
            return DAO.ListCatergoryBook();
        }

        /// <summary>
        /// Hàm thêm mới một category thêm thành công trả về 1, thất bại trả về -1, 0 nếu Category đã tồn tại
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <returns></returns>
        public int addCategory(string CategoryName)
        {
            int checkID = DAO.IDofCategoryName(CategoryName);
            if (checkID != 0)
            {
                return 0;
            }
            else
            {
                return DAO.addCategory(CategoryName);
            }
        }

        /// <summary>
        /// Hàm cập nhật tên mới cho 1 category thành công trả về 1, thất bại trả về -1, nếu Category đã tồn tại trả về 0
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int updateCategory(CCategory category)
        {
            int checkID = DAO.IDofCategoryName(category.Name);
            if(checkID !=0 && checkID != category.ID)
            {
                return 0;
            }
            else
            {
                return DAO.updateCategory(category);
            }
        }

        public int deleteCategory(int CategoryID)
        {
            int checkUsed = DAO.isCategoryUsed(CategoryID);
            if (checkUsed != 0)
            {
                return 0;
            }
            return DAO.deleteCategory(CategoryID);
        }
    }
}
