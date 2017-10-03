<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Buy.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 250px;
        }
        .auto-style3 {
            width: 500px;
        }
        .auto-style4 {
            width: 350px;
        }
        .auto-style5 {
            width: 100px;
        }
      
    </style>
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
           
                

           <br /><br />
                  </td>
            <td>
            
            <td class="auto-style5">
           <h4>Block:</h4>
          <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("blockID") %>' />
          <br /><br />
                </td>
                
            <td><hr width="1" size="120"></td>
            <td class="auto-style3">
          <h4>Description:</h4>
          <asp:Label ID="descriptionLabel" runat="server" Text='<%# Eval("description") %>' />
            <br /><br />
         </td>
                 <td><hr width="1" size="120"></td>
            <td class="auto-style4">
          <h4>Hectares for sale:</h4>
          <asp:Label ID="Label1" runat="server" Text='<%# Eval("RHectares") %>' />
               <br /> <br />  
                
                </td>
                <td><hr width="1" size="120"></td>
               <td class="auto-style4">
          <h4>Price:</h4>
          <asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
          Grouch per 10 hectares.
               <br /><br />
                </td>
                
                

            
            </tr>
           </table>
                <hr />

      </ItemTemplate>
         


    </asp:ListView>
     <br />
     <br />
    <p>
        <center>
        <asp:Label ID="Label2" runat="server" Text="Write the hectares you want to buy: " Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add to Cart" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Only numbers allowed!" ForeColor="Red" ValidationExpression="^\d+"></asp:RegularExpressionValidator>


            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>


        </center>
    </p>
</asp:Content>

