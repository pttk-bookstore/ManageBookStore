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

        }

        #endregion

        private List<CBookTransaction> _listBook;
        /// <summary>
        /// Danh sách sách trong giỏ hàng
        /// </summary>
        public List<CBookTransaction> ListBook
        {
            get { return _listBook; }
            set { _listBook = value; }
        }

        /// <summary>
        /// Thêm sách vào trong giỏ hàng
        /// </summary>
        /// <param name="Book"></param>
        /// <returns></returns>
        public bool Add(CBookTransaction Book)
        {
            return true;
        }

        /// <summary>
        /// Xóa sách khỏi giỏ hàng
        /// </summary>
        /// <param name="Book"></param>
        /// <returns></returns>
        public bool Remove(CBookTransaction Book)
        {
            return true;
        }

        /// <summary>
        /// Cập nhật thông tin sách trên giỏ hàng
        /// </summary>
        /// <param name="Book"></param>
        /// <param name="DataUpdate"></param>
        /// <returns></returns>
        public bool Upadte(CBookTransaction Book,CBookTransaction DataUpdate)
        {
            return true;
        }

        /// <summary>
        /// Xóa toàn bộ sách trong giỏ hàng
        /// </summary>
        /// <returns></returns>
        public bool RemoveAll()
        {

            return true;
        }
        


    }
}
