using BookStore.BUS;
using BookStore.DTO;
using BookStore.VIEW.ViewClass;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookStore.VIEW.ViewModels
{
    public class HistoryWareHousePageVM : BaseViewModel
    {
        #region Global

        WareHouseBUS wareHouseBUS = new WareHouseBUS();

        private int _currentPage;
        public int CurrentPage { get => _currentPage; set { if (value == _currentPage) return; _currentPage = value; OnPropertyChanged(); } }

        int NumberPage = 6;

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

        private ObservableCollection<CBookReipt> _listWareHouse;
        public ObservableCollection<CBookReipt> listWareHouse { get => _listWareHouse; set { if (value == _listWareHouse) return; _listWareHouse = value; OnPropertyChanged(); } }

        private CBookReipt _wareHouseSelectedItem;
        public CBookReipt WareHouseSelectedItem { get => _wareHouseSelectedItem; set { if (value == _wareHouseSelectedItem) return; _wareHouseSelectedItem = value; OnPropertyChanged(); } }

        private int _wareHouseID;
        public int WareHouseID { get => _wareHouseID; set { if (value == _wareHouseID) return; _wareHouseID = value; OnPropertyChanged(); } }

        private ObservableCollection<CBookTransaction> _listDetail;
        public ObservableCollection<CBookTransaction> ListDetail { get => _listDetail; set { if (value == _listDetail) return; _listDetail = value; OnPropertyChanged(); } }

        private SeriesCollection _seriesCollection;
        public SeriesCollection SeriesCollection { get => _seriesCollection; set { if (value == _seriesCollection) return; _seriesCollection = value; OnPropertyChanged(); } }

        #endregion

        public ICommand LoadCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ICommand WareHouseSelectionChanged { get; set; }

        public ICommand SelectionChangedMonth { get; set; }
        public ICommand SelectionChangedYear { get; set; }

        public ICommand DateEndSelectedDateChanged { get; set; }
        public ICommand DateBeginSelectedDateChanged { get; set; }

        public HistoryWareHousePageVM()
        {
            WareHouseSelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadDetailWareHouse();
            }
             );

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

            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                firtLoad();
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

            loadWareHouseByMonthAndYear();
        }

        /// <summary>
        /// Cập nhật lại chi tiết nhập kho khi thay đổi
        /// </summary>
        private void loadDetailWareHouse()
        {
            if (WareHouseSelectedItem != null)
            {
                WareHouseID = WareHouseSelectedItem.ID;
                ListDetail = new ObservableCollection<CBookTransaction>(wareHouseBUS.DetailOfWareHouse(WareHouseSelectedItem.ID));
                LoadChart();
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

                loadWareHouseByMonthAndYear();
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
                loadWareHouseByDate();
            }
        }

        /// <summary>
        /// Load dữ liệu lịch sử nhập kho theo năm và tháng
        /// </summary>
        private void loadWareHouseByMonthAndYear()
        {
            listWareHouse = new ObservableCollection<CBookReipt>(wareHouseBUS.Warehouse_History(int.Parse(SelectedItemMonth), int.Parse(SelectedItemYear), CurrentPage, NumberPage));
        }

        /// <summary>
        /// Load dữ liệu theo ngày
        /// </summary>
        private void loadWareHouseByDate()
        {
            listWareHouse = new ObservableCollection<CBookReipt>(wareHouseBUS.Warehouse_History(DateBeginSelectedDate, DateEndSelectedDate, CurrentPage, NumberPage));
        }

        /// <summary>
        /// Cập nhật lại biểu đồ
        /// </summary>
        public void LoadChart()
        {
            SeriesCollection = new SeriesCollection();

            //Tạo mới list

            List<StructBook> listStruct = getStructDetail();

            var results = from p in listStruct
                          group p.Count by p.CategoryName into g
                          select new { Type = g.Key, Count = g.ToList() };

            foreach (var item in results)
            {
                var data = new PieSeries
                {
                    Title = item.Type,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(item.Count.Sum()) },
                    DataLabels = true
                };
                SeriesCollection.Add(data);
            }
        }

        /// <summary>
        /// Xóa list detail
        /// </summary>
        private void ClearList()
        {
            ListDetail.Clear();
            listWareHouse.Clear();
        }

        /// <summary>
        /// Trả về list struct của detail
        /// </summary>
        /// <returns></returns>
        private List<StructBook> getStructDetail()
        {
            List<StructBook> listStruct = new List<StructBook>();
            if (ListDetail.Count > 0)
            {
                foreach(var item in ListDetail)
                {
                    StructBook structBook = new StructBook
                    {
                        CategoryName = item.Category.Name,
                        Count = item.Count
                    };

                    listStruct.Add(structBook);
                }
            }
            return listStruct;
        } 
    }
}
