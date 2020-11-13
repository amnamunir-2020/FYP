using EmarketingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmarketingApp.Controllers
{
    public class AdminController : Controller
    {
        dbmarketingEntities db = new dbmarketingEntities();

        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tbl_admin avm)
        {


            tbl_admin ad = db.tbl_admin.Where(x => x.ad_username == avm.ad_username && x.ad_password == avm.ad_password).SingleOrDefault();
            if (ad != null)
            {

                Session["ad_id"] = ad.ad_id.ToString();
                return RedirectToAction("Create");


            }
            else
            {
                ViewBag.error = "Invalid username or password ";
            }
            return View();
        
    }




        public ActionResult Create()
        {
            if (Session["ad_id"] == null)
            {
                return RedirectToAction("Login");


            }
            return View();
        }



    }
}