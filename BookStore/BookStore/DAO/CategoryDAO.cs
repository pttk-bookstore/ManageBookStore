using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAO
{
    public class CategoryDAO
    {
        /// <summary>
        /// Hàm trả về danh sách tất cả các thể loại
        /// </summary>
        /// <returns></returns>
        public List<CCategory> ListCategory()
        {
            List<CCategory> List = new List<CCategory>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Categories;

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            List.Add(new CCategory
                            {
                                ID=item.Category_ID,
                                Name=item.Category_Name
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
