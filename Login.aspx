<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
       <br />
     <h1>login page</h1>
        <br />
    
        <div>
          <fieldset>
            <legend>
              <asp:Label ID="Label2" runat="server" Text="Login" Font-Size="Medium"
                Font-Names="Arial"></asp:Label>
            </legend>
            <label for="TextBoxUsrName">UserName:</label><asp:TextBox ID="TextBoxUsrName" runat="server"
              CssClass="textbox"></asp:TextBox><br />
            <label for="TextBoxPasswd">Password:</label><asp:TextBox ID="TextBoxPasswd" runat="server"
              TextMode="Password" CssClass="textbox"></asp:TextBox>
              <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
              <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
              <br />
          </fieldset><br />
&nbsp;<p>
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
          </p>
            <a href="Registration.aspx">Register Now!</a></center>
        </div>
        
    </center>
</asp:Content>

