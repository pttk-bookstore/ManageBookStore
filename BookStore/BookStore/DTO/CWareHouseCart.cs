using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    class CWareHouseCart
    {
        #region singleton
        private static CWareHouseCart _instance = null;
        public static CWareHouseCart Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CWareHouseCart();
                }

                return _instance;
            }
        }

        private CWareHouseCart()
        {
            listBookImport = new List<CBookTransaction>();
        }

        #endregion

        private List<CBookTransaction> _listBookImport;
        /// <summary>
        /// Danh sách sách trong giỏ hàng
        /// </summary>
        private List<CBookTransaction> listBookImport
        {
            get { return _listBookImport; }
            set { _listBookImport = value; }
        }

        /// <summary>
        /// Thêm sách vào trong giỏ hàng
        /// </summary>
        /// <param name="Book"></param>
        /// <returns></returns>
        public bool Add(CBookTransaction Book)
        {
            if (listBookImport.Where(x => x.ID == Book.ID).Count() > 0)
            {
                return false;
            }
            listBookImport.Add(Book);
            return true;
        }

        /// <summary>
        /// Xóa sách khỏi giỏ hàng
        /// </summary>
        /// <param name="Book"></param>
        /// <returns></returns>
        public bool Remove(CBookTransaction Book)
        {
            var find = listBookImport.Where(x => x.ID == Book.ID).FirstOrDefault();
            if (find != null)
            {
                listBookImport.Remove(find);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Cập nhật thông tin sách trên giỏ hàng
        /// </summary>
        /// <param name="Book"></param>
        /// <param name="DataUpdate"></param>
        /// <returns></returns>
        public bool Upadte(CBookTransaction Book)
        {
            var find = listBookImport.Where(x => x.ID == Book.ID).FirstOrDefault();
            find.Count = Book.Count;
            find.TotalMoney = Book.TotalMoney;
            find.Price = Book.Price;
            return true;
        }

        /// <summary>
        /// Kiểm tra sách đã được tick
        /// </summary>
        /// <param name="BookID"></param>
        /// <returns></returns>
        public bool isChoosed(int BookID)
        {
            if (listBookImport.Where(x => x.ID == BookID).Count() > 0)
            {
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Xóa toàn bộ sách trong giỏ hàng
        /// </summary>
        /// <returns></returns>
        public bool RemoveAll()
        {
            listBookImport.Clear();
            return true;
        }

        public int NumberBook()
        {
            return listBookImport.Count;
        }

        /// <summary>
        /// Trả về danh sách sách trong giỏ hàng
        /// </summary>
        /// <returns></returns>
        public List<CBookTransaction> ListBookTransaction()
        {
            return listBookImport;
        }
    }
}
