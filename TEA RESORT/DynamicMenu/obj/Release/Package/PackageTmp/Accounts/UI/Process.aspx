<%@ Page Title="" Language="C#" MasterPageFile="~/Dynamic.Master" AutoEventWireup="true" CodeBehind="Process.aspx.cs" Inherits="DynamicMenu.Accounts.UI.Process" %>
<%@ Import Namespace="DynamicMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../MenuCssJs/ui-gray/jquery-ui.css" rel="stylesheet" />
    <script src="../../MenuCssJs/js/jquery-2.1.3.js"></script>
    <script src="../../MenuCssJs/js/jquery-ui.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtDate").datepicker({ dateFormat: "dd/mm/yy", changeMonth: true, changeYear: true, yearRange: "-100:+0" });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-10 pull-right" id="mainContentBox">
        <div id="contentBox">
            <div id="contentHeaderBox">
                <h1>Process</h1>
                <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->


                <!-- logout option button -->
                <div class="btn-group pull-right" id="editOption">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                        <i class="fa fa-cog"></i>
                    </button>
                    <ul class="dropdown-menu pull-right" style="" role="menu">
                        
                    </ul>
                </div>
                <!-- end logout option -->


            </div>
            <!-- content header end -->


            <!-- Content Start From here -->
            <div class="form-class">


                <div class="row form-class">
                    <div class="col-md-3"></div>
                    <div class="col-md-1">Date:</div>
                    <div class="col-md-2"><asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" CssClass="form-control input-sm"
                                        ClientIDMode="Static" OnTextChanged="txtDate_TextChanged" TabIndex="1"></asp:TextBox></div>
                        
                    <div class="col-md-2">
                         <asp:Button ID="btnProcess" runat="server" CssClass="form-control input-sm btn-primary" 
                                        Font-Bold="True" Font-Italic="True" Text="Process"
                                        OnClick="btnProcess_Click" TabIndex="2" />
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div>
                    <asp:Label ID="lblSerial_Mrec" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblSerial_Jour" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblSerial_BUY" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblSerial_Mpay" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblSerial_Cont" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblSerial_SALE" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblSlSale_Dis" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblSerial_LC" runat="server" Visible="False"></asp:Label>
                </div>

                <div>
                    <asp:GridView ID="gridSingleVoucher" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gridBuy" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gridSale" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="GridView4" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gridWastage" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gridReceive" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gridIssue" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gridLC" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gridSale_Ret" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gridPurchase_Ret" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gridMultiple" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gvMicCollection" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gvMicCollectionMember" runat="server">
                    </asp:GridView>
                    <asp:GridView ID="gridSubContractReceive" runat="server">
                    </asp:GridView>
                     <asp:GridView ID="gridSubContractIssue" runat="server">
                    </asp:GridView>
                </div>


            </div>
            <!-- Content End From here -->
        </div>
    </div>


</asp:Content>
