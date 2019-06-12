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
    public class BookInfoPageVM : BaseViewModel
    {
        #region Global

        BookBUS bookBUS = new BookBUS();
        CategoryBUS categoryBUS = new CategoryBUS();
        SubCategoryBUS subcategoryBUS = new SubCategoryBUS();
        CompanyBUS companyBUS = new CompanyBUS();
        WareHouseBUS wareHouseBUS = new WareHouseBUS();
        EmployeeBUS employeeBUS = new EmployeeBUS();

        private int _currentPage;
        public int CurrentPage { get => _currentPage; set { if (value == _currentPage) return; _currentPage = value; OnPropertyChanged(); } }

        int NumberPage = 12;

        private int _roleID;

        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; OnPropertyChanged(); }
        }

        

        #endregion

        #region data binding

        public CEmployee EmployeeInfo;

        private ObservableCollection<CBook> _listBook;
        public ObservableCollection<CBook> ListBook { get => _listBook; set { if (value == _listBook) return; _listBook = value; OnPropertyChanged(); } }

        private CBook _listSelectedItem;
        public CBook ListSelectedItem { get => _listSelectedItem; set { if (value == _listSelectedItem) return; _listSelectedItem = value; OnPropertyChanged(); } }

        private BitmapImage _coverImage;
        public BitmapImage CoverImage { get => _coverImage; set { if (value == _coverImage) return; _coverImage = value; OnPropertyChanged(); } }

        private int _sumNumber;
        public int SumNumber { get => _sumNumber; set { if (value == _sumNumber) return; _sumNumber = value; OnPropertyChanged(); } }

        private DateTime _lastDate;
        public DateTime LastDate { get => _lastDate; set { if (value == _lastDate) return; _lastDate = value; OnPropertyChanged(); } }

        private int _lastNumberBook;
        public int LastNumberBook { get => _lastNumberBook; set { if (value == _lastNumberBook) return; _lastNumberBook = value; OnPropertyChanged(); } }

        private float _lastTotalMoney;
        public float LastTotalMoney { get => _lastTotalMoney; set { if (value == _lastTotalMoney) return; _lastTotalMoney = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _listAuthor;
        public ObservableCollection<string> ListAuthor { get => _listAuthor; set { if (value == _listAuthor) return; _listAuthor = value; OnPropertyChanged(); } }

        private ObservableCollection<CCategory> _listCategory;
        public ObservableCollection<CCategory> ListCategory { get => _listCategory; set { if (value == _listCategory) return; _listCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<CSubCategory> _listSubCategory;
        public ObservableCollection<CSubCategory> ListSubCategory { get => _listSubCategory; set { if (value == _listSubCategory) return; _listSubCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<CCompany> _listCompany;
        public ObservableCollection<CCompany> ListCompany { get => _listCompany; set { if (value == _listCompany) return; _listCompany = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _listSortBy;
        public ObservableCollection<string> ListSortBy { get => _listSortBy; set { if (value == _listSortBy) return; _listSortBy = value; OnPropertyChanged(); } }

        /// <summary>
        /// Binding selected item combobox
        /// </summary>

        private string _selectedItemAuthor;
        public string SelectedItemAuthor { get => _selectedItemAuthor; set { if (value == _selectedItemAuthor) return; _selectedItemAuthor = value; OnPropertyChanged(); } }

        private CSubCategory _selectedItemSubCategory;
        public CSubCategory SelectedItemSubCategory { get => _selectedItemSubCategory; set { if (value == _selectedItemSubCategory) return; _selectedItemSubCategory = value; OnPropertyChanged(); } }

        private CCategory _selectedItemCategory;
        public CCategory SelectedItemCategory { get => _selectedItemCategory; set { if (value == _selectedItemCategory) return; _selectedItemCategory = value; OnPropertyChanged(); } }

        private string _filterString;
        public string FilterString { get => _filterString; set { if (value == _filterString) return; _filterString = value; OnPropertyChanged(); } }

        private CCompany _selectedItemCompany;
        public CCompany SelectedItemCompany { get => _selectedItemCompany; set { if (value == _selectedItemCompany) return; _selectedItemCompany = value; OnPropertyChanged(); } }

        private string _selectedItemSortBy;
        public string SelectedItemSortBy { get => _selectedItemSortBy; set { if (value == _selectedItemSortBy) return; _selectedItemSortBy = value; OnPropertyChanged(); } }


        #endregion

        #region properties binding

        #endregion

        #region command binding

        public ICommand addNewBookCommand { get; set; }

        public ICommand LoadCommand { get; set; }

        public ICommand ListSelectionChanged { get; set; }

        public ICommand deleteBookCommand { get; set; }

        public ICommand editBookCommand { get; set; }

        public ICommand increaseBookCommand { get; set; }

        public ICommand PreviousPageCommand { get; set; }
        public ICommand NextPageCommand { get; set; }

        public ICommand CategorySelectionChanged { get; set; }
        public ICommand SubCategorySelectionChanged { get; set; }
        public ICommand AuthorSelectionChanged { get; set; }
        public ICommand CompanySelectionChanged { get; set; }
        public ICommand SortBySelectionChanged { get; set; }

        public ICommand searchCommand { get; set; }

        public ICommand checkedBook { get; set; }
        public ICommand uncheckedBook { get; set; }

        #endregion

        private bool _isIndeterminate;

        public bool IsIndeterminate
        {
            get { return _isIndeterminate; }
            set { _isIndeterminate = value; OnPropertyChanged(); }
        }

        public BookInfoPageVM()
        {
            checkedBook = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                addBookToTransaction();
            }
               );

            uncheckedBook = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                removeBookFromTransaction();
            }
               );

            searchCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadBook();
            }
               );

            PreviousPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (CurrentPage > 1)
                {
                    CurrentPage = CurrentPage - 1;
                    LoadBook();
                }
            }
              );

            NextPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CurrentPage = CurrentPage + 1;
                LoadBook();
            }
              );

            CategorySelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //Đổ lại subcategory
                loadSubCategory();
            }
               );

            SubCategorySelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadBook();
            }
               );

            AuthorSelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadBook();
            }
               );

            CompanySelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadBook();
            }
               );

            addNewBookCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //Khởi tạo
                AddNewBookWindow wd = new AddNewBookWindow();
                wd.ShowDialog();
                //Load lại List
                LoadBook();

            }
               );

            increaseBookCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (CWareHouseCart.Instance.NumberBook() > 0)
                {
                    ////Khởi tạo
                    IncreaseBookWindow wd = new IncreaseBookWindow();
                    wd.ShowDialog();
                    //Load lại List
                    LoadBook();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sách cần thêm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
               );

            deleteBookCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (ListSelectedItem != null)
                {
                    
                }
            }
               );

            editBookCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (ListSelectedItem != null)
                {
                    DetailBookWindow wd = new DetailBookWindow(ListSelectedItem);
                    wd.ShowDialog();
                    LoadBook();
                }
            }
               );

            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                firtLoad();
                LoadBook();
            }
               );

            ListSelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (ListSelectedItem != null)
                {
                    CoverImage = ListSelectedItem.Image;
                }
            }
               );

            SortBySelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadBook();
            }
               );
        }

        private void updateCheckedBook()
        {
            if (ListBook.Count > 0)
            {
                foreach(var item in ListBook)
                {
                    item.IsChecked = CWareHouseCart.Instance.isChoosed(item.ID);
                }
            }
        }

        /// <summary>
        /// Thêm sách vào để thêm vào đợt nhập kho mới
        /// </summary>
        private void addBookToTransaction()
        {
            if (ListSelectedItem != null)
            {
                //Tạo mới một book
                CBookTransaction book = new CBookTransaction
                {
                    ID = ListSelectedItem.ID,
                    Name = ListSelectedItem.Name,
                    Inventory = ListSelectedItem.Inventory,
                    Count = 1,
                    TotalMoney = 20000,
                    Price = 20000,
                    Image = ListSelectedItem.Image,
                    IsTrueValue = true
                };

                CWareHouseCart.Instance.Add(book);
            }
        }

        /// <summary>
        /// Xóa sách khỏi đợt nhập kho
        /// </summary>
        private void removeBookFromTransaction()
        {
            if (ListSelectedItem != null)
            {
                //Tạo mới một book
                CBookTransaction book = new CBookTransaction
                {
                    ID = ListSelectedItem.ID,
                    Name = ListSelectedItem.Name,
                    Inventory = ListSelectedItem.Inventory,
                    Count = 1,
                    TotalMoney = 20000,
                    Price = 20000,
                    Image = ListSelectedItem.Image,
                    IsTrueValue = true
                };
                CWareHouseCart.Instance.Remove(book);
            }
        }

        /// <summary>
        /// Load danh sách sách theo tiêu chí
        /// </summary>
        private void LoadBook()
        {
            if (isAllSelected())
            {
                ListBook = new ObservableCollection<CBook>(bookBUS.ListBook(FilterString, SelectedItemAuthor, SelectedItemCategory.ID,
                   SelectedItemSubCategory.ID, SelectedItemCompany.ID, SelectedItemSortBy, CurrentPage, NumberPage));

                updateCheckedBook();

            }   
        }

        /// <summary>
        /// Đổ lại dữ liệu ở cột subcategory khi thay đổi ở cột category
        /// </summary>
        private void loadSubCategory()
        {
            if (SelectedItemCategory != null)
            {
                ListSubCategory = new ObservableCollection<CSubCategory>(subcategoryBUS.ListSubCategory(SelectedItemCategory.ID));
                CSubCategory allSubCategory = new CSubCategory { ID = 0, Name = "Tất cả" };
                ListSubCategory.Add(allSubCategory);
                SelectedItemSubCategory = allSubCategory;
            }
        }

        /// <summary>
        /// Khởi tạo màn hình trong lần đầu tiên chạy
        /// </summary>
        private async void firtLoad()
        {
            RoleID = employeeBUS.RoleIdOfEmployee(DataTransfer.EmployeeID);

            CurrentPage = 1;
            FilterString = "";

            IsIndeterminate = true;
            await Task.Run(() =>
            {
                ListCategory = new ObservableCollection<CCategory>(categoryBUS.ListCategory());
                ListSubCategory = new ObservableCollection<CSubCategory>();
                ListCompany = new ObservableCollection<CCompany>(companyBUS.ListCompany());
                ListAuthor = new ObservableCollection<string>(bookBUS.ListAuthor());
            });
            IsIndeterminate = false;

            ListSortBy = new ObservableCollection<string>();

            ListSortBy.Add("Tên");
            ListSortBy.Add("Mã");
            ListSortBy.Add("Tồn kho giảm dần");
            ListSortBy.Add("Tồn kho tăng dần");
            ListSortBy.Add("Lượt mua giảm dần");
            ListSortBy.Add("Lượt mua tăng dần");

            CCategory allCategory = new CCategory { ID = 0, Name = "Tất cả" };
            ListCategory.Add(allCategory);
            CSubCategory allSubCategory = new CSubCategory { ID = 0, Name = "Tất cả" };
            ListSubCategory.Add(allSubCategory);
            CCompany allCompany = new CCompany { ID = 0, Name = "Tất cả" };
            ListCompany.Add(allCompany);
            ListAuthor.Add("Tất cả");

            SelectedItemAuthor = "Tất cả";
            SelectedItemCompany = allCompany;
            SelectedItemCategory = allCategory;
            SelectedItemSubCategory = allSubCategory;
            SelectedItemSortBy = "Tên";

            SumNumber = bookBUS.InventoryBook();

            loadLastWareHouse();
        }

        /// <summary>
        /// Kiểm tra tất cả đã được chọn
        /// </summary>
        /// <returns></returns>
        private bool isAllSelected()
        {
            if (SelectedItemAuthor != null && SelectedItemCategory != null && SelectedItemSubCategory != null
                && SelectedItemSortBy != null && SelectedItemCompany != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Hiển thị thông tin chi tiết lần nhập cuối
        /// </summary>
        private void loadLastWareHouse()
        {
            CBaseReceipt cBookReipt = wareHouseBUS.LastWarehouse();

            LastDate = cBookReipt.Date;
            LastNumberBook = cBookReipt.TotalCount;
            LastTotalMoney = cBookReipt.TotalMoney;
        }

    }
}
