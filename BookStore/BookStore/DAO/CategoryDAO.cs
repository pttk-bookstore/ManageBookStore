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

        /// <summary>
        /// Hàm trả về danh sách tất cả các thể loại kèm theo số lượng sách tương ứng
        /// </summary>
        /// <returns></returns>
        public List<CCategory> ListFullCategory()
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
                                ID = item.Category_ID,
                                Name = item.Category_Name,
                                Count = item.Books.Count
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

        /// <summary>
        /// Hàm trả về số lượng sách có trong kho tương ứng với Category
        /// </summary>
        /// <returns></returns>
        public List<CCategory> ListCatergoryBook()
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
                                ID = item.Category_ID,
                                Name = item.Category_Name,
                                Count = item.Books.Sum(x=>x.Book_Inventory)
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

        /// <summary>
        /// Hàm trả về ID của Category theo tên trả về 0 nếu như không tìm thấy
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <returns></returns>
        public int IDofCategoryName(string CategoryName)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Categories.Where(x => x.Category_Name.ToLower().Equals(CategoryName.ToLower())).FirstOrDefault();
                    if (find != null)
                    {
                        return find.Category_ID;
                    }          
                }
            }
            catch
            {

            }
            return 0;
        }

        /// <summary>
        /// Hàm thêm vào 1 category mới trả về id nếu như thêm thành công, nếu không trả về -1
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <returns></returns>
        public int addCategory(string CategoryName)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    Category category = new Category
                    {
                        Category_Name = CategoryName
                    };

                    DB.Categories.Add(category);
                    DB.SaveChanges();
                    return category.Category_ID;
                }
            }
            catch
            {

            }
            return -1;
        }

        /// <summary>
        /// Hàm cập nhật tên của category, cập nhật thành công trả về 1 thất bại trả về -1
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int updateCategory(CCategory category)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Categories.Find(category.ID);
                    if (find != null)
                    {
                        find.Category_Name = category.Name;
                    }

                    DB.SaveChanges();
                    return 1;
                }
            }
            catch
            {

            }
            return -1;
        }

        /// <summary>
        /// Xóa một Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int deleteCategory(int CategoryID)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Categories.Find(CategoryID);
                    if (find != null)
                    {
                        DB.Categories.Remove(find);
                    }

                    DB.SaveChanges();
                    return 1;
                }
            }
            catch
            {

            }
            return -1;
        }

        /// <summary>
        /// Kiểm tra loại này có đang được xử dụng hay không, trả về 0 nếu không được xử dụng
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public int isCategoryUsed(int CategoryID)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var count = DB.SubCategories.Where(x => x.Category_ID == CategoryID).Count();
                    if (count > 0)
                    {
                        return count;
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
