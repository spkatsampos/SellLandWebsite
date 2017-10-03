<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 119px;
        }
        .auto-style3 {
            width: 117px;
        }
        .auto-style4 {
            width: 45%;
        }
        .auto-style6 {
            color: #0033CC;
            font-weight: bold;
        }
        .auto-style7 {
            width: 204px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <hr />
    <table class="auto-style1">
        <tr>
            <asp:ListView ID="ListView1" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
        <LayoutTemplate>
        <ul>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />    
        </ul>                
    </LayoutTemplate>
        
        <ItemTemplate>
            <table class="auto-style1">
        <tr>
             <td>

           Block:
          <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("blockid") %>' />
          <br /><br />

            </td>
               <td>

           Hectares:
          <asp:Label ID="Label2" runat="server" Text='<%# Eval("hectares") %>' />
          <br /><br />

            </td>
            <td>       
          Price:
          <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
          Grouch.
               <br /><br />
                </td>
             </td>

            <td>
            
            
                 
                <asp:Button CommandName="Delete" CommandArgument='<%#Eval("blockID")%>' OnClick="ButtonTest_Click_Delete" ID="ButtonDel" runat="server"  Text="Delete" />
               
                 
            <br />
            </td>
            <td>
            
            
                 
                <asp:Button CommandName="Edit" CommandArgument='<%#Eval("blockID")%>' OnClick="ButtonTest_Click_Edit" ID="ButtonEdit" runat="server"  Text="Edit" />
               
                 
            <br />
            </td>
           

            </tr>
           </table>
            <hr />
      </ItemTemplate>
         


    </asp:ListView>
        </tr>
    </table>
   <center>
       <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Continue Shopping" Width="154px" />
&nbsp;&nbsp;&nbsp;
     <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Remove Cart" Width="154px" />
    </center>
    <br /><br />
    <br />
    <br />
    <p>


        


         </p>
    <table class="auto-style4">
        <tr>
            <td class="auto-style2">

            <asp:Label ID="Label4" runat="server" Text="Total Price: "></asp:Label>

            </td>
            <td class="auto-style7">

            <asp:Label ID="Totalprice" runat="server" ForeColor="#0033CC" Font-Bold="True"></asp:Label>

            &nbsp;<asp:Label ID="Label8" runat="server" Text="Grouch"></asp:Label>

            </td>
            <td class="auto-style3">

        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Buy" Width="112px" />
            </td>
            <td>
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    




    <p class="auto-style6">

            <asp:Label ID="LabelSoldLandtotal" runat="server" ForeColor="#0033CC" Font-Bold="True"></asp:Label>

            </p>
    <p>
         <hr />
       <h3>Your History</h3>
   <br />
        <asp:Label ID="Label3" runat="server" Text="You have bought: "></asp:Label>
   
   <br /><br />


        <asp:GridView ID="GridView1" runat="server"></asp:GridView>




        &nbsp;</p>
</asp:Content>

