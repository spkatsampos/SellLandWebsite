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

public partial class Checkout : System.Web.UI.Page
{
    //global variables
    DataTable dt;
    string username="";


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["login"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        //take the username from cookie
        var s = Request.Cookies["login"].Value;
        string[] un = s.Split('=');
        username = un[1];

        //define the DataTable;
        dt = new DataTable();

        DataColumn column = new DataColumn();
        column.DataType = Type.GetType("System.String");
        column.ColumnName = "blockid";
        dt.Columns.Add(column);

        column = new DataColumn();
        column.DataType = Type.GetType("System.Int32");
        column.ColumnName = "hectares";
        dt.Columns.Add(column);

        column = new DataColumn();
        column.DataType = Type.GetType("System.Int32");
        column.ColumnName = "price";
        dt.Columns.Add(column);


        dt = Session["dt"] as DataTable;
        this.ListView1.DataSource = dt;
        this.ListView1.DataBind();

       
        var price =Session["Totalprice"].ToString();
        Totalprice.Text = price;





    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        var RHectares = 0.0;



        foreach (DataRow dr in dt.Rows)
        {
                        

                    //write a row in SoldLand 


                    var dbConn = new DbConnection();
                    SqlConnection conn3 = dbConn.OpenConnection();
                    string constring3 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    string sql3 = "Insert into SoldLand(username,BlockID,Hectares) Values(@urnm,@blockid,@hectares)";
                    SqlCommand cmd = new SqlCommand(sql3, conn3);
                    cmd.Parameters.AddWithValue("@urnm", username);
                    cmd.Parameters.AddWithValue("@blockid", dr["blockid"].ToString());
                    cmd.Parameters.AddWithValue("@hectares", Convert.ToInt32(dr["hectares"]));

                    int recs = cmd.ExecuteNonQuery();


            //for each item into cart first check how hectares is the block ...total
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd1 = new SqlCommand("select  LandforSale.RHectares from LandforSale where  LandforSale.blockID = '" + dr["blockid"].ToString() + "'", con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            RHectares = (double)reader[0];
                            reader.Close();
                        }//if
                    }//using
                    con.Close();
                }//using
            }//using


            //change the hectares -->RHectares into LandforSale
            var rhect = RHectares - (Convert.ToInt32(dr["hectares"]));//Hectares in db minus what the customer bought
                    string constr4 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    using (SqlConnection conn4 = new SqlConnection(constr4))
                    {
                                                
                          conn4.Open();
                        using (SqlCommand cmd4 = new SqlCommand("update LandforSale set RHectares = @rhect where LandforSale.blockID = '" + dr["blockid"].ToString() + "'", conn4))
                        {                            
                            cmd4.Parameters.Add("@rhect", SqlDbType.Float).Value = rhect;
                            int rows4 = cmd4.ExecuteNonQuery();

                            //rows number of record got updated
                        }
                conn4.Close();
                    }
            rhect = 0;

              





            }//for each
        
           
            Session.Clear();
            Session.Abandon();
            dt.Clear();
            Response.Redirect("Confirmation.aspx");
        }













    
    protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}