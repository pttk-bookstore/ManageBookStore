using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAO
{
    public class BookDAO
    {
        /// <summary>
        /// Trả về danh sách sách trong cửa hàng, lọc theo điều kiện
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Author"></param>
        /// <param name="Category"></param>
        /// <param name="SubCategory"></param>
        /// <param name="Company"></param>
        /// <param name="isSale"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBook> ListBook(string Name, string Author, int Category, int SubCategory, int Company,bool isSale, int currentPage, int NumberPage)
        {
            List<CBook> List = new List<CBook>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    List<Book> data = DB.Books.ToList();

                    if (isSale)
                    {
                        data = data.Where(x => x.Book_Promotion != 0).ToList();
                    }

                    //Lọc theo tên
                    if (Name.ToLower() == "tất cả" || string.IsNullOrEmpty(Name))
                    {
                        //do nothing
                    }
                    else
                    {
                        data = data.Where(x => x.Book_Name.ToLower().Contains(Name.ToLower())).ToList();
                    }

                    //Lọc theo thể loại
                    if (Category == 0)
                    {
                        //do nothing
                    }
                    else
                    {
                        data = data.Where(x => x.Book_Category == Category).ToList();
                    }

                    //Lọc theo chủ đề
                    if (SubCategory == 0)
                    {
                        //do nothing
                    }
                    else
                    {
                        data = data.Where(x => x.Book_SubCategory == SubCategory).ToList();
                    }

                    //Lọc theo NXB
                    if (Company == 0)
                    {
                        //do nothing
                    }
                    else
                    {
                        data = data.Where(x => x.Book_Company == Company).ToList();
                    }

                    //Lọc theo tác giả
                    if (Author.ToLower() == "tất cả")
                    {
                        //do nothing
                    }
                    else
                    {
                        data = data.Where(x => x.Book_Author.ToLower().Contains(Author.ToLower())).ToList();
                    }

                    //Lấy từng trang
                    if (currentPage > 0 && NumberPage > 0)
                    {
                        data = data.Skip((currentPage - 1) * NumberPage).Take(NumberPage).ToList();
                    }

                    if (data.Count > 0)
                    {
                        //Thêm vào trong danh sách
                        foreach (var item in data)
                        {

                            //Tính tổng sách đã bán ra
                            int totalNumber = 0;
                            if (DB.Bill_Detail.Where(x => x.Book_ID == item.Book_ID).Count() > 0)
                            {
                                totalNumber = DB.Bill_Detail.Where(x => x.Book_ID == item.Book_ID).Sum(x => x.Book_Count);
                            }

                            if (item.Book_Status == 1)
                            {
                                //Tạo mới sách
                                CBook Book = new CBook
                                {
                                    ID = item.Book_ID,
                                    Name = item.Book_Name,
                                    Author = item.Book_Author,
                                    Company = new CCompany
                                    {
                                        ID=item.Company.Company_ID,
                                        Name=item.Company.Company_Name
                                    },
                                    Category = new CCategory
                                    {
                                        ID = item.Book_Category,
                                        Name = item.Category.Category_Name
                                    },
                                    SubCategory = new CSubCategory
                                    {
                                        ID = item.Book_SubCategory,
                                        Name = item.SubCategory.SubCategory_Name
                                    },
                                    Inventory = item.Book_Inventory,
                                    Price = (float)item.Book_Price,
                                    Promotion = (float)item.Book_Promotion,
                                    PricePromotion = item.Book_Promotion == 0 ? (float)item.Book_Price : (float)(item.Book_Price - item.Book_Price * item.Book_Promotion),
                                    Image = item.Book_Image == null ? Help.LoadImage("../Images/harry.jpg") : Help.ByteToImage(item.Book_Image),
                                    Sole = totalNumber
                                };

                                //Thêm vào danh sách
                                List.Add(Book);
                            }
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
        /// Hàm trả về danh sách tất cả các tác giả
        /// </summary>
        /// <returns></returns>
        public List<string> ListAuthor()
        {
            List<string> List = new List<string>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Books.Select(x => x.Book_Author).Distinct();
                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            List.Add(item);
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
        /// Hàm trả về danh sách sách có sắp xếp theo thứ tự
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Author"></param>
        /// <param name="Type"></param>
        /// <param name="Theme"></param>
        /// <param name="Company"></param>
        /// <param name="sortBy"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CBook> ListBook(string Name, string Author, int Category, int SubCategory, int Company, string sortBy, int currentPage, int NumberPage)
        {
            List<CBook> List = new List<CBook>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    List<Book> data = DB.Books.ToList();

                    //Lọc theo tên
                    if (Name.ToLower() == "tất cả" || string.IsNullOrEmpty(Name))
                    {
                        //do nothing
                    }
                    else
                    {
                        data = data.Where(x => x.Book_Name.ToLower().Contains(Name.ToLower())).ToList();
                    }

                    //Lọc theo thể loại
                    if (Category == 0)
                    {
                        //do nothing
                    }
                    else
                    {
                        data = data.Where(x => x.Book_Category == Category).ToList();
                    }

                    //Lọc theo chủ đề
                    if (SubCategory == 0)
                    {
                        //do nothing
                    }
                    else
                    {
                        data = data.Where(x => x.Book_SubCategory == SubCategory).ToList();
                    }

                    //Lọc theo NXB
                    if (Company == 0)
                    {
                        //do nothing
                    }
                    else
                    {
                        data = data.Where(x => x.Book_Company == Company).ToList();
                    }

                    //Lọc theo tác giả
                    if (Author.ToLower() == "tất cả")
                    {
                        //do nothing
                    }
                    else
                    {
                        data = data.Where(x => x.Book_Author.ToLower().Contains(Author.ToLower())).ToList();
                    }

                    //Sắp xếp theo điều kiện
                    if (string.IsNullOrEmpty(sortBy) || sortBy == "")
                    {
                        //do nothing
                    }
                    else
                    {
                        if (sortBy == "Tồn kho giảm dần")
                        {
                            data = data.OrderByDescending(x => x.Book_Inventory).ToList();
                        }
                        else if (sortBy == "Tồn kho tăng dần")
                        {
                            data = data.OrderBy(x => x.Book_Inventory).ToList();
                        }
                        else if (sortBy == "Tên")
                        {
                            data = data.OrderBy(x => x.Book_Name).ToList();
                        }
                        else if (sortBy == "Mã")
                        {
                            data = data.OrderBy(x => x.Book_ID).ToList();
                        }
                        else if (sortBy == "Lượt mua tăng dần")
                        {
                            data = data.OrderBy(x => x.Bill_Detail.Sum(y => y.Book_Count)).ToList();
                        }
                        else if (sortBy == "Lượt mua giảm dần")
                        {
                            data = data.OrderByDescending(x => x.Bill_Detail.Sum(y => y.Book_Count)).ToList();
                        }
                    }

                    //Lấy từng trang
                    if (currentPage > 0 && NumberPage > 0)
                    {
                        data = data.Skip((currentPage - 1) * NumberPage).Take(NumberPage).ToList();
                    }

                    if (data.Count > 0)
                    {
                        //Thêm vào trong danh sách
                        foreach (var item in data)
                        {

                            //Tính tổng sách đã bán ra
                            int totalNumber = 0;
                            if (DB.Bill_Detail.Where(x => x.Book_ID == item.Book_ID).Count() > 0)
                            {
                                totalNumber = DB.Bill_Detail.Where(x => x.Book_ID == item.Book_ID).Sum(x => x.Book_Count);
                            }

                            if (item.Book_Status == 1)
                            {
                                //Tạo mới sách
                                CBook Book = new CBook
                                {
                                    ID = item.Book_ID,
                                    Name = item.Book_Name,
                                    Author = item.Book_Author,
                                    Company = new CCompany
                                    {
                                        ID = item.Company.Company_ID,
                                        Name = item.Company.Company_Name
                                    },
                                    Category = new CCategory
                                    {
                                        ID = item.Book_Category,
                                        Name = item.Category.Category_Name
                                    },
                                    SubCategory = new CSubCategory
                                    {
                                        ID = item.Book_SubCategory,
                                        Name = item.SubCategory.SubCategory_Name
                                    },
                                    Inventory = item.Book_Inventory,
                                    Price = (float)item.Book_Price,
                                    Promotion = (float)item.Book_Promotion,
                                    PricePromotion = item.Book_Promotion == 0 ? (float)item.Book_Price : (float)(item.Book_Price - item.Book_Price * item.Book_Promotion),
                                    Image = item.Book_Image == null ? Help.LoadImage("../Images/harry.jpg") : Help.ByteToImage(item.Book_Image),
                                    Sole = totalNumber,
                                    IsChecked = false
                                };

                                //Thêm vào danh sách
                                List.Add(Book);
                            }

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
        /// Hàm cập nhật thông tin sách
        /// </summary>
        /// <param name="BookInfo"></param>
        /// <returns></returns>
        public int updateBookInfo(CBook BookInfo)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    //Tìm sách theo ID
                    var find = DB.Books.Find(BookInfo.ID);
                    if (find != null)
                    {
                        //Cập nhật thông tin mới cho sách
                        find.Book_Name = BookInfo.Name;
                        find.Book_Author = BookInfo.Author;
                        find.Book_Category = BookInfo.Category.ID;
                        find.Book_SubCategory = BookInfo.SubCategory.ID;
                        find.Book_Company = BookInfo.Company.ID;
                        find.Book_Image = Help.ImageToByte(BookInfo.Image);
                        find.Book_Price = BookInfo.Price;
                        find.Book_Promotion = BookInfo.Promotion;

                        //Lưu thay đổi
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

        /// <summary>
        /// Trả về ID của sách nếu như tìm thấy
        /// </summary>
        /// <param name="BookInfo"></param>
        /// <returns>Trả về ID nếu tìm thấy trả về 0 nếu như không tìm thấy</returns>
        public int IdOfBookInfo(CBook BookInfo)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Books.Where(x => x.Book_Name.ToLower() == BookInfo.Name.ToLower()
                    && x.Book_Author.ToLower() == BookInfo.Author.ToLower() && x.Book_Category == BookInfo.Category.ID
                    && x.Book_SubCategory == BookInfo.SubCategory.ID && x.Book_Company == BookInfo.Company.ID)
                    .Select(x => x.Book_ID).FirstOrDefault();
     
                    if (find != 0)
                    {
                        return find;
                    }
                }
            }
            catch
            {

            }
            return 0;
        }

        /// <summary>
        /// Trả về tổng số sách tồn trong kho
        /// </summary>
        /// <returns></returns>
        public int InventoryBook()
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var sum = DB.Books.Sum(x => x.Book_Inventory);

                    return sum;
                }
            }
            catch
            {

            }
            return 0;
        }


        /// <summary>
        /// Trả về Id của sách vừa thêm thành công
        /// </summary>
        /// <param name="Book"></param>
        /// <returns></returns>
        public int addNewBook(CBookTransaction Book)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    //Tạo mới sách
                    var bookdata = new Book
                    {
                        Book_Name = Book.Name,
                        Book_Author = Book.Author,
                        Book_Company = Book.Company.ID,
                        Book_Category = Book.Category.ID,
                        Book_SubCategory = Book.SubCategory.ID,
                        Book_Price = Book.Price * 1.3,
                        Book_Promotion = 0,
                        Book_Inventory = Book.Count,
                        Book_Image = Help.ImageToByte(Book.Image),
                        Book_Status = 1
                    };

                    //Thêm sách
                    DB.Books.Add(bookdata);

                    //Lưu thay đổi
                    DB.SaveChanges();

                    //Trả về ID sách vừa thêm
                    return bookdata.Book_ID;
                }

            }
            catch
            {

            }
            return 0;
        }

        /// <summary>
        /// Hàm trả về số lượng sách tồn trong kho của sách có ID
        /// </summary>
        /// <param name="BookID"></param>
        /// <returns></returns>
        public int InventoryOfBook(int BookID)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Books.Find(BookID);
                    if (find != null)
                    {
                        return find.Book_Inventory;
                    }
                }
            }
            catch
            {

            }
            return 0;
        }

        /// <summary>
        /// Trừ số lượng sách, trả về số lượng sách còn tồn trong kho
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="bookCount"></param>
        public int decreaseBook(int bookID,int bookCount)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Books.Find(bookID);
                    if (find != null)
                    {
                        find.Book_Inventory = find.Book_Inventory - bookCount;
                        DB.SaveChanges();
                        
                        return find.Book_Inventory;
                    }
                }
            }
            catch
            {

            }

            return 0;
        }

        /// <summary>
        /// Thêm vào số lượng sách
        /// </summary>
        /// <param name="BookID"></param>
        /// <param name="bookCount"></param>
        /// <returns></returns>
        public int increaseBook(int BookID,int bookCount)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Books.Find(BookID);
                    if (find != null)
                    {
                        find.Book_Inventory = find.Book_Inventory + bookCount;
                        DB.SaveChanges();

                        return find.Book_Inventory;
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
