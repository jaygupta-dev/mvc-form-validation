using BusinessLayer.DataBase_Class;
using BusinessLayer.Validate_Form;
using ModelLayer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerSideFormValidation.Controllers
{
    public class HomeController : Controller
    {
        DBContext_Layer dbdata = new DBContext_Layer();
        DetailForm_Model userdetail = new DetailForm_Model();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DetailForm_Model userdetail)
        {
            try
            {
                //(List<string> errorArray,string fieldname, bool isFormValid) = FormValidation.ValidateForm(userdetail);
                (string message, string fieldname, bool isFormValid) = FormValidation.ValidateForm(userdetail);
                if(isFormValid == true)
                {
                    int result = dbdata.AddUserData(userdetail);
                    if(result > 0)
                    {
                        return Content("<script>alert('data saved successfully!!!');location.href='/Home/About';</script>");
                    }
                    else
                    {
                        return Content("<script>alert('please try again!!!');location.href='/Home/About';</script>");
                    }
                }
                else
                {
                    ViewBag.fieldname = fieldname;
                    ViewBag.errormsg = message;
                    return View("Index");
                }
            }
            catch(Exception ex)
            {
                return Content($"<script>alert('some error occurrred');console.log{ex};location.href='/Home/Index';</script>");
            }
        }

        public ActionResult About(int? id)
        {
            if (id.HasValue)
            {
                int result = dbdata.DeleteUserData(id);
                if (result > 0)
                {
                    return Content("<script>alert('deleted successfully');location.href='/Home/About';</script>");
                }
                else
                {
                    return Content("<script>alert('try again');location.href='/Home/About';</script>");
                }
            }
            DataTable dt = dbdata.DisplayAllData();
            return View(dt);
        }
        public ActionResult Contact(int? id)
        {
            if (id.HasValue)
            {
                DataTable dt = dbdata.SelectOneData(id);
                return View(dt.Rows[0]);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Contact(DetailForm_Model userdetail)
        {
            try
            {
                //(List<string> errorArray,string fieldname, bool isFormValid) = FormValidation.ValidateForm(userdetail);
                (string message, string fieldname, bool isFormValid) = FormValidation.ValidateForm(userdetail);
                if (isFormValid == true)
                {
                    int result = dbdata.UpdateUserData(userdetail);
                    if (result > 0)
                    {
                        return Content("<script>alert('data updated successfully!!!');location.href='/Home/About';</script>");
                    }
                    else
                    {
                        return Content("<script>alert('please try again!!!');location.href='/Home/Contact';</script>");
                    }
                }
                else
                {
                    ViewBag.fieldname = fieldname;
                    ViewBag.errormsg = message;
                    return View("Contact");
                }
            }
            catch (Exception ex)
            {
                return Content($"<script>alert('some error occurrred');console.log{ex};location.href='/Home/Contact';</script>");
            }
        }
    }
}