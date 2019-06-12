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

        /// <summary>
        /// Hàm trả về danh sách code
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CDiscountCode> ListCode(bool isAll,int currentPage, int NumberPage)
        {
            return DAO.ListCode(isAll,currentPage, NumberPage);
        }

        /// <summary>
        /// Hàm trả về danh sách tất cả các loại khuyến mãi
        /// </summary>
        /// <returns></returns>
        public List<CDiscountType> ListCodeType()
        {
            return DAO.ListCodeType();
        }

        /// <summary>
        /// Cập nhật thông tin của mã code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int updateCode(CDiscountCode code)
        {
            return DAO.updateCode(code);
        }

        /// <summary>
        /// Xóa mã code theo ID
        /// </summary>
        /// <param name="CodeID"></param>
        /// <returns></returns>
        public int deleteCode(string CodeID)
        {
            return DAO.deleteCode(CodeID);
        }

        /// <summary>
        /// Khôi phục lại mã code
        /// </summary>
        /// <param name="CodeID"></param>
        /// <returns></returns>
        public int restoreCode(string CodeID)
        {
            return DAO.restoreCode(CodeID);
        }

        /// <summary>
        /// Hàm trả về mã khuyến mãi theo filterstring
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="isAll"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CDiscountCode> ListCode(string filterString, bool isAll, int currentPage, int NumberPage)
        {
            return DAO.ListCode(filterString, isAll, currentPage, NumberPage);
        }

        /// <summary>
        /// Hàm thêm mới mã thành công trả về 1 thất bại -1, 0 nếu đã tồn tại
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int addCode(CDiscountCode code)
        {
            bool result = DAO.isExistCode(code.Code);
            if (result == false)
            {
                return DAO.addCode(code);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Hàm trả về danh sách tất cả các loại theo trang
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CDiscountType> ListCodeType(int currentPage, int NumberPage)
        {
            return DAO.ListCodeType(currentPage,NumberPage);
        }

        /// <summary>
        /// Hàm trả về danh sách tất cả các loại theo tên có phân trang
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="currentPage"></param>
        /// <param name="NumberPage"></param>
        /// <returns></returns>
        public List<CDiscountType> ListCodeType(string filterString, int currentPage, int NumberPage)
        {
            return DAO.ListCodeType(filterString, currentPage, NumberPage);
        }

        /// <summary>
        /// Hàm xóa 1 loại trả về 1 nếu thành công, 0 nếu loại đang dùng, -1 nếu thất bại
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public int deleteType(int typeID)
        {
            int result = DAO.isTypeUsed(typeID);
            if (result == 1)
            {
                return 0;
            }
            else
            {
                return DAO.deleteType(typeID);
            }
        }

        /// <summary>
        /// Hàm thêm mới một loại mới thành công trả về 1, loại đã tồn tại trả về 0, thất bại trả về -1
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int addType(CDiscountType type)
        {
            int result = DAO.idOfType(type.Name);
            if(result != -1)
            {
                return 0;
            }
            else
            {
                return DAO.addType(type);
            }
        }

        /// <summary>
        /// Hàm cập nhật thông tin mới cho loại thành công trả về 1, thất bại -1, 0 nếu trùng thông tin với loại khác
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int updateType(CDiscountType type)
        {
            int result = DAO.idOfType(type.Name);
            if(result!=-1 && result != type.ID)
            {
                return 0;
            }
            else
            {
                return DAO.updateType(type);
            }
        }
    }
}
