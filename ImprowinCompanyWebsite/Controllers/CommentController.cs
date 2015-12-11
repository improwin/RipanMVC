using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ImprowinCompanyWebsite.Controllers
{
    
    public class CommentController : Controller
    {
        ImprowinDBEntities1 db = new ImprowinDBEntities1();
        public ActionResult Index()
        {
            return View(db.TblComments.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.StatusValue = new SelectList(db.TblStatus, "StatusID", "StatusName");
            //List<object> myModle = new List<object>();
            //myModle.Add(TblComment);
            //myModle.Add(db.TblStatus.ToList());
            //return View(myModle);
            return View();
        }

        [HttpPost]
        public ActionResult Create(TblComment Comnt )
        {
            if (ModelState.IsValid)
            {
                //Comnt.ActiveCD = 1;
                db.TblComments.Add(Comnt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Comnt);
        }

        [HttpGet]
        public ActionResult Edit(int?id)
        {
            TblComment Comment = db.TblComments.Find(id);
            ViewBag.StatusValue = new SelectList(db.TblStatus, "StatusID", "StatusName");

            //if (id == null)
            //{
            //    new HttpStatusCodeResult(HttpStatusCo.ba)
            //}
            return View(Comment);

        }
        [HttpPost]
        public ActionResult Edit(TblComment Comnt )
        {
            if (ModelState.IsValid)
            {
                db.Entry(Comnt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Comnt);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TblComment Comment = db.TblComments.Find(id);
                Int32 activecd = Comment.ActiveCD;               
                ViewBag.StatusName = GetStatusName(Convert.ToInt16(id));                 
                return View(Comment);
            }
            

        }
        private string GetStatusName(int id)
        {
            TblComment Comment = db.TblComments.Find(id);
            Int32 activecd = Comment.ActiveCD;

           
                var StatusName = from m in db.TblStatus
                                 where m.StatusID == activecd
                                 select m.StatusName;                
                return StatusName.First().ToString();
                
           
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TblComment Comment = db.TblComments.Find(id);
            db.TblComments.Remove(Comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TblComment Comment = db.TblComments.Find(id);
                Int32 activecd = Comment.ActiveCD;
                ViewBag.StatusName = GetStatusName(Convert.ToInt16(id));
                return View(Comment);
            }
        }
    }


}