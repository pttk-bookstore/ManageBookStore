using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.VIEW.ViewClass
{
    public class StructBook
    {
        private string _categoryName;
        /// <summary>
        /// Tên Category
        /// </summary>
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        private int _count;
        /// <summary>
        /// Số lượng sách tương ứng
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
    }
}
