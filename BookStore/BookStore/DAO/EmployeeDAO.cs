using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAO
{
    public class EmployeeDAO
    {
        /// <summary>
        /// Tên của nhân viên tương ứng với ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string EmployeeName(int ID)
        {
            string name = "";

            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Employees.Find(ID);

                    if (find != null)
                    {
                        return find.Employee_Name;
                    }
                }
            }
            catch
            {

            }

            return name;
        }
    }
}
