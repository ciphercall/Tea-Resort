<%@ Page Title="" Language="C#" MasterPageFile="~/Dynamic.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DynamicMenu.DeshBoard.UI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .panel-title {
            cursor: pointer;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- main content start here -->
    <div class="col-md-10 pull-right" id="mainContentBox">
        <div id="contentBox">
            <div id="contentHeaderBox">
                <h1>DASH BOARD</h1>
                <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->

            </div>
            <%
                if (Session["USERID"] == null)
                {
                    Response.Redirect("~/LogIn/UI/LogIn.aspx");
                }
                else
                {
                    if (Session["USERTYPE"].ToString() == "COMPADMIN")
                    { %>
            <!-- content header end -->
            <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true" style="padding: 10px; display: none">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingOne">
                        <h4 class="panel-title" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            <a style="text-decoration: none">CREDIT VOUCHER
                            </a>
                        </h4>
                    </div>
                    <div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                        <div class="panel-body">
                            <asp:GridView ID="GridView1" CssClass="table table-hover" runat="server" AutoGenerateColumns="False"
                                OnRowDataBound="GridView1_RowDataBound" Width="100%" ShowFooter="True">
                                <Columns>
                                    <asp:BoundField HeaderText="Date">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle Width="10%" CssClass="GridRowStyle" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="V. No">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Branch">
                                        <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Debit Head">
                                        <HeaderStyle HorizontalAlign="Center" Width="26%" />
                                        <ItemStyle HorizontalAlign="Left" Width="26%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Credit Head">
                                        <HeaderStyle HorizontalAlign="Center" Width="26%" />
                                        <ItemStyle HorizontalAlign="Left" Width="26%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Amount">
                                        <HeaderStyle HorizontalAlign="Center" Width="13%" />
                                        <ItemStyle HorizontalAlign="Right" Width="13%" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle Font-Names="Calibri" Font-Size="14px" />
                                <HeaderStyle Font-Names="Calibri" BackColor="#819FF7" Font-Size="14px" />
                                <RowStyle Font-Size="12px" Font-Names="Calibri" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingTwo">
                        <h4 class="panel-title" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                            <a style="text-decoration: none">DEBIT VOUCHER
                            </a>
                        </h4>
                    </div>
                    <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                        <div class="panel-body">
                            <asp:GridView ID="GridView2" CssClass="table table-hover" runat="server" AutoGenerateColumns="False"
                                OnRowDataBound="GridView2_RowDataBound" Width="100%" ShowFooter="True">
                                <Columns>
                                    <asp:BoundField HeaderText="Date">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle Width="10%" CssClass="GridRowStyle" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="V. No">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Branch">
                                        <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Debit Head">
                                        <HeaderStyle HorizontalAlign="Center" Width="26%" />
                                        <ItemStyle HorizontalAlign="Left" Width="26%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Credit Head">
                                        <HeaderStyle HorizontalAlign="Center" Width="26%" />
                                        <ItemStyle HorizontalAlign="Left" Width="26%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Amount">
                                        <HeaderStyle HorizontalAlign="Center" Width="13%" />
                                        <ItemStyle HorizontalAlign="Right" Width="13%" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle Font-Names="Calibri" Font-Size="14px" />
                                <HeaderStyle Font-Names="Calibri" BackColor="#819FF7" Font-Size="14px" />
                                <RowStyle Font-Size="12px" Font-Names="Calibri" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingThree">
                        <h4 class="panel-title" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                            <a style="text-decoration: none">JOURNAL VOUCHER
                            </a>
                        </h4>
                    </div>
                    <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                        <div class="panel-body">
                            <asp:GridView ID="GridView3" CssClass="table table-hover" runat="server" AutoGenerateColumns="False"
                                OnRowDataBound="GridView3_RowDataBound" Width="100%" ShowFooter="True">
                                <Columns>
                                    <asp:BoundField HeaderText="Date">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle Width="10%" CssClass="GridRowStyle" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="V. No">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Branch">
                                        <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Debit Head">
                                        <HeaderStyle HorizontalAlign="Center" Width="26%" />
                                        <ItemStyle HorizontalAlign="Left" Width="26%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Credit Head">
                                        <HeaderStyle HorizontalAlign="Center" Width="26%" />
                                        <ItemStyle HorizontalAlign="Left" Width="26%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Amount">
                                        <HeaderStyle HorizontalAlign="Center" Width="13%" />
                                        <ItemStyle HorizontalAlign="Right" Width="13%" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle Font-Names="Calibri" Font-Size="14px" />
                                <HeaderStyle Font-Names="Calibri" BackColor="#819FF7" Font-Size="14px" />
                                <RowStyle Font-Size="12px" Font-Names="Calibri" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingFour">
                        <h4 class="panel-title" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                            <a style="text-decoration: none">CONTRA VOUCHER
                            </a>
                        </h4>
                    </div>
                    <div id="collapseFour" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingFour">
                        <div class="panel-body">
                            <asp:GridView ID="GridView4" CssClass="table table-hover" runat="server" AutoGenerateColumns="False"
                                OnRowDataBound="GridView4_RowDataBound" Width="100%" ShowFooter="True">
                                <Columns>
                                    <asp:BoundField HeaderText="Date">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle Width="10%" CssClass="GridRowStyle" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="V. No">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Branch">
                                        <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Debit Head">
                                        <HeaderStyle HorizontalAlign="Center" Width="26%" />
                                        <ItemStyle HorizontalAlign="Left" Width="26%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Credit Head">
                                        <HeaderStyle HorizontalAlign="Center" Width="26%" />
                                        <ItemStyle HorizontalAlign="Left" Width="26%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Amount">
                                        <HeaderStyle HorizontalAlign="Center" Width="13%" />
                                        <ItemStyle HorizontalAlign="Right" Width="13%" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle Font-Names="Calibri" Font-Size="14px" />
                                <HeaderStyle Font-Names="Calibri" BackColor="#819FF7" Font-Size="14px" />
                                <RowStyle Font-Size="12px" Font-Names="Calibri" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <% }
                } %>
        </div>
        <!-- content box end here -->


    </div>
    <!-- main content end here -->


</asp:Content>
