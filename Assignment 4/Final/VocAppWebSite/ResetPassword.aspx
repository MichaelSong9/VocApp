<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table>
   <tr>
<td>
<asp:Label ID="lbUserName" runat="server" AssociatedControlID="UserName">Enter Username to reset password:</asp:Label></td>
<td><asp:TextBox ID="UserName" runat="server" Width="150px" ></asp:TextBox></td>
<td><asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="UserName" 
          ErrorMessage="User Name is required." ToolTip="User Name is required."></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td><asp:Label ID="lbPassword" runat="server" AssociatedControlID="Password">Enter New Password:</asp:Label></td>
 <td><asp:TextBox ID="Password" runat="server" TextMode="Password" Width="150px"></asp:TextBox></td>
 <td><asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
          ErrorMessage="Password is required." ToolTip="Password is required."></asp:RequiredFieldValidator>
</td>
</tr>
</table>
<p>
<asp:Button ID="btSubmit" runat="server" CommandName="Submit" Text="Set" 
        onclick="btSubmit_Click"/>
</p>

</asp:Content>

