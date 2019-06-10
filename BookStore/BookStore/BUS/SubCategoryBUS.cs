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

        /// <summary>
        /// Hàm trả về danh sách tất cả các chủ đề thuộc thê loại theo ID bao gồm số lượng đầu sách tương ứng
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public List<CSubCategory> ListFullSubCategory(int CategoryID)
        {
            return DAO.ListFullSubCategory(CategoryID);
        }

        /// <summary>
        /// Hàm thêm vào một subCategory mới, thêm thành công trả về 1 nếu đã tồn tại loại trả về 0, thất bại trả về -1
        /// </summary>
        /// <param name="SubCategoryName"></param>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public int addSubCategory(string SubCategoryName,int CategoryID)
        {
            int checkID = DAO.IDofSubCategoryName(SubCategoryName);
            if (checkID != 0)
            {
                return 0;
            }
            else
            {
                return DAO.addSubCategory(SubCategoryName, CategoryID);
            }
        }

        /// <summary>
        /// Hàm cập nhật tên mới cho 1 subcategory thành công trả về 1, thất bại trả về -1, nếu subCategory đã tồn tại trả về 0
        /// </summary>
        /// <param name="subcategory"></param>
        /// <returns></returns>
        public int updateSubCategory(CSubCategory subcategory)
        {
            int checkID = DAO.IDofSubCategoryName(subcategory.Name);
            if (checkID != 0 && checkID != subcategory.ID)
            {
                return 0;
            }
            else
            {
                return DAO.updateSubCategory(subcategory);
            }
        }

        /// <summary>
        /// Hàm xóa 1 sub category nếu như loại đang được dùng thì trả về 0, thành công trả về 1, thất bại trả về -1
        /// </summary>
        /// <param name="SubCategoryID"></param>
        /// <returns></returns>
        public int deleteSubCategory(int SubCategoryID)
        {
            int checkUsed = DAO.isSubCategoryUsed(SubCategoryID);
            if (checkUsed != 0)
            {
                return 0;
            }
            return DAO.deleteSubCategory(SubCategoryID);
        }

    }
}
