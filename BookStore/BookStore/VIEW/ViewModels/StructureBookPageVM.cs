using BookStore.BUS;
using BookStore.DTO;
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
    public class StructureBookPageVM : BaseViewModel
    {
        #region global

        CategoryBUS categoryBUS = new CategoryBUS();

        #endregion

        #region data binding

        private SeriesCollection _seriesCollection;
        public SeriesCollection SeriesCollection { get => _seriesCollection; set { if (value == _seriesCollection) return; _seriesCollection = value; OnPropertyChanged(); } }

        private ObservableCollection<CCategory> _listCategory;
        public ObservableCollection<CCategory> ListCategory { get => _listCategory; set { if (value == _listCategory) return; _listCategory = value; OnPropertyChanged(); } }

        #endregion

        #region command binding

        public ICommand LoadCommand { get; set; }

        #endregion

        public StructureBookPageVM()
        {
            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loaddata();
                LoadChart();
            }
               );
        }

        public void loaddata()
        {
            ListCategory = new ObservableCollection<CCategory>(categoryBUS.ListCatergoryBook());
        }

        public void LoadChart()
        {
            SeriesCollection = new SeriesCollection();

            foreach (var item in ListCategory)
            {
                var data = new PieSeries
                {
                    Title = item.Name,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(item.Count) },
                    DataLabels = true
                };
                SeriesCollection.Add(data);
            }
        }
    }
}
