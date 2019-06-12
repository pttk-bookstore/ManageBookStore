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

        /// <summary>
        /// Kiểm tra mật khẩu đúng hay không đúng trả về 1 sai trả về -1
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public int isTruePass(int EmployeeID,string pass)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Employee_Account.Find(EmployeeID);
                    if (find != null)
                    {
                        if(find.Account_Passwork == pass)
                        {
                            return 1;
                        }
                    }
                }
            }
            catch
            {

            }
            return -1;
        }

        /// <summary>
        /// Thay đổi mật khẩu của nhân viên thành công trả về 1 thất bại trả về -1
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public int changePass(int EmployeeID,string pass)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Employee_Account.Find(EmployeeID);
                    if (find != null)
                    {
                        find.Account_Passwork = pass;
                        DB.SaveChanges();
                        return 1;
                    }
                }
            }
            catch
            {

            }
            return -1;
        }
    }
}
