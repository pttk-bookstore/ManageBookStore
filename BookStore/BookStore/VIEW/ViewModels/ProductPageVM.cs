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
    public class ProductPageVM : BaseViewModel
    {
        #region Global

        BookBUS bookBUS = new BookBUS();
        CategoryBUS categoryBUS = new CategoryBUS();
        SubCategoryBUS subcategoryBUS = new SubCategoryBUS();
        CompanyBUS companyBUS = new CompanyBUS();

        private int _currentPage;
        public int CurrentPage { get => _currentPage; set { if (value == _currentPage) return; _currentPage = value; OnPropertyChanged(); } }

        int NumberPage = 8;
        public bool isSale = false;

        private int _numberProduct;
        public int NumberProduct { get => _numberProduct; set { if (value == _numberProduct) return; _numberProduct = value; OnPropertyChanged(); } }

        #endregion

        #region data binding

        private ObservableCollection<CBook> _listBook;
        public ObservableCollection<CBook> ListBook { get => _listBook; set { if (value == _listBook) return; _listBook = value; OnPropertyChanged(); } }

        private CBook _listSelectedItem;
        public CBook ListSelectedItem { get => _listSelectedItem; set { if (value == _listSelectedItem) return; _listSelectedItem = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _listAuthor;
        public ObservableCollection<string> ListAuthor { get => _listAuthor; set { if (value == _listAuthor) return; _listAuthor = value; OnPropertyChanged(); } }

        private ObservableCollection<CCategory> _listCategory;
        public ObservableCollection<CCategory> ListCategory { get => _listCategory; set { if (value == _listCategory) return; _listCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<CSubCategory> _listSubCategory;
        public ObservableCollection<CSubCategory> ListSubCategory { get => _listSubCategory; set { if (value == _listSubCategory) return; _listSubCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<CCompany> _listCompany;
        public ObservableCollection<CCompany> ListCompany { get => _listCompany; set { if (value == _listCompany) return; _listCompany = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _listPrice;
        public ObservableCollection<string> ListPrice { get => _listPrice; set { if (value == _listPrice) return; _listPrice = value; OnPropertyChanged(); } }

        /// <summary>
        /// Binding selected item combobox
        /// </summary>

        private string _selectedItemAuthor;
        public string SelectedItemAuthor { get => _selectedItemAuthor; set { if (value == _selectedItemAuthor) return; _selectedItemAuthor = value; OnPropertyChanged(); } }

        private string _selectedItemPrice;
        public string SelectedItemPrice { get => _selectedItemPrice; set { if (value == _selectedItemPrice) return; _selectedItemPrice = value; OnPropertyChanged(); } }

        private CSubCategory _selectedItemSubCategory;
        public CSubCategory SelectedItemSubCategory { get => _selectedItemSubCategory; set { if (value == _selectedItemSubCategory) return; _selectedItemSubCategory = value; OnPropertyChanged(); } }

        private CCategory _selectedItemCategory;
        public CCategory SelectedItemCategory { get => _selectedItemCategory; set { if (value == _selectedItemCategory) return; _selectedItemCategory = value; OnPropertyChanged(); } }

        private string _filterString;
        public string FilterString { get => _filterString; set { if (value == _filterString) return; _filterString = value; OnPropertyChanged(); } }

        private CCompany _selectedItemCompany;
        public CCompany SelectedItemCompany { get => _selectedItemCompany; set { if (value == _selectedItemCompany) return; _selectedItemCompany = value; OnPropertyChanged(); } }

        #endregion

        #region properties binding

        private Visibility _messTextVisibility;
        public Visibility MessTextVisibility { get => _messTextVisibility; set { if (value == _messTextVisibility) return; _messTextVisibility = value; OnPropertyChanged(); } }

        private bool _isIndeterminate;

        public bool IsIndeterminate
        {
            get { return _isIndeterminate; }
            set { _isIndeterminate = value; OnPropertyChanged(); }
        }

        #endregion

        #region command binding

        public ICommand LoadCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ICommand CategorySelectionChanged { get; set; }
        public ICommand SubCategorySelectionChanged { get; set; }
        public ICommand AuthorSelectionChanged { get; set; }
        public ICommand CompanySelectionChanged { get; set; }
        public ICommand PriceSelectionChanged { get; set; }
        public ICommand searchCommand { get; set; }
        public ICommand addProductCommand { get; set; }
        public ICommand makeBillCommand { get; set; }

        #endregion

        public ProductPageVM()
        {
            searchCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadBook();
            }
               );

            makeBillCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (CCart.Instance.NumberBook() == 0)
                {
                    MessageBox.Show("Vui lòng chọn sách để thanh toán","Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MakeBillWindow wd = new MakeBillWindow();
                    wd.ShowDialog();
                    updateNumberBook();
                }            
            }
               );

            addProductCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                addBookToCart();
            }
               );

            CategorySelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //Đổ lại dữ liệu của subcategory
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

            PriceSelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
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

            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                firtLoad();
                LoadBook();
                updateNumberBook();
            }
               );
        }

        /// <summary>
        /// Thêm sách vào giỏ hàng
        /// </summary>
        private void addBookToCart()
        {
            if (ListSelectedItem != null)
            {
                CBookTransaction Book = new CBookTransaction
                {
                    ID = ListSelectedItem.ID,
                    Name = ListSelectedItem.Name,
                    Author = ListSelectedItem.Author,
                    Category = ListSelectedItem.Category,
                    SubCategory = ListSelectedItem.SubCategory,                    
                    Inventory = ListSelectedItem.Inventory - 1,
                    Image = ListSelectedItem.Image,
                    Price = ListSelectedItem.Price,
                    Promotion = ListSelectedItem.Promotion,
                    PricePromotion = ListSelectedItem.PricePromotion,
                    Count = 1,
                    TotalMoney = ListSelectedItem.PricePromotion,
                    IsTrueValue = true
                };
               
                if (CCart.Instance.Add(Book))
                {
                    updateNumberBook();
                }
                else
                {
                    MessageBox.Show("Sách này đã có trong giỏ hàng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }           
        }

        /// <summary>
        /// Cập nhật lại số lượng sách trong giỏ hàng
        /// </summary>
        public void updateNumberBook()
        {
            NumberProduct = CCart.Instance.NumberBook();
            //NumberProduct = 1;
        }

        /// <summary>
        /// Khởi tạo màn hình trong lần đầu tiên chạy
        /// </summary>
        private void firtLoad()
        {
            isSale = false;
            NumberProduct = 0;

            CurrentPage = 1;
            FilterString = "";
            MessTextVisibility = Visibility.Hidden;

            ListCategory = new ObservableCollection<CCategory>(categoryBUS.ListCategory());
            ListSubCategory = new ObservableCollection<CSubCategory>();
            ListCompany = new ObservableCollection<CCompany>(companyBUS.ListCompany());
            ListAuthor = new ObservableCollection<string>(bookBUS.ListAuthor());
            ListPrice = new ObservableCollection<string> { "Tất cả", "Giảm giá" };

            CCategory allCategory = new CCategory { ID = 0, Name = "Tất cả" };
            ListCategory.Add(allCategory);
            CSubCategory allSubCategory = new CSubCategory { ID = 0, Name = "Tất cả" };
            ListSubCategory.Add(allSubCategory);
            CCompany allCompany = new CCompany { ID = 0, Name = "Tất cả" };
            ListCompany.Add(allCompany);
            ListAuthor.Add("Tất cả");

            SelectedItemAuthor = "Tất cả";
            SelectedItemPrice = "Tất cả";
            SelectedItemCompany = allCompany;
            SelectedItemCategory = allCategory;
            SelectedItemSubCategory = allSubCategory;
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
        /// Hàm load sách theo trang
        /// </summary>
        private void LoadBook()
        {
            if (isAllSelected())
            {
                if (SelectedItemPrice == "Tất cả")
                {
                    isSale = false;
                }
                else
                {
                    isSale = true;
                }
                
                ListBook = new ObservableCollection<CBook>(bookBUS.ListBook(FilterString, SelectedItemAuthor, _selectedItemCategory.ID,
                    SelectedItemSubCategory.ID, SelectedItemCompany.ID, isSale, CurrentPage, NumberPage));

                

                if (ListBook.Count() == 0)
                {
                    MessTextVisibility = Visibility.Visible;
                }
                else
                {
                    MessTextVisibility = Visibility.Hidden;
                }
            }
        }

        /// <summary>
        /// Kiểm tra tất cả đã được chọn
        /// </summary>
        /// <returns></returns>
        private bool isAllSelected()
        {
            if (SelectedItemAuthor != null && SelectedItemCategory != null&&SelectedItemSubCategory!=null
                && SelectedItemPrice != null && SelectedItemCompany != null)
            {
                return true;
            }
            return false;
        }
    }
}
