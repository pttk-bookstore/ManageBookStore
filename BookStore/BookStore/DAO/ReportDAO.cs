using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAO
{
    public class ReportDAO
    {
        /// <summary>
        /// Trả về báo cáo lợi nhuận theo tháng của cửa hàng
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public List<CReportMonth> MonthlyReport(int Year)
        {
            List<CReportMonth> List = new List<CReportMonth>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    for (int Month = 1; Month <= 12; Month++)
                    {
                        //Lấy ra tổng số sách nhập trong tháng
                        int CountBookInput = DB.WareHouse_Detail.Where(x => SqlFunctions.DatePart("year", x.WareHouse.WareHouse_Date) == Year &&
                        SqlFunctions.DatePart("month", x.WareHouse.WareHouse_Date) == Month).Select(x => x.Book_Count).DefaultIfEmpty(0).Sum();

                        //Lấy ra tổng số tiền nhập sách trong tháng
                        float TotalMoneyInput = (float)DB.WareHouse_Detail.Where(x => SqlFunctions.DatePart("year", x.WareHouse.WareHouse_Date) == Year &&
                        SqlFunctions.DatePart("month", x.WareHouse.WareHouse_Date) == Month).Select(x => x.Book_Count * x.Book_Price).DefaultIfEmpty(0).Sum();

                        //Lấy ra tổng tiền bán sách trong tháng
                        float TotalMoney = (float)DB.Bills.Where(x => SqlFunctions.DatePart("year", x.Bill_Date) == Year &&
                        SqlFunctions.DatePart("month", x.Bill_Date) == Month).Select(x => x.Total_Money).DefaultIfEmpty(0).Sum();

                        //Lấy ra tổng số sách bán được trong tháng
                        int CountBook = DB.Bill_Detail.Where(x => SqlFunctions.DatePart("year", x.Bill.Bill_Date) == Year &&
                        SqlFunctions.DatePart("month", x.Bill.Bill_Date) == Month).Select(x => x.Book_Count).DefaultIfEmpty(0).Sum();

                        //Lấy ra tổng tiền lương trả cho nhân viên trong tháng
                        float SumSalary = (float)DB.Page_Wage.Where(x => SqlFunctions.DatePart("year", x.Date) == Year &&
                          SqlFunctions.DatePart("month", x.Date) == Month).Select(x => x.Salary).DefaultIfEmpty(0).Sum();

                        //Tính toán lợi nhuận bằng tiền bán sách trừ cho tiền nhập sách với tiền lương trả cho nhân viên trong tháng đó
                        float Profit = TotalMoney - TotalMoneyInput - SumSalary;

                        //Tạo mới CReport
                        CReportMonth Report = new CReportMonth
                        {
                            Month = Month,
                            ToltalBookIn = CountBookInput,
                            ToltalMoneyBooksIn = TotalMoneyInput,
                            ToltalBooksSold = CountBook,
                            ToltalMoneyBooksSell = TotalMoney,
                            ToltalSalary = SumSalary,
                            TotalProfit = Profit
                        };

                        //Thêm vào List
                        List.Add(Report);
                    }
                }
            }
            catch
            {

            }
            return List;
        }

        /// <summary>
        /// Hàm trả về lợi nhuận theo ngày trong tháng và năm
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        /// <returns></returns>
        public List<CReportDate> DailyReport(int Month, int Year)
        {
            List<CReportDate> List = new List<CReportDate>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    //Lấy ra list date trong danh sách hóa đơn (lấy ra những ngày khác nhau không lấy ra giờ vì trong một ngày có thể có nhiều hóa đơn)
                    //Lấy ra những tháng và năm như điều kiện nhập vào
                    //https://stackoverflow.com/questions/30588033/get-date-part-only-from-datetime-value-using-entity-framework

                    var ListDate = DB.Bills.Where(x => SqlFunctions.DatePart("year", x.Bill_Date) == Year
                    && SqlFunctions.DatePart("month", x.Bill_Date) == Month).Select(x => DbFunctions.TruncateTime(x.Bill_Date)).Distinct();

                    if (ListDate.Count() > 0)
                    {
                        foreach (var date in ListDate)
                        {
                            //Tạo mới 1 Report
                            CReportDate Report = new CReportDate();

                            //Lấy ra danh sách thông tin hóa đơn theo ngày (như là groupby)
                            var dataBillInfo = DB.Bill_Detail.Where(x => DbFunctions.TruncateTime(x.Bill.Bill_Date) == DbFunctions.TruncateTime(date));

                            //Lấy ra tổng số sách bán trong ngày
                            Report.ToltalBooksSold = dataBillInfo.Sum(x => x.Book_Count);

                            //Lấy ra tổng tiền thu được trong ngày
                            float ToltalMoney = (float)DB.Bills.Where(x => DbFunctions.TruncateTime(x.Bill_Date) == DbFunctions.TruncateTime(date)).Sum(x => x.Total_Money);
                            Report.ToltalMoneyBookSell = ToltalMoney;

                            Report.Date = (DateTime)date;

                            float SumInMonney = (float)DB.Bill_Detail.Where(x => DbFunctions.TruncateTime(x.Bill.Bill_Date) == DbFunctions.TruncateTime(date))
                                .Sum(x => x.Book_InPrice * x.Book_Count);

                            Report.ToltalMoneyBookIn = SumInMonney;

                            //Lấy ra tổng khách hàng trong ngày
                            int SumCustomer = DB.Bills.Where(x => DbFunctions.TruncateTime(x.Bill_Date) == DbFunctions.TruncateTime(date)).GroupBy(x => x.Customer_ID).Count();
                            Report.TotalCustomers = SumCustomer;

                            //Lợi nhuận
                            Report.TotalProfit = ToltalMoney - SumInMonney;

                            List.Add(Report);
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
        /// Hàm trả về  lợi nhuận theo ngày từ ngày đến ngày
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="Year"></param>
        /// <param name="MinDate"></param>
        /// <param name="MaxDate"></param>
        /// <returns></returns>
        public List<CReportDate> DailyReport(DateTime DateStart, DateTime DateEnd)
        {
            List<CReportDate> List = new List<CReportDate>();
            try
            {
                using (var DB = new MiniBookStoreEntities())
                {
                    //Lấy ra list date trong danh sách hóa đơn (lấy ra những ngày khác nhau không lấy ra giờ vì trong một ngày có thể có nhiều hóa đơn)
                    //Lấy ra những tháng và năm như điều kiện nhập vào
                    //https://stackoverflow.com/questions/30588033/get-date-part-only-from-datetime-value-using-entity-framework

                    var ListDate = DB.Bills.Where(x => DbFunctions.TruncateTime(x.Bill_Date) >= DbFunctions.TruncateTime(DateStart)
                    && DbFunctions.TruncateTime(x.Bill_Date) <= DbFunctions.TruncateTime(DateEnd))
                    .Select(x => DbFunctions.TruncateTime(x.Bill_Date)).Distinct();

                    if (ListDate.Count() > 0)
                    {
                        foreach (var date in ListDate)
                        {
                            //Tạo mới 1 Report
                            CReportDate Report = new CReportDate();

                            //Lấy ra danh sách thông tin hóa đơn theo ngày (như là groupby)
                            var dataBillInfo = DB.Bill_Detail.Where(x => DbFunctions.TruncateTime(x.Bill.Bill_Date) == DbFunctions.TruncateTime(date));

                            //Lấy ra tổng số sách bán trong ngày
                            Report.ToltalBooksSold = dataBillInfo.Sum(x => x.Book_Count);

                            //Lấy ra tổng tiền thu được trong ngày
                            float ToltalMoney = (float)DB.Bills.Where(x => DbFunctions.TruncateTime(x.Bill_Date) == DbFunctions.TruncateTime(date)).Sum(x => x.Total_Money);
                            Report.ToltalMoneyBookSell = ToltalMoney;

                            Report.Date = (DateTime)date;

                            float SumInMonney = (float)DB.Bill_Detail.Where(x => DbFunctions.TruncateTime(x.Bill.Bill_Date) == DbFunctions.TruncateTime(date))
                                .Sum(x => x.Book_InPrice * x.Book_Count);

                            Report.ToltalMoneyBookIn = SumInMonney;

                            //Lợi nhuận
                            Report.TotalProfit = ToltalMoney - SumInMonney;

                            //Lấy ra tổng khách hàng trong ngày
                            int SumCustomer = DB.Bills.Where(x => DbFunctions.TruncateTime(x.Bill_Date) == DbFunctions.TruncateTime(date)).GroupBy(x => x.Customer_ID).Count();
                            Report.TotalCustomers = SumCustomer;

                            List.Add(Report);
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
