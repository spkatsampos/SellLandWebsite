using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["login"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        if (!this.IsPostBack)
        {
            this.BindRepeater();
        }//if








    }//pageload
    /// <summary>
    /// /////////////////////////////////////////////
    /// </summary>
    private void BindRepeater()
    {

        //string blockid = Request.QueryString["id"];
        string blockid = Session["blockid"].ToString();
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("select LandforSale.imageurl,  LandforSale.blockID, LandforSale.description, LandforSale.RHectares, Prices.price from LandforSale, Prices where LandforSale.category=Prices.category and LandforSale.RHectares>0  and LandforSale.blockID = '" + blockid + "'", con)) 
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtd = new DataTable();
                    sda.Fill(dtd);
                    this.ListView1.DataSource = dtd;
                    this.ListView1.DataBind();


                }//using
            }//using
        }//using
}//bind repeater
    /// <summary>




    protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {

}

    
    protected void Button2_Click(object sender, EventArgs e)
    {
       
        //make the session and response to cart
        string blockid = Session["blockid"].ToString();
        var RHectares = 0.0;
        string constr1 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con1 = new SqlConnection(constr1))
        {
            using (SqlCommand cmd1 = new SqlCommand("select LandforSale.RHectares from LandforSale where LandforSale.RHectares>=0  and LandforSale.blockID = '" + blockid + "'", con1))
            {
                con1.Open();
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        RHectares = (double)reader[0];
                        reader.Close();
                    }//if


                }//using
            }//using
        }//using
        string hect = TextBox1.Text;

        //request db about the remain hectares and if textbox > RHectares  or hectares>500--> error label 
        //------------------------------------------------------------------------------
        if (Int32.Parse(hect) > 500)
        { ErrorLabel.Text = "You can buy until 500 hectares!"; }
        else if (RHectares >= Int32.Parse(hect))
        {
            

        

                    CartItems ci = new CartItems { blockid = Session["blockid"].ToString(), hectares = Int32.Parse(hect) };
                     if (Session["cartlist"] == null)
                 {
                        List<CartItems> cartlist = new List<CartItems> { };
                        cartlist.Add(ci);
                        Session["cartlist"] = cartlist;
                            }
                        else
                         {
                            var products = (List<CartItems>)Session["cartlist"];
                               products.Add(ci);
                            }
       
        
        Response.Redirect("Cart.aspx");
            //////////////////
        }
        else
        {
            ErrorLabel.Text = "You can buy until : "+ RHectares +" hectares!";
        }

    }
}