using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["login"] != null)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string name = TextBoxUsrName.Text;
            string pass = TextBoxPasswd.Text;
            Admin user = new Admin();
            bool ok = user.CheckLogin(name, pass);
            if (ok)
            {
                HttpCookie mycookie = new HttpCookie("login");
                mycookie["login"] = name;
                mycookie.Expires = DateTime.Now.AddDays(1d);
                Response.Cookies.Add(mycookie);
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                ErrorLabel.Text = "This combination of username and password could not be found";
            }
        }
    }
}