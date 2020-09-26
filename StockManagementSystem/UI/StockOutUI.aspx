<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementSystem.UI.StockOutUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Out</title>
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
                        <h4>Stock Out</h4>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-10 margin-bottom">

                            <asp:HiddenField ID="idsHiddenField" Value='<%#Eval("Sl") %>' runat="server" />
                              <h5 style="color:red"><asp:Label ID="outputMsgLabel" runat="server" Text=""></asp:Label></h5> 
         <br />
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Company" CssClass="col-md-4 control-label"></asp:Label>
                                
                                <div class="col-md-8">
                                    <asp:DropDownList ID="companyDropDownList" runat="server" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control margin-bottom ">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Item" CssClass="col-md-4 control-label"></asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="itemDropDownList" runat="server" CssClass="form-control margin-bottom"  OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server" Text="Reorder Level" CssClass="col-md-4 control-label"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="reorderTextBox" runat="server" CssClass="form-control margin-bottom "> </asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="Available Quantity " CssClass="col-md-4 control-label"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="availableQty" runat="server" CssClass="form-control margin-bottom "> </asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="Label6" runat="server" Text="Stock In Quantity" CssClass="col-md-4 control-label"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="stockInTextBox" runat="server" CssClass="form-control margin-bottom "></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-sm-8 col-sm-offset-3">
                                    <div class="pull-right">
                                        <asp:Button ID="addButton" runat="server" Width="190%" Text="Add" OnClick="addButton_Click" CssClass="btn btn-default" />
                                    </div>
                                </div>

                            </div>
                            <hr />
                        </div>

                        <!-- GTRID VIEW HERE LOAD -->

                        <asp:GridView ID="stockOutGridView" runat="server" Width="100%" CssClass="table table-bordered table-responsive table-hover success">
                            <Columns>
                                <asp:TemplateField HeaderText="Sl" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                          <h5 style="color:black"><asp:Label ID="msgQty" runat="server" Text=""></asp:Label></h5> 

                    </div>
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
                            <asp:Button ID="btnSell" runat="server" Text="Sell" CssClass="btn btn-primary" OnClick="btnSell_Click"/>
                            <asp:Button ID="btnDamage" runat="server" Text="Damage" CssClass="btn btn-primary" OnClick="btnDamage_Click"/>
                            <asp:Button ID="btnLost" runat="server" Text="Lost" CssClass="btn btn-primary" OnClick="btnLost_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
         
    </form>
</body>
</html>
