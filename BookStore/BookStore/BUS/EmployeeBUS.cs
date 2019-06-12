using BookStore.DAO;
using BookStore.DTO;
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

        /// <summary>
        /// Hàm trả về về thông tin chi tiết của nhân viên
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public CEmployee InfoOfEmployee(int EmployeeID)
        {
            return DAO.InfoOfEmployee(EmployeeID);
        }

        /// <summary>
        /// Trả về id loại nhân viên
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public int RoleIdOfEmployee(int EmployeeID)
        {
            return DAO.RoleIdOfEmployee(EmployeeID);
        }
    }
}
