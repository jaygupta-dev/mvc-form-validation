using ModelLayer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.Validate_Form
{
    public class FormValidation
    {
        //public static (List<string>,string, bool) ValidateForm(DetailForm_Model userdetail)
        public static (string,string, bool) ValidateForm(DetailForm_Model userdetail)
        {
            //List<string> errorArray = new List<string>();
            string message = "";
            string fieldname = "";

            //if(userdetail.name != null && userdetail.email != null && userdetail.mobile != null && userdetail.city != null)
            //{

            //}

            if (userdetail.name == "" || userdetail.name == null)
            {
                fieldname = "name";
                message = "Please enter name";
                //errorArray.Add("Please enter name");
                return (message, fieldname, false);
                //return (errorArray, fieldname, false);
            }
            else if(userdetail.name != null || userdetail.name != "")
            {
                string regex = @"^[a-zA-Z ]*$";
                Regex reg = new Regex(regex);
                if (!reg.IsMatch(userdetail.name) || userdetail.name.Length<3)
                {
                    fieldname = "name";
                    message = "Please enter correct name";
                    return (message, fieldname, false);
                }
              
            }
            if (userdetail.email == "" || userdetail.email == null)
            {
                fieldname = "email";
                message = "Please enter email";
                //errorArray.Add("Please enter email");
                return (message, fieldname, false);
                //return (errorArray, fieldname, false);
            }
            else if(userdetail.email != null || userdetail.email == "")
            {
                string regex = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
                Regex reg = new Regex(regex);
                fieldname = "email";
                message = "Please enter valid email";
            }
            if (userdetail.mobile == "" || userdetail.mobile == null)
            {
                fieldname = "mobile";
                message = "Please enter mobile/phone number";
                //errorArray.Add("Please enter mobile number");
                return (message,fieldname, false);
                //return (errorArray, fieldname, false);
            }
            else if(userdetail.mobile != null || userdetail.mobile != "")
            {
                string regex = "^[0-9]{10,12}$";
                Regex reg = new Regex(regex);
                fieldname = "mobile";
                message = "Please enter valid mobile/phone number";
            }
            if (userdetail.city == "" || userdetail.city == null)
            {
                fieldname = "city";
                message = "Please enter city name";
                //errorArray.Add("Please enter city name");
                return (message,fieldname, false);
                //return (errorArray, fieldname, false);
            }

            return (message, fieldname,true);
            //return (errorArray, fieldname,true);
        }
    }
}
