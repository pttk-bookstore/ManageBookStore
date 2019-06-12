using BookStore.BUS;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookStore.VIEW.ViewModels
{
    public class CustomerInfoPageVM : BaseViewModel
    {
        #region Global 

        CustomerBUS customerBUS = new CustomerBUS();

        private int _currentPage;
        public int CurrentPage { get => _currentPage; set { if (value == _currentPage) return; _currentPage = value; OnPropertyChanged(); } }

        int NumberPage = 15;

        #endregion

        #region data binding

        private ObservableCollection<CCustomer> _listCustomer;
        public ObservableCollection<CCustomer> ListCustomer { get => _listCustomer; set { if (value == _listCustomer) return; _listCustomer = value; OnPropertyChanged(); } }

        private CCustomer _listCustomerSelectedItem;
        public CCustomer ListCustomerSelectedItem { get => _listCustomerSelectedItem; set { if (value == _listCustomerSelectedItem) return; _listCustomerSelectedItem = value; OnPropertyChanged(); } }

        private string _filterString;
        public string FilterString { get => _filterString; set { if (value == _filterString) return; _filterString = value; OnPropertyChanged(); } }

        #endregion

        #region command binding

        public ICommand LoadCommand { get; set; }
        public ICommand searchCommand { get; set; }

        public ICommand PreviousPageCommand { get; set; }
        public ICommand NextPageCommand { get; set;}
        public ICommand detailCustomer { get; set; }


        #endregion

        public CustomerInfoPageVM()
        {
            PreviousPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (CurrentPage > 1)
                {
                    CurrentPage = CurrentPage - 1;
                    searchCustomer();
                }
            }
              );

            NextPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CurrentPage = CurrentPage + 1;
                searchCustomer();
            }
              );

            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                firstLoad();
            }
               );

            detailCustomer = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                showDetail();
            }
               );

            searchCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) =>
            {
                searchCustomer();
            }
              );
        }

        /// <summary>
        /// Khởi tạo màn hình lần đầu tiên chạy
        /// </summary>
        private void firstLoad()
        {
            CurrentPage = 1;
            FilterString = "";
            searchCustomer();
        }

        /// <summary>
        /// Tìm kiếm khách hàng
        /// </summary>
        private void searchCustomer()
        {
            if (Help.isInt(FilterString) == true)
            {
                ListCustomer = new ObservableCollection<CCustomer>(customerBUS.ListCustomerPhone(FilterString, CurrentPage, NumberPage));
            }
            else
            {
                ListCustomer = new ObservableCollection<CCustomer>(customerBUS.ListCustomerName(FilterString, CurrentPage, NumberPage));
            }
        }

        /// <summary>
        /// Xem thông tin chi tiết giao dịch của khách hàng
        /// </summary>
        private void showDetail()
        {
            if (ListCustomerSelectedItem != null)
            {
                //Tạo mới màn hình truyền qua ID và tên của customer
                DetailCustomerWindow wd = new DetailCustomerWindow(ListCustomerSelectedItem.Name, ListCustomerSelectedItem.ID);
                wd.ShowDialog();
            }
        }
    }
}
