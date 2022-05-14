using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using _1410831003.Models;
namespace _1410831003.Services
{
    public class thumbNDBService
    {
        //建立與資料庫的連線字串
        private readonly static string cnstr =
        ConfigurationManager.ConnectionStrings["ASP.NET MVC"].ConnectionString;
        //建立與資料庫的連線
        private readonly SqlConnection conn = new SqlConnection(cnstr);
        // 取得陣列資料方法
        public List<thumbN> GetDataList()
        {
            List<thumbN> DataList = new List<thumbN>();
            //Sql 語法
            string sql = @" SELECT * FROM thumbN; "
            ;
            // 確保程式不會因執行錯誤而整個中斷
            try
            {
                // 開啟資料庫連線
                conn.Open();
                // 執行Sql 指令
                SqlCommand cmd = new SqlCommand
                (sql, conn);
                // 取得Sql 資料
                SqlDataReader dr = cmd.ExecuteReader();
                while
                (dr.Read()) // 獲得下一筆資料直到沒有資料
                {
                    thumbN Data = new thumbN();
                    Data.tid = Convert.ToInt32(dr["tid"]);
                    Data.img = dr["img"].ToString();
                    // 確定此筆資料不為空值
                    //因C# 是強型別語言，所以轉換時Datetime 型態不允許存取null
if (!dr["head"].Equals(DBNull.Value)){
                        Data.head = dr["head"].ToString();
                    }
                    if (!dr["info"].Equals(DBNull.Value)){
                        Data.info = dr["info"].ToString();
                    }
                    if (!dr
                    ["link"].Equals(DBNull.Value))
                    {
                        Data.link = dr
                        ["link"].ToString();
                    }
                    DataList.Add(Data);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString()); // 丟出錯誤
            }
            finally
            {
                conn.Close(); // 關閉資料庫連線
            }
            return DataList
            ;
        }
    }
}