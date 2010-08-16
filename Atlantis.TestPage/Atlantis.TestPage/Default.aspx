<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Atlantis.TestPage._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Atlantis Framework</title>
    <link href="http://presentationcentral.dev.glbt1.gdg/atlantis/styles/pc.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <!-- Page Header/Page Footer -->
    <asp:Label ID="PageHeader" runat="server" Text="Page Header and Footer" 
                 Font-Bold="True" />
    <hr />
    <div>
        <br />
        <asp:Literal ID="PageHeaderLiteral" runat="server"></asp:Literal>
        <br />
        <asp:Literal ID="PageFooterLiteral" runat="server"></asp:Literal>
        <br />
    </div>
    
    <div>
    <!-- Errors -->
        
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Errors" Font-Bold="True" />
    <br />
    
    <br />
    <asp:Literal ID="ErrorLiteral" runat="server" Text="None" />
    <br />
    
    <!-- Get Shopper --> 
    
        UpdateItem<br />
        <br />
        <asp:Button ID="cmdUpdateItem" runat="server" onclick="cmdUpdateItem_Click" 
            Text="Update Item" />
    
    <br />
    <asp:Label ID="GetShopperLabel" runat="server" Text="Get Shopper" Font-Bold="True" />
    <br />
    
    <br />
    <asp:Label ID="GetShopperIDLabel" runat="server" Text="ShopperID: " />
    <asp:TextBox ID="GetShopperIDTextBox" runat="server" Text="839627" />    
    <br />

    <br />
    <asp:Button ID="GetShopperIDButton" runat="server" Text="Get Shopper" />
    <br />        
    
    <br />
    <asp:Literal ID="GetShopperLiteral" runat="server" />
    <br />
    
    <!-- Search Shoppers -->
    
    <br />
    <asp:Label ID="SearchShoppersLabel"  runat="server" Text="Search Shoppers" Font-Bold="True" />
    <br />
    
    <br />
    <asp:Label ID="SearchShoppersFirstNameLabel" runat="server" Text="FirstName: " />
    <asp:TextBox ID="SearchShoppersFirstNameTextBox" runat="server" />
    
    <asp:Label ID="SearchShoppersLastNameLabel" runat="server" Text="LastName: " />
    <asp:TextBox ID="SearchShoppersLastNameTextBox" runat="server" />
    <br />
    
    <br />
    <asp:Button ID="SearchShoppersButton" runat="server" Text="Search Shoppers" OnClick="SearchShoppersButton_Click" />
    <br />
    
    <br />
    <asp:DataGrid ID="SearchShoppersResultDG" runat="server" GridLines="Both" />
    
    <asp:Table ID="SearchShoppersResultTable" runat="server" GridLines="Both">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell Text="Email" />
            <asp:TableHeaderCell Text="ShopperID" />
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <asp:Literal ID="SearchShoppersResultLiteral" runat="server" />
    <br />
    
    <!-- Get Mini Cart -->
    
    <br />
    <asp:Label ID="GetMiniCartLabel" runat="server" Text="Get Mini Cart" Font-Bold="True" />
    <br />
    
    <br />
    <asp:Label ID="GetMiniCartShopperIDLabel" runat="server" Text="ShopperID: " />
    <asp:TextBox ID="GetMiniCartShopperIDTextBox" runat="server" Text="846908" />
    <br />
    
    <br />
    <asp:Button ID="GetMiniCartButton" runat="server" Text="Get Mini Cart" />
    <br />
    
    <br />
    <asp:Table ID="GetMiniCartResultTable" runat="server" GridLines="Both" >
        <asp:TableHeaderRow>
            <asp:TableHeaderCell Text="PFID" />
            <asp:TableHeaderCell Text="Quantity" />
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    
    <!-- Get Basket -->
    
    <br />
    <asp:Label ID="GetBasketLabel" runat="server" Text="Get Basket" Font-Bold="True"/>
    <br />
    
    <br />
    <asp:Label ID="GetBasketShopperIDLabel" runat="server" Text="ShopperID: " />
    <asp:TextBox ID="GetBasketShopperIDTextBox" runat="server" Text="846908" />
    <br />
    
    <br />
    <asp:Button ID="GetBasketButton" runat="server" Text="Get Basket" />
    <br />
    
    <br />
    <asp:Table ID="GetBasketResultTable" runat="server" GridLines="Both" >
        <asp:TableHeaderRow>
            <asp:TableHeaderCell Text="PFID" />
            <asp:TableHeaderCell Text="Quantity" />
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <asp:Literal ID="DeleteItemResultLiteral" runat="server" />
    <br />
    
    <!-- Add Item -->
    
    <br />
    <asp:Label ID="AddItemLabel" runat="server" Text="Add Item" Font-Bold="True" />
    <br />
    
    <br />
    <asp:Label ID="AddItemShopperIDLabel" runat="server" Text="ShopperID: " />
    <asp:TextBox ID="AddItemShopperIDTextBox" runat="server" Text="846908" />
    
    <asp:Label ID="AddItemProductIDLabel" runat="server" Text="ProductID: " />
    <asp:TextBox ID="AddItemProductIDTextBox" runat="server" Text="6701"/>
    
    <asp:Label ID="AddItemQuantityLabel" runat="server" Text="Quantity: " />
    <asp:TextBox ID="AddItemQuantityTextBox" runat="server" Text="5" />
    <br />
    
    <br />
    <asp:Button ID="AddItemButton" runat="server" Text="Add Item" OnClick="AddItemButton_Click" />
    <br />
    
    <br />
    <asp:Literal ID="AddItemResultLiteral" runat="server" />
    <br />
    
    
    <!-- Modify Item -->
    
    <br />
    <asp:Label ID="ModifyItemLabel" runat="server" Text="Modify Item" Font-Bold="True"/>
    <br />
    
    <br />
    <asp:Label ID="ModifyItemShopperIDLabel" runat="server" Text="ShopperID: " />
    <asp:TextBox ID="ModifyItemShopperIDTextBox" runat="server" Text="846908" />
    
    <asp:Label ID="ModifyItemIndexLabel" runat="server" Text="Index" />
    <asp:TextBox ID="ModifyItemIndexTextBox" runat="server" Text="0" />
    
    <asp:Label ID="ModifyItemQuantityLabel" runat="server" Text="Quantity" />
    <asp:TextBox ID="ModifyItemQuantityTextBox" runat="server" Text="1" />
    <br />
    
    <br />
    <asp:Button ID="ModifyItemButton" runat="server" Text="Modify Item" OnClick="ModfiyItemButton_Click" />
    <br />
    
    <br />
    <asp:Literal ID="ModifyItemResultLiteral" runat="server" />
    <br />
    
    <!-- Custom Content -->
    
    <br />
    <asp:Label ID="CustomContentLabel" runat="server" Text="Custom Content" Font-Bold="True" />
    <br />
    
    <br />
    <asp:Label ID="CustomContentIDListLabel" runat="server" Text="Custom Content IDs: " />
    <asp:TextBox ID="CustomContentIDListTextBox" runat="server" Text="0,1,2" />
    
    <asp:Label ID="CustomContentAppHeaderLabel" runat="server" Text="App Header: " />
    <asp:TextBox ID="CustomContentAppHeaderTextBox" runat="server" />
    
    <asp:Label ID="CustomContentFromAppLabel" runat="server" Text="From App: " />
    <asp:TextBox ID="CustomContentFromAppTextBox" runat="server" />
    <br />
    
    <br />
    <asp:Label ID="CustomContentISCCodeLabel" runat="server" Text="ISC Code: " />
    <asp:TextBox ID="CustomContentISCCodeTextBox" runat="server" Text="mike01" />
    
    <asp:Label ID="CustomContentIPAddressLabel" runat="server" Text="IP Address: " />
    <asp:TextBox ID="CustomContentIPAddressTextBox" runat="server" Text="192.168.1.2" />
    <br />
    
    <br />
    <asp:Button ID="CustomContentButton" runat="server" Text="Get Custom Content" OnClick="CustomContentButton_Click" />
    <br />
    
    <br />
    <asp:Literal ID="CustomContentResultLiteral" runat="server" />
    <br />
    
    <!-- Banner Content -->
    
    <br />
    <asp:Label ID="BannerContentLabel" runat="server" Text="Banner Content" Font-Bold="True" />
    <br />
    
    <br />
    <asp:Label ID="BannerContentPriceTypeLabel" runat="server" Text="Price Type: " />
    <asp:TextBox ID="BannerContentPriceTypeTextBox" runat="server" Text="0" />
    
    <asp:Label ID="BannerContentAppHeaderLabel" runat="server" Text="App Header: " />
    <asp:TextBox ID="BannerContentAppHeaderTextBox" runat="server" />
    
    <asp:Label ID="BannerContentFromAppLabel" runat="server" Text="From App: " />
    <asp:TextBox ID="BannerContentFromAppTextBox" runat="server" />
    <br />
    
    <br />
    <asp:Label ID="BannerContentISCCodeLabel" runat="server" Text="ISC Code: " />
    <asp:TextBox ID="BannerContentISCCodeTextBox" runat="server" Text="mike01" />
    
    <asp:Label ID="BannerContentIPAddressLabel" runat="server" Text="IP Address: " />
    <asp:TextBox ID="BannerContentIPAddressTextBox" runat="server" Text="192.168.1.2" />
    <br />
    
    <br />
    <asp:Button ID="BannerContentButton" runat="server" Text="Get Banner Content" OnClick="BannerContentButton_Click" />
    <br />
    
    <br />
    <asp:Literal ID="BannerContentResultLiteral" runat="server" />
    <br />
    
    
    <!-- Link Info -->
    
    <br />
    <asp:Label ID="LinkInfoLabel" runat="server" Text="Link Info" Font-Bold="True" />
    <br />
    
    <br />
    <asp:Label ID="LinkInfoContextIDLabel" runat="server" Text="ContextID: " />
    <asp:TextBox ID="LinkInfoContextIDTextBox" runat="server" Text="0" />
    
    <asp:Label ID="LinkInfoEnvLabel" runat="server" Text="Environment: " />
    <asp:TextBox ID="LinkInfoEnvTextBox" runat="server" Text="Development"/>
    <br />
    
    <br />
    <asp:Button ID="LinkInfoButton" runat="server" Text="Get Link Info" OnClick="LinkInfoButton_Click" />
    <br />
    
    <br />
    <asp:Literal ID="LinkInfoResultLiteral" runat="server" />
    <br />
    
    <!-- Product Group -->
    
    <br />
    <asp:Label ID="ProductGroup" runat="server" Text="Product Group" Font-Bold="True" />
    <br />
    
    <br />
    <asp:Label ID="ProductGroupUnifiedIDLabel" runat="server" Text="UnifiedProductGroupID: " />
    <asp:TextBox ID="ProductGroupUnifiedIDTextBox" runat="server" Text="67" />
    <br />
    
    <br />
    <asp:Button ID="ProductGroupButton" runat="server" Text="Get Product Group" OnClick="ProductGroupButton_Click" />
    <br />
    
    <br />
    <asp:Literal ID="ProductGroupResultLiteral" runat="server" />
    <br />
    
    <!-- Get Plan Features -->
    
    <br />
    <asp:Label ID="GetPlanFeaturesLabel" runat="server" Text="Plan Features" Font-Bold="True" />
    <br />
    
    <br />
    <asp:Label ID="GetPlanFeaturesUnifiedPFIDLabel" runat="server" Text="UnifiedPFID: " />
    <asp:TextBox ID="GetPlanFeaturesUnifiedPFIDTextBox" runat="server" Text="6701" />
    <br />
    
    <br />
    <asp:Button ID="GetPlanFeaturesButton" runat="server" Text="Get Plan Features" OnClick="GetPlanFeaturesButton_Click" />
    <br />
    
    <br />
    <asp:Literal ID="GetPlanFeaturesResultLiteral" runat="server" />
    <br />
    
    
    <!-- Product Offering -->
    
    <br />
    <asp:Label ID="ProductOfferLabel" runat="server" Text="Product Offerings" Font-Bold="true" />
    <br />
    
    <br />
    <asp:Label ID="ProductOfferPLIDLabel" runat="server" Text="PrivateLabelID: " />
    <asp:TextBox ID="ProductOfferPLIDTextBox" runat="server" Text="1" />
    <br />
    
    <br />
    <asp:Button ID="ProductOfferButton" runat="server" Text="Get Product Offerings" OnClick="ProductOfferButton_Click" />
    <br />
    
    <br />
    <asp:Literal ID="ProductOfferResultLiteral" runat="server" />
    <br />
        
    <br />
    <asp:Label ID="ShopperPriceTypeLabel" runat="server" Font-Bold="True" 
        Text="Shopper PriceType"></asp:Label>
    <br />
    <br />
    <asp:Label ID="ShopperPriceTypeShopperIDLabel" runat="server" 
        Text="ShopperID: "></asp:Label>
    <asp:TextBox ID="ShopperPriceTypeShopperIDTextBox" runat="server">838388</asp:TextBox>
    &nbsp;<asp:Label ID="ShopperPriceTypePrivateLabelIDLabel" runat="server" Text="PrivateLabelID: "></asp:Label>
    <asp:TextBox ID="ShopperPriceTypePLIDTextBox" runat="server">1</asp:TextBox>
    <br />
    <br />
    <asp:Button ID="ShopperPriceTypeButton" runat="server" 
        onclick="ShopperPriceTypeButton_Click" Text="Get Shopper PriceType" />
    <br />
    <br />

    <asp:Literal ID="ShopperPriceTypeLiteral" runat="server"></asp:Literal>

    <br />
    <br />
    <asp:Label ID="GetOverrideHashLabel" runat="server" Font-Bold="True" 
        Text="Get Override Hash"></asp:Label>
    <br />
    <br />
    <asp:Label ID="GetOverrideHashPLID" runat="server" Text="PrivateLabelID: "></asp:Label>
    <asp:TextBox ID="GetOverrideHashPLIDTextBox" runat="server">1</asp:TextBox>
    <asp:Label ID="GetOverrideHashUnifiedPFIDLabel" runat="server" 
        Text="UnifiedPFID: "></asp:Label>
    <asp:TextBox ID="GetOverrideHashUnifiedPFIDTextBox" runat="server">6701</asp:TextBox>
