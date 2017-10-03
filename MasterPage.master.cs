using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if logged in print a welcome label
        if (Request.Cookies["login"] != null)
        {
            var s = Request.Cookies["login"].Value;
            string[] un = s.Split('=');
            var username = un[1];
            WelcomeLabel.Text = "   Welcome: " + username;
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie mycookie = new HttpCookie("login");
        mycookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(mycookie);
        Session.Clear();
        Session.Abandon();
        Response.Redirect("HomePage.aspx");
    }
}
