using BookStore.BUS;
using BookStore.DTO;
using Microsoft.Win32;
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
    public class AddNewBookWindowVM : BaseViewModel
    {

        #region global

        BookBUS bookBUS = new BookBUS();
        CategoryBUS categoryBUS = new CategoryBUS();
        SubCategoryBUS subcategoryBUS = new SubCategoryBUS();
        CompanyBUS companyBUS = new CompanyBUS();
        EmployeeBUS employeeBUS = new EmployeeBUS();
        WareHouseBUS wareHouseBUS = new WareHouseBUS();

        public string FileName;

        #endregion

        #region data binding

        private string _employeeName;
        public string EmployeeName { get => _employeeName; set { if (value == _employeeName) return; _employeeName = value; OnPropertyChanged(); } }

        private string _dateNow;
        public string DateNow { get => _dateNow; set { if (value == _dateNow) return; _dateNow = value; OnPropertyChanged(); } }

        private ObservableCollection<CBookTransaction> _listBook;
        /// <summary>
        /// Danh sách sách hiển thị trên màn hình
        /// </summary>
        public ObservableCollection<CBookTransaction> ListBook { get => _listBook; set { if (value == _listBook) return; _listBook = value; OnPropertyChanged(); } }

        private int _listSelectedIndex;
        public int ListSelectedIndex { get => _listSelectedIndex; set { if (value == _listSelectedIndex) return; _listSelectedIndex = value; OnPropertyChanged(); } }

        private CBookTransaction _listSelectedItem;
        public CBookTransaction ListSelectedItem { get => _listSelectedItem; set { if (value == _listSelectedItem) return; _listSelectedItem = value; OnPropertyChanged(); } }

        private ObservableCollection<CCategory> _listCategory;
        public ObservableCollection<CCategory> ListCategory { get => _listCategory; set { if (value == _listCategory) return; _listCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<CSubCategory> _listSubCategory;
        public ObservableCollection<CSubCategory> ListSubCategory { get => _listSubCategory; set { if (value == _listSubCategory) return; _listSubCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<CCompany> _listCompany;
        public ObservableCollection<CCompany> ListCompany { get => _listCompany; set { if (value == _listCompany) return; _listCompany = value; OnPropertyChanged(); } }

        private CSubCategory _selectedItemSubCategory;
        public CSubCategory SelectedItemSubCategory { get => _selectedItemSubCategory; set { if (value == _selectedItemSubCategory) return; _selectedItemSubCategory = value; OnPropertyChanged(); } }

        private CCategory _selectedItemCategory;
        public CCategory SelectedItemCategory { get => _selectedItemCategory; set { if (value == _selectedItemCategory) return; _selectedItemCategory = value; OnPropertyChanged(); } }

        private CCompany _selectedItemCompany;
        public CCompany SelectedItemCompany { get => _selectedItemCompany; set { if (value == _selectedItemCompany) return; _selectedItemCompany = value; OnPropertyChanged(); } }

        private string _name;
        public string Name { get => _name; set { if (value == _name) return; _name = value; OnPropertyChanged(); } }

        private string _author;
        public string Author { get => _author; set { if (value == _author) return; _author = value; OnPropertyChanged(); } }

        

        private string _warehouseInventory;
        public string WarehouseInventory { get => _warehouseInventory; set { if (value == _warehouseInventory) return; _warehouseInventory = value; OnPropertyChanged(); } }

        private string _inPrice;
        public string InPrice { get => _inPrice; set { if (value == _inPrice) return; _inPrice = value; OnPropertyChanged(); } }

        private float _totalPrice;
        public float TotalPrice { get => _totalPrice; set { if (value == _totalPrice) return; _totalPrice = value; OnPropertyChanged(); } }

        private BitmapImage _coverImage;
        public BitmapImage CoverImage { get => _coverImage; set { if (value == _coverImage) return; _coverImage = value; OnPropertyChanged(); } }



        #endregion

        #region properties binding


        #endregion


        #region command binding
        public ICommand LoadCommand { get; set; }

        public ICommand addToListCommand { get; set; }
        public ICommand editListCommand { get; set; }
        public ICommand deleteListCommand { get; set; }

        public ICommand addCommand { get; set; }
        public ICommand imageCommand { get; set; }

        public ICommand CategorySelectionChanged { get; set; }

        public ICommand ListSelectionChanged { get; set; }

        public ICommand CountTextChange { get; set; }
        public ICommand InPriceTextChange { get; set; }


        #endregion

        public AddNewBookWindowVM()
        {
            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {              
                firtLoad();
            }
               );

            CountTextChange = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (Help.isInt(WarehouseInventory) == true && Help.isFloat(InPrice) == true)
                {
                    TotalPrice = int.Parse(WarehouseInventory) * float.Parse(InPrice);
                }
            }
               );

            InPriceTextChange = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (Help.isInt(WarehouseInventory) == true && Help.isFloat(InPrice) == true)
                {
                    TotalPrice = int.Parse(WarehouseInventory) * float.Parse(InPrice);
                }
            }
               );

            CategorySelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadSubCategory();
            }
               );

            deleteListCommand = new RelayCommand<object>((p) => {
                return checkDelete();
            }, (p) =>
            {
                removeBookAtIndex();
            }
               );

            editListCommand = new RelayCommand<object>((p) => {
                return checkDelete();
            }, (p) =>
            {
                updateBookInList();
            }
               );

            addCommand = new RelayCommand<object>((p) => {
                if (ListBook.Count() == 0)
                    return false;

                return true;
            }, (p) =>
            {
                addTransaction();
            }
               );

            ListSelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                changeBookInfo();
            }
               );

            imageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg|PNG|*.png", ValidateNames = true, Multiselect = false };

                var dialogOk = ofd.ShowDialog();
                if (dialogOk == true)
                {
                    FileName = ofd.FileName;
                    CoverImage = new BitmapImage(new Uri(FileName));
                }
            }
               );

            addToListCommand = new RelayCommand<object>((p) =>
            {
                if (CheckTrue() == false)
                    return false;
                return true;
            }
            , (p) =>
            {
                addBookToList();
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
                TypeID = 0
            };

            int BookCount = wareHouseBUS.addTransactionListNewBook(bookReipt);

            if(BookCount == ListBook.Count)
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
        }

        /// <summary>
        /// Khởi tạo các giá trị của màn hình trong lần đầu tiên chạy
        /// </summary>
        private void firtLoad()
        {
            EmployeeName = employeeBUS.EmployeeName(DataTransfer.EmployeeID);
            DateNow = DateTime.Now.ToShortDateString();

            ListBook = new ObservableCollection<CBookTransaction>();

            ListCategory = new ObservableCollection<CCategory>(categoryBUS.ListCategory());
            ListSubCategory = new ObservableCollection<CSubCategory>(subcategoryBUS.ListSubCategory(ListCategory[0].ID));
            ListCompany = new ObservableCollection<CCompany>(companyBUS.ListCompany());

            SelectedItemCategory = ListCategory[0];
            SelectedItemCompany = ListCompany[0];
            SelectedItemSubCategory = ListSubCategory[0];
        }

        /// <summary>
        /// Thay đổi thông tin sách khi chọn vào các item trên list
        /// </summary>
        private void changeBookInfo()
        {
            if (ListSelectedItem != null)
            {
                ////Đưa lại dữ liệu lên trên
                Name = ListSelectedItem.Name;
                Author = ListSelectedItem.Author;
                InPrice = ListSelectedItem.Price.ToString();
                WarehouseInventory = ListSelectedItem.Count.ToString();
                TotalPrice = ListSelectedItem.TotalMoney;
                CoverImage = ListSelectedItem.Image;
                SelectedItemCompany = ListSelectedItem.Company;
                SelectedItemCategory = ListSelectedItem.Category;

                ListSubCategory = new ObservableCollection<CSubCategory>(subcategoryBUS.ListSubCategory(ListSelectedItem.Category.ID));
                SelectedItemSubCategory = ListSubCategory.Where(x => x.ID == ListSelectedItem.SubCategory.ID).FirstOrDefault();
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
            }
        }
 
        /// <summary>
        /// Thêm sách mới vào list
        /// </summary>
        private void addBookToList()
        {
            //Tạo mới một sách
            CBookTransaction Book = new CBookTransaction
            {
                Name = Name,
                Author = Author,
                Category = SelectedItemCategory,
                SubCategory = SelectedItemSubCategory,
                Company = SelectedItemCompany,
                Image = CoverImage,
                Price = float.Parse(InPrice),
                Count = int.Parse(WarehouseInventory),
                TotalMoney = float.Parse(InPrice) * int.Parse(WarehouseInventory)
            };

            CBook BookInfo = new CBook
            {
                Name = Name,
                Author = Author,
                Category = SelectedItemCategory,
                SubCategory = SelectedItemSubCategory,
                Company = SelectedItemCompany,
            };

            if (isExistInDB(BookInfo))
            {
                MessageBox.Show("Sách đã có Kho", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (isExistInList(Book))
                {
                    MessageBox.Show("Sách đã có trong List", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    ListBook.Add(Book);
                }
            }              
        }

        /// <summary>
        /// Kiểm tra điều kiện xóa sách khỏi list
        /// </summary>
        /// <returns></returns>
        private bool checkDelete()
        {
            if (ListBook.Count() == 0)
                return false;
            if (ListSelectedItem == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cập nhật thông tin sách trong list
        /// </summary>
        private void updateBookInList()
        {
            if (ListSelectedItem != null)
            {
                //Cập nhật theo index
                //Tạo mới một sách
                CBookTransaction Book = new CBookTransaction
                {
                    Name = Name,
                    Author = Author,
                    Category = SelectedItemCategory,
                    SubCategory = SelectedItemSubCategory,
                    Company = SelectedItemCompany,
                    Image = CoverImage,
                    Price = float.Parse(InPrice),
                    Count = int.Parse(WarehouseInventory),
                    TotalMoney = float.Parse(InPrice) * int.Parse(WarehouseInventory)
                };

                ListBook[ListSelectedIndex] = Book;
            }
        }

        /// <summary>
        /// Xóa sách tại vị trí được chọn
        /// </summary>
        private void removeBookAtIndex()
        {
            if (ListSelectedItem != null)
            {
                ListBook.RemoveAt(ListSelectedIndex);
            }
        }

        /// <summary>
        /// Kiểm tra thông tin nhập vào là đầy đủ và hợp lệ
        /// </summary>
        /// <returns></returns>
        private bool CheckTrue()
        {
            //Kiểm tra nhập đầy đủ thông tin
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Author) || SelectedItemCategory==null || SelectedItemSubCategory==null ||
                SelectedItemCompany==null || CoverImage == null || string.IsNullOrEmpty(WarehouseInventory) || string.IsNullOrEmpty(InPrice))
            {
                return false;
            }
            //Kiểm tra thông tin nhập vào là hợp lệ
            float FInPrice;
            int IWarehouseInventory;

            if (int.TryParse(WarehouseInventory, out IWarehouseInventory) == false || float.TryParse(InPrice, out FInPrice) == false)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra sách đã tồn tại trong danh sách bên dưới hay chưa
        /// </summary>
        /// <param name="Book"></param>
        /// <returns></returns>
        private bool isExistInList(CBookTransaction Book)
        {
            if (ListBook.Count() > 0)
            {
                if (ListBook.Where(x => x.Name.ToLower() == Book.Name.ToLower() && x.Author.ToLower() == Book.Author.ToLower() &&
             x.SubCategory.ID == Book.SubCategory.ID && Book.Category.ID == x.Category.ID && x.Company.ID == Book.Company.ID).Count() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra sách đã tồn tại trong DB
        /// </summary>
        private bool isExistInDB(CBook Book)
        {
            int checkDB = bookBUS.IdOfBookInfo(Book);
            if (checkDB != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
