using BookStore.VIEW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CDiscountCode:BaseViewModel
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

        private CDiscountType _type;
        /// <summary>
        /// Loại mã khuyến mãi
        /// </summary>
        public CDiscountType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private bool _istrueValue;

        public bool IstrueValue
        {
            get { return _istrueValue; }
            set { _istrueValue = value; OnPropertyChanged(); }
        }

        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value;OnPropertyChanged(); }
        }


    }
}
