using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CCart
    {
        #region singleton
        private static CCart _instance = null;
        public static CCart Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CCart();
                }

                return _instance;
            }
        }

        private CCart()
        {
            listBookBill = new List<CBookTransaction>();
        }

        #endregion

        private List<CBookTransaction> _listBookBill;
        /// <summary>
        /// Danh sách sách trong giỏ hàng
        /// </summary>
        private List<CBookTransaction> listBookBill
        {
            get { return _listBookBill; }
            set { _listBookBill = value; }
        }

        /// <summary>
        /// Thêm sách vào trong giỏ hàng
        /// </summary>
        /// <param name="Book"></param>
        /// <returns></returns>
        public bool Add(CBookTransaction Book)
        {
            if (listBookBill.Where(x => x.ID == Book.ID).Count() > 0)
            {      
                return false;
            }
            listBookBill.Add(Book);
            return true;          
        }

        /// <summary>
        /// Xóa sách khỏi giỏ hàng
        /// </summary>
        /// <param name="Book"></param>
        /// <returns></returns>
        public bool Remove(CBookTransaction Book)
        {
            var find = listBookBill.Where(x => x.ID == Book.ID).FirstOrDefault();
            if (find != null)
            {
                listBookBill.Remove(find);
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
            var find = listBookBill.Where(x => x.ID == Book.ID).FirstOrDefault();
            find.Count = Book.Count;
            find.Inventory = Book.Inventory;
            find.TotalMoney = Book.TotalMoney;

            return true;
        }

        /// <summary>
        /// Xóa toàn bộ sách trong giỏ hàng
        /// </summary>
        /// <returns></returns>
        public bool RemoveAll()
        {
            listBookBill.Clear();
            return true;
        }

        public int NumberBook()
        {
            return listBookBill.Count;
        }
        
        /// <summary>
        /// Trả về danh sách sách trong giỏ hàng
        /// </summary>
        /// <returns></returns>
        public List<CBookTransaction> ListBookTransaction()
        {
            return listBookBill;
        }

    }
}
