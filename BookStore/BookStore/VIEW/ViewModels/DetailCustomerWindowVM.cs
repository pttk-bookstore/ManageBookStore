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
    class DetailCustomerWindowVM:BaseViewModel
    {
        #region Global

        BillBUS billBUS = new BillBUS();

        private int _currentPage;
        public int CurrentPage { get => _currentPage; set { if (value == _currentPage) return; _currentPage = value; OnPropertyChanged(); } }

        int NumberPage = 5;

        private string _customerName;

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value;OnPropertyChanged(); }
        }

        private int _customerID;

        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }



        #endregion

        #region data binding

        private ObservableCollection<string> _listMonth;
        public ObservableCollection<string> ListMonth { get => _listMonth; set { if (value == _listMonth) return; _listMonth = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _listYear;
        public ObservableCollection<string> ListYear { get => _listYear; set { if (value == _listYear) return; _listYear = value; OnPropertyChanged(); } }

        private string _selectedItemMonth;
        public string SelectedItemMonth { get => _selectedItemMonth; set { if (value == _selectedItemMonth) return; _selectedItemMonth = value; OnPropertyChanged(); } }

        private string _selectedItemYear;
        public string SelectedItemYear { get => _selectedItemYear; set { if (value == _selectedItemYear) return; _selectedItemYear = value; OnPropertyChanged(); } }

        private DateTime _dateEndSelectedDate;
        public DateTime DateEndSelectedDate { get => _dateEndSelectedDate; set { if (value == _dateEndSelectedDate) return; _dateEndSelectedDate = value; OnPropertyChanged(); } }

        private DateTime _dateBeginSelectedDate;
        public DateTime DateBeginSelectedDate { get => _dateBeginSelectedDate; set { if (value == _dateBeginSelectedDate) return; _dateBeginSelectedDate = value; OnPropertyChanged(); } }

        private ObservableCollection<CBill> _listBill;
        public ObservableCollection<CBill> ListBill { get => _listBill; set { if (value == _listBill) return; _listBill = value; OnPropertyChanged(); } }

        private CBill _billSelectedItem;
        public CBill BillSelectedItem { get => _billSelectedItem; set { if (value == _billSelectedItem) return; _billSelectedItem = value; OnPropertyChanged(); } }

        private int _billID;
        public int BillID { get => _billID; set { if (value == _billID) return; _billID = value; OnPropertyChanged(); } }

        private ObservableCollection<CBookTransaction> _listDetail;
        public ObservableCollection<CBookTransaction> ListDetail { get => _listDetail; set { if (value == _listDetail) return; _listDetail = value; OnPropertyChanged(); } }

        #endregion

        #region command binding

        public ICommand LoadCommand { get; set; }

        public ICommand PreviousPageCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ICommand BillSelectionChanged { get; set; }

        public ICommand SelectionChangedMonth { get; set; }
        public ICommand SelectionChangedYear { get; set; }

        public ICommand DateEndSelectedDateChanged { get; set; }
        public ICommand DateBeginSelectedDateChanged { get; set; }

        public ICommand VerifyBillCommand { get; set; }

        #endregion

        public DetailCustomerWindowVM(string CustomerName,int CustomerID)
        {
            DateEndSelectedDateChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                reloadWhenDateChange();
            }
             );

            DateBeginSelectedDateChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                reloadWhenDateChange();
            }
             );

            SelectionChangedYear = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                reloadWhenMonthYearChange();
            }
             );

            SelectionChangedMonth = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                reloadWhenMonthYearChange();
            }
             );

            BillSelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadDetailBill();
            }
              );

            PreviousPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (CurrentPage > 1)
                {
                    CurrentPage = CurrentPage - 1;
                    reloadWhenDateChange();
                }
            }
              );

            NextPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CurrentPage = CurrentPage + 1;
                reloadWhenDateChange();
            }
              );

            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                this.CustomerID = CustomerID;
                this.CustomerName = CustomerName;
                firtLoad();
            }
               );

            VerifyBillCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                verifyBill();
            }
             );
        }

        /// <summary>
        /// Cập nhật trạng thái của hóa đơn
        /// </summary>
        private void verifyBill()
        {
            if (BillSelectedItem != null)
            {
                int result = billBUS.VerifyBill(BillSelectedItem.ID);

                if (result == 1)
                {
                    MessageBox.Show("Cập nhật trạng thái thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    BillSelectedItem.Status = 1;
                }
                else
                {
                    MessageBox.Show("Cập nhật trạng thái thất bại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Khởi tạo màn hình trong lần đầu tiên chạy
        /// </summary>
        private void firtLoad()
        {
            CurrentPage = 1;
            CreateMonth();
            CreateYear();

            SelectedItemMonth = DateTime.Now.Month.ToString();
            SelectedItemYear = DateTime.Now.Year.ToString();

            ListDetail = new ObservableCollection<CBookTransaction>();

            //https://stackoverflow.com/questions/24245523/getting-the-first-and-last-day-of-a-month-using-a-given-datetime-object

            DateTime date = new DateTime(int.Parse(SelectedItemYear), int.Parse(SelectedItemMonth), 1);
            DateBeginSelectedDate = new DateTime(date.Year, date.Month, 1);
            DateEndSelectedDate = DateBeginSelectedDate.AddMonths(1).AddDays(-1);

            loadBillByMonthAndYear();
        }

        /// <summary>
        /// Cập nhật lại chi tiết nhập kho khi thay đổi
        /// </summary>
        private void loadDetailBill()
        {
            if (BillSelectedItem != null)
            {
                BillID = BillSelectedItem.ID;
                ListDetail = new ObservableCollection<CBookTransaction>(billBUS.DetailOfBill(BillSelectedItem.ID));
            }
        }

        /// <summary>
        /// Tạo list tháng
        /// </summary>
        void CreateMonth()
        {
            ListMonth = new ObservableCollection<string>();
            for (int i = 1; i <= 12; i++)
            {
                ListMonth.Add(i.ToString());
            }
        }

        /// <summary>
        /// Tạo list năm
        /// </summary>
        void CreateYear()
        {
            ListYear = new ObservableCollection<string>();
            for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year + 5; i++)
            {
                ListYear.Add(i.ToString());
            }
        }

        /// <summary>
        /// Load lại dữ liệu lịch sử nhập kho khi thay đổi tháng và năm
        /// </summary>
        private void reloadWhenMonthYearChange()
        {
            if (SelectedItemMonth != null && SelectedItemYear != null)
            {
                ClearList();

                DateTime date = new DateTime(int.Parse(SelectedItemYear), int.Parse(SelectedItemMonth), 1);
                DateBeginSelectedDate = new DateTime(date.Year, date.Month, 1);
                DateEndSelectedDate = DateBeginSelectedDate.AddMonths(1).AddDays(-1);

                loadBillByMonthAndYear();
            }
        }

        /// <summary>
        /// load lại dữ lịch sử nhập kho khi thay đổi ngày bắt đầu và ngày kết thúc
        /// </summary>
        private void reloadWhenDateChange()
        {
            if (DateBeginSelectedDate != null && DateEndSelectedDate != null)
            {
                ClearList();
                loadBillByDate();
            }
        }

        /// <summary>
        /// Load dữ liệu lịch sử nhập kho theo năm và tháng
        /// </summary>
        private void loadBillByMonthAndYear()
        {
            ListBill = new ObservableCollection<CBill>(billBUS.Bill_History(CustomerID, int.Parse(SelectedItemMonth), int.Parse(SelectedItemYear), CurrentPage, NumberPage));
        }

        /// <summary>
        /// Load dữ liệu theo ngày
        /// </summary>
        private void loadBillByDate()
        {
            ListBill = new ObservableCollection<CBill>(billBUS.Bill_History(CustomerID, DateBeginSelectedDate, DateEndSelectedDate, CurrentPage, NumberPage));
        }

        /// <summary>
        /// Xóa list detail
        /// </summary>
        private void ClearList()
        {
            ListDetail.Clear();
            ListBill.Clear();
        }
    }
}
