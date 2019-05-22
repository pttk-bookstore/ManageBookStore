using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CBookReipt:CBaseReceipt
    {
        private CEmployee _bManager;
        /// <summary>
        /// Quản lý nhập sách
        /// </summary>
        public CEmployee BManager
        {
            get { return _bManager; }
            set { _bManager = value; }
        }

    }
}
