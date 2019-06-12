using BookStore.BUS;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookStore.VIEW.ViewModels
{
    public class EmployeeInfoPageVM : BaseViewModel
    {

        #region global

        EmployeeBUS employeeBUS = new EmployeeBUS();

        #endregion

        #region data binding

        private CEmployee _Employee;
        public CEmployee Employee
        {
            get { return _Employee; }
            set
            {
                _Employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }


        #endregion

        #region command binding

        public ICommand LoadCommand { get; set; }
        public ICommand ChangePassCommand { get; set; }

        #endregion

        public EmployeeInfoPageVM()
        {
            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadInfoEmployee();
            }
               );

            ChangePassCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ChangePasswordWindow wd = new ChangePasswordWindow();
                wd.ShowDialog();
            }
               );
        }

        /// <summary>
        /// Load thông tin của nhân viên theo ID
        /// </summary>
        private void loadInfoEmployee()
        {
            Employee = employeeBUS.InfoOfEmployee(DataTransfer.EmployeeID);
        }
    }
}
