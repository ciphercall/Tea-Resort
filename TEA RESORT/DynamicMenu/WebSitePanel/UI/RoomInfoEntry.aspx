<%@ Page Title="" Language="C#" MasterPageFile="~/Dynamic.Master" AutoEventWireup="true" CodeBehind="RoomInfoEntry.aspx.cs" Inherits="DynamicMenu.WebSitePanel.UI.RoomInfoEntry" %>
<%@ Import Namespace="DynamicMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../MenuCssJs/ui-gray/jquery-ui.css" rel="stylesheet" />
    <script src="../../MenuCssJs/js/jquery-2.1.3.js"></script>
    <script src="../../MenuCssJs/js/jquery-ui.js"></script>
    <script src="../../MenuCssJs/js/function.js"></script>

    <script type="text/javascript">
        function confMSG() {
            if (confirm("Are you Sure to Delete?")) {
                //                alert("Clicked Yes");
            }
            else {
                //                alert("Clicked No");
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-10 pull-right" id="mainContentBox">
        <div id="contentBox">
            <div id="contentHeaderBox">
                <h1>ROOM ENTRY</h1>
                <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->


            </div>
            <!-- content header end -->


            <!-- Content Start From here -->
            <div class="form-class">
                <div class="row">
                    <asp:Label ID="lblMaxStID" runat="server"></asp:Label>
                    <asp:Label ID="lblSTID" runat="server"></asp:Label>
                </div>
                <%--<div class="row form-class">
                    <div class="col-md-2"></div>
                    <div class="col-md-4"></div>
                    <div class="col-md-2"></div>
                    <div class="col-md-4"></div>
                </div>
                <div class="row form-class">
                    <div class="col-md-5"></div>
                    <div class="col-md-2"></div>
                    <div class="col-md-5"></div>
                </div>--%>

                <div class="table table-responsive table-hover" style="border: 1px solid #ddd; border-radius: 5px;">
                    <asp:GridView ID="gvDetails" runat="server" BackColor="White" BorderStyle="None" CellPadding="3" CssClass="Gridview text-center"
                        CellSpacing="1" GridLines="Both" Width="100%" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="gvDetails_RowDataBound"
                        OnRowCommand="gvDetails_RowCommand" OnRowCancelingEdit="gvDetails_RowCancelingEdit" OnRowDeleting="gvDetails_RowDeleting" OnRowEditing="gvDetails_RowEditing"
                        OnRowUpdating="gvDetails_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="Room ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblROOMID" runat="server" Text='<%# Eval("ROOMID") %>' Width="100%" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblROOMIDEdit" runat="server" Text='<%# Eval("ROOMID") %>' Width="100%" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>

                                <FooterStyle Width="6%" HorizontalAlign="Center" />
                                <HeaderStyle Width="6%" HorizontalAlign="Center" />
                                <ItemStyle Width="6%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Room Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblROOMNM" runat="server" Text='<%# Eval("ROOMNM") %>' Width="100%" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtROOMNMEdit" runat="server" Text='<%#Eval("ROOMNM") %>' CssClass="form-control input-sm"
                                        TabIndex="6" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtROOMNM" runat="server" CssClass="form-control input-sm" TabIndex="1" />
                                </FooterTemplate>

                                <FooterStyle Width="20%" HorizontalAlign="Left" />
                                <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Room Details">
                                <ItemTemplate>
                                    <asp:Label ID="lblROOMDTL" runat="server" Text='<%#Eval("ROOMDTL") %>' Width="100%" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtROOMDTLEdit" runat="server" Text='<%#Eval("ROOMDTL") %>' CssClass="form-control input-sm"
                                        TabIndex="7" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtROOMDTL" runat="server" CssClass="form-control input-sm" TabIndex="2" />
                                </FooterTemplate>

                                <FooterStyle HorizontalAlign="Left" Width="32%" />
                                <HeaderStyle HorizontalAlign="Center" Width="32%" />
                                <ItemStyle HorizontalAlign="Left" Width="32%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Room Qty">
                                <ItemTemplate>
                                    <asp:Label ID="lblROOMQTY" runat="server" Text='<%#Eval("ROOMQTY") %>' Width="100%"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtROOMQTYEdit" runat="server" Text='<%#Eval("ROOMQTY") %>' CssClass="form-control input-sm"
                                        TabIndex="8" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtROOMQTY" runat="server" TabIndex="3" CssClass="form-control input-sm" />
                                </FooterTemplate>

                                 <FooterStyle Width="6%" HorizontalAlign="Center" />
                                <HeaderStyle Width="6%" HorizontalAlign="Center" />
                                <ItemStyle Width="6%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Max People">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaxPeople" runat="server" Text='<%#Eval("MAXPEOPLE") %>' Width="100%"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaxPeopleEdit" runat="server" Text='<%#Eval("MAXPEOPLE") %>' CssClass="form-control input-sm"
                                        TabIndex="8" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtMaxPeople" runat="server" TabIndex="4" CssClass="form-control input-sm" />
                                </FooterTemplate>

                                 <FooterStyle Width="6%" HorizontalAlign="Center" />
                                <HeaderStyle Width="6%" HorizontalAlign="Center" />
                                <ItemStyle Width="6%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Room Rate">
                                <ItemTemplate>
                                    <asp:Label ID="lblROOMRT" runat="server" Text='<%# Eval("ROOMRT") %>' Width="100%"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtROOMRTEdit" runat="server" Text='<%#Eval("ROOMRT") %>' CssClass="form-control input-sm"
                                        TabIndex="9" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtROOMRT" runat="server" CssClass="form-control input-sm" TabIndex="5" />
                                </FooterTemplate>

                                 <FooterStyle Width="8%" HorizontalAlign="Right" />
                                <HeaderStyle Width="8%" HorizontalAlign="Center" />
                                <ItemStyle Width="8%" HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/Images/update.png"
                                        ToolTip="Update" Height="20px" Width="20px" TabIndex="10" />
                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/Images/Cancel.png"
                                        ToolTip="Cancel" Height="20px" Width="20px" TabIndex="11" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <% if (UserPermissionChecker.checkParmit("/WebSitePanel/UI/RoomInfoEntry.aspx", "UPDATER") == true)
                                       { %>
                                    <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Images/Edit.png"
                                        ToolTip="Edit" Height="20px" Width="20px" TabIndex="101" />
                                    <% } %>
                                    <% if (UserPermissionChecker.checkParmit("/WebSitePanel/UI/RoomInfoEntry.aspx", "DELETER") == true)
                                       { %>
                                    <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                        ImageUrl="~/Images/delete.png" ToolTip="Delete" Height="20px" Width="20px" OnClientClick="return confMSG()"
                                        TabIndex="111" />
                                    <% } %>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <% if (UserPermissionChecker.checkParmit("/WebSitePanel/UI/RoomInfoEntry.aspx", "INSERTR") == true)
                                       { %>
                                    <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/Images/AddNewitem.png"
                                        CommandName="AddNew" Width="25px" Height="30px" ToolTip="Add new Record" ValidationGroup="validaiton"
                                        TabIndex="5" />
                                    <% } %>
                                </FooterTemplate>
                                <FooterStyle Width="5%" HorizontalAlign="Right" />
                                <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                <ItemStyle Width="5%" HorizontalAlign="Right" />
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
