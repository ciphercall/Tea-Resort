using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicMenu.WebSitePanel.Interface
{
    public class WebSiteInterface
    {
        public string CompanyId { get; set; }
        public string HeadName { get; set; }
        public string Title { get; set; }
        public string Descrition { get; set; }
        public string NewsId { get; set; }
        public string FileName { get; set; }
        public string UserPcInsUpd { get; set; }
        public Int64 UserIdInsUpd { get; set; }
        public DateTime InTimeInsUpd { get; set; }
        public string IpAddressInsUpd { get; set; }
        public string LotiLenInsUpd { get; set; }
        public string ImageId { get; set; }
        public int ImgID { get; set; }
        public string RoomId { get; set; }
        public string AlbamId { get; set; }
        public string AlbamNm { get; set; }
        public string sl { get; set; }
      


    }
    public class NewsFedd
    {
        public string HeadName { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Descrition { get; set; }
        public string NewsId { get; set; }
        public string FileName { get; set; }
    }
}