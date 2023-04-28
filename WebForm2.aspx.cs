using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace WebApplication13
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["name"]==null ||
                Request.QueryString["age"]==null)
            {
                string message = "Error: Name or age are missing";
                Response.Redirect("WebForm1.aspx?message=" + message);
            }
            string name = Request.QueryString["name"];
            int age = int.Parse(Request.QueryString["age"]);

            Label1.Text = $"Your name is {name} and age is {age}";
            //write information to cookies
            HttpCookie myC = new HttpCookie("UInfo");
            myC["uname"] = name;
            myC["age"] = age.ToString();
            myC["visit"] = DateTime.Now.ToString();
            myC.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(myC);


        }
    }
}