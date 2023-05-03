<%@ Page Title="" Language="C#" MasterPageFile="~/Dynamic.Master" AutoEventWireup="true" CodeBehind="SliderImage.aspx.cs" Inherits="DynamicMenu.WebSitePanel.UI.SliderImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../MenuCssJs/ui-gray/jquery-ui.css" rel="stylesheet" />
    <script src="../../MenuCssJs/js/jquery-2.1.3.js"></script>
    <script src="../../MenuCssJs/js/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#username').editable();
        });
         function deleteslide(imgid) {
            if (confirm("Are you Sure to Delete?")) {
                $.ajax({
                    url: "SliderImage.aspx/DeleteSlide",
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
        function updateslide(imgid) {
            if (confirm("Are you Sure to Update?")) {
                var sl = $("#text" + imgid).val();
                $.ajax({
                    url: "SliderImage.aspx/DeleteSlide",
                    contentType: "application/json; charset=utf-8;",
                    type: "POST",
                    dataType: "json",
                    data: "{ 'id' : '" + imgid + "', 'sl':'"+sl+"'}",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        if (data.d === "done") {

                        }
                        else alert('Data not updated');
                    },
                    error: function (result) {
                        alert(result.responseText);
                    }
                });
            }
            else { return false; }

        };
      
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

                <div class="row form-class text-center">
                    <asp:Label runat="server" ID="lblMsg" ForeColor="red" Visible="False"></asp:Label>
                </div>

                <div class="row form-class">
                    <div class="col-md-2">Slide Number</div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtImgId" type="number" class="form-control input-sm"
                            placeholder="Slide Number" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-1">Image</div>
                    <div class="col-md-4">
                        <asp:FileUpload ID="fileUpload" type="file" class="form-control input-sm" runat="server" accept="image/png, image/jpeg, image/jpg, image/gif" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button class="form-control input-sm btn-primary" runat="server" Text="Submit" ID="btnSave" OnClick="btnSave_OnClick" />
                    </div>
                </div>

                <div class="row form-class">
                    <asp:Repeater ID="rpt" runat="server">
                        <ItemTemplate>
                            <div class="col-xs-6  col-md-4" id="<%# Eval("ID") %>">
                                <a href="#" class="thumbnail">
                                    <img src="<%#Eval("IMGPATH") %>" alt="" style="max-height: 120px">
                                </a>
                                <p>Slide no <a href="#" id="username">#<%# Eval("SL") %></a>
                                    <a href="#" class="btn btn-danger btn-sm" role="button" onclick="deleteslide(<%# Eval("ID") %>)">Delete</a>
                                    <div id="text<%# Eval("ID") %>">
                                         
                                    </div>
                                  
                                </p>
                              
                                <p>
                                    
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
