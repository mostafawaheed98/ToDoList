using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
using Microsoft.AspNet.Identity;


namespace ToDoList.Controllers
{
    public class UserTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserTasks
        public ActionResult Index()
        {
            string ThisUserId = User.Identity.GetUserId();
            if (ThisUserId != null)
            {
                ApplicationUser ThisUser = db.Users.FirstOrDefault(x => x.Id == ThisUserId);
                return View(db.Tasks.ToList().OrderBy( x => x.Priority ).Where( x=>x.User == ThisUser));
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
            
        }

        // GET: UserTasks/Details/5
        public ActionResult Details(int? id)
        {
            string ThisUserId = User.Identity.GetUserId();
            if (ThisUserId != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                UserTask userTask = db.Tasks.Find(id);
                if (userTask == null)
                {
                    return HttpNotFound();
                }
                return View(userTask);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: UserTasks/Create
        public ActionResult Create()
        {
            string ThisUserId = User.Identity.GetUserId();
            if (ThisUserId != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: UserTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,DueData,Status,Priority,Attachment")] UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                string ThisUserId = User.Identity.GetUserId();
                ApplicationUser ThisUser = db.Users.FirstOrDefault(x => x.Id == ThisUserId);
                userTask.User = ThisUser;
                db.Tasks.Add(userTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userTask);
        }

        // GET: UserTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            string ThisUserId = User.Identity.GetUserId();
            if (ThisUserId != null)
            {
                UserTask userTask = db.Tasks.Find(id);
                ApplicationUser ThisUser = db.Users.FirstOrDefault(x => x.Id == ThisUserId);
                if (id == null || userTask.User != ThisUser)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (userTask == null)
                {
                    return HttpNotFound();
                }
                return View(userTask);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: UserTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,DueData,Status,Priority")] UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTask);
        }

        // GET: UserTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            string ThisUserId = User.Identity.GetUserId();
            if (ThisUserId != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                UserTask userTask = db.Tasks.Find(id);
                if (userTask == null)
                {
                    return HttpNotFound();
                }
                return View(userTask);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: UserTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTask userTask = db.Tasks.Find(id);
            db.Tasks.Remove(userTask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
