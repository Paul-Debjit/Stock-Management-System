<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySetupUI.aspx.cs" Inherits="StockManagementSystem.UI.CompanySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>company Setup</title>
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
                        <h4>Company Setup</h4>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-10 margin-bottom">

                    <h5 style="color:red"><asp:Label ID="outputMsgLabel" runat="server" Text=""></asp:Label></h5>

                    <div class="form-group"><asp:Label ID="Label1" runat="server" Text="Company Name" CssClass="col-md-4 control-label"></asp:Label>
                    </div>
                    <div class="col-md-8"> <asp:TextBox ID="nameTextBox" runat="server" CssClass="form-control margin-bottom "></asp:TextBox>
                        </div>
                        </div>
                        </div>
                       
                     <!-- GTRID VIEW HERE LOAD -->

                        <asp:GridView ID="companyGridView" runat="server" Width="100%" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                            CssClass="table table-bordered table-responsive">
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
                            <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                        </div>
                                 
                            
                    </div>
   
    </div></div></div>
                 
                    </form>
</body>
</html>
