using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["login"] != null)
        // {
        //    Response.Redirect(Request.UrlReferrer.ToString());
        // }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        ErrorLabelpwd.Text = "";
        ErrorLabelusername.Text = "";
        string username = TextBox1.Text;
        Boolean flag=true;

        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("select  username from Users where username = '" + username + "'", con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        flag = false;
                        ErrorLabelusername.Text = "This username used from another user!";
                    }//if

                    }//using

                con.Close();
            }//using
            
        }//using

        if (flag == true)
                    {

            string urnm = TextBox1.Text;
            string pwd = TextBox2.Text;
            string fname = TextBox3.Text;
            string lname = TextBox4.Text;
            string email = TextBox5.Text;
            string addr = TextBox6.Text;
            string postc = TextBox7.Text;
            //"Insert into Users(username,password,FirstName,LastName,email,Address,PostCode) Values(@urnm,@pwd,@fname,@lname,@email,@addr, @postc)"
            string pwd2 = TextBoxpwd.Text;

            if (pwd == pwd2) { 

            var dbConn = new DbConnection();
            SqlConnection conn = dbConn.OpenConnection();
            string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string sql = "Insert into Users(username,password,FirstName,LastName,email,Address,PostCode) Values(@urnm,@pwd,@fname,@lname,@email,@addr, @postc)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@urnm", urnm);
            cmd.Parameters.AddWithValue("@pwd", Security.HashSHA1(pwd));
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@addr", addr);
            cmd.Parameters.AddWithValue("@postc", postc);
            int recs = cmd.ExecuteNonQuery();

            if (recs == 1) {
                    LabelRegOK.Text = "Your registration was sucessful";
                    Response.AddHeader("REFRESH", "3;HomePage.aspx");
                   
                }
            else { LabelRegOK.Text = "Your registration was not sucessful, try again"; }
               
            }
            else
            {
                ErrorLabelpwd.Text = "Passwords do not much!";
            }
        }
      
        
    }
    




    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox1.Text = String.Empty;
        TextBox2.Text = String.Empty;
        TextBox3.Text = String.Empty;
        TextBox4.Text = String.Empty;
        TextBox5.Text = String.Empty;
        TextBox6.Text = String.Empty;
        TextBox7.Text = String.Empty;
    }
}