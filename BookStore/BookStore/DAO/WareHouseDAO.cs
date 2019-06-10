using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAO
{
    public class WareHouseDAO
    {
        /// <summary>
        /// Chi tiết tồn kho của từng đợt nhập của sách
        /// </summary>
        /// <param name="BookID"></param>
        /// <param name="isAll">true thì hiển thị tất cả, false thì hiển thị những đợt nhập lớn hơn 0</param>
        /// <returns></returns>
        public List<CBookTransaction> DetailsInventoryOfBook(int BookID, bool isAll)
        {
            List<CBookTransaction> List = new List<CBookTransaction>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Book_Inventory.Where(x => x.Book_ID == BookID);

                    foreach (var item in data)
                    {
                        //Lấy ra giá nhập sách của đợt này              
                        float Price = (float)DB.WareHouse_Detail.Where(x => x.WareHouse_ID == item.WareHouse_ID && x.Book_ID == item.Book_ID).Select(x => x.Book_Price).FirstOrDefault();
                        CBookTransaction history = new CBookTransaction
                        {
                            TransactionID = item.WareHouse_ID,
                            Count = item.Book_Count,
                            Price = Price,
                            DateTransaction = item.WareHouse.WareHouse_Date,
                            TypeTransaction = item.WareHouse.WareHouse_Type == 0 ? "Nhập mới" : "Nhập thêm"
                        };

                        if (isAll == true && item.Book_Count == 0)
                        {
                            List.Add(history);
                        }
                        else if (isAll == false && item.Book_Count == 0)
                        {
                            continue;
                        }
                        else
                        {
                            List.Add(history);
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
        /// Trả về chi tiết của đợt nhập kho cuối cùng
        /// </summary>
        /// <returns></returns>
        public CBaseReceipt LastWarehouse()
        {
            CBaseReceipt data = new CBaseReceipt();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.WareHouses.OrderByDescending(x => x.WareHouse_Date).FirstOrDefault();

                    if (find != null)
                    {
                        data.Date = find.WareHouse_Date;
                        data.TotalMoney = (float)find.WareHouse_Total_Money;
                        data.TotalCount = find.WareHouse_Detail.Sum(x => x.Book_Count);
                    }
                }
            }
            catch
            {

            }
            return data;
        }

        /// <summary>
        /// Thêm vào lịch sử nhập kho mới trả về lịch sử nhập kho
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="time"></param>
        /// <param name="Type"></param>
        /// <param name="TotalMoney"></param>
        /// <returns></returns>
        public int addWareHouseTransaction(int EmployeeID,DateTime Time,int TypeID,float TotalMoney)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var wareHouse = new WareHouse
                    {
                        WareHouse_Type = TypeID,
                        WareHouse_Total_Money = TotalMoney,
                        Employee_ID = EmployeeID,
                        WareHouse_Date = Time
                    };

                    DB.WareHouses.Add(wareHouse);
                    DB.SaveChanges();

                    return wareHouse.WareHouse_ID;
                }
            }
            catch
            {

            }

            return 0;
        }


        /// <summary>
        /// Thêm vào bảng chi tiết lịch sử nhập kho
        /// </summary>
        /// <param name="book"></param>
        /// <param name="WareHouseID"></param>
        /// <returns></returns>
        public int addWareHouseDetail(CBookTransaction book,int WareHouseID)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var wareHouse_Detail = new WareHouse_Detail
                    {
                        WareHouse_ID = WareHouseID,
                        Book_ID = book.ID,
                        Book_Count = book.Count,
                        Book_Price = book.Price
                    };

                    DB.WareHouse_Detail.Add(wareHouse_Detail);
                    DB.SaveChanges();

                    return wareHouse_Detail.WareHouseDetail_ID;
                }
            }
            catch
            {

            }

            return 0;
        }

        /// <summary>
        /// Thêm vào bảng tồn kho của sách
        /// </summary>
        /// <param name="book"></param>
        /// <param name="WareHouseID"></param>
        /// <returns></returns>
        public int addBookInventory(CBookTransaction book,int WareHouseID)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var book_Inventory = new Book_Inventory
                    {
                        WareHouse_ID = WareHouseID,
                        Book_ID = book.ID,
                        Book_Count = book.Count
                    };

                    DB.Book_Inventory.Add(book_Inventory);
                    DB.SaveChanges();

                    return 1;
                }
            }
            catch
            {

            }

            return 0;
        }

        /// <summary>
        /// Hàm trả về lịch sử nhập kho trong tháng của năm
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBookReipt> Warehouse_History(int Month, int Year, int currentPage, int NumberPage)
        {
            List<CBookReipt> List = new List<CBookReipt>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.WareHouses.Where(x => SqlFunctions.DatePart("year",
                         x.WareHouse_Date) == Year && SqlFunctions.DatePart("month", x.WareHouse_Date) == Month).OrderByDescending(x => x.WareHouse_Date).ToList().
                        Skip((currentPage - 1) * NumberPage).Take(NumberPage);

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            //Tạo mới
                            CBookReipt History = new CBookReipt
                            {
                                ID = item.WareHouse_ID,
                                TotalMoney = (float)item.WareHouse_Total_Money,
                                Date = item.WareHouse_Date,
                                Type = item.WareHouse_Type == 0 ? "Nhập mới" : "Nhập thêm",
                                TotalCount = item.WareHouse_Detail.Sum(x => x.Book_Count),
                                BManager = new CEmployee { ID = item.Employee_ID, Name = item.Employee.Employee_Name }
                            };

                            //Thêm vào
                            List.Add(History);
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
        /// Hàm trả về lịch sử nhập kho từ ngày đến ngày
        /// </summary>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBookReipt> Warehouse_History(DateTime DateBegin, DateTime DateEnd, int currentPage, int NumberPage)
        {
            List<CBookReipt> List = new List<CBookReipt>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.WareHouses.Where(x => DbFunctions.TruncateTime(x.WareHouse_Date) >= DbFunctions.TruncateTime(DateBegin)
                    && DbFunctions.TruncateTime(x.WareHouse_Date) <= DbFunctions.TruncateTime(DateEnd)).OrderByDescending(x => x.WareHouse_Date).ToList().
                        Skip((currentPage - 1) * NumberPage).Take(NumberPage);

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            //Tạo mới
                            CBookReipt History = new CBookReipt
                            {
                                ID = item.WareHouse_ID,
                                TotalMoney = (float)item.WareHouse_Total_Money,
                                Date = item.WareHouse_Date,
                                Type = item.WareHouse_Type == 0 ? "Nhập mới" : "Nhập thêm",
                                TotalCount = item.WareHouse_Detail.Sum(x => x.Book_Count),
                                BManager = new CEmployee { ID = item.Employee_ID, Name = item.Employee.Employee_Name }
                            };

                            //Thêm vào
                            List.Add(History);
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
        /// Hàm trả về chi tiết lịch sử nhập kho
        /// </summary>
        /// <param name="WareHouseID"></param>
        /// <returns></returns>
        public List<CBookTransaction> DetailOfWareHouse(int WareHouseID)
        {
            List<CBookTransaction> List = new List<CBookTransaction>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.WareHouse_Detail.Where(x => x.WareHouse_ID == WareHouseID);
                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            CBookTransaction Book = new CBookTransaction
                            {
                                ID = item.Book_ID,
                                Name = item.Book.Book_Name,
                                Count = item.Book_Count,
                                Price = (float)item.Book_Price,
                                TotalMoney = (float)item.Book_Price * item.Book_Count,
                                Category = new CCategory
                                {
                                    ID = item.Book.Book_Category,
                                    Name = item.Book.Category.Category_Name
                                },
                                SubCategory = new CSubCategory
                                {
                                    ID = item.Book.Book_SubCategory,
                                    Name = item.Book.SubCategory.SubCategory_Name
                                }
                            };

                            List.Add(Book);
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
        /// Trừ số lượng sách tồn kho trong bảng tồn kho trả về ID nhập kho, số lượng sách đã trừ,số lượng sách đưa vào sau khi trừ, 
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="bookCount"></param>
        public Tuple<int,int,int> decreaseInventory(int bookID,int bookCount)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var firstInventory = DB.Book_Inventory.Where(x => x.Book_ID == bookID && x.Book_Count != 0)
                        .OrderBy(x => x.WareHouse.WareHouse_Date).FirstOrDefault();

                    if (firstInventory != null)
                    {
                        int bookDecrease = 0;
                        if(bookCount >= firstInventory.Book_Count)
                        {
                            bookDecrease = firstInventory.Book_Count;
                            bookCount -= firstInventory.Book_Count;
                            //Cập nhật lại thông tin sách bằng 0
                            firstInventory.Book_Count = 0;                                                   
                        }
                        else
                        {
                            bookDecrease = bookCount;
                            firstInventory.Book_Count -= bookCount;
                            bookCount = 0;
                        }

                        DB.SaveChanges();
                        return new Tuple<int, int, int>(firstInventory.WareHouse_ID, bookDecrease, bookCount);
                    }
                }
            }
            catch
            {

            }

            return new Tuple<int, int, int>(0, 0, bookCount);
        }

        /// <summary>
        /// Hàm trả về giá tiền nhập tương ứng với ID sách và ID nhập kho
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="wareHouseID"></param>
        /// <returns></returns>
        public float BookInPrice(int bookID,int wareHouseID)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.WareHouse_Detail.Where(x => x.Book_ID == bookID && x.WareHouse_ID == wareHouseID).FirstOrDefault();

                    if (find != null)
                    {
                        return (float)find.Book_Price;
                    }
                }
            }
            catch
            {

            }
            return 0;
        }
    }
}
