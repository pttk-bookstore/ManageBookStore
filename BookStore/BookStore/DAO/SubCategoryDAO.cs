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


        /// <summary>
        /// Hàm trả về danh sách tất cả các chủ đề thuộc thê loại theo ID bao gồm số lượng đầu sách tương ứng
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public List<CSubCategory> ListFullSubCategory(int CategoryID)
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
                                Name = item.SubCategory_Name,
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
        /// Hàm trả về ID của SubCategory theo tên trả về 0 nếu như không tìm thấy
        /// </summary>
        /// <param name="SubCategoryName"></param>
        /// <returns></returns>
        public int IDofSubCategoryName(string SubCategoryName)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.SubCategories.Where(x => x.SubCategory_Name.ToLower().Equals(SubCategoryName.ToLower())).FirstOrDefault();
                    if (find != null)
                    {
                        return find.SubCategory_ID;
                    }
                }
            }
            catch
            {

            }
            return 0;
        }

        /// <summary>
        /// Hàm thêm vào 1 SubCategory mới trả về id nếu như thêm thành công, nếu không trả về -1
        /// </summary>
        /// <param name="SubCategoryName"></param>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public int addSubCategory(string SubCategoryName,int CategoryID)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    SubCategory subCategory = new SubCategory
                    {
                        SubCategory_Name = SubCategoryName,
                        Category_ID = CategoryID
                    };

                    DB.SubCategories.Add(subCategory);
                    DB.SaveChanges();
                    return subCategory.SubCategory_ID;
                }
            }
            catch
            {

            }
            return -1;
        }

        /// <summary>
        /// Hàm cập nhật tên của Subcategory, cập nhật thành công trả về 1 thất bại trả về -1
        /// </summary>
        /// <param name="subcategory"></param>
        /// <returns></returns>
        public int updateSubCategory(CSubCategory subcategory)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.SubCategories.Find(subcategory.ID);
                    if (find != null)
                    {
                        find.SubCategory_Name = subcategory.Name;
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
        /// Xóa một SubCategory
        /// </summary>
        /// <param name="SubCategoryID"></param>
        /// <returns></returns>
        public int deleteSubCategory(int SubCategoryID)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.SubCategories.Find(SubCategoryID);
                    if (find != null)
                    {
                        DB.SubCategories.Remove(find);
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
        /// <param name="SubCategoryID"></param>
        /// <returns></returns>
        public int isSubCategoryUsed(int SubCategoryID)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var count = DB.Books.Where(x => x.Book_SubCategory == SubCategoryID).Count();
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
