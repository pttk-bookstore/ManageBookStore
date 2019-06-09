using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAO
{
    public class SubCategoryDAO
    {
        /// <summary>
        /// Hàm trả về danh sách tất cả các chủ đề thuộc thể loại theo ID
        /// </summary>
        /// <param name="CategoryID">ID chủ đề</param>
        /// <returns></returns>
        public List<CSubCategory> ListSubCategory(int CategoryID)
        {
            List<CSubCategory> List = new List<CSubCategory>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.SubCategories.Where(x => x.Category_ID == CategoryID);

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            List.Add(new CSubCategory
                            {
                                ID = item.SubCategory_ID,
                                Name = item.SubCategory_Name
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
