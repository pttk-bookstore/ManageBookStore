using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BookStore.VIEW.ViewModels
{
    public class BookInfoPageVM : BaseViewModel
    {
        #region Global

        private int _currentPage;
        public int CurrentPage { get => _currentPage; set { if (value == _currentPage) return; _currentPage = value; OnPropertyChanged(); } }

        int NumberPage = 12;


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

        private ObservableCollection<string> _listType;
        public ObservableCollection<string> ListType { get => _listType; set { if (value == _listType) return; _listType = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _listTheme;
        public ObservableCollection<string> ListTheme { get => _listTheme; set { if (value == _listTheme) return; _listTheme = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _listCompany;
        public ObservableCollection<string> ListCompany { get => _listCompany; set { if (value == _listCompany) return; _listCompany = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _listSortBy;
        public ObservableCollection<string> ListSortBy { get => _listSortBy; set { if (value == _listSortBy) return; _listSortBy = value; OnPropertyChanged(); } }

        /// <summary>
        /// Binding selected item combobox
        /// </summary>

        private string _selectedItemAuthor;
        public string SelectedItemAuthor { get => _selectedItemAuthor; set { if (value == _selectedItemAuthor) return; _selectedItemAuthor = value; OnPropertyChanged(); } }

        private string _selectedItemTheme;
        public string SelectedItemTheme { get => _selectedItemTheme; set { if (value == _selectedItemTheme) return; _selectedItemTheme = value; OnPropertyChanged(); } }

        private string _selectedItemType;
        public string SelectedItemType { get => _selectedItemType; set { if (value == _selectedItemType) return; _selectedItemType = value; OnPropertyChanged(); } }

        private string _filterString;
        public string FilterString { get => _filterString; set { if (value == _filterString) return; _filterString = value; OnPropertyChanged(); } }

        private string _selectedItemCompany;
        public string SelectedItemCompany { get => _selectedItemCompany; set { if (value == _selectedItemCompany) return; _selectedItemCompany = value; OnPropertyChanged(); } }

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

        public ICommand TypeSelectionChanged { get; set; }
        public ICommand ThemeSelectionChanged { get; set; }
        public ICommand AuthorSelectionChanged { get; set; }
        public ICommand CompanySelectionChanged { get; set; }
        public ICommand SortBySelectionChanged { get; set; }

        public ICommand searchCommand { get; set; }

        #endregion

        public BookInfoPageVM()
        {
            searchCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadBookWithSort();
            }
               );

            PreviousPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (CurrentPage > 1)
                {
                    CurrentPage = CurrentPage - 1;
                    LoadBookWithSort();
                }
            }
              );

            NextPageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CurrentPage = CurrentPage + 1;
                LoadBookWithSort();
            }
              );

            TypeSelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (SelectedItemType != null)
                {
                    

                    LoadBookWithSort();
                }
            }
               );

            ThemeSelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadBookWithSort();
            }
               );

            AuthorSelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadBookWithSort();
            }
               );

            CompanySelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoadBookWithSort();
            }
               );

            addNewBookCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //Khởi tạo
                AddNewBookWindow wd = new AddNewBookWindow();
                wd.ShowDialog();
                //Load lại List
                LoadBookWithSort();
                
            }
               );

            increaseBookCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //Khởi tạo
                IncreaseBookWindow wd = new IncreaseBookWindow();
                wd.ShowDialog();
                //Load lại List
                LoadBookWithSort();
                
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
                
            }
               );

            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CurrentPage = 1;
                FilterString = "";

                
                
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
                LoadBookWithSort();
            }
               );
        }

        private void LoadBook()
        {
            if (SelectedItemCompany != null && SelectedItemTheme != null && SelectedItemType != null && SelectedItemAuthor != null)
            {
                
            }
        }

        private void LoadBookWithSort()
        {
            if (SelectedItemCompany != null && SelectedItemTheme != null && SelectedItemType != null && SelectedItemAuthor != null && SelectedItemSortBy != null)
            {
                
            }
        }

        private void CreateSortBy()
        {
            ListSortBy = new ObservableCollection<string>();
            ListSortBy.Add("Tên");
            ListSortBy.Add("Mã");
            ListSortBy.Add("Tồn kho giảm dần");
            ListSortBy.Add("Tồn kho tăng dần");
            ListSortBy.Add("Lượt mua giảm dần");
            ListSortBy.Add("Lượt mua tăng dần");
        }
    }
}
