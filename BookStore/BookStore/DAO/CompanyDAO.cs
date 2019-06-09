using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAO
{
    public class CompanyDAO
    {
        /// <summary>
        /// Hàm trả về danh sách tất cả các nhà xuất bản
        /// </summary>
        /// <returns></returns>
        public List<CCompany> ListCompany()
        {
            List<CCompany> List = new List<CCompany>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Companies;

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            List.Add(new CCompany
                            {
                                ID = item.Company_ID,
                                Name = item.Company_Name
                            }
                            );
                        }
                    }
                }
            }
            catch
            {

            }

            return List;
        }
    }
}
