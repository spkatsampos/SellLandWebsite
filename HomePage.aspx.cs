using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class HomePage : System.Web.UI.Page
{
    private object rptItems;

    protected void Page_Load(object sender, EventArgs e)
    {



        if (!this.IsPostBack)
        {
            this.BindRepeater();
        }

        
        

    }
   
    /// <summary>
    /// /////////////////////////////////////////////
    /// </summary>
    private void BindRepeater()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("select LandforSale.imageurl,  LandforSale.blockID, LandforSale.description, LandforSale.RHectares, Prices.price from LandforSale, Prices where LandforSale.category=Prices.category and LandforSale.RHectares>0", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.ListView1.DataSource = dt;
                    this.ListView1.DataBind();
                    

                }
            }
        }
    }
    /// <summary>
    /// ////////////////
    /// </summary>

    protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    /////////////



  

    protected void ButtonTest_Click(object sender, EventArgs e)
    {
        string argument = ((Button)sender).CommandArgument;
        Session["blockid"] = argument;
        Response.Redirect("Buy.aspx");

    }
}




