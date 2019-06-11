using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CReportMonth
    {
        private int _month;
        /// <summary>
        /// Tháng báo cáo
        /// </summary>
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        private int _toltalBookIn;
        /// <summary>
        /// Tổng sách đã nhập
        /// </summary>
        public int ToltalBookIn
        {
            get { return _toltalBookIn; }
            set { _toltalBookIn = value; }
        }

        private int _totalBooksSold;
        /// <summary>
        /// Tổng sách đã bán
        /// </summary>
        public int ToltalBooksSold
        {
            get { return _totalBooksSold; }
            set { _totalBooksSold = value; }
        }

        private float _totalMoneyBooksSell;
        /// <summary>
        /// Tổng tiền bán sách
        /// </summary>
        public float ToltalMoneyBooksSell
        {
            get { return _totalMoneyBooksSell; }
            set { _totalMoneyBooksSell = value; }
        }

        private float _totalMoneyBooksIn;
        /// <summary>
        /// Tổng tiền nhập sách
        /// </summary>
        public float ToltalMoneyBooksIn
        {
            get { return _totalMoneyBooksIn; }
            set { _totalMoneyBooksIn = value; }
        }

        private float _totalProfit;
        /// <summary>
        /// Tổng lợi nhuận
        /// </summary>
        public float TotalProfit
        {
            get { return _totalProfit; }
            set { _totalProfit = value; }
        }

        private float _toltalSalary;
        /// <summary>
        /// Tổng tiền lương thanh toán cho nhân viên
        /// </summary>
        public float ToltalSalary
        {
            get { return _toltalSalary; }
            set { _toltalSalary = value; }
        }


    }
}
