using BookStore.BUS;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookStore.VIEW.ViewModels
{
    public class ReportDatePageVM : BaseViewModel
    {
        #region global

        ReportBUS reportBUS = new ReportBUS();

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

        private ObservableCollection<CReportDate> _listReport;
        public ObservableCollection<CReportDate> ListReport { get => _listReport; set { if (value == _listReport) return; _listReport = value; OnPropertyChanged(); } }
        #endregion

        #region properties binding

        private bool _isIndeterminate;

        public bool IsIndeterminate
        {
            get { return _isIndeterminate; }
            set { _isIndeterminate = value; OnPropertyChanged(); }
        }

        #endregion

        #region command binding

        public ICommand LoadCommand { get; set; }
        public ICommand DateBeginSelectedDateChanged { get; set; }
        public ICommand DateEndSelectedDateChanged { get; set; }
        public ICommand SelectionChangedMonth { get; set; }
        public ICommand SelectionChangedYear { get; set; }

        #endregion

        public ReportDatePageVM()
        {
            DateBeginSelectedDateChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadReportWhenDateChange();
            }
               );

            DateEndSelectedDateChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadReportWhenDateChange();
            }
              );

            SelectionChangedMonth = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadReportWhenMonthYearChange();
            }
               );

            SelectionChangedYear = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadReportWhenMonthYearChange();
            }
              );

            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                firstLoad();               
            }
               );

        }

        /// <summary>
        /// Khởi tạo màn hình trong lần đầu tiên chạy
        /// </summary>
        private async void firstLoad()
        {
            IsIndeterminate = true;
            await Task.Run(() =>
            {
                CreateMonth();
                CreateYear();

                SelectedItemMonth = DateTime.Now.Month.ToString();
                SelectedItemYear = DateTime.Now.Year.ToString();

                //https://stackoverflow.com/questions/24245523/getting-the-first-and-last-day-of-a-month-using-a-given-datetime-object

                DateTime date = new DateTime(int.Parse(SelectedItemYear), int.Parse(SelectedItemMonth), 1);
                DateBeginSelectedDate = new DateTime(date.Year, date.Month, 1);
                DateEndSelectedDate = DateBeginSelectedDate.AddMonths(1).AddDays(-1);

                ListReport = new ObservableCollection<CReportDate>();
                
            });
            loadReportWhenMonthYearChange();
        }

        /// <summary>
        /// Load lại dữ liệu theo tháng và năm
        /// </summary>
        private async void loadReportWhenMonthYearChange()
        {
            ListReport.Clear();
            if (SelectedItemMonth != null && SelectedItemYear != null)
            {
                IsIndeterminate = true;
                await Task.Run(() =>
                {
                    DateTime date = new DateTime(int.Parse(SelectedItemYear), int.Parse(SelectedItemMonth), 1);
                    DateBeginSelectedDate = new DateTime(date.Year, date.Month, 1);
                    DateEndSelectedDate = DateBeginSelectedDate.AddMonths(1).AddDays(-1);
                    ListReport = new ObservableCollection<CReportDate>(reportBUS.DailyReport(int.Parse(SelectedItemMonth), int.Parse(SelectedItemYear)));
                });
                IsIndeterminate = false;
            }         
        }

        /// <summary>
        /// Load lại dữ liệu theo ngày
        /// </summary>
        private async void loadReportWhenDateChange()
        {
            ListReport.Clear();

            if (DateEndSelectedDate!=null && DateEndSelectedDate != null)
            {
                IsIndeterminate = true;
                await Task.Run(() =>
                {
                    ListReport = new ObservableCollection<CReportDate>(reportBUS.DailyReport(DateBeginSelectedDate, DateEndSelectedDate));
                });
                IsIndeterminate = false;
            }
        }

        void CreateMonth()
        {
            ListMonth = new ObservableCollection<string>();
            for (int i = 1; i <= 12; i++)
            {
                ListMonth.Add(i.ToString());
            }
        }

        void CreateYear()
        {
            ListYear = new ObservableCollection<string>();
            for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year + 5; i++)
            {
                ListYear.Add(i.ToString());
            }
        }
    }
}
