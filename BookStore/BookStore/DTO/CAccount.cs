using BookStore.VIEW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CAccount:BaseViewModel
    {
        private int _iD;
        /// <summary>
        /// ID tài khoản
        /// </summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _userName;
        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value;OnPropertyChanged(); }
        }

        private string  _passWord;
        /// <summary>
        /// Mật khẩu tài khoản
        /// </summary>
        public string  PassWord
        {
            get { return _passWord; }
            set { _passWord = value; }
        }

        private DateTime _lastLogin;
        /// <summary>
        /// Lần đăng nhập cuối
        /// </summary>
        public DateTime LastLogin
        {
            get { return _lastLogin; }
            set { _lastLogin = value; }
        }
    }
}
