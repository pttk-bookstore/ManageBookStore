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
    }
}
