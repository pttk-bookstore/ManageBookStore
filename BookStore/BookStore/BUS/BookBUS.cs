using BookStore.DAO;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BUS
{
    public class BookBUS
    {
        BookDAO DAO = new BookDAO();

        /// <summary>
        /// Hàm trả về danh sách lọc theo yêu cầu
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Author"></param>
        /// <param name="Category"></param>
        /// <param name="SubCategory"></param>
        /// <param name="Company"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBook> ListBook(string Name, string Author, int Category, int SubCategory, int Company,bool isSale, int currentPage, int NumberPage)
        {
            return DAO.ListBook(Name, Author, Category, SubCategory, Company, isSale, currentPage, NumberPage);
        }

        /// <summary>
        /// Hàm trả về danh sách lọc theo yêu cầu, có sắp xếp
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Author"></param>
        /// <param name="Category"></param>
        /// <param name="SubCategory"></param>
        /// <param name="Company"></param>
        /// <param name="sortBy"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBook> ListBook(string Name, string Author, int Category, int SubCategory, int Company, string sortBy, int currentPage, int NumberPage)
        {
            return DAO.ListBook(Name, Author, Category, SubCategory, Company, sortBy, currentPage, NumberPage);
        }

        /// <summary>
        /// Hàm trả về danh sách tất cả cá tác giả
        /// </summary>
        /// <returns></returns>
        public List<string> ListAuthor()
        {
            return DAO.ListAuthor();
        }

        /// <summary>
        /// Cập nhật thông tin sách 
        /// </summary>
        /// <param name="BookInfo"></param>
        /// <returns>trả về 0 nếu sách đã tồn tại, trả về 1 nếu như sách cập nhật thành công,-1 nếu thất bại</returns>
        public int updateBookInfo(CBook BookInfo)
        {
            //Kiểm tra sách đã tồn tại hay chưa
            int isExits = DAO.IdOfBookInfo(BookInfo);
            if(isExits != 0)
            {
                if(isExits != BookInfo.ID)
                {
                    return 0;
                }            
            }
            return DAO.updateBookInfo(BookInfo);
        }

        /// <summary>
        /// Trả về ID của sách có thông tin
        /// </summary>
        /// <param name="BookInfo"></param>
        /// <returns></returns>
        public int IdOfBookInfo(CBook BookInfo)
        {
            return DAO.IdOfBookInfo(BookInfo);
        }


        /// <summary>
        /// Hàm trả về tổng số lượng sách tồn trong kho
        /// </summary>
        /// <returns></returns>
        public int InventoryBook()
        {
            return DAO.InventoryBook();
        }

        /// <summary>
        /// Hàm trả về số lượng sách tồn trong kho của sách có ID
        /// </summary>
        /// <param name="BookID"></param>
        /// <returns></returns>
        public int InventoryOfBook(int BookID)
        {
            return DAO.InventoryOfBook(BookID);
        }

    }
}
