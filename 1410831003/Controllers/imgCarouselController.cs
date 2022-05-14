using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1410831003.Models;
using _1410831003.Services;
using _1410831003.ViewModels;

namespace _1410831003.Controllers
{
    public class imgCarouselController : Controller
    {
        //宣告ImgCarousel資料表的Service物件
        private readonly imgCarouselDBService ImgCarouselService
        = new imgCarouselDBService();
        // GET: ImgCarousel
        public ActionResult Index()
        {
            //宣告一個新頁面模型
            imgCarouselViewModel Data = new imgCarouselViewModel();
            //從Service 中取得頁面所需陣列資料
            Data.DataList = ImgCarouselService.GetDataList();
            //將頁面資料傳入View 中
            return View(Data);
        }
        //宣告thumbN資料表的Service物件
        private readonly thumbNDBService thumbNService = new thumbNDBService();
        public ActionResult thumbN()
        {
            //宣告一個新頁面模型
            thumbNViewModel Data = new thumbNViewModel();
            //從Service 中取得頁面所需陣列資料
            Data.DataList = thumbNService.GetDataList();
            //將頁面資料傳入View 中
            return View(Data);
        }
    }
}