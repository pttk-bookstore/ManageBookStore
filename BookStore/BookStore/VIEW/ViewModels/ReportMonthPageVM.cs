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
    public class ReportMonthPageVM : BaseViewModel
    {

        #region global

        ReportBUS reportBUS = new ReportBUS();

        #endregion
        #region data binding

        private ObservableCollection<string> _listYear;
        public ObservableCollection<string> ListYear { get => _listYear; set { if (value == _listYear) return; _listYear = value; OnPropertyChanged(); } }

        private string _selectedItemYear;
        public string SelectedItemYear { get => _selectedItemYear; set { if (value == _selectedItemYear) return; _selectedItemYear = value; OnPropertyChanged(); } }

        private ObservableCollection<CReportMonth> _listReport;
        public ObservableCollection<CReportMonth> ListReport { get => _listReport; set { if (value == _listReport) return; _listReport = value; OnPropertyChanged(); } }

        private int _bookInCount;
        public int BookInCount { get => _bookInCount; set { if (value == _bookInCount) return; _bookInCount = value; OnPropertyChanged(); } }

        private float _bookInPrice;
        public float BookInPrice { get => _bookInPrice; set { if (value == _bookInPrice) return; _bookInPrice = value; OnPropertyChanged(); } }

        private int _bookOutCount;
        public int BookOutCount { get => _bookOutCount; set { if (value == _bookOutCount) return; _bookOutCount = value; OnPropertyChanged(); } }

        private float _bookOutPrice;
        public float BookOutPrice { get => _bookOutPrice; set { if (value == _bookOutPrice) return; _bookOutPrice = value; OnPropertyChanged(); } }

        private float _profit;
        public float Profit { get => _profit; set { if (value == _profit) return; _profit = value; OnPropertyChanged(); } }

        private float _salary;
        public float Salary { get => _salary; set { if (value == _salary) return; _salary = value; OnPropertyChanged(); } }

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
        public ICommand SelectionChangedYear { get; set; }

        #endregion

        public ReportMonthPageVM()
        {
            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                firtLoad();
            }
               );

            SelectionChangedYear = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (SelectedItemYear != null)
                {
                    loadReport();
                }
            }
               );
        }

        /// <summary>
        /// Khởi tạo các giá trị của màn hình trong lần đầu chạy
        /// </summary>
        private async void firtLoad()
        {
            IsIndeterminate = true;
            await Task.Run(() =>
            {
                CreateYear();
                SelectedItemYear = DateTime.Now.Year.ToString();               
            });
            loadReport();
        }

        /// <summary>
        /// tải báo cáo lên từ csdl
        /// </summary>
        private async void loadReport()
        {
            if (ListReport != null)
            {
                ListReport.Clear();
            }
            IsIndeterminate = true;
            await Task.Run(() =>
            {               
                ListReport = new ObservableCollection<CReportMonth>(reportBUS.MonthlyReport(int.Parse(SelectedItemYear)));
                updateSumYear();
            });
            IsIndeterminate = false;    
        }

        /// <summary>
        /// Cập nhật thông tin tổng cộng
        /// </summary>
        private void updateSumYear()
        {
            BookInCount = ListReport.Sum(x => x.ToltalBookIn);
            BookInPrice = ListReport.Sum(x => x.ToltalMoneyBooksIn);
            BookOutCount = ListReport.Sum(x => x.ToltalBooksSold);
            BookOutPrice = ListReport.Sum(x => x.ToltalMoneyBooksSell);
            Profit = ListReport.Sum(x => x.TotalProfit);
            Salary = ListReport.Sum(x => x.ToltalSalary);
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
