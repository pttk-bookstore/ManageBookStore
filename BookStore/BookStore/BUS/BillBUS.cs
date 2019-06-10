using BookStore.DAO;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BUS
{
    public class BillBUS
    {
        BillDAO DAO = new BillDAO();
        CustomerDAO customerDAO = new CustomerDAO();
        BookDAO bookDAO = new BookDAO();
        WareHouseDAO wareHouseDAO = new WareHouseDAO();

        /// <summary>
        /// Hàm trả về danh sách tất cả các loại hóa đơn
        /// </summary>
        /// <returns></returns>
        public List<CBillType> ListBillType()
        {
            return DAO.ListBillType();
        }

        /// <summary>
        /// Thêm một bill mới lịch sử
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public int addTransactionNewBill(CBill bill)
        {
            //Kiểm tra thông tin khách hàng đã tồn tại chưa

            int customerID = customerDAO.IDofCustomerPhone(bill.BCustomer.Phone);
            if (customerID == -1)
            {
                //Thêm mới khách hàng
                customerID = customerDAO.addCustomer(bill.BCustomer);
            }

            bill.BCustomer.ID = customerID;
            //Tạo mới bill
            int billID = DAO.addNewBill(bill);
            
            //Thêm vào chi tiết
            foreach(var book in bill.ListBook)
            {
                //Trừ trong bảng book
                bookDAO.decreaseBook(book.ID, book.Count);
                //Trừ tương ứng ở bảng inventory và thêm vào bảng detail
                while (true)
                {
                    Tuple<int, int, int> result = wareHouseDAO.decreaseInventory(book.ID, book.Count);
                    //Lấy ra giá nhập tương ứng
                    float bookInPrice = wareHouseDAO.BookInPrice(book.ID, result.Item1);

                    //Cập nhật thông tin cho sách
                    book.InPrice = bookInPrice;
                    book.Count = result.Item2;

                    //Tạo mới Detail
                    DAO.addDetailBill(book, billID);

                    if (result.Item3 == 0)
                    {
                        break;
                    }
                }
            }

            return bill.ListBook.Count;
        }
    }
}
