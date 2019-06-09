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
    public class DetailsBookWindowVM : BaseViewModel
    {
        #region 
        BookBUS bookBUS = new BookBUS();
        CategoryBUS categoryBUS = new CategoryBUS();
        SubCategoryBUS subcategoryBUS = new SubCategoryBUS();
        CompanyBUS companyBUS = new CompanyBUS();
        WareHouseBUS wareHouseBUS = new WareHouseBUS();

        string FileName;
        CBook BookInfo;

        #endregion

        #region data binding

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

        private int _iD;
        public int ID { get => _iD; set { if (value == _iD) return; _iD = value; OnPropertyChanged(); } }

        private int _inventory;
        public int Inventory { get => _inventory; set { if (value == _inventory) return; _inventory = value; OnPropertyChanged(); } }

        private int _sold;
        public int Sold { get => _sold; set { if (value == _sold) return; _sold = value; OnPropertyChanged(); } }

        private string _outPrice;
        public string OutPrice { get => _outPrice; set { if (value == _outPrice) return; _outPrice = value; OnPropertyChanged(); } }

        private string _promotion;
        public string Promotion { get => _promotion; set { if (value == _promotion) return; _promotion = value; OnPropertyChanged(); } }

        private float _outPricePromotion;
        public float OutPricePromotion { get => _outPricePromotion; set { if (value == _outPricePromotion) return; _outPricePromotion = value; OnPropertyChanged(); } }

        private BitmapImage _coverImage;
        public BitmapImage CoverImage { get => _coverImage; set { if (value == _coverImage) return; _coverImage = value; OnPropertyChanged(); } }

        private ObservableCollection<CBookTransaction> _listWarehouse;
        public ObservableCollection<CBookTransaction> ListWarehouse { get => _listWarehouse; set { if (value == _listWarehouse) return; _listWarehouse = value; OnPropertyChanged(); } }

        #endregion

        #region properties binding

        private bool _isChecked;
        public bool IsChecked { get => _isChecked; set { if (value == _isChecked) return; _isChecked = value; OnPropertyChanged(); } }

        #endregion

        #region command binding

        public ICommand LoadCommand { get; set; }
        public ICommand CategorySelectionChanged { get; set; }
        public ICommand imageCommand { get; set; }
        public ICommand updateCommand { get; set; }

        public ICommand OutPriceTextChanged { get; set; }
        public ICommand PromotionTextChanged { get; set; }

        public ICommand CheckedCommand { get; set; }

        #endregion

        public DetailsBookWindowVM(CBook BookDetails)
        {
            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                BookInfo = BookDetails;
                //Cập nhật lại thông tin lên giao diện
                loadInfo();
            }
               );

            CheckedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ListWarehouse = new ObservableCollection<CBookTransaction>(wareHouseBUS.DetailsInventoryOfBook(BookInfo.ID, IsChecked));
            }
               );

            CategorySelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadSubCategory();
            }
               );

            OutPriceTextChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (Help.isFloat(OutPrice) == true && Help.isFloat(Promotion) == true)
                {
                    OutPricePromotion = float.Parse(OutPrice) - float.Parse(OutPrice) * float.Parse(Promotion);
                }
            }
               );

            PromotionTextChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (Help.isFloat(OutPrice) == true && Help.isFloat(Promotion) == true)
                {
                    OutPricePromotion = float.Parse(OutPrice) - float.Parse(OutPrice) * float.Parse(Promotion);
                }
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

            updateCommand = new RelayCommand<object>((p) => {
                if (CheckTrue() == false)
                    return false;
                return true;
            }, (p) =>
            {
                updateBook();
            }
               );
        }

        public bool CheckTrue()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Author) || SelectedItemCategory == null || SelectedItemSubCategory == null ||
                SelectedItemCompany == null || CoverImage == null || string.IsNullOrEmpty(Promotion) || string.IsNullOrEmpty(OutPrice))
            {
                return false;
            }

            float FOutPrice;
            float FPromotion;

            if (float.TryParse(Promotion, out FPromotion) == false || float.TryParse(OutPrice, out FOutPrice) == false)
            {
                return false;
            }
            if (FOutPrice <= 0)
            {
                return false;
            }
            if (FPromotion < 0 || FPromotion > 1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cập nhật thông tin cho giao diện
        /// </summary>
        private void loadInfo()
        {
            IsChecked = false;
            ID = BookInfo.ID;
            Name = BookInfo.Name;
            Author = BookInfo.Author;       
            Inventory = BookInfo.Inventory;
            OutPrice = BookInfo.Price.ToString();
            Promotion = BookInfo.Promotion.ToString();
            OutPricePromotion = BookInfo.PricePromotion;            
            Sold = BookInfo.Sole;
            CoverImage = BookInfo.Image;

            ListCategory = new ObservableCollection<CCategory>(categoryBUS.ListCategory());
            ListSubCategory = new ObservableCollection<CSubCategory>(subcategoryBUS.ListSubCategory(BookInfo.Category.ID));
            ListCompany = new ObservableCollection<CCompany>(companyBUS.ListCompany());

            SelectedItemCategory = ListCategory.Where(x => x.ID == BookInfo.Category.ID).FirstOrDefault();
            SelectedItemSubCategory = ListSubCategory.Where(x => x.ID == BookInfo.SubCategory.ID).FirstOrDefault();
            SelectedItemCompany = ListCompany.Where(x => x.ID == BookInfo.Company.ID).FirstOrDefault();

            ListWarehouse = new ObservableCollection<CBookTransaction>(wareHouseBUS.DetailsInventoryOfBook(BookInfo.ID, false));
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
        /// Cập nhật thông tin sách
        /// </summary>
        private void updateBook()
        {
            //Tạo mới thông tin của sách cần update
            CBook Book = new CBook
            {
                ID = ID,
                Name = Name,
                Author = Author,
                Category = new CCategory {
                    ID = SelectedItemCategory.ID
                },
                SubCategory = new CSubCategory {
                    ID = SelectedItemSubCategory.ID
                },
                Company = new CCompany
                {
                    ID=SelectedItemCompany.ID
                },
                Image = CoverImage,
                Price = float.Parse(OutPrice),
                Promotion = float.Parse(Promotion)
            };
            //Gọi hàm update
            int isSucces = bookBUS.updateBookInfo(Book);

            if (isSucces == 1)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else if(isSucces == 0)
            {
                MessageBox.Show("Sách này đã tồn tại trong kho", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
