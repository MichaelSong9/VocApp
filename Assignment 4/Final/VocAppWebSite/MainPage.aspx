<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="MainPage.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VocApp</title>
</head>
<body>
    <form id="form1" runat="server">
    <h1 style="text-align: center">VocApp</h1>
    <h3 style="text-align:right"><asp:Label runat="server" ID="Label1"></asp:Label></h3>
     <table>
     <tr>
     <h3 style="text-align: center">Complete View</h3>
     </tr>
            <tr>
                <td colspan="2">
                    <div>                    
                        <asp:GridView runat="server" ID="dgvCompleteGridView" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Spelling" DataSourceID="SqlDataSource" OnDataBound="dgvCompleteGridView_DataBound" OnSelectedIndexChanged="dgvCompleteGridView_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="Spelling" HeaderText="Spelling" ReadOnly="True" SortExpression="Spelling"/>
                                <asp:BoundField DataField="Meaning" HeaderText="Meaning" />
                                <asp:BoundField DataField="Example" HeaderText="Example" />
                                <asp:BoundField DataField="TimeCreated" HeaderText="TimeCreated" SortExpression="TimeCreated"/>
                                <asp:BoundField DataField="TimeUpdated" HeaderText="TimeUpdated" SortExpression="TimeUpdated" />
                            </Columns>
                            <SelectedRowStyle BackColor="#99FF99" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:WordsDBConnStr %>" SelectCommand="SELECT * FROM [all-word-table]"></asp:SqlDataSource>
                    </div>
                </td>
            </tr>
            
            <tr>
            <td>
            <table>
            <tr>
     <h3 style="text-align: center">Details View</h3>
     </tr>
            <tr>
            <td><asp:Label runat="server" ID="lbSpelling">Spelling</asp:Label></td>
            <td><asp:TextBox runat="server" ID="tbSpelling"></asp:TextBox></td>
            </tr>
            <tr>
            <td><asp:Label runat="server" ID="lbMeaning">Meaning</asp:Label></td>
            <td><asp:TextBox runat="server" ID="tbMeaning"></asp:TextBox></td>
            </tr>
            <tr>
            <td><asp:Label runat="server" ID="lbMSampleSentence">Sample Sentence</asp:Label></td>
            <td><asp:TextBox runat="server" ID="tbSampleSentence"></asp:TextBox></td>
            </tr>
            <tr>
            <td  style="text-align:center;">
            <asp:Button runat="server" ID="btSave" Text="Add Word" OnClick="btSave_Click"/>
            </td>
            <td  style="text-align:center;">
            <asp:Button runat="server" ID="btCancel" Text="Cancel" OnClick="btCancel_Click"/>
            </td>
            </tr>
            </table>
            </td>
            <td>
            <table>
            <tr>
            <td>
            <asp:Label ID="lbSearchTheWord" runat="server">Search</asp:Label></td>
            <td>
            <asp:TextBox runat="server" ID="tbSearchSpelling"></asp:TextBox>
            <asp:Button runat="server" ID="btSearch" OnClick="btSearch_Click" Text="Search"/></td>
            </tr>
            <tr>
            <td>
            <asp:Button runat="server" ID="btEdit" OnClick="btEdit_Click" Text="Edit&Save"/>
            </td>
            <td>
            <asp:Button runat="server" ID="btDeleteRow" OnClick="btDeleteRow_Click" Text="Delete Row"/>
            </td>
            </tr>
            </table>
            </td>
            </tr>
            </table>
    </form>
</body>
</html>
