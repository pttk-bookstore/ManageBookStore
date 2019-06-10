using BookStore.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BUS
{
    public class EmployeeBUS
    {
        EmployeeDAO DAO = new EmployeeDAO();

        /// <summary>
        /// Hàm trả về tên của nhân viên tương ứng với ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string EmployeeName(int ID)
        {
            return DAO.EmployeeName(ID);
        }
    }
}
