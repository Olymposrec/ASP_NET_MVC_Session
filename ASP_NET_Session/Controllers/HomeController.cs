using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Session.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Homepage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Homepage(string text)
        {
            Session["deger"] = text;
            //Session.Add("deger", text);
            return RedirectToAction("Homepage2");
        }
        public ActionResult Homepage2()
        {
            if(Session["deger"]!=null)
                ViewBag.deger = Session["deger"].ToString();
            else
             ViewBag.deger = "Session verisi yoktur.";
            
            return View();
        }
        [HttpPost,ActionName("Homepage2")]
        public ActionResult Homepage2s()
        {
            return RedirectToAction("Homepage3");
        }
        public ActionResult Homepage3()
        {
            if (Session["deger"] != null)
                Session.Remove("deger");

            return RedirectToAction("Homepage2");
        }







    }
}