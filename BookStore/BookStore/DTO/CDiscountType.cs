using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CDiscountType
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




    }
}
