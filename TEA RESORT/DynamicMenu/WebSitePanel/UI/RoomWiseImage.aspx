<%@ Page Title="" Language="C#" MasterPageFile="~/Dynamic.Master" AutoEventWireup="true" CodeBehind="RoomWiseImage.aspx.cs" Inherits="DynamicMenu.WebSitePanel.UI.RoomWiseImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../MenuCssJs/ui-gray/jquery-ui.css" rel="stylesheet" />
    <script src="../../MenuCssJs/js/jquery-2.1.3.js"></script>
    <script src="../../MenuCssJs/js/jquery-ui.js"></script>
    <script src="../../MenuCssJs/js/function.js"></script>

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

        function deleteslide(imgid) {
            if (confirm("Are you Sure to Delete?")) {
                $.ajax({
                    url: "RoomWiseImage.aspx/DeleteSlide",
                    contentType: "application/json; charset=utf-8;",
                    type: "POST",
                    dataType: "json",
                    data: "{ 'id' : '" + imgid + "'}",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        if (data.d === "done") {
                            $("#" + imgid).hide();
                            alert('Successfuly deleted');
                        }
                        else alert('Data not deleted');
                    },
                    error: function (result) {
                        alert(result.responseText);
                    }
                });
            }
            else { return false; }

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-10 pull-right" id="mainContentBox">
        <div id="contentBox">
            <div id="contentHeaderBox">
                <h1>Room Wise Image Upload</h1>
                <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->


                <!-- logout option button -->
                <div class="btn-group pull-right" id="editOption">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="modal" data-target="#myModal">
                        <i class="fa fa-cog"></i>
                    </button>
                    <%--<ul class="dropdown-menu pull-right" style="" role="menu">
                    </ul>--%>
                </div>
                <!-- end logout option -->


            </div>
            <!-- content header end -->

            <!-- Content Start From here -->
            <div class="form-class">

                <div class="row form-class text-center">
                    <asp:Label runat="server" ID="lblMsg" ForeColor="red" Visible="False"></asp:Label>
                </div>

                <div class="row form-class">
                    <div class="col-md-1">Room</div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtRoomNM" class="form-control input-sm" placeholder="Room Name" runat="server" AutoPostBack="True" OnTextChanged="txtRoomNM_OnTextChanged"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtRoomId" Style="display: none"></asp:TextBox>
                    </div>
                    <div class="col-md-1">Image</div>
                    <div class="col-md-3">
                        <asp:FileUpload ID="fileUpload" type="file" class="form-control input-sm" runat="server" accept="image/png, image/jpeg, image/jpg, image/gif" />

                    </div>
                   
                    <div class="col-md-2">
                        <asp:TextBox ID="txtImgId" type="number" class="form-control input-sm" placeholder="Image Serial" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button class="form-control input-sm btn-primary" runat="server" Text="Submit" ID="btnSave" OnClick="btnSave_OnClick"/>
                    </div>

                </div>

                <div class="row form-class">
                    <asp:Repeater ID="rpt" runat="server">
                        <ItemTemplate>
                            <div class="col-xs-6  col-md-4" id="<%# Eval("IMGID") %>">
                                <a href="#" class="thumbnail">
                                    <img src="<%#Eval("IMGURL") %>" alt="" style="max-height: 120px">
                                </a>
                                <p>
                             <%--  Sl no <a href="#" id="username">#<%# Eval("SL") %></a>--%>
                                    <div id="text<%# Eval("IMGID") %>">
                                    </div>
                                </p>

                                <p>
                                    <a href="#" class="btn btn-danger btn-sm" role="button" onclick="deleteslide(<%# Eval("IMGID") %>)">Delete</a>

                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

            </div>
            <!-- Content End From here -->
        </div>
    </div>
</asp:Content>
