using BookStore.DTO;
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

        /// <summary>
        /// Trả về thông tin chi tiết của nhân viên
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public CEmployee InfoOfEmployee(int EmployeeID)
        {
            using(var DB = new MiniBookStoreEntities())
            {
                var find = DB.Employees.Find(EmployeeID);
                if (find != null)
                {
                    CEmployee employee = new CEmployee
                    {
                        ID = find.Employee_ID,
                        Name = find.Employee_Name,
                        FirstDate = find.Employee_CreatedDate,
                        Address = find.Employee_Address,
                        DOB = find.Employee_DOB,
                        Gender = find.Employee_Gender == 0 ? "Nam" : "Nữ",
                        Phone = find.Employee_Phone,
                        SumDate = find.Sum_Date,
                        Role = new CEmployeeRole
                        {
                            ID = find.Role.Role_ID,
                            Name = find.Role.Role_Name,
                            Salary = (float)find.Role.Role_Salary
                        },

                        MonthSalary = find.Sum_Date * (float)find.Role.Role_Salary
                    };

                    return employee;
                }
            }

            return null;
        }

        /// <summary>
        /// Trả về RoleId của nhân viên
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public int RoleIdOfEmployee(int EmployeeID)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Employees.Find(EmployeeID);
                    if (find != null)
                    {
                        return find.Role.Role_ID;
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
