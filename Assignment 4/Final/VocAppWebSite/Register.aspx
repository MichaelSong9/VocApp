<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>
   Create a New Customer</h2>
   <table>
   <tr>
<td>
<asp:Label ID="lbFirstname" runat="server" AssociatedControlID="FirstName">FirstName:</asp:Label></td>
<td><asp:TextBox ID="FirstName" runat="server" Width="150px" ></asp:TextBox></td>
<td><asp:RequiredFieldValidator ID="rfvFirstname" runat="server" ControlToValidate="FirstName" 
          ErrorMessage="FirstName is required." ToolTip="FirstName is required."></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td>
<asp:Label ID="lbLastname" runat="server" AssociatedControlID="LastName">LastName:</asp:Label></td>
<td><asp:TextBox ID="LastName" runat="server" Width="150px" ></asp:TextBox></td>
<td><asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="LastName" 
          ErrorMessage="LastName is required." ToolTip="LastName is required."></asp:RequiredFieldValidator></td>
</tr>
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
          ErrorMessage="Password is required." ToolTip="Password is required."></asp:RequiredFieldValidator></td>
</tr>
</table>
<p>
<asp:Button ID="btSubmit" runat="server" CommandName="Submit" Text="Submit" 
        onclick="btSubmit_Click"/>
</p>
</asp:Content>

