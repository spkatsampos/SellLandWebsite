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

public partial class Cart : System.Web.UI.Page
{

    DataTable dt;
    int sum = 0;
    string username;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["login"] == null)
        {
            Response.Redirect("Login.aspx");
        }


        //if login is ok then do the following 




        //////////////

        



        // variables in page load
        var unitprice=0.0;
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


        //open session list  ...
        var list = Session["cartlist"] as List<CartItems>;

            

        if (list != null)
        {
            foreach (CartItems cartitem in list)
            {
                string blockid= cartitem.blockid;
                int hectares = cartitem.hectares;
                




                //////////////////////////////////
                //ask the price for the specific block id and make a DataTable with blockid/hectares/price and present in listview
                //////////////////////////////////
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select  Prices.price from LandforSale, Prices where LandforSale.category = Prices.category and LandforSale.RHectares > 0 and LandforSale.blockID = '" + blockid + "'", con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                unitprice = (double)reader[0];
                                reader.Close();
                            }//if
                        }//using
                        
                        DataRow row= dt.NewRow();
                        row["blockid"] = blockid;
                        row["hectares"] = hectares;
                        row["price"] = hectares * (unitprice / 10.0);
                        dt.Rows.Add(row);
                                             
                            this.ListView1.DataSource = dt;
                            this.ListView1.DataBind();
                        }//using
                    }//using
                }//for each

            ///////////////////////////////////////////////////////////////


            //total price label ... add all prices
            foreach (DataRow dr in dt.Rows)
            {
                sum += Convert.ToInt32(dr["price"]);


            }

            Totalprice.Text = sum.ToString();
            Session["Totalprice"]= sum.ToString();

        }//if list not null





        //username from cookie here
       
        
        var s = Request.Cookies["login"].Value;
        string[] un= s.Split('=');
         username = un[1];
        
            ////////////////////////////////////////////////////////////////////////////////////////////////////
        //history gridview
        

        string constrhist = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection conhist = new SqlConnection(constrhist))
        {
            using (SqlCommand cmdconhist = new SqlCommand("select BlockID,  Hectares from SoldLand where username= '" + username + "'", conhist))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmdconhist))
                {
                    DataTable dthist = new DataTable();
                    sda.Fill(dthist);
                    this.GridView1.DataSource = dthist;
                    this.GridView1.DataBind();
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////






    }//page load




    protected void Button3_Click(object sender, EventArgs e)
    {
        var Hectares = 0.0;
        List<double> Histhectares = new List<double> { };
        var Histotalthectares = 0.0;
        var totalcarthectares = 0.0;

        foreach (DataRow dr in dt.Rows)
        {
            totalcarthectares += Convert.ToInt32(dr["hectares"]);
        }


        if (totalcarthectares < 20 || totalcarthectares > 500)
        {
            ErrorLabel.Text = "Not acceptable transaction, hectares out of order";

        }
        else
        {
            ///////read the total hectares for every block in the cart
            foreach (DataRow dr in dt.Rows)
            {
                //for each item into cart first check how hectares is the block ...total
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select  LandforSale.Hectares from LandforSale where  LandforSale.blockID = '" + dr["blockid"].ToString() + "'", con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                Hectares = (double)reader[0];
                                reader.Close();
                            }//if
                        }//using
                        con.Close();
                    }//using
                }//using


                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //for each item into cart first check how hectares the person have already buy
                string constr1 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con1 = new SqlConnection(constr1))
                {
                    using (SqlCommand cmd1 = new SqlCommand("select  SoldLand.Hectares from SoldLand where BlockID='" + dr["blockid"].ToString() + "'and username='" + username + "'", con1))
                    {
                        con1.Open();
                        using (SqlDataReader reader1 = cmd1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                Histhectares.Add((double)reader1[0]);
                            }
                        }//using
                        con1.Close();
                    }//using
                }//using


                //////////////////////////////////////////////////////////////////////////////


                //total hectares for each block from history - add all list element
                foreach (var d in Histhectares)
                {
                    Histotalthectares += d; //this variable has the total hectars for block(i) that has buy the person
                }

                // for each item (we are in each)... if hectares to buy >25% 

                if ((Convert.ToInt32(dr["hectares"]) + Histotalthectares) > (0.25 * (Hectares)))
                {
                    ErrorLabel.Text = "Not acceptable transaction, hectares in "+ dr["blockid"] + " out of order 25% of total Block";
                    
                }
                
                else
                {
                    Session["dt"] = dt; //put the Datatable in session 
                    Response.Redirect("Checkout.aspx");
                }
            }

        }//button3

    }




    protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        sum = 0;
        //dt.Clear();
        Response.Redirect("Cart.aspx");
    }

    protected void ButtonTest_Click_Edit(object sender, EventArgs e)
    {
        string argument = ((Button)sender).CommandArgument;

        var list = Session["cartlist"] as List<CartItems>;

        if (list != null)
        {
            
            list.RemoveAll(s => s.blockid ==argument);
            Session["cartlist"] = list;
            Session["blockid"] = argument;
            Response.Redirect("Buy.aspx");
        }
    }

    protected void ButtonTest_Click_Delete(object sender, EventArgs e)
    {

        string argument = ((Button)sender).CommandArgument;
        var list = Session["cartlist"] as List<CartItems>;

        if (list != null)
        {
            list.RemoveAll(s => s.blockid == argument);
            Session["cartlist"] = list;
            Response.Redirect(Request.RawUrl);
        }
    }








    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePage.aspx");
    }
}

   
    






