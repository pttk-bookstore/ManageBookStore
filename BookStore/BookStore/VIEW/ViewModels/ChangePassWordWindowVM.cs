using BookStore.BUS;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookStore.VIEW.ViewModels
{
    public class ChangePassWordWindowVM : BaseViewModel
    {

        #region global

        AccountBUS accountBUS = new AccountBUS();

        #endregion

        #region data binding

        private string _OldPassWord;
        public string OldPassWord
        {
            get { return _OldPassWord; }
            set
            {
                _OldPassWord = value;
                OnPropertyChanged(nameof(OldPassWord));
            }
        }

        private string _NewPassWord;
        public string NewPassWord
        {
            get { return _NewPassWord; }
            set
            {
                _NewPassWord = value;
                OnPropertyChanged(nameof(NewPassWord));
            }
        }

        private string _ComfirmPassWord;
        public string ComfirmPassWord
        {
            get { return _ComfirmPassWord; }
            set
            {
                _ComfirmPassWord = value;
                OnPropertyChanged(nameof(ComfirmPassWord));
            }
        }

        #endregion

        #region command binding

        public ICommand AcceptCommand { get; set; }
        public ICommand OldPassCommand { get; set; }
        public ICommand NewPassCommand { get; set; }
        public ICommand ComfirmPassCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        #endregion

        public ChangePassWordWindowVM()
        {
            LoadCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                //Employee = DataTransfer.EmployeeInfo;
            }
               );

            AcceptCommand = new RelayCommand<PasswordBox>((p) =>
            {
                return checkTrueValue();
            },
            (p) =>
            {
                updatePassWord();
            }
               );

            OldPassCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                OldPassWord = p.Password;
            }
               );

            NewPassCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                NewPassWord = p.Password;
            }
               );

            ComfirmPassCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                ComfirmPassWord = p.Password;
            }
               );
        }

        /// <summary>
        /// Kiểm tra thông tin đúng
        /// </summary>
        private bool checkTrueValue()
        {
            if (string.IsNullOrEmpty(OldPassWord) || string.IsNullOrEmpty(NewPassWord) || string.IsNullOrEmpty(ComfirmPassWord))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cập nhật mật khẩu
        /// </summary>
        private void updatePassWord()
        {       
            //Kiểm tra mật khẩu mới có trùng với mật khẩu xác nhận hay không
            if (NewPassWord != ComfirmPassWord)
            {
                MessageBox.Show("Mật khẩu xác nhận không đúng");
                return;
            }
            else
            {
                int result = accountBUS.changePass(DataTransfer.EmployeeID, Help.Base64Encode(OldPassWord), Help.Base64Encode(NewPassWord));
                if(result == 0)
                {
                    MessageBox.Show("Mật khẩu không đúng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (result == 1)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    clearInput();
                    return;
                }
                else
                {
                    MessageBox.Show("Có lỗi trong quá trình cập nhật","Lỗi",MessageBoxButton.OK,MessageBoxImage.Error);
                    return;
                }
            }

        }

        /// <summary>
        /// Xóa trắng thông tin
        /// </summary>
        private void clearInput()
        {
            //trả về trắng thông tin
            NewPassWord = "";
            OldPassWord = "";
            ComfirmPassWord = "";
        }
    }
}
