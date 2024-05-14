using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ELEarningSystemMVC.Models;

namespace ELEarningSystemMVC.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Team()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Registrtaion()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CourseRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(TblFeedback tblFeedback)
        {
            using (ELearningEntities db = new ELearningEntities())
            {
                if (ModelState.IsValid)
                {
                    db.TblFeedbacks.Add(tblFeedback);
                    db.SaveChanges();
                    ViewBag["Message"] = "Feedback Send Sucessfully";

                    ModelState.Clear();
                }
            }
            return View(tblFeedback);
        }
        [HttpPost]
        public ActionResult Registration(TblUser tblUser)
        {
            using (ELearningEntities db = new ELearningEntities())
            {
                if (ModelState.IsValid)
                {
                    db.TblUsers.Add(tblUser);
                    db.SaveChanges();
                    ViewBag["Message"] = "Registration Sucessfully";

                    ModelState.Clear();
                }
            }
            return View(tblUser);
        }
        [HttpPost]
        public ActionResult CourseRegistration(BookingTbl bookingTbl)
        {
            using (ELearningEntities db = new ELearningEntities())
            {
                if (ModelState.IsValid)
                {
                    db.BookingTbls.Add(bookingTbl);
                    db.SaveChanges();
                    ViewBag["Message"] = "Subcription Sucessfully";

                    ModelState.Clear();
                }
            }
            return View(bookingTbl);
        }
        [HttpPost]
        public ActionResult Login(TblUser tblUser)
        {
            using (ELearningEntities db = new ELearningEntities())
            {
                if (ModelState.IsValid)
                {
                    var obj = db.TblUsers.Where(a => a.email.Equals(tblUser.email) && a.pass.Equals(tblUser.pass)).FirstOrDefault();
                    if (obj != null)
                    {
                        //Session["UserID"] = obj.UserId.ToString();
                        //Session["UserName"] = obj.email.ToString();
                        return RedirectToAction("Students/CourseRegistration");
                    }
                    ModelState.Clear();
                }
            }
            return View(tblUser);
        }
    }   
}

