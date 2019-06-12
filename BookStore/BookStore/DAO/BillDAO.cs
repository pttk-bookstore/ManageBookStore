using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
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

        /// <summary>
        /// Hàm trả về danh sách hóa đơn tương ứng với tháng năm
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBill> Bill_History(int Month, int Year, int currentPage, int NumberPage)
        {
            List<CBill> List = new List<CBill>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Bills.Where(x => SqlFunctions.DatePart("year",
                        x.Bill_Date) == Year && SqlFunctions.DatePart("month", x.Bill_Date) == Month).OrderByDescending(x => x.Bill_Date).ToList().
                        Skip((currentPage - 1) * NumberPage).Take(NumberPage);

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            //Tạo mới hóa đơn
                            CBill myBill = new CBill
                            {
                                ID = item.Bill_ID,
                                Date = item.Bill_Date,
                                TotalMoney = (float)item.Total_Money,
                                BCustomer = new CCustomer { Name = item.Customer.Customer_Name },
                                BSalesman = new CEmployee { Name = item.Employee.Employee_Name },
                                Promotion = item.Discount_Code == null ? 0 : (float)item.Discount_Code.Discount_Type.DiscountType_Promotion,
                                TotalCount = item.Bill_Detail.Sum(x => x.Book_Count),
                                TypeBill = new CBillType { ID = item.Bill_Type, Name = item.Bill_Type1.BillType_Name },
                                Status = item.Bill_Status
                            };

                            //Thêm
                            List.Add(myBill);
                        }
                    }
                }

            }
            catch
            {

            }
            return List;
        }

        /// <summary>
        /// Hàm trả về lịch sử giao dịch của khách hàng
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBill> Bill_History(int CustomerID,int Month, int Year, int currentPage, int NumberPage)
        {
            List<CBill> List = new List<CBill>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Bills.Where(x => SqlFunctions.DatePart("year",
                        x.Bill_Date) == Year && SqlFunctions.DatePart("month", x.Bill_Date) == Month && x.Customer_ID==CustomerID).OrderByDescending(x => x.Bill_Date).ToList().
                        Skip((currentPage - 1) * NumberPage).Take(NumberPage);

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            //Tạo mới hóa đơn
                            CBill myBill = new CBill
                            {
                                ID = item.Bill_ID,
                                Date = item.Bill_Date,
                                TotalMoney = (float)item.Total_Money,
                                BCustomer = new CCustomer { Name = item.Customer.Customer_Name },
                                BSalesman = new CEmployee { Name = item.Employee.Employee_Name },
                                Promotion = item.Discount_Code == null ? 0 : (float)item.Discount_Code.Discount_Type.DiscountType_Promotion,
                                TotalCount = item.Bill_Detail.Sum(x => x.Book_Count),
                                TypeBill = new CBillType { ID = item.Bill_Type, Name = item.Bill_Type1.BillType_Name },
                                Status = item.Bill_Status
                            };

                            //Thêm
                            List.Add(myBill);
                        }
                    }
                }

            }
            catch
            {

            }
            return List;
        }

        /// <summary>
        /// Hàm trả về danh sách hóa đơn từ ngày đến ngày
        /// </summary>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBill> Bill_History(DateTime DateBegin, DateTime DateEnd, int currentPage, int NumberPage)
        {
            List<CBill> List = new List<CBill>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Bills.Where(x => DbFunctions.TruncateTime(x.Bill_Date) >= DbFunctions.TruncateTime(DateBegin)
                    && DbFunctions.TruncateTime(x.Bill_Date) <= DbFunctions.TruncateTime(DateEnd)).OrderByDescending(x => x.Bill_Date).ToList().
                        Skip((currentPage - 1) * NumberPage).Take(NumberPage);

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            //Tạo mới hóa đơn
                            CBill myBill = new CBill
                            {
                                ID = item.Bill_ID,
                                Date = item.Bill_Date,
                                TotalMoney = (float)item.Total_Money,
                                BCustomer = new CCustomer { Name = item.Customer.Customer_Name },
                                BSalesman = new CEmployee { Name = item.Employee.Employee_Name },
                                Promotion = item.Discount_Code == null ? 0 : (float)item.Discount_Code.Discount_Type.DiscountType_Promotion,
                                TotalCount = item.Bill_Detail.Sum(x => x.Book_Count),
                                TypeBill = new CBillType { ID = item.Bill_Type, Name = item.Bill_Type1.BillType_Name },
                                Status = item.Bill_Status
                            };

                            //Thêm
                            List.Add(myBill);
                        }
                    }
                }

            }
            catch
            {

            }
            return List;
        }

        /// <summary>
        /// Hàm trả về lịch sử giao dịch của khách hàng
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBill> Bill_History(int CustomerID,DateTime DateBegin, DateTime DateEnd, int currentPage, int NumberPage)
        {
            List<CBill> List = new List<CBill>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Bills.Where(x => DbFunctions.TruncateTime(x.Bill_Date) >= DbFunctions.TruncateTime(DateBegin)
                    && DbFunctions.TruncateTime(x.Bill_Date) <= DbFunctions.TruncateTime(DateEnd) &&x.Customer_ID == CustomerID).OrderByDescending(x => x.Bill_Date).ToList().
                        Skip((currentPage - 1) * NumberPage).Take(NumberPage);

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            //Tạo mới hóa đơn
                            CBill myBill = new CBill
                            {
                                ID = item.Bill_ID,
                                Date = item.Bill_Date,
                                TotalMoney = (float)item.Total_Money,
                                BCustomer = new CCustomer { Name = item.Customer.Customer_Name },
                                BSalesman = new CEmployee { Name = item.Employee.Employee_Name },
                                Promotion = item.Discount_Code == null ? 0 : (float)item.Discount_Code.Discount_Type.DiscountType_Promotion,
                                TotalCount = item.Bill_Detail.Sum(x => x.Book_Count),
                                TypeBill = new CBillType { ID = item.Bill_Type, Name = item.Bill_Type1.BillType_Name },
                                Status = item.Bill_Status
                            };

                            //Thêm
                            List.Add(myBill);
                        }
                    }
                }

            }
            catch
            {

            }
            return List;
        }


        /// <summary>
        /// Hàm trả về list sách chi tiết của billID
        /// </summary>
        /// <param name="BillID"></param>
        /// <returns></returns>
        public List<CBookTransaction> DetailOfBill(int BillID)
        {
            List<CBookTransaction> List = new List<CBookTransaction>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Bill_Detail.Where(x => x.Bill_ID == BillID);
                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            //Tạo mới
                            CBookTransaction Detailt = new CBookTransaction
                            {
                                ID = item.Bill_ID,
                                Name = item.Book.Book_Name,
                                Price = (float)item.Book_Price,
                                Promotion = (float)item.Book_Promotion,
                                PricePromotion = (float)(item.Book_Price - item.Book_Price * item.Book_Promotion),
                                Count = item.Book_Count,
                                TotalMoney = item.Book_Count * (float)(item.Book_Price - item.Book_Price * item.Book_Promotion)
                            };

                            //Thêm vào
                            List.Add(Detailt);
                        }
                    }
                }
            }
            catch
            {

            }
            return List;
        }

        /// <summary>
        /// Cập nhật trạng thái của đơn hàng thành đã thanh toán
        /// </summary>
        /// <param name="billID"></param>
        /// <returns></returns>
        public int VerifyBill(int billID)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Bills.Find(billID);
                    if (find != null)
                    {
                        find.Bill_Status = 1;
                        DB.SaveChanges();
                        return 1;
                    }
                }
            }
            catch
            {

            }

            return -1;
        }
    }
}
