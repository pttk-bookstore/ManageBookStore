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
    
    public class CodePromotionPageVM : BaseViewModel
    {

        #region Global 

        DiscountCodeBUS discountCodeBUS = new DiscountCodeBUS();

        private int _currentPage;
        public int CurrentPage { get => _currentPage; set { if (value == _currentPage) return; _currentPage = value; OnPropertyChanged(); } }

        int NumberPage = 10;

        #endregion

        #region data binding

        private ObservableCollection<CDiscountCode> _listCode;
        public ObservableCollection<CDiscountCode> ListCode { get => _listCode; set { if (value == _listCode) return; _listCode = value; OnPropertyChanged(); } }

        private CDiscountCode _selectedItem;
        public CDiscountCode SelectedItem { get => _selectedItem; set { if (value == _selectedItem) return; _selectedItem = value; OnPropertyChanged(); } }

        private ObservableCollection<CDiscountType> _listType;
        public ObservableCollection<CDiscountType> ListType { get => _listType; set { if (value == _listType) return; _listType = value; OnPropertyChanged(); } }

        private string _iD;
        public string ID { get => _iD; set { if (value == _iD) return; _iD = value; OnPropertyChanged(); } }

        private string _name;
        public string Name { get => _name; set { if (value == _name) return; _name = value; OnPropertyChanged(); } }

        private CDiscountType _type;
        public CDiscountType Type { get => _type; set { if (value == _type) return; _type = value; OnPropertyChanged(); } }

        private DateTime _dateBegin;
        public DateTime DateBegin { get => _dateBegin; set { if (value == _dateBegin) return; _dateBegin = value; OnPropertyChanged(); } }

        private DateTime _dateEnd;
        public DateTime DateEnd { get => _dateEnd; set { if (value == _dateEnd) return; _dateEnd = value; OnPropertyChanged(); } }

        private string _filterString;
        public string FilterString { get => _filterString; set { if (value == _filterString) return; _filterString = value; OnPropertyChanged(); } }

        #endregion

        #region properties binding

        private bool _isChecked;
        public bool IsChecked { get => _isChecked; set { if (value == _isChecked) return; _isChecked = value; OnPropertyChanged(); } }

        #endregion

        #region command binding

        public ICommand LoadCommand { get; set; }
        public ICommand addCommand { get; set; }
        public ICommand deleteCommand { get; set; }
        public ICommand CheckedCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand searchCommand { get; set; }
        public ICommand restoreCommand { get; set; }

        public ICommand PreviousPageCommand { get; set; }
        public ICommand NextPageCommand { get; set; }

        #endregion

        public CodePromotionPageVM()
        {
            PreviousPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (CurrentPage > 1)
                {
                    CurrentPage = CurrentPage - 1;
                    searchCode();
                }
            }
              );

            NextPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CurrentPage = CurrentPage + 1;
                searchCode();
            }
              );

            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                firstLoad();
            }
              );

            CheckedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadCode();
            }
              );

            searchCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                searchCode();
            }
              );

            editCommand = new RelayCommand<object>((p) => {
                checkRowTrue();
                return true;
            }, (p) =>
            {
                updateCode();
            }
              );

            restoreCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                restoreCode();
            }
              );

            deleteCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                deleteCode();
            }
              );

            addCommand = new RelayCommand<object>((p) => {
                return checkTrueValue();
            }, (p) =>
            {
                addCode();
            }
              );
        }

        /// <summary>
        /// Khởi tạo các giá trị trong lần đầu tiên chạy
        /// </summary>
        private void firstLoad()
        {
            FilterString = "";
            DateBegin = DateTime.Now;
            DateEnd = DateTime.Now;
            IsChecked = false;
            CurrentPage = 1;
            loadCode();
            ListType = new ObservableCollection<CDiscountType>(discountCodeBUS.ListCodeType());
        }

        /// <summary>
        /// Tải code từ db
        /// </summary>
        private void loadCode()
        {
            ListCode = new ObservableCollection<CDiscountCode>(discountCodeBUS.ListCode(IsChecked, CurrentPage, NumberPage));
        }

        /// <summary>
        /// Kiểm tra điều kiện đúng của hàng khi nhập
        /// </summary>
        private void checkRowTrue()
        {
            if (SelectedItem != null)
            {
                if (string.IsNullOrEmpty(SelectedItem.Name))
                {
                    SelectedItem.IstrueValue = false;
                }
                else
                {
                    if (SelectedItem.DateStart > SelectedItem.DateEnd)
                    {
                        SelectedItem.IstrueValue = false;
                    }
                    else
                    {
                        SelectedItem.IstrueValue = true;
                    }
                }
            }
        }

        /// <summary>
        /// Cập nhật thông tin của mã code
        /// </summary>
        private void updateCode()
        {
            if (SelectedItem != null)
            {
                int result = discountCodeBUS.updateCode(SelectedItem);
                if (result == 1)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    ListCode = new ObservableCollection<CDiscountCode>(discountCodeBUS.ListCode(IsChecked,CurrentPage, NumberPage));
                }
            }
        }

        /// <summary>
        /// Xóa mã
        /// </summary>
        private void deleteCode()
        {
            if (SelectedItem != null)
            {
                int result = discountCodeBUS.deleteCode(SelectedItem.Code);
                if (result == 1)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    ListCode = new ObservableCollection<CDiscountCode>(discountCodeBUS.ListCode(IsChecked,CurrentPage, NumberPage));
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Khôi phục lại mã code
        /// </summary>
        private void restoreCode()
        {
            if (SelectedItem != null)
            {
                int result = discountCodeBUS.restoreCode(SelectedItem.Code);
                if (result == 1)
                {
                    MessageBox.Show("Khôi phục thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    SelectedItem.Status = 1;
                }
                else
                {
                    MessageBox.Show("Khôi phục thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Tìm kiếm mã
        /// </summary>
        private void searchCode()
        {
            if (FilterString == "")
            {
                ListCode = new ObservableCollection<CDiscountCode>(discountCodeBUS.ListCode(IsChecked, CurrentPage, NumberPage));
            }
            else
            {
                ListCode = new ObservableCollection<CDiscountCode>(discountCodeBUS.ListCode(FilterString, IsChecked, CurrentPage, NumberPage));
            }
        }

        /// <summary>
        /// Thêm mới code
        /// </summary>
        private void addCode()
        {
            //Tạo mới
            CDiscountCode Code = new CDiscountCode
            {
                Code = ID,
                Name = Name,
                Type = Type,
                DateStart = DateBegin,
                DateEnd = DateEnd
            };

            int result = discountCodeBUS.addCode(Code);


            if (result == 0)
            {
                MessageBox.Show("Mã đã tồn tại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (result == -1)
            {
                MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                loadCode();
                clearInput();
            }
        }

        /// <summary>
        /// Kiểm tra đầy đủ thông tin
        /// </summary>
        /// <returns></returns>
        private bool checkTrueValue()
        {
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(Name))
            {
                return false;
            }
            if (DateBegin == null || DateEnd == null || Type == null)
            {
                return false;
            }

            if (DateBegin > DateEnd)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Xóa trắng
        /// </summary>
        private void clearInput()
        {
            ID = "";
            Name = "";
        }
    }
}
