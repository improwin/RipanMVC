using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using ImprowinCompanyWebsite.Models;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Collections;

namespace ImprowinCompanyWebsite.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contact()
        {
            if (Request.HttpMethod == "POST")
            {
                Hashtable hs = new Hashtable();
                foreach (string item in Request.Form)
                {
                    hs.Add(item, Request.Form[item]);
                }


                StringBuilder strMailBody = new StringBuilder();
                strMailBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
                strMailBody.Append("<head>");
                strMailBody.Append("</head>");
                strMailBody.Append("<body>");

                #region MailBody
                strMailBody.Append("<div><div><label><b>Name :</b></label>");
                strMailBody.Append(hs["name"].ToString());
                strMailBody.Append("</div><div><label><b>Email:</b></label>");
                strMailBody.Append(hs["email"].ToString());
                strMailBody.Append("</div><div><label><b>Phone :</b></label>");
                strMailBody.Append(hs["ph"].ToString());
                strMailBody.Append("</div><div><label><b>Company Name :</b></label>");
                strMailBody.Append(hs["company"].ToString());
                strMailBody.Append("</div><div><label><b>Subject:</b></label>");
                strMailBody.Append(hs["subject"].ToString());
                strMailBody.Append("</div><div><label><b>Message:</b></label>");
                strMailBody.Append(hs["msg"].ToString());
                strMailBody.Append("</div></div>");
                strMailBody.Append("</body>");
                strMailBody.Append("</html>");

                EmailHandler _emailHanlder = new EmailHandler();
                _emailHanlder._subject = hs["subject"].ToString();
                _emailHanlder._sender = "info@improwinsolutions.com";
                _emailHanlder._displayName = "Improwin Sender";
                _emailHanlder._mailbody = strMailBody;
                _emailHanlder._recipients = new string[] { "info@improwinsolutions.com" };


                if (_emailHanlder.Send() == true)
                { return this.Json(new { msg = "success" }); }
                else { return this.Json(new { msg = "failure" }); }

                #endregion MailBody


                //Main Table End

            }
            else
            { return View(); }


        }


        public ActionResult About1()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}