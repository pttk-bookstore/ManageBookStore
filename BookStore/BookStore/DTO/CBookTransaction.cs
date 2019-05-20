using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CBookTransaction:CBook
    {
        private int _count;
        /// <summary>
        /// Số lượng sách giao dịch
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private float _totalMoney;
        /// <summary>
        /// Tổng tiền thanh toán tương ứng
        /// </summary>
        public float TotalMoney
        {
            get { return _totalMoney; }
            set { _totalMoney = value; }
        }


    }
}
