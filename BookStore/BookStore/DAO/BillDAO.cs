using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BookStore.DAO
{
    public class BillDAO
    {

        /// <summary>
        /// Hàm trả về danh sách loại hóa đơn
        /// </summary>
        /// <returns></returns>
        public List<CBillType> ListBillType()
        {
            List<CBillType> List = new List<CBillType>();
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Bill_Type;

                    foreach(var item in data)
                    {
                        CBillType type = new CBillType
                        {
                            ID = item.BillType_ID,
                            Name = item.BillType_Name
                        };

                        List.Add(type);
                    }
                }
            }
            catch
            {

            }
            return List;
        }

        /// <summary>
        /// Thêm mới một hóa đơn mới, trả về ID của hóa đơn vừa được tạo
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public int addNewBill(CBill billData)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    Bill bill = new Bill
                    {
                        Bill_Date = billData.Date,
                        Employee_ID = billData.BSalesman.ID,
                        Customer_ID = billData.BCustomer.ID,
                        Total_Money = billData.TotalMoney,
                        Excess_Cash = billData.ExcessCash,
                        Sum_Money = billData.SumMoney,
                        Bill_Type = billData.TypeBill.ID,
                        DiscountCode = billData.BDiscountCode.Code == "" ? null : billData.BDiscountCode.Code,
                        Bill_Status = billData.Status,
                        Customer_Cash = billData.Cash
                    };

                    DB.Bills.Add(bill);
                    DB.SaveChanges();
                    return bill.Bill_ID;
                }
            }
            catch
            {

            }

            return 0;
        }

        /// <summary>
        /// Thêm vào chi tiết của hóa đơn
        /// </summary>
        /// <param name="book"></param>
        /// <param name="billID"></param>
        /// <returns></returns>
        public int addDetailBill(CBookTransaction book,int billID)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    Bill_Detail detail = new Bill_Detail
                    {
                        Bill_ID = billID,
                        Book_ID = book.ID,
                        Book_Count = book.Count,
                        Book_Price = book.Price,
                        Book_InPrice = book.InPrice,
                        Book_Promotion = book.Promotion
                    };
                    DB.Bill_Detail.Add(detail);
                    DB.SaveChanges();
                    return detail.Detail_ID;
                }
            }
            catch
            {

            }
            return 0;
        }
    }
}
