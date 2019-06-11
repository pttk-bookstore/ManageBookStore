using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CReportDate
    {
        private DateTime _date;
        /// <summary>
        /// Ngày báo cáo
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private int _totalCustomers;
        /// <summary>
        /// Tổng khách mua trong ngày
        /// </summary>
        public int TotalCustomers
        {
            get { return _totalCustomers; }
            set { _totalCustomers = value; }
        }

        private int _totalBooksSold;
        /// <summary>
        /// Tổng sách bán được trong ngày
        /// </summary>
        public int ToltalBooksSold
        {
            get { return _totalBooksSold; }
            set { _totalBooksSold = value; }
        }

        private float _totalMoneyBookSell;
        /// <summary>
        /// Tổng tiền bán sách trong ngày
        /// </summary>
        public float ToltalMoneyBookSell
        {
            get { return _totalMoneyBookSell; }
            set { _totalMoneyBookSell = value; }
        }

        private float _totalProfit;
        /// <summary>
        /// Ước lượng lợi nhuận
        /// </summary>
        public float TotalProfit
        {
            get { return _totalProfit; }
            set { _totalProfit = value; }
        }

        private float _toltalMoneyBookIn;

        public float ToltalMoneyBookIn
        {
            get { return _toltalMoneyBookIn; }
            set { _toltalMoneyBookIn = value; }
        }

    }
}
