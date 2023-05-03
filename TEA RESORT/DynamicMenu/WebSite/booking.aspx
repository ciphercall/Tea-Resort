<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/WebSiteMasterPage.Master" AutoEventWireup="true" CodeBehind="booking.aspx.cs" Inherits="DynamicMenu.WebSite.booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
  
    <style>
        .grd {
            border: none;
        }

            .grd th {
                border: none;
            }

            .grd td {
                border: none;
            }

            .grd tr:hover {
                background: #e6e6fa;
            }
    </style>
    
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- header theme section start -->
    <section class="headerThemeSection row-fluid animated fadeIn">
        <div id="subHeader">
            <h2>Booking
            </h2>
        </div>
    </section>
    <!-- header theme section end -->
    <br>
    <section class="fow-fluid" id="contact">
        <div class="container">
            <div class="col-md-3">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title"><i class="fa fa-calendar"></i>QUERY</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-6" style="float: left; color: #708090">
                                Check In    
                                <%-- <% HttpCookie CookiesData = HttpContext.Current.Request.Cookies["indexCookies"]; string CheckinDt = CookiesData["CKCheckinDt"].ToString();%>--%>
                                <asp:TextBox runat="server" type="text" class="form-control datepicker" placeholder="Checkin" ID="txtcheckinDt">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-6" style="float: left; color: #708090">
                                Check Out    
                                <asp:TextBox runat="server" type="text" class="form-control datepicker clearfix" placeholder="Checkout" ID="txtcheckOutdt"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6" style="float: left; color: #708090">
                                Rooms
                                 <asp:TextBox runat="server" type="number" class="form-control" placeholder="Rooms" ID="txtrooms" min="1"></asp:TextBox>
                            </div>
                            <div class="col-md-6" style="float: left; display: inline-block; color: #708090">
                                Night
                                 <asp:TextBox runat="server" type="text" class="form-control" placeholder="Night" ID="txtnight" min="1"> </asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6" style="float: left; display: inline-block; color: #708090">
                                Adults 
                                <asp:TextBox runat="server" type="number" class="form-control" placeholder="Adult" ID="txtAdults" min="1"></asp:TextBox>
                            </div>
                            <div class="col-md-6" style="float: left; color: #708090">
                                Children
                                 <asp:TextBox runat="server" type="number" class="form-control" placeholder="Children" ID="txtchildren" min="0"></asp:TextBox>
                            </div>
                        </div>

                        <%--<input type="text" class="form-control datepicker" placeholder="Checkin">
                        <input type="text" class="form-control datepicker clearfix" placeholder="Checkout">--%>

                        <p class="clearfix"></p>
                        <button type="button"
                            class="btn btn_full color_yellow clearfix">
                            FIND</button>

                    </div>
                </div>
            </div>
            <!--wizard  -->
            <div class="col-md-9">
                <div id="smartwizard">
                    <ul>
                        <li><a href="#step-1">Avaiable Room List<br />
                            <small>Choose your room</small></a></li>
                        <li><a href="#step-2">Reservation<br />
                            <small>Enter your identity</small></a></li>
                        <li><a href="#step-3">Confirmation<br />
                            <small>Confirm your booking</small></a></li>

                    </ul>

                    <div>
                        <div id="step-1" class="">
                            <!--single item  -->
                            <%-- <div class="row room_list_row">
                                <div class="col-md-3">
                                    <article class="room">
                                        <figure>
                                            <div class="price">৳89 <span>/ night</span></div>
                                            <a class="hover_effect h_blue h_link" href="room.html">
                                                <img src="https://www.eagle-themes.com/zantehotel/images/rooms/xsingle-room.jpg.pagespeed.ic.UZ6NiWnfp9.webp" class="img-responsive" alt="Image">
                                            </a>
                                        </figure>
                                    </article>
                                </div>
                                <div class="col-md-9">
                                    <figcaption>
                                        <h4><a href="#">Single Room</a></h4>
                                        <p>Adult: 2 Children: 2</p>

                                        <a href="#" type="button" class="btn btn-large btn-default">SELECT</a>

                                    </figcaption>
                                </div>
                            </div>--%>
                            <!--# single item  -->

                            <!--single item  -->
                            <%-- <div class="row room_list_row">
                                <div class="col-md-3">
                                    <article class="room">
                                        <figure>
                                            <div class="price">৳89 <span>/ night</span></div>
                                            <a class="hover_effect h_blue h_link" href="room.html">
                                                <img src="https://www.eagle-themes.com/zantehotel/images/rooms/xsingle-room.jpg.pagespeed.ic.UZ6NiWnfp9.webp" class="img-responsive" alt="Image">
                                            </a>
                                        </figure>
                                    </article>
                                </div>
                                <div class="col-md-9">
                                    <figcaption>
                                        <h4><a href="#">VIP Room</a></h4>
                                        <p>Adult: 2 Children: 1</p>

                                        <a href="#" type="button" class="btn btn-large btn-default">SELECT</a>

                                    </figcaption>
                                </div>
                            </div>--%>
                            <!--#single item  -->
                            <asp:Repeater runat="server" ID="repeater" OnItemDataBound="repeater_ItemDataBound">
                                <ItemTemplate>
                                    <%-- <div class="container">
                                        <div class="row">
                                            <div class="col-md-8">
                                                <h3 style="color: #4b4b4b; font-size: 17px; font-weight: bold; float: left; text-transform: uppercase; letter-spacing: 2px;"><%#Eval("ROOMNM")%></h3>
                                                <h3 style="color: #B4D7FA; font-size: 20px; font-weight: bold; float: right; font-style: italic">Tk.<%#Eval("ROOMRT")%>/Night</h3>
                                            </div>
                                        </div>
                                    </div>--%>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="panel panel-default">
                                                <div class="panel-heading" style="height: 40px">
                                                    <div style="float: left; display: inline-block">
                                                        <h3 class="panel-title-booking"><%#Eval("ROOMNM")%></h3>
                                                    </div>
                                                    <div style="float: right; display: inline-block">
                                                        <h3 class="panel-title-booking">Tk.<%#Eval("ROOMRT")%>/Night</h3>
                                                    </div>


                                                </div>
                                                <div class="panel-body">
                                                    <%--    <div class="row">
                                                <div class="col-md-4">Image</div>
                                                <div class="col-md-4">Facilities</div>
                                                <div class="col-md-4"></div>
                                            </div>--%>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <img src='<%#Eval("IMGURL")%>' class="img-responsive" alt="Image" style="width: 750px; height: 150px;">
                                                            <asp:Label ID="lblROOMID" runat="server" Text='<%#Eval("ROOMID")%>' Style="display: none"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Font-Size="10PT"
                                                                Width="100%" ShowHeader="True" CssClass="grd">
                                                                <Columns>
                                                                    <asp:BoundField HeaderText="Facilities" DataField="FS">
                                                                        <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <HeaderStyle Font-Bold="True" Font-Names="Calibri" Font-Size="16px" />
                                                                <RowStyle Font-Names="Calibri" Font-Size="14px" />
                                                            </asp:GridView>

                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="row"></div>
                                                            <div class="row"></div>
                                                            <div class="row">
                                                                <div class="col-md-8">
                                                                    Room Qty :
                                                                   <asp:TextBox runat="server" type="number" class="form-control" placeholder="Room Qty" ID="txtRoomSelect" min="1"></asp:TextBox>
                                                                    <asp:Button runat="server" CssClass="btn btn_full color_yellow clearfix" Text="Select" />
                                                                </div>
                                                                <div class="col-md-4"></div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                        <div id="step-2" class="">
                            <!--row  -->
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="first_name">First Name</label>
                                        <input type="text" name="first_name" class="form-control">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="last_name">Last Name</label>
                                        <input type="text" name="last_name" class="form-control">
                                    </div>
                                </div>
                            </div>
                            <!--row  -->
                            <!--row  -->
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="email">E-mail</label>
                                        <input type="text" name="email" class="form-control">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="phone">Phone</label>
                                        <input type="text" name="phone" class="form-control">
                                    </div>
                                </div>
                            </div>
                            <!--row  -->
                            <!--row  -->
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="address">Address</label>
                                        <textarea name="address" class="form-control"></textarea>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="additional_node">Additional Node</label>
                                        <textarea name="additional_node" class="form-control"></textarea>
                                    </div>
                                </div>
                            </div>
                            <!--row  -->
                        </div>
                        <div id="step-3" class="">
                            Step Content
                        </div>
                        <div id="step-4" class="">
                            Step Content
                        </div>
                    </div>
                </div>
            </div>
            <!--wizard  -->
        </div>
    </section>

    
      <link href="css/bootstrap-datepicker.min.css" rel="stylesheet" />
<%--    <link href="css/bootstrap.min.css" rel="stylesheet" />--%>
    <script src="js/bootstrap-datepicker.min.js"></script>

</asp:Content>
