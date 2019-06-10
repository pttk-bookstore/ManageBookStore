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
    }
}
