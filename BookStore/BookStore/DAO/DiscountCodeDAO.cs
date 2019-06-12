using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAO
{
    public class DiscountCodeDAO
    {
        /// <summary>
        /// Hàm trả về thông tin chi tiết của mã tương ứng nếu không tồn tại mã thì trả về null
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public CDiscountCode DiscountCodeInfo(string Code)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Discount_Code.Find(Code);
                    if (data != null)
                    {
                        CDiscountCode discountCode = new CDiscountCode
                        {
                            Code = data.Code_ID,
                            Name = data.Code_Name,
                            DateStart = data.Date_Start,
                            DateEnd = data.Date_End,
                            Type = new CDiscountType
                            {
                                ID = data.Discount_Type.DiscountType_ID,
                                Name = data.Discount_Type.DiscountType_Name,
                                MinCount = data.Discount_Type.Book_Count,
                                Promotion = (float)data.Discount_Type.DiscountType_Promotion
                            }
                        };

                        return discountCode;
                    }
                }
            }
            catch
            {

            }
            return null;
        }

        /// <summary>
        /// Hàm trả về danh sách mã khuyến mãi
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CDiscountCode> ListCode(bool isAll,int currentPage,int NumberPage)
        {
            List<CDiscountCode> List = new List<CDiscountCode>();
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Discount_Code.ToList().Skip((currentPage - 1) * NumberPage).Take(NumberPage);

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            CDiscountCode code = new CDiscountCode
                            {
                                Code = item.Code_ID,
                                Name = item.Code_Name,
                                DateEnd = item.Date_End,
                                DateStart = item.Date_Start,
                                Type = new CDiscountType
                                {
                                    ID = item.Discount_Type.DiscountType_ID,
                                    Name = item.Discount_Type.DiscountType_Name,
                                    MinCount = item.Discount_Type.Book_Count,
                                    Promotion = (float)item.Discount_Type.DiscountType_Promotion
                                },
                                IstrueValue = true,
                                Status = item.Code_Status
                            };
                            if (isAll == true)
                            {
                                List.Add(code);
                            }
                            else if(isAll == false && item.Code_Status == 1)
                            {
                                List.Add(code);
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
        /// Hàm trả về danh sách mã khuyến mãi lọc theo tên
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="isAll"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CDiscountCode> ListCode(string filterString,bool isAll, int currentPage, int NumberPage)
        {
            List<CDiscountCode> List = new List<CDiscountCode>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Discount_Code.Where(x=>x.Code_Name.ToLower().Contains(filterString.ToLower()))
                        .ToList().Skip((currentPage - 1) * NumberPage).Take(NumberPage);
                    
                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            CDiscountCode code = new CDiscountCode
                            {
                                Code = item.Code_ID,
                                Name = item.Code_Name,
                                DateEnd = item.Date_End,
                                DateStart = item.Date_Start,
                                Type = new CDiscountType
                                {
                                    ID = item.Discount_Type.DiscountType_ID,
                                    Name = item.Discount_Type.DiscountType_Name,
                                    MinCount = item.Discount_Type.Book_Count,
                                    Promotion = (float)item.Discount_Type.DiscountType_Promotion
                                },
                                IstrueValue = true,
                                Status = item.Code_Status
                            };
                            if (isAll == true)
                            {
                                List.Add(code);
                            }
                            else if (isAll == false && item.Code_Status == 1)
                            {
                                List.Add(code);
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
        /// Hàm trả về danh sách tất cả các loại khuyến mãi
        /// </summary>
        /// <returns></returns>
        public List<CDiscountType> ListCodeType()
        {
            List<CDiscountType> List = new List<CDiscountType>();
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Discount_Type;
                    if (data.Count() > 0)
                    {
                        foreach(var item in data)
                        {
                            CDiscountType type = new CDiscountType
                            {
                                ID = item.DiscountType_ID,
                                Name = item.DiscountType_Name,
                                MinCount = item.Book_Count,
                                Promotion = (float)item.DiscountType_Promotion
                            };

                            List.Add(type);
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
        /// Cập nhật thông tin của mã code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int updateCode(CDiscountCode code)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Discount_Code.Find(code.Code);
                    if (find != null)
                    {
                        find.Code_Name = code.Name;
                        find.Date_Start = code.DateStart;
                        find.Date_End = code.DateEnd;
                        find.Code_Type = code.Type.ID;

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
        /// Xóa mã khuyến mãi
        /// </summary>
        /// <param name="CodeID"></param>
        public int deleteCode(string CodeID)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Discount_Code.Find(CodeID);
                    if (find != null)
                    {
                        find.Code_Status = 0;
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
        /// Khôi phục lại mã code
        /// </summary>
        /// <param name="CodeID"></param>
        /// <returns></returns>
        public int restoreCode(string CodeID)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Discount_Code.Find(CodeID);
                    if (find != null)
                    {
                        find.Code_Status = 1;
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
        /// Hàm thêm mới mã
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int addCode(CDiscountCode code)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    Discount_Code newCode = new Discount_Code
                    {
                        Code_ID = code.Code,
                        Code_Name = code.Name,
                        Date_Start = code.DateStart,
                        Date_End = code.DateEnd,
                        Code_Status = 1,
                        Code_Type = code.Type.ID
                    };
                    DB.Discount_Code.Add(newCode);
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
        /// Kiểm tra mã đã tồn tại hay chưa
        /// </summary>
        /// <param name="CodeID"></param>
        /// <returns></returns>
        public bool isExistCode(string CodeID)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Discount_Code.Find(CodeID);
                    if (find != null)
                    {
                        return true;
                    }
                }
            }
            catch
            {

            }
            return false;
        }

        /// <summary>
        /// Hàm trả về danh sách loại khuyến mãi theo trang
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CDiscountType> ListCodeType(int currentPage, int NumberPage)
        {
            List<CDiscountType> List = new List<CDiscountType>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Discount_Type.ToList().Skip((currentPage - 1) * NumberPage).Take(NumberPage);

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            CDiscountType type = new CDiscountType
                            {
                                ID = item.DiscountType_ID,
                                Name = item.DiscountType_Name,
                                Promotion = (float)item.DiscountType_Promotion,
                                MinCount = item.Book_Count,
                                Count = item.Discount_Code.Count,
                                IsTrueValue = true
                            };

                            List.Add(type);
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
        /// Hàm trả về danh sách loại lọc theo tên và trang
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CDiscountType> ListCodeType(string filterString,int currentPage, int NumberPage)
        {
            List<CDiscountType> List = new List<CDiscountType>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var data = DB.Discount_Type.Where(x => x.DiscountType_Name.ToLower().Contains(filterString.ToLower()))
                        .ToList().Skip((currentPage - 1) * NumberPage).Take(NumberPage);

                    if (data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            CDiscountType type = new CDiscountType
                            {
                                ID = item.DiscountType_ID,
                                Name = item.DiscountType_Name,
                                Promotion = (float)item.DiscountType_Promotion,
                                MinCount = item.Book_Count,
                                Count = item.Discount_Code.Count,
                                IsTrueValue = true
                            };

                            List.Add(type);

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
        /// Cập nhật thông tin của loại mã
        /// </summary>
        /// <param name="cotypede"></param>
        /// <returns></returns>
        public int updateType(CDiscountType type)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Discount_Type.Find(type.ID);
                    if (find != null)
                    {
                        find.DiscountType_Name = type.Name;
                        find.DiscountType_Promotion = type.Promotion;
                        find.Book_Count = type.MinCount;

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
        /// Xóa loại
        /// </summary>
        /// <param name="typeID"></param>
        public int deleteType(int typeID)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Discount_Type.Find(typeID);
                    if (find != null)
                    {
                        DB.Discount_Type.Remove(find);
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
        /// Hàm kiểm tra loại có đang được xử dụng hay không trả về 1 nếu đang dùng -1 nếu không dùng
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public int isTypeUsed(int typeID)
        {
            try
            {
                using(var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Discount_Type.Find(typeID);
                    if (find != null)
                    {
                        if (find.Discount_Code.Count > 0)
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
        /// Hàm thêm mới loại
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int addType(CDiscountType type)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    Discount_Type newType = new Discount_Type
                    {
                        DiscountType_Name = type.Name,
                        DiscountType_Promotion = type.Promotion,
                        Book_Count = type.MinCount
                    };
                    DB.Discount_Type.Add(newType);
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
        /// Trả về ID của loại theo tên -1 nếu không tìm thất
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public int idOfType(string typeName)
        {
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    var find = DB.Discount_Type.Where(x => x.DiscountType_Name.ToLower().Equals(typeName.ToLower())).FirstOrDefault();
                    if (find != null)
                    {
                        return find.DiscountType_ID;
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
