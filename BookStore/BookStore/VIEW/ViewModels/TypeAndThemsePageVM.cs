using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookStore.VIEW.ViewModels
{
    public class TypeAndThemsePageVM:BaseViewModel
    {
        #region data binding

        //private ObservableCollection<CBookType> _listType;
        //public ObservableCollection<CBookType> ListType { get => _listType; set { if (value == _listType) return; _listType = value; OnPropertyChanged(); } }

        //private CBookType _typeSelectedItem;
        //public CBookType TypeSelectedItem { get => _typeSelectedItem; set { if (value == _typeSelectedItem) return; _typeSelectedItem = value; OnPropertyChanged(); } }

        //private ObservableCollection<CBookTheme> _listTheme;
        //public ObservableCollection<CBookTheme> ListTheme { get => _listTheme; set { if (value == _listTheme) return; _listTheme = value; OnPropertyChanged(); } }

        //private CBookTheme _themeSelectedItem;
        //public CBookTheme ThemeSelectedItem { get => _themeSelectedItem; set { if (value == _themeSelectedItem) return; _themeSelectedItem = value; OnPropertyChanged(); } }

        private string _currentType;
        public string CurrentType { get => _currentType; set { if (value == _currentType) return; _currentType = value; OnPropertyChanged(); } }

        private bool _typeIsChecked;
        public bool TypeIsChecked { get => _typeIsChecked; set { if (value == _typeIsChecked) return; _typeIsChecked = value; OnPropertyChanged(); } }

        private string _typeName;
        public string TypeName { get => _typeName; set { if (value == _typeName) return; _typeName = value; OnPropertyChanged(); } }

        private bool _themeIsChecked;
        public bool ThemeIsChecked { get => _themeIsChecked; set { if (value == _themeIsChecked) return; _themeIsChecked = value; OnPropertyChanged(); } }

        private string _themeName;
        public string ThemeName { get => _themeName; set { if (value == _themeName) return; _themeName = value; OnPropertyChanged(); } }


        #endregion

        public ICommand LoadCommand { get; set; }
        public ICommand TypeSelectionChanged { get; set; }

        public ICommand editTypeCommand { get; set; }
        public ICommand deleteTypeCommand { get; set; }
        public ICommand restoreTypeCommand { get; set; }

        public ICommand TypeCheckedCommand { get; set; }

        public ICommand addTypeCommand { get; set; }

        public ICommand editThemeCommand { get; set; }
        public ICommand deleteThemeCommand { get; set; }
        public ICommand restoreThemeCommand { get; set; }

        public ICommand ThemeCheckedCommand { get; set; }

        public ICommand addThemeCommand { get; set; }

        #region command binding

        #endregion

        public TypeAndThemsePageVM()
        {
            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                TypeIsChecked = false;
                ThemeIsChecked = false;
                
                CurrentType = "";
            }
              );

            ThemeCheckedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
            }
              );

            addThemeCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) =>
            {
                
            }
              );

            deleteThemeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
            }
              );

            restoreThemeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
            }
              );

            editThemeCommand = new RelayCommand<object>((p) => {
                return true;
                
            }, (p) =>
            {
                
            }
              );


            addTypeCommand = new RelayCommand<object>((p) => {
                

                return true;
            }, (p) =>
            {
                

            }
              );

            TypeCheckedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
            }
              );

            restoreTypeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
            }
              );

            deleteTypeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
            }
              );

            editTypeCommand = new RelayCommand<object>((p) => {
                
                return true;
            }, (p) =>
            {
                
            }
              );

            TypeSelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
            }
             );
        }
    }
}
