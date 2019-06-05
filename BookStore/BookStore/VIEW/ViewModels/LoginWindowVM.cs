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
    public class LoginWindowVM : BaseViewModel
    {
        #region data binding

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string _PassWord;
        public string PassWord
        {
            get { return _PassWord; }
            set { _PassWord = value; }
        }

        #endregion

        #region properties binding

        private Visibility _errorVisibility;
        public Visibility ErrorVisibility { get => _errorVisibility; set { if (value == _errorVisibility) return; _errorVisibility = value; OnPropertyChanged(); } }

        private string _errorMess;
        public string ErrorMess { get => _errorMess; set { if (value == _errorMess) return; _errorMess = value; OnPropertyChanged(); } }

        #endregion

        #region command binding

        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand UserTextChanged { get; set; }

        #endregion

        public LoginWindowVM()
        {
            LoadedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ErrorVisibility = Visibility.Collapsed;
            }
                );

            UserTextChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ErrorVisibility = Visibility.Collapsed;
            }
                );

            LoginCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                checkLogin();
                DashboardWindow wd = new DashboardWindow();
                (p as Window)?.Hide();
                wd.ShowDialog();
                (p as Window)?.Show();
            }
               );

            PasswordChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                PassWord = (p as PasswordBox)?.Password;
                ErrorVisibility = Visibility.Collapsed;
            }
                );
        }

        private bool checkLogin()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(PassWord))
            {
                ErrorMess = "Thông tin không được để trống";
                ErrorVisibility = Visibility.Visible;
                return false;
            }
            else
            {
                return true;

            }
        }
    }
}
