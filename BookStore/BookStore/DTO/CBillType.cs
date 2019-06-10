using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CBillType
    {
        private int _iD;
        /// <summary>
        /// Mã loại
        /// </summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _name;
        /// <summary>
        /// Tên loại hóa đơn
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
