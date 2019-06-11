using BookStore.VIEW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CBaseReceipt:BaseViewModel
    {
        private int _iD;
        /// <summary>
        /// ID giao dịch
        /// </summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private DateTime _date;
        /// <summary>
        /// Thời gian giao dịch
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private float _totalMoney;
        /// <summary>
        /// Tổng tiền trong đợt giao dịch
        /// </summary>
        public float TotalMoney
        {
            get { return _totalMoney; }
            set { _totalMoney = value; }
        }

        private List<CBookTransaction> _listBook;
        /// <summary>
        /// List sách trong lần giao dịch
        /// </summary>
        public List<CBookTransaction> ListBook
        {
            get { return _listBook; }
            set { _listBook = value; }
        }

        private string _type;
        /// <summary>
        /// Loại giao dịch
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _typeID;
        /// <summary>
        /// Mã loại giao dịch
        /// </summary>
        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }

        private int _totalCount;
        /// <summary>
        /// Tổng sách trong đợt giao dịch
        /// </summary>
        public int TotalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }
    }
}
