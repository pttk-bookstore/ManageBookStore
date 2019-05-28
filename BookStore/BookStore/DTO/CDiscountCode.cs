using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CDiscountCode
    {
        private string _code;
        /// <summary>
        /// Mã code khuyến mãi
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _name;
        /// <summary>
        /// Tên code khuyến mãi
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private float _percent;
        /// <summary>
        /// Phần trăm khuyến mãi
        /// </summary>
        public float Percent
        {
            get { return _percent; }
            set { _percent = value; }
        }

        private DateTime _dateStart;
        /// <summary>
        /// Ngày bắt đầu áp dụng
        /// </summary>
        public DateTime DateStart
        {
            get { return _dateStart; }
            set { _dateStart = value; }
        }

        private DateTime _dateEnd;
        /// <summary>
        /// Ngày hết hạn khuyến mãi
        /// </summary>
        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set { _dateEnd = value; }
        }

        private int _numberBook;
        /// <summary>
        /// Số lượng sách tối thiểu cần phải mua để áp dụng khuyến mãi
        /// </summary>
        public int NumberBook
        {
            get { return _numberBook; }
            set { _numberBook = value; }
        }






    }
}
