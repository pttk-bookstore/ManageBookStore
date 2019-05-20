using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CCategory
    {
        private int _iD;
        /// <summary>
        /// ID chuyên mục
        /// </summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _name;
        /// <summary>
        /// Tên chuyên mục
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _count;
        /// <summary>
        /// Số sách cùng loại
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }



    }
}
