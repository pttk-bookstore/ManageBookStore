using BookStore.VIEW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CDiscountType:BaseViewModel
    {
        private int _iD;
        /// <summary>
        /// ID loại
        /// </summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _name;
        /// <summary>
        /// Tên loại
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _minCount;
        /// <summary>
        /// Số lượng sách tối thiểu để được khuyến mãi
        /// </summary>
        public int MinCount
        {
            get { return _minCount; }
            set { _minCount = value; }
        }

        private float _promotion;
        /// <summary>
        /// Khuyến mãi tương ứng 
        /// </summary>
        public float Promotion
        {
            get { return _promotion; }
            set { _promotion = value; }
        }

        private bool _isTrueValue;

        public bool IsTrueValue
        {
            get { return _isTrueValue; }
            set { _isTrueValue = value;OnPropertyChanged(); }
        }

        private int _count;
        /// <summary>
        /// Số lượng mã áp dụng
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
    }
}
