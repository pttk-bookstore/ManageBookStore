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
    public class MakeBillWindowVM : BaseViewModel
    {
        #region global

        BookBUS bookBUS = new BookBUS();
        BillBUS billBUS = new BillBUS();
        DiscountCodeBUS discountCodeBUS = new DiscountCodeBUS();
        CustomerBUS customerBUS = new CustomerBUS();
        EmployeeBUS employeeBUS = new EmployeeBUS();

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

        private ObservableCollection<CBillType> _listTypePayment;
        public ObservableCollection<CBillType> ListTypePayment { get => _listTypePayment; set { if (value == _listTypePayment) return; _listTypePayment = value; OnPropertyChanged(); } }

        private CBillType _listTypePaymentSelectedItem;
        public CBillType ListTypePaymentSelectedItem { get => _listTypePaymentSelectedItem; set { if (value == _listTypePaymentSelectedItem) return; _listTypePaymentSelectedItem = value; OnPropertyChanged(); } }

        private float _totalPrice;
        public float TotalPrice { get => _totalPrice; set { if (value == _totalPrice) return; _totalPrice = value; OnPropertyChanged(); } }

        private string _code;
        public string Code { get => _code; set { if (value == _code) return; _code = value; OnPropertyChanged(); } }

        private float _promotion;
        public float Promotion { get => _promotion; set { if (value == _promotion) return; _promotion = value; OnPropertyChanged(); } }

        private string _errorMess;
        public string ErrorMess { get => _errorMess; set { if (value == _errorMess) return; _errorMess = value; OnPropertyChanged(); } }

        private float lastTotalPrice;
        public float LastTotalPrice { get => lastTotalPrice; set { if (value == lastTotalPrice) return; lastTotalPrice = value; OnPropertyChanged(); } }

        private string _customerMoney;
        public string CustomerMoney { get => _customerMoney; set { if (value == _customerMoney) return; _customerMoney = value; OnPropertyChanged(); } }

        private float _excessCash;
        public float ExcessCash { get => _excessCash; set { if (value == _excessCash) return; _excessCash = value; OnPropertyChanged(); } }

        private bool _isCustomerChecked;
        public bool IsCustomerChecked { get => _isCustomerChecked; set { if (value == _isCustomerChecked) return; _isCustomerChecked = value; OnPropertyChanged(); } }

        /// <summary>
        /// Thông tin khách hàng
        /// </summary>

        private int _iD;
        public int ID { get => _iD; set { if (value == _iD) return; _iD = value; OnPropertyChanged(); } }

        private string _name;
        public string Name { get => _name; set { if (value == _name) return; _name = value; OnPropertyChanged(); } }

        private string _phone;
        public string Phone { get => _phone; set { if (value == _phone) return; _phone = value; OnPropertyChanged(); } }

        private string _email;
        public string Email { get => _email; set { if (value == _email) return; _email = value; OnPropertyChanged(); } }

        private string _address;
        public string Address { get => _address; set { if (value == _address) return; _address = value; OnPropertyChanged(); } }

        private ObservableCollection<CCustomer> _listCustomer;
        public ObservableCollection<CCustomer> ListCustomer { get => _listCustomer; set { if (value == _listCustomer) return; _listCustomer = value; OnPropertyChanged(); } }

        private CCustomer _listCustomerSelectedItem;
        public CCustomer ListCustomerSelectedItem { get => _listCustomerSelectedItem; set { if (value == _listCustomerSelectedItem) return; _listCustomerSelectedItem = value; OnPropertyChanged(); } }

        private string _filterString;
        public string FilterString { get => _filterString; set { if (value == _filterString) return; _filterString = value; OnPropertyChanged(); } }

        #endregion

        #region properties binding

        private Visibility _messVisibility;
        public Visibility MessVisibility { get => _messVisibility; set { if (value == _messVisibility) return; _messVisibility = value; OnPropertyChanged(); } }

        #endregion

        #region command binding

        public ICommand LoadCommand { get; set; }
        public ICommand ListBookSelectionChanged { get; set; }
        public ICommand deleteCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand CodeTextChangeCommand { get; set; }
        public ICommand CustomerTextChangeCommand { get; set; }

        public ICommand PayCommand { get; set; }
        public ICommand ListCustomerSelectionChanged { get; set; }
        public ICommand PhoneTextChange { get; set; }

        public ICommand searchCommand { get; set; }

        #endregion

        public MakeBillWindowVM()
        {
            PhoneTextChange = new RelayCommand<object>((p) => {
                return true;
            }, (p) =>
            {
                updateCustomerInfo();
            }
               );

            searchCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) =>
            {
                searchCustomer();
            }
              );

            ListCustomerSelectionChanged = new RelayCommand<object>((p) => {
                return true;
            }, (p) =>
            {
                if (ListCustomerSelectedItem != null)
                {
                    loadFullCustomerInfo(ListCustomerSelectedItem);      
                }
            }
               );

            PayCommand = new RelayCommand<object>((p) => {
                return checkTrueBill();
            }, (p) =>
            {
                createBill();
            }
               );

            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                firtLoad();
            }
               );

            CustomerTextChangeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                updateExcessCash();              
            }
               );

            CodeTextChangeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                updateMessDiscountCode();
                updateExcessCash();
            }
               );

            editCommand = new RelayCommand<object>((p) => {
                changeEnableButtonEdit();
                return true;
            }, (p) =>
            {
                updateBook();
                updateMessDiscountCode();
                updateExcessCash();
            }
               );

            deleteCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                removeBook();
                updateMessDiscountCode();
                updateExcessCash();
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
        /// Tìm kiếm khách hàng
        /// </summary>
        private void searchCustomer()
        {
            ListCustomer.Clear();
            if (Help.isInt(FilterString) == true)
            {
                ListCustomer = new ObservableCollection<CCustomer>(customerBUS.ListCustomerPhone(FilterString));
            }
            else
            {
                ListCustomer = new ObservableCollection<CCustomer>(customerBUS.ListCustomerName(FilterString));
            }
        }

        /// <summary>
        /// Tạo mới một hóa đơn
        /// </summary>
        private void createBill()
        {
            //Tạo mới một khách hàng
            CCustomer myCustomer = new CCustomer
            {
                Name = Name,
                Phone = Phone,
                Email = Email,
                Address = Address,
            };

            //1 thanh toán trức tiếp,2 chuyển khoảng,3 giao hàng
            int billTypeID = ListTypePaymentSelectedItem.ID;
            //status 1 đã thanh toán, 2 chưa thanh toán, 3 đang giao

            ////Tạo mới một Bill
            CBill Bill = new CBill
            {
                BSalesman = new CEmployee { ID = DataTransfer.EmployeeID },
                BCustomer = myCustomer,
                TypeBill = ListTypePaymentSelectedItem,
                BDiscountCode = new CDiscountCode
                {
                    Code = Code
                },
                SumMoney = TotalPrice,
                TotalMoney = LastTotalPrice,
                Cash = float.Parse(CustomerMoney),
                ExcessCash = ExcessCash,
                Promotion = Promotion / 100,
                Date = DateTime.Now,
                Status = billTypeID,
                ListBook = ListBook.ToList()
            };

            int result = billBUS.addTransactionNewBill(Bill);
            if(result == ListBook.Count)
            {
                MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                clearPage();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// xóa toàn bộ dữ liệu trên trang
        /// </summary>
        private void clearPage()
        {           
            //Xóa List hiện tại
            ListBook.Clear();
            //Xóa trong giỏ hàng
            CCart.Instance.RemoveAll();

            ID = 0;
            Name = "";
            Phone = "";
            Email = "";
            Address = "";
            Code = "";
            Promotion = 0;

            TotalPrice = 0;
            lastTotalPrice = 0;
            CustomerMoney = "";
            ExcessCash = 0;
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng tương ứng với số điện thoại
        /// </summary>
        private void updateCustomerInfo()
        {
            if (!string.IsNullOrEmpty(Phone))
            {
                int iDCusomter = customerBUS.IDofCustomerPhone(Phone);
                if (iDCusomter != -1)
                {
                    IsCustomerChecked = true;
                    CCustomer customer = customerBUS.InFoOfCustomer(iDCusomter);
                    loadFullCustomerInfo(customer);
                }
                else
                {
                    IsCustomerChecked = false;
                }
            }
            else
            {
                IsCustomerChecked = false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng trong ô nhập thông tin khách hàng
        /// </summary>
        /// <param name="customer"></param>
        private void loadFullCustomerInfo(CCustomer customer)
        {
            ID = customer.ID;
            Name = customer.Name;
            Phone = customer.Phone;
            Address = customer.Address;
            Email = customer.Email;
        }

        /// <summary>
        /// Cập nhật thông tin tiền thừa của khách
        /// </summary>
        private void updateExcessCash()
        {
            if (string.IsNullOrEmpty(CustomerMoney))
            {
                ExcessCash = 0;
            }
            else
            {
                if (Help.isFloat(CustomerMoney) == true)
                {
                    ExcessCash = float.Parse(CustomerMoney) - LastTotalPrice;
                }
            }
        }

        /// <summary>
        /// Cập nhật thông tin mã khuyến mãi khi thay đổi test
        /// </summary>
        private void updateMessDiscountCode()
        {
            int sumBook = ListBook.Sum(x => x.Count);

            if (Code == "")
            {
                MessVisibility = Visibility.Collapsed;
                Promotion = 0;
                updateSumMoney();
            }
            else
            {
                float codePromotion = discountCodeBUS.PromotionOfDiscountCode(Code, sumBook);
                if(codePromotion == -2)
                {
                    ErrorMess = "Mã code không hợp lệ";
                    MessVisibility = Visibility.Visible;
                    Promotion = 0;
                }
                else if (codePromotion == -1)
                {
                    ErrorMess = "Mã này đã hết hạn";
                    MessVisibility = Visibility.Visible;
                    Promotion = 0;
                }
                else if (codePromotion == -3)
                {
                    ErrorMess = "Không đủ số lượng sách";
                    MessVisibility = Visibility.Visible;
                    Promotion = 0;
                }
                else
                {
                    MessVisibility = Visibility.Collapsed;
                    Promotion = codePromotion * 100;
                }

                updateSumMoney();
            }
        }

        private void firtLoad()
        {
            ListCustomer = new ObservableCollection<CCustomer>();
            ListBook = new ObservableCollection<CBookTransaction>(CCart.Instance.ListBookTransaction());
            EmployeeName = employeeBUS.EmployeeName(DataTransfer.EmployeeID);
            DateNow = DateTime.Now.ToShortDateString();
            if (ListBook.Count == 1)
            {
                CoverImage = ListBook[0].Image;
            }

            ListTypePayment = new ObservableCollection<CBillType>(billBUS.ListBillType());
            ListTypePaymentSelectedItem = ListTypePayment.Where(x => x.ID == 1).FirstOrDefault();

            updateSumMoney();

            MessVisibility = Visibility.Collapsed;
            Code = "";
            ErrorMess = "Mã code không hợp lệ";
            Promotion = 0;
            ExcessCash = 0;        

            //ListCustomer = new ObservableCollection<CCustomer>(CCustomer.Ins.ListCustomerFilterPhone(""));
        }

        /// <summary>
        /// Xóa sách khỏi giỏ hàng
        /// </summary>
        private void removeBook()
        {
            if (ListBookSelectedItem != null)
            {
                //Xóa trong giỏ hàng
                CCart.Instance.Remove(ListBookSelectedItem);
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

                //Lấy ra tổng số sách có trong kho
                int inventoryBook = bookBUS.InventoryOfBook(ListBookSelectedItem.ID);
                //Cập nhật lại số lượng sách tồn trong kho trên list
                ListBookSelectedItem.Inventory = inventoryBook - ListBookSelectedItem.Count;
                //Cập nhật lại tổng tiền trên list
                ListBookSelectedItem.TotalMoney = ListBookSelectedItem.PricePromotion * ListBookSelectedItem.Count;

                //Cập nhật lại thông tin trên giỏ hàng
                CCart.Instance.Upadte(ListBookSelectedItem);

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
                    int inventoryBook = bookBUS.InventoryOfBook(ListBookSelectedItem.ID);
                    if (inventoryBook - ListBookSelectedItem.Count < 0)
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
            TotalPrice = ListBook.Sum(x => x.TotalMoney);
            LastTotalPrice = ListBook.Sum(x => x.TotalMoney) - ListBook.Sum(x => x.TotalMoney) * Promotion / 100;
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
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(CustomerMoney))
            {
                return false;
            }
            if (Help.isFloat(CustomerMoney) == false)
            {
                return false;
            }
            if (ExcessCash < 0)
            {
                return false;
            }
            if (Help.isInt(Phone) == false)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(Email))
            {
                if (Help.isEmail(Email) == false)
                {
                    return false;
                }
            }
            if (ListTypePaymentSelectedItem == null)
            {
                return false;
            }
            return true;
        }
    }
}
