<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesTwoDateUI.aspx.cs" Inherits="StockManagementSystem.UI.ViewSalesTwoDateUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Sales</title>
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
                        <h4>View Sales</h4>
                    </div>
                     
                    <div class="panel-body">
                        <div class="col-md-10 margin-bottom">
                    <h5 style="color:red"><asp:Label ID="outputMsgLabel" runat="server" Text=""></asp:Label></h5> 
                    <div class="form-group"><asp:Label ID="Label1" runat="server" Text="From Date" CssClass="col-md-4 control-label"></asp:Label></div>
                     <div class="col-md-8"><asp:TextBox ID="fromDateTextBox" runat="server" CssClass="form-control margin-bottom " type="date"></asp:TextBox></div>
                    
                    <div class="form-group"><asp:Label ID="Label2" runat="server" Text="To Date" CssClass="col-md-4 control-label"></asp:Label></div>
                     <div class="col-md-8"><asp:TextBox ID="toDateTextBox" runat="server"  CssClass="form-control margin-bottom " type="date"></asp:TextBox></div>
                    </div>
                        </div>
                  
                   <asp:GridView ID="sellGridView" runat="server" CssClass="table table-bordered table-responsive table-hover success">
                        <Columns>
                        <asp:TemplateField HeaderText="Sl" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                   </asp:GridView>
      
                      <!-- PANEL BODY END-->
                    <div class="panel-footer">


                        <div class="col-md-3">
                            <div class="pull-left">
                                <a href="HomeUI.aspx" class="btn btn-info btn-sm">
                                    <i class="fa fa-arrow-circle-left"></i>Back to Home
                                </a>
                            </div>
                        </div>

                        <div class="btn-group  col-md-offset-3">
                        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                        </div>

                    </div>
                    

    </div></div></div>
        
    </form>
</body>
</html>
