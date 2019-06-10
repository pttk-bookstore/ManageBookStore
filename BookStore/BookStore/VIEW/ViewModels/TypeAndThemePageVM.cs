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
    public class TypeAndThemePageVM : BaseViewModel
    {

        #region global

        CategoryBUS categoryBUS = new CategoryBUS();
        SubCategoryBUS subCategoryBUS = new SubCategoryBUS();

        #endregion

        #region data binding

        private ObservableCollection<CCategory> _listCategory;
        public ObservableCollection<CCategory> ListCategory { get => _listCategory; set { if (value == _listCategory) return; _listCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<CSubCategory> _listSubCategory;
        public ObservableCollection<CSubCategory> ListSubCategory { get => _listSubCategory; set { if (value == _listSubCategory) return; _listSubCategory = value; OnPropertyChanged(); } }

        private CSubCategory _selectedItemSubCategory;
        public CSubCategory SelectedItemSubCategory { get => _selectedItemSubCategory; set { if (value == _selectedItemSubCategory) return; _selectedItemSubCategory = value; OnPropertyChanged(); } }

        private CCategory _selectedItemCategory;
        public CCategory SelectedItemCategory { get => _selectedItemCategory; set { if (value == _selectedItemCategory) return; _selectedItemCategory = value; OnPropertyChanged(); } }

        private string _categoryName;
        public string CategoryName { get => _categoryName; set { if (value == _categoryName) return; _categoryName = value; OnPropertyChanged(); } }

        

        private string _subCategory;
        public string SubCategoryName { get => _subCategory; set { if (value == _subCategory) return; _subCategory = value; OnPropertyChanged(); } }


        #endregion

        public ICommand LoadCommand { get; set; }
        public ICommand CategorySelectionChanged { get; set; }

        public ICommand editTypeCommand { get; set; }
        public ICommand deleteTypeCommand { get; set; }

        public ICommand addTypeCommand { get; set; }

        public ICommand editThemeCommand { get; set; }
        public ICommand deleteThemeCommand { get; set; }

        public ICommand addThemeCommand { get; set; }

        #region command binding

        #endregion

        public TypeAndThemePageVM()
        {
            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                firtLoad();
            }
              );

            addThemeCommand = new RelayCommand<object>((p) => {
                return checkTrueSubCategory();
            }, (p) =>
            {
                addSubCategory();
            }
              );

            deleteThemeCommand = new RelayCommand<object>((p) => { return checkTrueRowSubCategory(); }, (p) =>
            {
                deleteSubCategory();
            }
              );

            editThemeCommand = new RelayCommand<object>((p) => {
                return checkTrueRowSubCategory();
            }, (p) =>
            {
                updateSubCategory();
            }
              );

            addTypeCommand = new RelayCommand<object>((p) => {
                return checkTrueCategory();
            }, (p) =>
            {
                addCategory();
            }
              );

            deleteTypeCommand = new RelayCommand<object>((p) => { return checkTrueRowCategory(); }, (p) =>
            {
                deleteCategory();
            }
              );

            editTypeCommand = new RelayCommand<object>((p) => {
                return checkTrueRowCategory();
            }, (p) =>
            {
                updateCategory();
            }
              );

            CategorySelectionChanged = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadSubCategory();
            }
             );
        }

        /// <summary>
        /// Khởi tạo màn hình trong lần đầu chạy
        /// </summary>
        private void firtLoad()
        {
            ListCategory = new ObservableCollection<CCategory>(categoryBUS.ListFullCategory());
            ListSubCategory = new ObservableCollection<CSubCategory>(subCategoryBUS.ListFullSubCategory(1));
        }

        /// <summary>
        /// Đổi dữ liệu của subcategory theo category
        /// </summary>
        private void loadSubCategory()
        {
            if (SelectedItemCategory != null)
            {
                ListSubCategory = new ObservableCollection<CSubCategory>(subCategoryBUS.ListFullSubCategory(SelectedItemCategory.ID));
            }
        }

        /// <summary>
        /// Thêm mới một Category
        /// </summary>
        private void addCategory()
        {
            int result = categoryBUS.addCategory(CategoryName);
            if(result == -1)
            {
                MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (result == 0)
            {
                MessageBox.Show("Đã tồn tại loại này", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                ListCategory = new ObservableCollection<CCategory>(categoryBUS.ListFullCategory());
                CategoryName = "";
            }
        }

        /// <summary>
        /// Cập nhật thông tin mới cho Category
        /// </summary>
        private void updateCategory()
        {
            int result = categoryBUS.updateCategory(SelectedItemCategory);
            if (result == -1)
            {
                MessageBox.Show("Cập nhật thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                ListCategory = new ObservableCollection<CCategory>(categoryBUS.ListFullCategory());
            }
            else if (result == 0)
            {
                MessageBox.Show("Đã tồn tại loại này", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                ListCategory = new ObservableCollection<CCategory>(categoryBUS.ListFullCategory());
            }
            else
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        /// <summary>
        /// Xóa một category
        /// </summary>
        private void deleteCategory()
        {
            int result = categoryBUS.deleteCategory(SelectedItemCategory.ID);
            if (result == -1)
            {
                MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (result == 0)
            {
                MessageBox.Show("Xóa thất bại loại này đang dùng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                ListCategory = new ObservableCollection<CCategory>(categoryBUS.ListFullCategory());
            }
        }

        /// <summary>
        /// Kiểm tra thông tin nhập vào của Category mới
        /// </summary>
        /// <returns></returns>
        private bool checkTrueCategory()
        {
            if (string.IsNullOrEmpty(CategoryName))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra thông tin trên hàng của Category
        /// </summary>
        /// <returns></returns>
        private bool checkTrueRowCategory()
        {
            if (SelectedItemCategory != null)
            {
                if (string.IsNullOrEmpty(SelectedItemCategory.Name))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Thêm mới một SubCategory
        /// </summary>
        private void addSubCategory()
        {
            int result = subCategoryBUS.addSubCategory(SubCategoryName,SelectedItemCategory.ID);
            if (result == -1)
            {
                MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (result == 0)
            {
                MessageBox.Show("Đã tồn tại loại này", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                ListSubCategory = new ObservableCollection<CSubCategory>(subCategoryBUS.ListFullSubCategory(SelectedItemCategory.ID));
                SubCategoryName = "";
            }
        }

        /// <summary>
        /// Cập nhật thông tin mới cho SubCategory
        /// </summary>
        private void updateSubCategory()
        {
            int result = subCategoryBUS.updateSubCategory(SelectedItemSubCategory);
            if (result == -1)
            {
                MessageBox.Show("Cập nhật thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                ListSubCategory = new ObservableCollection<CSubCategory>(subCategoryBUS.ListFullSubCategory(SelectedItemCategory.ID));
            }
            else if (result == 0)
            {
                MessageBox.Show("Đã tồn tại loại này", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                ListSubCategory = new ObservableCollection<CSubCategory>(subCategoryBUS.ListFullSubCategory(SelectedItemCategory.ID));
            }
            else
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        /// <summary>
        /// Xóa một subcategory
        /// </summary>
        private void deleteSubCategory()
        {
            int result = subCategoryBUS.deleteSubCategory(SelectedItemSubCategory.ID);
            if (result == -1)
            {
                MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (result == 0)
            {
                MessageBox.Show("Xóa thất bại loại này đang dùng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                ListSubCategory = new ObservableCollection<CSubCategory>(subCategoryBUS.ListFullSubCategory(SelectedItemCategory.ID));
            }
        }

        /// <summary>
        /// Kiểm tra thông tin nhập của Subcategory mới
        /// </summary>
        /// <returns></returns>
        private bool checkTrueSubCategory()
        {
            if (!string.IsNullOrEmpty(SubCategoryName) &&SelectedItemCategory!=null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra thông tin trên hàng của Subcategory
        /// </summary>
        /// <returns></returns>
        private bool checkTrueRowSubCategory()
        {
            if (SelectedItemSubCategory != null && SelectedItemCategory!=null)
            {
                if (string.IsNullOrEmpty(SelectedItemSubCategory.Name))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

    }
}
