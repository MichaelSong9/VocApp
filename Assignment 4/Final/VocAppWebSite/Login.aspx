<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Login
    </h2>
<table>
<tr>
<td>
<asp:Label ID="lbUserName" runat="server" AssociatedControlID="UserName">Username:</asp:Label></td>
<td><asp:TextBox ID="UserName" runat="server" Width="150px" ></asp:TextBox></td>
<td><asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="UserName" 
          ErrorMessage="User Name is required." ToolTip="User Name is required."></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td><asp:Label ID="lbPassword" runat="server" AssociatedControlID="Password">Password:</asp:Label></td>
 <td><asp:TextBox ID="Password" runat="server" TextMode="Password" Width="150px"></asp:TextBox></td>
 <td><asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
          ErrorMessage="Password is required." ToolTip="Password is required." ></asp:RequiredFieldValidator></td>
</tr>
</table>
<p>
<asp:Button ID="btLogin" runat="server" CommandName="Login" Text="Login" 
        onclick="btLogin_Click" />
</p>
<p>
<asp:HyperLink ID="hlregister" runat="server" NavigateUrl="Register.aspx">Not Registered? Create an account</asp:HyperLink>
</p>
<p>
<asp:HyperLink ID="hlResetPassword" runat="server" NavigateUrl="ResetPassword.aspx">Reset Password</asp:HyperLink>
</p>
    <asp:Label ID="lblError" runat="server" Text="Label" Visible="false"></asp:Label>
    
</asp:Content>

