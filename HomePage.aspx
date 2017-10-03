<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 400px;
        }
        .auto-style3 {
            width: 300px;
        }
                
        .auto-style4 {
            width: 300px;
        }
         .auto-style5 {
            width: 100px;
            }
    </style>

            <br />

    <asp:ListView ID="ListView1" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
        <LayoutTemplate>
        <ul>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />    
        </ul>                
    </LayoutTemplate>
        
        <ItemTemplate>
            <table class="auto-style1">
        <tr>
              <td class="auto-style4">
                              
            <img src='<%#Eval("imageurl")%>' alt='<%#Eval("blockID")%>' Height="200px"  Width="300px"  />
           
                </td>

           <td class="auto-style2">
           Block:
          <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("blockID") %>' />
          <br /><br />
         <b>Description:</b> 
          <asp:Label ID="descriptionLabel" runat="server" Text='<%# Eval("description") %>' />
            <br /><br />
          </td>
               
                <td class="auto-style3">
          <b>Hectares for sale:</b>
          <asp:Label ID="Label1" runat="server" Text='<%# Eval("RHectares") %>' />
               <br /> <br />  </td>
          <td class="auto-style3">          
          <b>Price:</b>
          <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
          Grouch (per 10 hectares)
               <br /><br />
                </td>

            <td class="auto-style5">
            
            
                 
                <asp:Button CommandName="Add" CommandArgument='<%#Eval("blockID")%>' OnClick="ButtonTest_Click" ID="ButtonTest" runat="server"  Text="Add to Cart" />
               
                 
            <br />
            </td>

            </tr>
                <hr />
           </table>
      </ItemTemplate>
         


    </asp:ListView>
     <br />
    </asp:Content>