&nbsp;<br />
    <br />
    <asp:Label ID="GetOverrideHashOverrideListPriceLabel" runat="server" 
        Text="OverrideListPrice: "></asp:Label>
    <asp:TextBox ID="GetOverrideHashOverrideListPriceTextBox" runat="server">123</asp:TextBox>
    <asp:Label ID="GetOverrideHashOverrideCurrentPriceLabel" runat="server" 
        Text="OverrideCurrentPrice: "></asp:Label>
    <asp:TextBox ID="GetOverrideHashOverrideCurrentPriceTextBox" runat="server">122</asp:TextBox>
    <br />
    <br />
    <asp:Button ID="GetOverrideHashButton" runat="server" 
        onclick="GetOverrideHashButton_Click" Text="Get Override Hash" />
    <br />
    <br />
    <asp:Literal ID="GetOverrideHashLiteral" runat="server"></asp:Literal>
    <br />
    <br />
    <asp:Label ID="GetDurationHashLabel" runat="server" Font-Bold="True" 
        Text="Get Duration Hash"></asp:Label>
    <br />
    <br />
    <asp:Label ID="GetDurationHashPLIDLabel" runat="server" Text="PrivateLabelID: "></asp:Label>
    <asp:TextBox ID="GetDurationHashPLIDTextBox" runat="server">1</asp:TextBox>
    <asp:Label ID="GetDurationHashUnifiedPFIDLabel" runat="server" 
        Text="UnifiedPFID:"></asp:Label>
