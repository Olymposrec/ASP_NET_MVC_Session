using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Session.Controllers
{
    public class Home3Controller : Controller
    {
        // GET: Home3
        public ActionResult Index()
        {
            //HttpContext.Cache["deger"] = "İsim";
            //HttpContext.Cache.Remove("deger");
            //HttpContext.Cache.Add("ad", "Melih Akkose", null,System.Web.Caching.Cache.NoAbsoluteExpiration, new 
            //    TimeSpan(0, 0, 10),System.Web.Caching.CacheItemPriority.Normal, null);
            HttpContext.Cache.Add("ad", "Melih Akkose", null,  System.Web.Caching.Cache.NoAbsoluteExpiration,new TimeSpan(0,0,10),
                System.Web.Caching.CacheItemPriority.Normal, CacheItemExpired);
            return View();
        }
        private void CacheItemExpired(string key,object value, System.Web.Caching.CacheItemRemovedReason reason)
        {
            //Mail Atılabilir
            System.IO.File.WriteAllText(Server.MapPath("~/cache-expired-note.txt"),
                $"{key} cache item and { value.ToString()} cache item value are expired. Reason: {reason.ToString()}.");
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            HttpContext.Cache.Remove("ad");
            return View();
        }
    }
}