using BookStore.DAO;
using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BUS
{
    public class ReportBUS
    {
        ReportDAO DAO = new ReportDAO();

        /// <summary>
        /// Trả về báo cáo lợi nhuận trong tháng của cửa hàng
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public List<CReportMonth> MonthlyReport(int Year)
        {
            return DAO.MonthlyReport(Year);
        }

        /// <summary>
        /// Hàm trả về lợi nhuận theo ngày của các ngày trong tháng, năm
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        /// <returns></returns>
        public List<CReportDate> DailyReport(int Month, int Year)
        {
            return DAO.DailyReport(Month, Year);
        }

        /// <summary>
        /// Hàm trả về lợi nhuận từ ngày đến ngày
        /// </summary>
        /// <param name="DateStart"></param>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        public List<CReportDate> DailyReport(DateTime DateStart, DateTime DateEnd)
        {
            return DAO.DailyReport(DateStart, DateEnd);
        }

    }
}
