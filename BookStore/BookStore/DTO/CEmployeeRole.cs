using BookStore.VIEW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class CEmployeeRole:BaseViewModel
    {
        private int _iD;
        /// <summary>
        /// Mã loại nhân viên
        /// </summary>
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _name;
        /// <summary>
        /// Tên loại nhân viên
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value;OnPropertyChanged(); }
        }

        private float _salary;
        /// <summary>
        /// Lương nhân viên
        /// </summary>
        public float Salary
        {
            get { return _salary; }
            set { _salary = value; OnPropertyChanged(); }
        }

        private int _count;
        /// <summary>
        /// Tổng số lượng nhân viên loại này
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }




    }
}
