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
/// <summary>
/// Summary description for Admin
/// </summary>
public class Admin
{
    protected DbConnection dbconn = null;
    public Admin()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool CheckLogin(String uname, String pass)
    {
        bool ok = false;
        dbconn = new DbConnection();
        SqlConnection conn = dbconn.OpenConnection();
        String sql = "SELECT username, password from Users where username = @name AND password = @pass";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@name", uname);
        cmd.Parameters.AddWithValue("@pass", Security.HashSHA1(pass));
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
            ok = true;
        return ok;
    }
}