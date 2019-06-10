using BookStore.DAO;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BUS
{
    public class DiscountCodeBUS
    {
        DiscountCodeDAO DAO = new DiscountCodeDAO();

        /// <summary>
        /// Hàm trả về khuyến mãi tương ứng với mã, trả về -2 nếu mã không hợp lệ, trả về -1 nếu như mã đã hết hạn,-3 nếu như số lượng sách không đủ
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="BookCount"></param>
        /// <returns></returns>
        public float PromotionOfDiscountCode(string Code,int BookCount)
        {
            CDiscountCode codeInfo = DAO.DiscountCodeInfo(Code);

            if (codeInfo != null)
            {
                //Kiểm tra thời gian của mã khuyến mãi
                if(codeInfo.DateEnd>=DateTime.Now && codeInfo.DateStart <= DateTime.Now)
                {
                    if (BookCount < codeInfo.Type.MinCount)
                    {
                        return -3;
                    }
                    else
                    {
                        return codeInfo.Type.Promotion;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }
    }
}
