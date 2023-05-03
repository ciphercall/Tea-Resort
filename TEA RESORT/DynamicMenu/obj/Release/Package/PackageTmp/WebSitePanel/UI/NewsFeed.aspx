<%@ Page Title="" Language="C#" MasterPageFile="~/Dynamic.Master" AutoEventWireup="true" CodeBehind="NewsFeed.aspx.cs" Inherits="DynamicMenu.WebSitePanel.UI.NewsFeed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../MenuCssJs/ui-gray/jquery-ui.css" rel="stylesheet" />
    <script src="../../MenuCssJs/js/jquery-2.1.3.js"></script>
    <script src="../../MenuCssJs/js/jquery-ui.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            loaddata();
        });
        function deletedata(newsid) {
            if (confirm("Are you Sure to Delete?")) {
                $.ajax({
                    url: "NewsFeed.aspx/DeleteNewsFeed",
                    contentType: "application/json; charset=utf-8;",
                    type: "POST",
                    dataType: "json",
                    data: "{ 'id' : '" + newsid + "'}",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        if (data.d === "done") {
                            alert('Successfuly deleted');
                            loaddata();
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
        function loaddata() {
            $.ajax({
                url: "NewsFeed.aspx/ShowNewsFeed",
                contentType: "application/json; charset=utf-8;",
                type: "POST",
                dataType: "json",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    var html = "";
                    $("#showdatatable tbody").empty();
                    $.each(data.d, function (index, element) {
                        html += "<tr>";
                        html += "<td>" + element.NewsId + "</td>";
                        html += "<td>" + element.HeadName + "</td>";
                        html += "<td>" + element.Title + "</td>";
                        html += "<td><span class='more'>" + element.Descrition + "</span></td>";
                        html += "<td><img src='" + element.FileName + "' style='width: 50px; height: 50px'/></td>";
                        html += "<td><span class='fa fa-close deletenews' style='font-size: 20px; font-weight: 800; cursor: pointer' onclick='deletedata(" + element.NewsId + ");'></span></td>";
                        html += "</tr>";
                    });
                    $("#showdatatable tbody").append(html);
                },
                error: function (result) {
                    alert(result.responseText);
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-10 pull-right" id="mainContentBox">
        <div id="contentBox">
            <div id="contentHeaderBox">
                <h1>News Feed Entry</h1>
                <!-- <span class="pull-right" id="editOption"><i class="fa fa-cog"></i></span> -->


                <!-- logout option button -->
                <div class="btn-group pull-right" id="editOption">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="modal" data-target="#myModal">
                        <i class="fa fa-plus-circle"></i>
                    </button>
                    <%--<ul class="dropdown-menu pull-right" style="" role="menu">
                    </ul>--%>
                </div>
                <!-- end logout option -->


            </div>
            <!-- content header end -->


            <!-- Content Start From here -->
            <div class="form-class">


                <!-- Modal -->
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title" id="myModalLabel">Modal title</h4>
                            </div>
                            <div class="modal-body">
                                <div class="row form-class">
                                    <div class="col-md-3">Publish Head</div>
                                    <div class="col-md-9">
                                        <asp:TextBox runat="server" ID="txtHead" type="text" class="form-control input-sm"
                                            placeholder="Publish Head" />
                                    </div>
                                </div>
                                <div class="row form-class">
                                    <div class="col-md-3">Publish Title</div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtTitle" type="text" class="form-control input-sm"
                                            placeholder="Publish Title" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row form-class">
                                    <div class="col-md-3">Description</div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" class="form-control input-sm" Style="min-height: 200px"
                                            placeholder="Description" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row form-class">
                                    <div class="col-md-3">Feature Image</div>
                                    <div class="col-md-9">
                                        <asp:FileUpload ID="fileUpload" type="file" class="form-control input-sm" runat="server"  accept="image/png, image/jpeg, image/jpg, image/gif"/>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                <asp:Button class="btn btn-primary" runat="server" Text="Submit" ID="btnSave" OnClick="btnSave_OnClick" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row form-class">
                    <asp:Label runat="server" ID="lblMsg" ForeColor="red" Visible="False"></asp:Label>
                </div>

                <div class="row form-class">
                    <div class="col-md-12">
                        <table class="table table-hover" style="width: 100%" id="showdatatable">
                            <thead>
                                <tr>
                                    <th style="width: 5%">SL</th>
                                    <th style="width: 15%">Head</th>
                                    <th style="width: 20%">Title</th>
                                    <th style="width: 54%">Description</th>
                                    <th style="width: 10%">Iamge</th>
                                    <th style="width: 5%"></th>
                                </tr>
                            </thead>
                            <tbody style="font-weight: 500; text-align: justify; font-family: monospace;"></tbody>
                        </table>
                    </div>
                </div>

            </div>
            <!-- Content End From here -->
        </div>
    </div>
</asp:Content>
