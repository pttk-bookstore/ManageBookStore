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
    }
}
