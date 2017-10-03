<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .auto-style1 {
            width: 100%;
        }
        .auto-style17 {
            width: 99px;
            height: 48px;
            text-align: right;
        }
        .auto-style18 {
            height: 48px;
            width: 60px;
        }
        .auto-style19 {
            width: 295px;
            height: 48px;
        }
        .auto-style7 {
            width: 99px;
            text-align: right;
        }
        .auto-style20 {
            width: 60px;
        }
        .auto-style12 {
            width: 295px;
        }
        .auto-style9 {
            width: 99px;
            height: 26px;
            text-align: right;
        }
        .auto-style15 {
            width: 60px;
            height: 26px;
        }
        .auto-style13 {
            height: 26px;
            width: 295px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
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

           

            </tr>
           </table>
      </ItemTemplate>
         


    </asp:ListView>
        </tr>
    </table>
     <hr />
    <table class="auto-style1">
        <tr>
            <td class="auto-style17">

            <asp:Label ID="Label4" runat="server" Text="Total Price: "></asp:Label>

            </td>
            <td class="auto-style18">

            <asp:Label ID="Totalprice" runat="server" ForeColor="#0033CC" Font-Bold="True"></asp:Label>

                <asp:Label ID="Label8" runat="server" Text="Grouch"></asp:Label>
            </td>
            <td class="auto-style19">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style17">
                <asp:Label ID="Label5" runat="server" Text="Card Number:"></asp:Label>
            </td>
            <td class="auto-style18">
                <asp:TextBox ID="TextBox1" runat="server" Width="184px"></asp:TextBox>
            </td>
            <td class="auto-style19">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="You should give your card number" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Not correct form of Card Number" ForeColor="Red" ValidationExpression="^\d{16}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="Label6" runat="server" Text="CVC:"></asp:Label>
            </td>
            <td class="auto-style20">
                <asp:TextBox ID="TextBox2" runat="server" Width="184px"></asp:TextBox>
            </td>
            <td class="auto-style12">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="You should give your card CVC" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Not correct format (should be 3 digits)" ForeColor="Red" ValidationExpression="^[0-9]{3,4}$" ControlToValidate="TextBox2"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Label ID="Label7" runat="server" Text="Expires End: "></asp:Label>
            </td>
            <td class="auto-style15">
                <asp:TextBox ID="TextBox3" runat="server" Width="184px"></asp:TextBox>
            </td>
            <td class="auto-style13">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="You should give your card  Expire Date" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Puta correct date (MM/YYYY)" ForeColor="Red" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](19|20)\d\d$" ControlToValidate="TextBox3"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style15">
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Buy" Width="76px" />
            </td>
            <td class="auto-style13">
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
     <hr />
    <br />
</asp:Content>

