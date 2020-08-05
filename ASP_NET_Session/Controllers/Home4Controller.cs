using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Session.Controllers
{
    public class Home4Controller : Controller
    {
        // GET: Home4
        public ActionResult Index()
        {
            HttpCookie cookie = new HttpCookie("username", "melihakkose");
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Response.Cookies.Add(cookie);

            return View();
        }
        public ActionResult Index2()
        {
           if(HttpContext.Request.Cookies["username"]!=null)
            {
                ViewBag.Username = HttpContext.Request.Cookies["username"].Value;

            }
           else
            {
                ViewBag.Username = "Cookie yok!";
            }
            return View();
        }
        public ActionResult Index3()
        {
            if (HttpContext.Request.Cookies["username"] != null)
            {
                //HttpContext.Request.Cookies.Remove("username");
                HttpContext.Response.Cookies["username"].Expires = DateTime.Now.AddSeconds(2);

            }
            else
            {
                ViewBag.Username = "Cookie yok!";
            }
            
            return View();
        }
    }
}