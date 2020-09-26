<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeUI.aspx.cs" Inherits="StockManagementSystem.UI.HomeUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="../style/bootstrap.min.css" rel="stylesheet" />
    <style>
        .margin-bottom {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="container">
            <h3 class="text-center">Stock Management Sysem</h3>
            <div class="col-md-8 col-md-offset-2">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>HOME</h4>
                    </div>
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="CatagorySetupUI.aspx">Catagory Setup</asp:HyperLink><br/><br/>

        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="CompanySetupUI.aspx">Company Setup</asp:HyperLink>><br/><br/>
        
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="ItemSetupUI.aspx">Item Setup</asp:HyperLink>><br/><br/>
        
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="StockInUI.aspx">Stock In</asp:HyperLink>><br/><br/>
        
        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="StockOutUI.aspx">Stock Out</asp:HyperLink>><br/><br/>
        
        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="SearchViewItemUI.aspx">Search View Item</asp:HyperLink>><br/><br/>
        
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="ViewSalesTwoDateUI.aspx">View Sales Two Date</asp:HyperLink>><br/><br/>
    
       
    </div>

                </div>

            </div>

         </div>
        

    </form>
</body>
</html>
