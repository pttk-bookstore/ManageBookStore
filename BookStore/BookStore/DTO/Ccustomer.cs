using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CCustomer:CPeople
    {
        private int _numberBook;
        /// <summary>
        /// Số lượng sách mà khách hàng đã mua
        /// </summary>
        public int NumberBook
        {
            get { return _numberBook; }
            set { _numberBook = value; }
        }

        private float _moneyPaid;
        /// <summary>
        /// Tổng số tiền mà khách đã chi trả cho cửa hàng
        /// </summary>
        public float MoneyPaid
        {
            get { return _moneyPaid; }
            set { _moneyPaid = value; }
        }

        private DateTime _lastTransaction;
        /// <summary>
        /// Giao dịch cuối của khách hàng
        /// </summary>
        public DateTime LastTransaction
        {
            get { return _lastTransaction; }
            set { _lastTransaction = value; }
        }



    }
}
