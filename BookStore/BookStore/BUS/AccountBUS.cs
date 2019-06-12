using BookStore.DAO;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BUS
{
    public class AccountBUS
    {
        AccountDAO DAO = new AccountDAO();

        /// <summary>
        /// Hàm trả về ID của nhân viên đăng nhập
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public int IDEmployee(CAccount account)
        {
            return DAO.IDEmployee(account);
        }


        /// <summary>
        /// Cập nhật mật khẩu trả về 1 nếu thành công, 0 nếu mật khẩu xác nhận sai, -1 nếu thất bại
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public int changePass(int EmployeeID, string oldpass,string newpass)
        {
            int result = DAO.isTruePass(EmployeeID, oldpass);
            if(result == 1)
            {
                return DAO.changePass(EmployeeID, newpass);
            }
            else
            {
                return 0;
            }
        }
    }
}
