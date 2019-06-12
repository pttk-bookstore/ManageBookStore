using BookStore.VIEW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CPeople:BaseViewModel
    {
        private int _iD;
        /// <summary>
        /// ID nhân viên hoặc khách hàng
        /// </summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; OnPropertyChanged(); }
        }

        private string _name;
        /// <summary>
        /// Tên nhân viên hoặc khách hàng
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value;OnPropertyChanged(); }
        }

        private string _address;
        /// <summary>
        /// Địa chỉ nhân viên hoặc khách hàng
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged(); }
        }

        private string _email;
        /// <summary>
        /// Email nhân viên hoặc khách hàng
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        private string _phone;
        /// <summary>
        /// Số điện thoại nhân viên hoặc khách hàng
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(); }
        }

        private string _gender;
        /// <summary>
        /// Giới tính
        /// </summary>
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged(); }
        }

    }
}
