using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using _1410831003.Models;
using _1410831003.Models.Guestbooks;
using _1410831003.Services;

namespace _1410831003.ViewModels
{

    public class GuestbooksViewModel
    {
        // 搜尋欄位
        [DisplayName(" 搜尋：")]
        public string Search { get; set; }
        public List<Guestbooks> DataList { get; set; }
        // 分頁內容
        public ForPaging Paging { get; set; }
    }
}