<%@ Page Title="" Language="C#" MasterPageFile="~/Dynamic.Master" AutoEventWireup="true" CodeBehind="RoomFeatures.aspx.cs" Inherits="DynamicMenu.WebSitePanel.UI.RoomFeatures" %>

<%@ Import Namespace="DynamicMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../MenuCssJs/js/jquery-2.1.3.js"></script>
    <script src="../../MenuCssJs/js/jquery-ui.js"></script>
    <link href="../../MenuCssJs/ui-gray/jquery-ui.css" rel="stylesheet" />


    <script>
        $(document).ready(function () {
            BindControlEvents();
        });
        function BindControlEvents() {
            GetCompletionListRoomNM();
        }


        function confMSG() {
            if (confirm("Are you Sure to Delete?")) {
                //                alert("Clicked Yes");
            } else {
                //                alert("Clicked No");
                return false;
            }
        }



        function GetCompletionListRoomNM() {
            $("#<%=txtRoomNM.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../../search.asmx/GetCompletionListRoomNM",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtRoomNM.ClientID %>").val() + "'}",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.label,
                                    value: item.label,
                                    x: item.value
                                };
                            }));
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                },
                minLength: 1,
                select: function (event, ui) {
                    $("#<%=txtRoomId.ClientID %>").val(ui.item.x);

                }
            });
            }


    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-10 pull-right" id="mainContentBox">
        <div id="contentBox">
            <div id="contentHeaderBox">
                <h1>ROOM FEATURES ENTRY</h1>
                <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->


            </div>
            <!-- content header end -->


            <!-- Content Start From here -->
            <div class="form-class">
                <div class="row">
                    <asp:Label ID="lblMaxStID" runat="server"></asp:Label>
                    <asp:Label ID="lblSTID" runat="server"></asp:Label>
                </div>
                <br />
                <div class="row form-class">
                    <div class="col-md-2"></div>
                    <div class="col-md-2">Room Name :</div>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtRoomNM" runat="server" class="form-control input-sm" AutoPostBack="True"></asp:TextBox>

                    </div>
                    <div class="col-md-2">
                        <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_OnClick" Text="Submit" CssClass="form-control btn-info"/>
                        <asp:TextBox runat="server" ID="txtRoomId" style="display: none"></asp:TextBox>
                    </div>
                </div>


                <div class="table table-responsive table-hover" style="border: 1px solid #ddd; border-radius: 5px;">
                    <asp:GridView ID="gvDetails" runat="server" BackColor="White" BorderStyle="None" CellPadding="3" CssClass="Gridview text-center"
                        CellSpacing="1" GridLines="Both" Width="100%" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="gvDetails_RowDataBound" OnRowCommand="gvDetails_RowCommand"
                        OnRowCancelingEdit="gvDetails_RowCancelingEdit" OnRowEditing="gvDetails_RowEditing" OnRowUpdating="gvDetails_RowUpdating" OnRowDeleting="gvDetails_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Features ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblFSID" runat="server" Text='<%# Eval("FSID") %>' Width="100%" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblFSIDEdit" runat="server" Text='<%# Eval("FSID") %>' Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>

                                <FooterStyle Width="4%" HorizontalAlign="Center" />
                                <HeaderStyle Width="4%" HorizontalAlign="Center" />
                                <ItemStyle Width="4%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Features Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblFSTP" runat="server" Text='<%# Eval("FSTP") %>' Width="100%" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFSTPEdit" runat="server" Text='<%#Eval("FSTP") %>' CssClass="form-control input-sm"
                                        TabIndex="6" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFSTP" runat="server" CssClass="form-control input-sm" TabIndex="1" />
                                </FooterTemplate>

                                <FooterStyle Width="15%" HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                <ItemStyle Width="15%" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Features Details">
                                <ItemTemplate>
                                    <asp:Label ID="lblFSDATA" runat="server" Text='<%#Eval("FSDATA") %>' Width="100%" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtFSDATAEdit" runat="server" Text='<%#Eval("FSDATA") %>' CssClass="form-control input-sm"
                                        TabIndex="7" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtFSDATA" runat="server" CssClass="form-control input-sm" TabIndex="2" />
                                </FooterTemplate>

                                <FooterStyle HorizontalAlign="Left" Width="32%" />
                                <HeaderStyle HorizontalAlign="Center" Width="32%" />
                                <ItemStyle HorizontalAlign="Left" Width="32%" />
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Images/update.png"
                                        ToolTip="Update" Height="20px" Width="20px" TabIndex="10" />
                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/Cancel.png"
                                        ToolTip="Cancel" Height="20px" Width="20px" TabIndex="11" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <% if (UserPermissionChecker.checkParmit("/WebSitePanel/UI/RoomFeatures.aspx", "UPDATER") == true)
                                        { %>
                                    <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Images/Edit.png"
                                        ToolTip="Edit" Height="20px" Width="20px" TabIndex="101" />
                                    <% } %>
                                    <% if (UserPermissionChecker.checkParmit("/WebSitePanel/UI/RoomFeatures.aspx", "DELETER") == true)
                                        { %>
                                    <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                        ImageUrl="~/Images/delete.png" ToolTip="Delete" Height="20px" Width="20px" OnClientClick="return confMSG()"
                                        TabIndex="111" />
                                    <% } %>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <% if (UserPermissionChecker.checkParmit("/WebSitePanel/UI/RoomFeatures.aspx", "INSERTR") == true)
                                        { %>
                                    <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/Images/AddNewitem.png"
                                        CommandName="AddNew" Width="25px" Height="30px" ToolTip="Add new Record" ValidationGroup="validaiton"
                                        TabIndex="5" />
                                    <% } %>
                                </FooterTemplate>
                                <FooterStyle Width="5%" HorizontalAlign="Center" />
                                <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="text-center" BorderColor="Gray" BorderWidth="2px" HorizontalAlign="Center" Height="30px" Font-Size="13px" BackColor="#5e727b" ForeColor="White" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    </asp:GridView>
                </div>
            </div>
            <!-- Content End From here -->
        </div>
    </div>
</asp:Content>
