<%@ Page Language="C#" Async="true" AsyncTimeout="8" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Atlantis.TestPage.DomainSearch._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Atlantis Framework - Domain Search</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Literal ID="CallTimesLiteral" runat="server" />
        <br />
        
        <br />
        <asp:TextBox ID="DomainSearchTextBox" runat="server" Height="16px" Width="800px">test.com google.com test01.com test02.com</asp:TextBox>
        <br />
        
        <br />
        <asp:Button ID="DomainSearchButton" runat="server" Height="22px" Text="Search" Width="194px" OnClick="DomainSearchButton_Click" />
        <br />
        
        <br />
        <asp:Label ID="DomainCheckLabel" runat="server" Text="Domains Registry Check and Backorder Status" Font-Bold="true" />
        <br />
        
        <br />
        <asp:Table ID="DomainCheckTable" runat="server" GridLines="Both">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Domain</asp:TableHeaderCell>
                <asp:TableHeaderCell>Available</asp:TableHeaderCell>
                <asp:TableHeaderCell>Available Result</asp:TableHeaderCell>
                <asp:TableHeaderCell>Valid Syntax</asp:TableHeaderCell>
                <asp:TableHeaderCell>Syntax Result</asp:TableHeaderCell>
                <asp:TableHeaderCell>Syntax Description</asp:TableHeaderCell>
                <asp:TableHeaderCell>Backorderable</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br />
        
        <br />
        <asp:Label ID="BuyDomainsLabel" runat="server" Text="Buy Domains" Font-Bold="true" />
        <br />
        
        <br />
        <asp:Table ID="BuyDomainsTable" runat="server" GridLines="Both" >
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Domain</asp:TableHeaderCell>
                <asp:TableHeaderCell>Price</asp:TableHeaderCell>
                <asp:TableHeaderCell>IsFastTransfer</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br />
        
        <br />
        <asp:Label ID="DomainsBotLabel" runat="server" Text="Domains Bot" Font-Bold="true" />
        <br />
        Total results:
        <asp:Label ID="lbDomainBotTotal" runat="server" Text="Label"></asp:Label>
        <br />
        
        <br />
        <asp:Table ID="DomainsBotTable" runat="server" GridLines="Both" >
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Domain</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br />
        
        <br />
        <asp:Label ID="FabDomainsLabel" runat="server" Text="Fabulous Domains" Font-Bold="true" />
        <br />
        
        <br />
        <asp:Table ID="FabDomainsTable" runat="server" GridLines="Both" >
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Domain</asp:TableHeaderCell>
                <asp:TableHeaderCell>OwnerType</asp:TableHeaderCell>
                <asp:TableHeaderCell>Price</asp:TableHeaderCell>
                <asp:TableHeaderCell>WaterlinePrice</asp:TableHeaderCell>
                <asp:TableHeaderCell>Commission</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br />
        
        <br />
        <asp:Literal ID="DomainCheckLiteral" runat="server" />
        <br />
        
        <br />
        <asp:Literal ID="BackorderLiteral" runat="server" />
        <br />
        
        <br />
        <asp:Literal ID="BuyDomainsLiteral" runat="server" />
        <br />
        
        <br />
        <asp:Literal ID="DomainsBotLiteral" runat="server" />
        <br />
        
        <br />
        <asp:Literal ID="FabDomainsLiteral" runat="server" />
        <br />
        
    </div>
    </form>
</body>
</html>
