using Microsoft.Ajax.Utilities;
using MontCrest_Task_ClietSide.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MontCrest_Task_ClietSide.Controllers
{
    public class DashBoardController : Controller
    {
        MontCrestEntities db;
        public DashBoardController()
        {
            db= new MontCrestEntities();
        }
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SIndex(string email)
        {
            StudentRegistration s=db.StudentRegistrations.FirstOrDefault(e=>e.Email==email);
            if (s.Role == "admin")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(s);
            }
        }
        public ActionResult Create()
        {
            ViewBag.msg = "";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student s,HttpPostedFileBase photo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (photo==null)
            {
                ViewBag.msg = "Please Select Photo";
                return View();
            }
            else
            {
                StudentRegistration sr=new StudentRegistration()
                {
                    Fname=s.Fname,
                    Lname=s.Lname,
                    Email=s.Email,
                    Password=s.Password,
                    Mobile=s.Mobile,
                    Address=s.Address,
                    Adharno=s.Adharno,
                    Role=s.Role
                };
                if (photo.ContentLength > 0)
                {
                    string imgname = s.Fname + Path.GetExtension(photo.FileName);
                    string imgpath = Server.MapPath("~/Profilephotos/" + imgname);
                    sr.Profile = imgname;
                    photo.SaveAs(imgpath);
                    db.StudentRegistrations.Add(sr);
                    db.SaveChanges();
                    return RedirectToAction("Index","Login");
                }
                return View();
            }
        }
        public ActionResult Logout()
        {
            return View();
        }
    }
}