&nbsp;<asp:TextBox ID="GetDurationHashUnifiedPFIDTextBox" runat="server">6701</asp:TextBox>
    <asp:Label ID="GetDurationHashDurationLabel" runat="server" Text="Duration: "></asp:Label>
    <asp:TextBox ID="GetDurationHashDurationTextBox" runat="server">1.0</asp:TextBox>
        <br />
    <br />

</div>
<asp:Button ID="GetDurationHashButton" runat="server" 
    onclick="GetDurationHashButton_Click" Text="Get Duration Hash" />
&nbsp;&nbsp;&nbsp;
    <asp:Literal ID="GetDurationHashLiteral" runat="server"></asp:Literal>
<br />
    <br />
    <hr />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Create Shopper"></asp:Label>
<br />
    <asp:Button ID="Button1" runat="server" onclick="CreateShopper_Click" 
        Text="Create Shopper" Height="19px" Width="99px" />
    <asp:Label ID="Label2" runat="server" Width="50px"></asp:Label>
<asp:Literal ID="CreateShopperLiteral" runat="server"></asp:Literal>
    <br />
    <br />
    <asp:Label ID="ProductOfferPLIDLabel0" runat="server" 
        Text="PrivateLabel ID: " />
    <asp:TextBox ID="CreateShopperPLIDTextBox" runat="server">1</asp:TextBox>
    <hr />
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Add Contact"></asp:Label>
    <p>
        <asp:Button ID="Button2" runat="server" onclick="AddContactInfo_Click" 
            Text="Add Contact" />
    <br />
    <br />
    <asp:Label ID="ProductOfferPLIDLabel1" runat="server" 
        Text="AddContactXML" />
    <asp:TextBox ID="AddContactXmlTextBox" runat="server" Height="98px" Width="726px">1</asp:TextBox>
    </p>
    </form>
</body>
</html>
