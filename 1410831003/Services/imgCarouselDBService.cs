using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using _1410831003.Models;


namespace _1410831003.Services
{
    public class imgCarouselDBService
    {
        //建立與資料庫的連線字串
        private readonly static string cnstr =
        ConfigurationManager.ConnectionStrings["ASP.NET MVC"].ConnectionString;
        //建立與資料庫的連線
        private readonly SqlConnection conn = new SqlConnection(cnstr);
        // 取得陣列資料方法
        public List<imgCarousel> GetDataList()
        {
            List<imgCarousel> DataList = new List<imgCarousel>();
            //Sql 語法
            string sql = @" SELECT * FROM ImgCarousel; ";
            // 確保程式不會因執行錯誤而整個中斷
            try
            {
                // 開啟資料庫連線
                conn.Open();
                // 執行Sql 指令
                SqlCommand cmd = new SqlCommand(sql, conn);
                // 取得Sql 資料
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) // 獲得下一筆資料直到沒有資料
                {
                    imgCarousel Data = new imgCarousel();
                    Data.pid = Convert.ToInt32(dr["pid"]);
                    Data.pfile = dr["pfile"].ToString();
                    // 確定此筆資料不為空值
                    // 因C# 是強型別語言，所以轉換時Datetime 型態不允許存取null
                    if (!dr["ptitle"].Equals(DBNull.Value))
                    {
                        Data.ptitle = dr["ptitle"].ToString();
                    }
                    if (!dr["pinfo"].Equals(DBNull.Value))
                    {
                        Data.pinfo = dr["pinfo"].ToString();
                    }
                    DataList.Add(Data);
                }
            }
            catch (Exception e)
            { // 丟出錯誤
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close(); // 關閉資料庫連線
            }
            return DataList;
        }
    }
}