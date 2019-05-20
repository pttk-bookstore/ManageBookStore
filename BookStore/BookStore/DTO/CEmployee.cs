using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BookStore.DTO
{
    public class CEmployee:CPeople
    {
        private BitmapImage _avatar;
        /// <summary>
        /// Ảnh đại diện nhân viên
        /// </summary>
        public BitmapImage Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        private DateTime _doB;
        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        public DateTime DOB
        {
            get { return _doB; }
            set { _doB = value; }
        }


        private DateTime _firstDate;
        /// <summary>
        /// Ngày bắt đầu làm việc
        /// </summary>
        public DateTime FirstDate
        {
            get { return _firstDate; }
            set { _firstDate = value; }
        }

        private CEmployeeRole _role;
        /// <summary>
        /// Loại nhân viên
        /// </summary>
        public CEmployeeRole Role
        {
            get { return _role; }
            set { _role = value; }
        }


        private int _sumDate;
        /// <summary>
        /// Tổng ngày làm việc trong tháng
        /// </summary>
        public int SumDate
        {
            get { return _sumDate; }
            set { _sumDate = value; }
        }


    }
}
