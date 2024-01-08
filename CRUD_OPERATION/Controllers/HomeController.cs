using CRUD_OPERATION.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_OPERATION.Controllers
{
    public class HomeController : Controller
    {
        DatabaseFirstEFEntities db=new DatabaseFirstEFEntities();
        private int id;

        // GET: Home
        public ActionResult Index()
        {
            var data=db.Students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid==true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('NOT Inserted!!')</script>";
                }

            }
            
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row=db.Students.Where(model => model.Id==id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if(ModelState.IsValid==true)
            {
                db.Entry(s).State=EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdatedMessage"] = "<script>alert('Updated!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdatedMessage"] = "<script>alert('NOT Updated!!')</script>";
                }

            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var DeleteRow = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(DeleteRow);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DelectedMessage"] = "<script>alert('Delected!!')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DelectedMessage"] = "<script>alert('NOT Delected!!')</script>";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }




    }
}