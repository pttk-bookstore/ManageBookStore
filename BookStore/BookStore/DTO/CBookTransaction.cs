﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CBookTransaction:CBook
    {
        private int _transactionID;
        /// <summary>
        /// ID giao dịch nếu có
        /// </summary>
        public int TransactionID
        {
            get { return _transactionID; }
            set { _transactionID = value; }
        }

        private string _typeTransaction;
        /// <summary>
        /// Loại giao dịch nếu có
        /// </summary>
        public string TypeTransaction
        {
            get { return _typeTransaction; }
            set { _typeTransaction = value; }
        }

        private DateTime _dateTransaction;
        /// <summary>
        /// Ngày giao dịch nếu có
        /// </summary>
        public DateTime DateTransaction
        {
            get { return _dateTransaction; }
            set { _dateTransaction = value; }
        }



        private int _count;
        /// <summary>
        /// Số lượng sách giao dịch
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private float _totalMoney;
        /// <summary>
        /// Tổng tiền thanh toán tương ứng
        /// </summary>
        public float TotalMoney
        {
            get { return _totalMoney; }
            set { _totalMoney = value; }
        }


    }
}
