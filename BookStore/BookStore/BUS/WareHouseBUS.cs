using BookStore.DAO;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BUS
{
    public class WareHouseBUS
    {
        WareHouseDAO DAO = new WareHouseDAO();
        BookDAO bookDAO = new BookDAO();

        /// <summary>
        /// Hàm trả về chi tiết tồn kho của sách theo từng đợt nhập
        /// </summary>
        /// <param name="BookID"></param>
        /// <param name="isAll"></param>
        /// <returns></returns>
        public List<CBookTransaction> DetailsInventoryOfBook(int BookID, bool isAll)
        {
            return DAO.DetailsInventoryOfBook(BookID, isAll);
        }

        /// <summary>
        /// Trả về thông tin chi tiết lần nhập kho cuối
        /// </summary>
        /// <returns></returns>
        public CBaseReceipt LastWarehouse()
        {
            return DAO.LastWarehouse();
        }

        /// <summary>
        /// Thêm sách vào kho và lịch sử nhập kho
        /// </summary>
        /// <param name="bookReipt"></param>
        /// <returns></returns>
        public int addTransactionListNewBook(CBookReipt bookReipt)
        {
            //Tạo mới lịch sử nhập kho
            int wareHouseID = DAO.addWareHouseTransaction(bookReipt.BManager.ID, bookReipt.Date, bookReipt.TypeID, bookReipt.TotalMoney);

            foreach(var book in bookReipt.ListBook)
            {
                //Thêm sách vào csdl
                book.ID = bookDAO.addNewBook(book);
                //Thêm vào bảng chi tiết nhập kho
                DAO.addWareHouseDetail(book, wareHouseID);
                //Thêm vào bảng tồn kho
                DAO.addBookInventory(book, wareHouseID);
            }

            return bookReipt.ListBook.Count;
        }

        /// <summary>
        /// Hàm thêm sách vào kho và lịch sử nhập kho
        /// </summary>
        /// <param name="bookReipt"></param>
        /// <returns></returns>
        public int addTransactionIncreaseBook(CBookReipt bookReipt)
        {
            //Tạo mới lịch sử nhập kho
            int wareHouseID = DAO.addWareHouseTransaction(bookReipt.BManager.ID, bookReipt.Date, bookReipt.TypeID, bookReipt.TotalMoney);

            foreach (var book in bookReipt.ListBook)
            {
                //Thêm vào bảng chi tiết nhập kho
                DAO.addWareHouseDetail(book, wareHouseID);
                //Thêm vào bảng tồn kho
                DAO.addBookInventory(book, wareHouseID);
                //Thêm vào số lượng sách
                bookDAO.increaseBook(book.ID, book.Count);
            }

            return bookReipt.ListBook.Count;
        }

        /// <summary>
        /// Hàm trả về lịch sử nhập kho trong tháng
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBookReipt> Warehouse_History(int Month, int Year, int currentPage, int NumberPage)
        {
            return DAO.Warehouse_History(Month, Year, currentPage, NumberPage);
        }

        /// <summary>
        /// Hàm trả về chi tiết lịch sử nhập kho
        /// </summary>
        /// <param name="WareHouseID"></param>
        /// <returns></returns>
        public List<CBookTransaction> DetailOfWareHouse(int WareHouseID)
        {
            return DAO.DetailOfWareHouse(WareHouseID);
        }

        /// <summary>
        /// Hàm trả về lịch sử nhập kho từ ngày đến ngày
        /// </summary>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBookReipt> Warehouse_History(DateTime DateBegin, DateTime DateEnd, int currentPage, int NumberPage)
        {
            return DAO.Warehouse_History(DateBegin, DateEnd, currentPage, NumberPage);
        }
    }
}
