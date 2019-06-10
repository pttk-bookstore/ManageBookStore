using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAO
{
    public class AccountDAO
    {
        /// <summary>
        /// Hàm trả về ID của nhân viên theo tên đăng nhập và mật khẩu
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public int IDEmployee(CAccount account)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Employee_Account.Where(x => x.Account_UserName.Equals(account.UserName) 
                    && x.Account_Passwork.Equals(account.PassWord)).FirstOrDefault();

                    if (find != null)
                    {
                        return find.Employee_ID;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch
            {

            }
            return 0;
        }
    }
}
