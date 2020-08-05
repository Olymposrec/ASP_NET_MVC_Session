using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ASP_NET_Session.Controllers
{
    public class Home2Controller : Controller
    {
        // GET: Home2
        public ActionResult Index()
        {

            HttpContext.Application["sayac"] = 1;
            //HttpContext.Application.Add("sayac", 1);

            return RedirectToAction("Index2");
        }
        public ActionResult Index2()
        {
            if (HttpContext.Application["sayac"] == null)
            {
               return RedirectToAction("Index");
            }
            else
            {
                ViewBag.sayac = HttpContext.Application["sayac"].ToString();
                return View();
            }
            
            
        }
        [HttpPost]
        public ActionResult Index2(string text="")
        {
            
                return RedirectToAction("Index3");
 
        }
        public ActionResult Index4(string text)
        {
            //HttpContext.Application.Clear();
            //HttpContext.Application.RemoveAll();

            if (HttpContext.Application["sayac"] != null)
                HttpContext.Application.Remove("sayac"); 
            return RedirectToAction("Index2");
            

            
        }
        public ActionResult Index3()
        {
            if(HttpContext.Application["sayac"]!=null)
            {
                int sayac = (int)HttpContext.Application["sayac"];
                sayac++;
                HttpContext.Application["sayac"] = sayac;
            }
            
            return RedirectToAction("Index2");
        }
    }
}