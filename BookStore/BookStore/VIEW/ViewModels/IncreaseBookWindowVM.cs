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
using System.Windows.Media.Imaging;

namespace BookStore.VIEW.ViewModels
{
    public class IncreaseBookWindowVM:BaseViewModel
    {
        #region global

        EmployeeBUS employeeBUS = new EmployeeBUS();
        WareHouseBUS wareHouseBUS = new WareHouseBUS();

        #endregion

        #region data binding

        private ObservableCollection<CBookTransaction> _listBook;
        public ObservableCollection<CBookTransaction> ListBook { get => _listBook; set { if (value == _listBook) return; _listBook = value; OnPropertyChanged(); } }

        private CBookTransaction _listBookSelectedItem;
        public CBookTransaction ListBookSelectedItem { get => _listBookSelectedItem; set { if (value == _listBookSelectedItem) return; _listBookSelectedItem = value; OnPropertyChanged(); } }

        private int _listBookSelectedIndex;
        public int ListBookSelectedIndex { get => _listBookSelectedIndex; set { if (value == _listBookSelectedIndex) return; _listBookSelectedIndex = value; OnPropertyChanged(); } }

        private BitmapImage _coverImage;
        public BitmapImage CoverImage { get => _coverImage; set { if (value == _coverImage) return; _coverImage = value; OnPropertyChanged(); } }

        private string _employeeName;
        public string EmployeeName { get => _employeeName; set { if (value == _employeeName) return; _employeeName = value; OnPropertyChanged(); } }

        private string _dateNow;
        public string DateNow { get => _dateNow; set { if (value == _dateNow) return; _dateNow = value; OnPropertyChanged(); } }

        private float _totalPrice;

        public float TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value;OnPropertyChanged(); }
        }

        #endregion

        #region command binding

        public ICommand LoadCommand { get; set; }
        public ICommand ListBookSelectionChanged { get; set; }
        public ICommand deleteCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand addCommand { get; set; }

        #endregion

        public IncreaseBookWindowVM()
        { 
            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                firtLoad();
            }
               );

            addCommand = new RelayCommand<object>((p) => { return checkTrueBill(); }, (p) =>
            {
                addTransaction();
            }
               );

            editCommand = new RelayCommand<object>((p) => {
                changeEnableButtonEdit();
                return true;
            }, (p) =>
            {
                updateBook();
            }
               );

            deleteCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                removeBook();
            }
               );

            ListBookSelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (ListBookSelectedItem != null)
                {
                    CoverImage = ListBookSelectedItem.Image;
                }
            }
               );
        }

        /// <summary>
        /// Thêm sách vào trong kho
        /// </summary>
        private void addTransaction()
        {
            //Tạo mới một giao dịch
            CBookReipt bookReipt = new CBookReipt
            {
                BManager = new CEmployee { ID = DataTransfer.EmployeeID },
                Date = DateTime.Now,
                TotalMoney = ListBook.Sum(x => x.TotalMoney),
                ListBook = ListBook.ToList(),
                TypeID = 1
            };

            int BookCount = wareHouseBUS.addTransactionIncreaseBook(bookReipt);

            if (BookCount == ListBook.Count)
            {
                ////Thông báo nhập thành công
                MessageBox.Show("Nhập thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                ////Thông báo nhập thành công
                MessageBox.Show("Đã có lỗi trong quá trình nhập", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Làm mới ListBook
            ListBook.Clear();
            //Xóa giỏ hàng
            CWareHouseCart.Instance.RemoveAll();
            updateSumMoney();
        }

        /// <summary>
        /// Khởi tạo màn hình trong lần đầu tiên chạy
        /// </summary>
        private void firtLoad()
        {
            ListBook = new ObservableCollection<CBookTransaction>(CWareHouseCart.Instance.ListBookTransaction());
            EmployeeName = employeeBUS.EmployeeName(DataTransfer.EmployeeID);
            DateNow = DateTime.Now.ToShortDateString();
            if (ListBook.Count == 1)
            {
                CoverImage = ListBook[0].Image;
            }

            updateSumMoney();
        }

        /// <summary>
        /// Xóa sách khỏi giỏ hàng
        /// </summary>
        private void removeBook()
        {
            if (ListBookSelectedItem != null)
            {
                //Xóa trong giỏ hàng
                CWareHouseCart.Instance.Remove(ListBookSelectedItem);
                //Xóa theo index
                ListBook.RemoveAt(ListBookSelectedIndex);

                updateSumMoney();
            }
        }

        /// <summary>
        /// Cập nhật lại số lượng sách trong giỏ hàng
        /// </summary>
        private void updateBook()
        {
            if (ListBookSelectedItem != null)
            {
                //Kiểm tra điều kiện số lượng sách tồn trong kho tối thiểu trước khi thay đổi

                ListBookSelectedItem.TotalMoney = ListBookSelectedItem.Count * ListBookSelectedItem.Price;

                //Cập nhật lại thông tin trên giỏ hàng
                CWareHouseCart.Instance.Upadte(ListBookSelectedItem);

                updateSumMoney();
            }
        }

        /// <summary>
        /// Thay đổi trạng thái cập nhật của nút cập nhật trên list
        /// </summary>
        private void changeEnableButtonEdit()
        {
            if (ListBookSelectedItem != null)
            {
                if (ListBookSelectedItem.Count <= 0)
                {
                    ListBookSelectedItem.IsTrueValue = false;
                }
                else
                {
                    if (ListBookSelectedItem.Price <= 0)
                    {
                        ListBookSelectedItem.IsTrueValue = false;
                    }
                    else
                    {
                        ListBookSelectedItem.IsTrueValue = true;
                    }
                }
            }
        }

        /// <summary>
        /// Cập nhật lại tổng số tiền khi thay đổi các giá trị
        /// </summary>
        private void updateSumMoney()
        {
            //Cập nhật lại tổng tiền
            if (ListBook.Count > 0)
            {
                TotalPrice = ListBook.Sum(x => x.Count * x.Price);
            }
            else
            {
                TotalPrice = 0;
            }
        }

        /// <summary>
        /// Kiểm tra thông tin nhập đã đầy đủ hay chưa
        /// </summary>
        /// <returns></returns>
        private bool checkTrueBill()
        {
            if (ListBook.Count == 0)
            {
                return false;
            }
            if (TotalPrice <= 0)
            {
                return false;
            }
            
            return true;
        }
    }
}
