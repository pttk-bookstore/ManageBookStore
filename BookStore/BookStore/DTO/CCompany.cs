using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CCompany
    {
        private int _iD;
        /// <summary>
        /// ID công ty
        /// </summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _name;
        /// <summary>
        /// Tên Công ty
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _count;
        /// <summary>
        /// Số sách cùng công ty
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

    }
}
