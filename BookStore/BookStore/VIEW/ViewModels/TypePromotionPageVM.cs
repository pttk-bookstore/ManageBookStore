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
    public class TypePromotionPageVM : BaseViewModel
    {
        #region Global 

        DiscountCodeBUS discountCodeBUS = new DiscountCodeBUS();

        private int _currentPage;
        public int CurrentPage { get => _currentPage; set { if (value == _currentPage) return; _currentPage = value; OnPropertyChanged(); } }

        int NumberPage = 10;

        #endregion

        #region data binding

        private ObservableCollection<CDiscountType> _listType;
        public ObservableCollection<CDiscountType> ListType { get => _listType; set { if (value == _listType) return; _listType = value; OnPropertyChanged(); } }

        private CDiscountType _selectedItem;
        public CDiscountType SelectedItem { get => _selectedItem; set { if (value == _selectedItem) return; _selectedItem = value; OnPropertyChanged(); } }

        private string _name;
        public string Name { get => _name; set { if (value == _name) return; _name = value; OnPropertyChanged(); } }

        private string _count;
        public string Count { get => _count; set { if (value == _count) return; _count = value; OnPropertyChanged(); } }

        private string _promotion;
        public string Promotion { get => _promotion; set { if (value == _promotion) return; _promotion = value; OnPropertyChanged(); } }

        private string _filterString;
        public string FilterString { get => _filterString; set { if (value == _filterString) return; _filterString = value; OnPropertyChanged(); } }

        #endregion

        #region command binding

        public ICommand addCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand deleteCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand CheckedCommand { get; set; }
        
        public ICommand searchCommand { get; set; }

        public ICommand PreviousPageCommand { get; set; }
        public ICommand NextPageCommand { get; set; }

        #endregion

        public TypePromotionPageVM()
        {
            PreviousPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (CurrentPage > 1)
                {
                    CurrentPage = CurrentPage - 1;
                    searchType();
                }
            }
              );

            NextPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CurrentPage = CurrentPage + 1;
                searchType(); 
            }
              );

            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                firstLoad();
            }
               );

            searchCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                searchType();
            }
               );

            editCommand = new RelayCommand<object>((p) => {
                checkRowTrue();
                return true;
            }, (p) =>
            {
                updateType();
            }
               );

            deleteCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                deleteType();
            }
               );

            addCommand = new RelayCommand<object>((p) => {
                return checkTrueValue();
            }, (p) =>
            {
                addType();
            }
               );
        }

        /// <summary>
        /// Khởi tạo các giá trị trong lần đầu tiên chạy
        /// </summary>
        private void firstLoad()
        {
            FilterString = "";
            CurrentPage = 1;
            loadType();
        }

        /// <summary>
        /// Tải code từ db
        /// </summary>
        private void loadType()
        {
            ListType = new ObservableCollection<CDiscountType>(discountCodeBUS.ListCodeType(CurrentPage, NumberPage));
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
                    SelectedItem.IsTrueValue = false;
                }
                else
                {
                    if (SelectedItem.MinCount < 0 || SelectedItem.Promotion < 0 || SelectedItem.Promotion > 1)
                    {
                        SelectedItem.IsTrueValue = false;
                    }
                    else
                    {
                        SelectedItem.IsTrueValue = true;
                    }
                }
            }
        }

        /// <summary>
        /// Cập nhật thông tin của mã code
        /// </summary>
        private void updateType()
        {
            if (SelectedItem != null)
            {
                int result = discountCodeBUS.updateType(SelectedItem);
                if (result == 1)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else if (result == 0)
                {
                    MessageBox.Show("Tên trùng với loại khác", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    loadType();
                }
            }
        }

        /// <summary>
        /// Xóa mã
        /// </summary>
        private void deleteType()
        {
            if (SelectedItem != null)
            {
                int result = discountCodeBUS.deleteType(SelectedItem.ID);
                if (result == 1)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    loadType();
                }
                else if (result == 0)
                {
                    MessageBox.Show("Loại đang được dùng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Tìm kiếm mã
        /// </summary>
        private void searchType()
        {
            if (FilterString == "")
            {
                ListType = new ObservableCollection<CDiscountType>(discountCodeBUS.ListCodeType(CurrentPage, NumberPage));
            }
            else
            {
                ListType = new ObservableCollection<CDiscountType>(discountCodeBUS.ListCodeType(FilterString,CurrentPage, NumberPage));
            }
        }

        /// <summary>
        /// Thêm mới code
        /// </summary>
        private void addType()
        {
            //Tạo mới
            CDiscountType Type = new CDiscountType
            {
                Name = Name,
                MinCount = int.Parse(Count),
                Promotion = float.Parse(Promotion)
            };

            int result = discountCodeBUS.addType(Type);

            if (result == 0)
            {
                MessageBox.Show("loại đã tồn tại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (result == -1)
            {
                MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                loadType();
                clearInput();
            }
        }

        /// <summary>
        /// Kiểm tra đầy đủ thông tin
        /// </summary>
        /// <returns></returns>
        private bool checkTrueValue()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Promotion) ||string.IsNullOrEmpty(Count))
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
            Name = "";
            Promotion = "";
            Count = "";
        }
    }
}
