using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace WebApplication13
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["message"]!=null)
            {
                Label1.Text = Request.QueryString["message"];
            }

            //read information from cookies
            HttpCookie cook = Request.Cookies["UInfo"];
            if (cook == null) 
                Label1.Text = "This is your first visit";
            else{
                string name = cook["uname"];
                int age = int.Parse(cook["age"]);
                DateTime visit = DateTime.Parse(cook["visit"]);
                TextBox1.Text = name;
                TextBox2.Text = age.ToString();
                Label1.Text = "Your last visit was on " + visit;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = TextBox1.Text;
                int age = int.Parse(TextBox2.Text);
                string url = $"WebForm2.aspx?name={name}&age={age}";
                Response.Redirect(url);
            }
            catch(Exception ee) { Label1.Text = ee.Message; }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpCookie cook = Request.Cookies["UInfo"];
            if (cook != null)
            {
                cook.Expires = DateTime.Now.AddDays(-7);
                Response.Cookies.Add(cook);
            }
        }
    }
}