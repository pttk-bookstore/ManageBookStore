using BookStore.DTO;
using System;
using System.Collections.Generic;
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
    }
}
