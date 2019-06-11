using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CBill:CBaseReceipt
    {
        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value;OnPropertyChanged(); }
        }

        private CCustomer _bCustomer;
        /// <summary>
        /// Khách mua hàng
        /// </summary>
        public CCustomer BCustomer
        {
            get { return _bCustomer; }
            set { _bCustomer = value; }
        }

        private CEmployee _bSalesman;
        /// <summary>
        /// Nhân viên bán hàng
        /// </summary>
        public CEmployee BSalesman
        {
            get { return _bSalesman; }
            set { _bSalesman = value; }
        }

        private CBillType _typeBill;
        /// <summary>
        /// Loại hóa đơn
        /// </summary>
        public CBillType TypeBill
        {
            get { return _typeBill; }
            set { _typeBill = value; }
        }

        private float _sumMoney;
        /// <summary>
        /// Tổng tiền của hóa đơn
        /// </summary>
        public float SumMoney
        {
            get { return _sumMoney; }
            set { _sumMoney = value; }
        }

        private CDiscountCode _bDiscountCode;
        /// <summary>
        /// Mã khuyến mãi nếu có của hóa đơn
        /// </summary>
        public CDiscountCode BDiscountCode
        {
            get { return _bDiscountCode; }
            set { _bDiscountCode = value; }
        }

        private float _cash;
        /// <summary>
        /// Tiền khách hàng đưa cho cửa hàng
        /// </summary>
        public float Cash
        {
            get { return _cash; }
            set { _cash = value; }
        }

        private float _excessCash;
        /// <summary>
        /// Tiền thừa trả khách hàng
        /// </summary>
        public float ExcessCash
        {
            get { return _excessCash; }
            set { _excessCash = value; }
        }

        private float _promotion;
        /// <summary>
        /// Khuyến mãi nếu có
        /// </summary>
        public float Promotion
        {
            get { return _promotion; }
            set { _promotion = value; }
        }
    }
}
