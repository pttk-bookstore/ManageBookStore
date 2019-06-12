using BookStore.VIEW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BookStore.DTO
{
    public class CBook:BaseViewModel
    {
        private int _iD;

        /// <summary>
        /// ID sách
        /// </summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private String _name;

        /// <summary>
        /// Tên sách
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private CCategory _category;

        /// <summary>
        /// Danh mục sách
        /// </summary>
        public CCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private CSubCategory _subCategory;

        /// <summary>
        /// Loại sách
        /// </summary>
        public CSubCategory SubCategory
        {
            get { return _subCategory; }
            set { _subCategory = value; }
        }


        private string _author;

        /// <summary>
        /// Tác giả
        /// </summary>
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        private CCompany _company;

        /// <summary>
        /// Nhà xuất bản
        /// </summary>
        public CCompany Company
        {
            get { return _company; }
            set { _company = value; }
        }

        private float _price;
        /// <summary>
        /// Giá gốc
        /// </summary>
        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _inventory;
        /// <summary>
        /// Tồn kho
        /// </summary>
        public int Inventory
        {
            get { return _inventory; }
            set { _inventory = value;OnPropertyChanged(); }
        }

        private float _promotion;
        /// <summary>
        /// Phần trăm khuyến mãi
        /// </summary>
        public float Promotion
        {
            get { return _promotion; }
            set { _promotion = value; }
        }

        private float _pricePromotion;
        /// <summary>
        /// Giá sau khuyến mãi
        /// </summary>
        public float PricePromotion
        {
            get { return _pricePromotion; }
            set { _pricePromotion = value; }
        }

        private BitmapImage _image;
        /// <summary>
        /// Hình đại diện sách
        /// </summary>
        public BitmapImage  Image
        {
            get { return _image; }
            set { _image = value; }
        }

        private int _sole;
        /// <summary>
        /// Số lượng sách đã bán ra
        /// </summary>
        public int Sole
        {
            get { return _sole; }
            set { _sole = value; }
        }

        private bool _isChecked;
        /// <summary>
        /// Thuộc tính để thêm vào trong sách thêm mới
        /// </summary>
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value;OnPropertyChanged(); }
        }

    }
}
