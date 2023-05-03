<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/WebSiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DynamicMenu.WebSite.Index" %>

<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="AlchemyAccounting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript">
        $(document).ready(function () {
            //slideload();

            nightCalc();

            BindControlEvents();
        });


        function slideload() {
            $.ajax({
                url: "Index.aspx/GetSliderName",
                contentType: "application/json; charset=utf-8;",
                type: "POST",
                dataType: "json",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    var html = "";
                    $("#owl-rs").empty();
                    $.each(data.d, function (index, element) {
                        html += "<img src='.." + element.label + "' alt='" + element.value + "' />";
                    });
                    $("#owl-rs").append(html);
                },
                error: function (result) {
                    alert(result.responseText);
                }
            });
        }

        function nightCalc() {
            $("#<%=txtCheckIn.ClientID%>"), $("#<%=txtcheckOut.ClientID%>").change(function () {
                var Checkindate = $("#<%=txtCheckIn.ClientID%>").val();
                var Checkoutdate = $("#<%=txtcheckOut.ClientID%>").val();
                //var diffDays = (Checkoutdate - Checkindate) / 1000 / 60 / 60 / 24;
                //var diff = new Date(Checkoutdate - Checkindate);
                //var days = diff / 1000 / 60 / 60 / 24;
                var days = (Checkoutdate - Checkindate) / (1000 * 60 * 60 * 24);

                var f = Math.round(days);
                $("#<%=txtNight.ClientID%>").val(f);
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--main slider start-->
    <section id="slider">
        <div class="row" id="owl-rs">
            <%
                var conn = new SqlConnection(DbFunctions.Connection);
                using (var objSqlcommand = new SqlCommand(@"SELECT TOP (5) ID, IMGPATH, SL FROM RES_SLIDE 
            WHERE (SL BETWEEN 1 AND 5) ORDER BY SL DESC", conn))
                {
                    conn.Open();
                    SqlDataReader objResult = objSqlcommand.ExecuteReader();
                    while (objResult.Read())
                    {
            %>
            <img src='..<%=objResult["IMGPATH"].ToString().TrimEnd() %>' alt='<%=objResult["SL"].ToString().TrimEnd() %>' />
            <%
                    }
                    objResult.Close();
                    conn.Close();
                }
            %>
        </div>

        <!--booking seach box-->
        <div class="booking-search">
            <div class="row">
                <div class="container">
                    <div class="booking-search-box">
                        <div class="title">
                            <p>BOOK YOUR</p>
                            <h2>ROOMS</h2>
                        </div>
                        <div class="inputs">
                            <asp:TextBox runat="server" ID="txtCheckIn" placeholder="Check In" ClientIDMode="Static"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtcheckOut" placeholder="Check Out" ClientIDMode="Static"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtNight" placeholder="Night" Enabled="False" type="Number" min="1"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAdults" placeholder="Adults" type="Number" min="1"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtChildren" placeholder="Children" type="Number" min="0"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtRoomQty" placeholder="Rooms" type="Number" min="1"></asp:TextBox>
                            <%-- <input type="text" class="datepicker" placeholder="Check In" />--%>
                            <%--   <input type="number" placeholder="Night" />--%>
                            <%--       <input type="text" class="datepicker" placeholder="Check Out" />--%>
                            <%--   <input type="number" placeholder="Adults" />
                            <input type="number" placeholder="Children" />--%>
                        </div>
                        <div class="submit">
                            <button id="btnBook" runat="server" onserverclick="bookNow_onclick">Book</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--booking seach box-->
        <!--slider message-->
        <div class="slider-message">
            <h2>Unlimited Luxury</h2>
            <h3>for Mind, Body and Soul</h3>
        </div>
        <!--slider message-->
    </section>
    <!--end main slider-->


    <br />
    <!--info section-->
    <section id="info">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2 style="text-align: center">Welcome to Tea Resort & Museum</h2>
                    <p align="center">Tea Resort, one of the most attractive modern leisure resorts constructed by the British consultants to suit their peaceful dwelling in the midst of tea estates with a wonderful landscape consisting of more than 25 acres of green hills and hilltops. The resort campus is gifted with a scenic beauty featuring modern interior design and architecture, outdoor park, modern swimming pool, lawn tennis, table tennis and badminton. Restaurant caters array of local, Asian and International cuisines with emphasis on fresh, healthy and creative flavours.  For site seeing, there are Monipuri Village, Khasiya Punji, Madabpur Lake, Tea Estates and Laua Cherra forest with their captivating views.</p>

                </div>



            </div>
        </div>
        <br />
    </section>
    <!--end info section-->
    <hr>
    <section>
        <div class="container">
            <div class="row">
                <asp:Repeater runat="server" ID="rpttr1" OnItemCommand="rpttr1_OnItemCommand">
                    <ItemTemplate>

                        <div class="col-md-4">
                            <article class="room">
                                <figure>
                                    <div class="price">৳<%#Eval("ROOMRT")%><span>/night</span></div>
                                    <a class="hover_effect h_blue h_link" href="#" />
                                    <%-- <img src="https://www.eagle-themes.com/zantehotel/images/rooms/xsingle-room.jpg.pagespeed.ic.UZ6NiWnfp9.webp" class="img-responsive" alt="Image">--%>
                                    <img src='<%#Eval("IMGURL")%>' class="img-responsive" alt="Image" style="width: 750px; height: 210px;">

                                    <%-- <asp:Label runat="server" ID="lblROOMID"><%#Eval("ROOMID")%></asp:Label>--%>
                                    <asp:Label ID="lblROOMID" runat="server" Text='<%#Eval("ROOMID")%>' Style="display: none"></asp:Label>
                                    <asp:Label ID="lblIMGURL" runat="server" Text='<%#Eval("IMGURL")%>' Style="display: none"></asp:Label>

                                    <figcaption>
                                        <h4><a href="#"><%#Eval("ROOMNM")%></a></h4>

                                        <%--<span class="f_right"><a href="#" class="button btn_sm btn_blue" onclick="GetRoomDetails_onclick">VIEW DETAILS</a></span>--%>
                                        <span class="f_right">
                                            <asp:LinkButton runat="server" ID="btnViewDetails" class="button btn_sm btn_blue" CommandName="BidNow" CommandArgument='<%#Eval("ROOMID")+","+Eval("IMGURL")+","+Eval("ROOMRT")+","+Eval("ROOMNM")%>'>VIEW DETAILS</asp:LinkButton></span>
                                    </figcaption>
                                </figure>
                            </article>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <%-- <div class="col-md-4">
                    <article class="room">
                        <figure>
                            <div class="price">৳129 <span>/ night</span></div>
                            <a class="hover_effect h_blue h_link" href="room.html">
                                <img src="https://www.eagle-themes.com/zantehotel/images/rooms/xdouble-room.jpg.pagespeed.ic.MahbaI_mcg.webp" class="img-responsive" alt="Image" data-pagespeed-url-hash="3557007964" onload="pagespeed.CriticalImages.checkImageForCriticality(this);">
                            </a>
                            <figcaption>
                                <h4><a href="room-details.aspx">Double Room</a></h4>
                                <span class="f_right"><a href="room-details.aspx" class="button btn_sm btn_blue">VIEW DETAILS</a></span>
                            </figcaption>
                        </figure>
                    </article>
                </div>--%>
                <%--  <div class="col-md-4">
                    <article class="room">
                        <figure>
                            <div class="price">৳189 <span>/ night</span></div>
                            <a class="hover_effect h_blue h_link" href="room-details.aspx">
                                <img src="https://www.eagle-themes.com/zantehotel/images/rooms/xdeluxe-room.jpg.pagespeed.ic.6tRvw-Rb2_.webp" class="img-responsive" alt="Image" data-pagespeed-url-hash="1599658418" onload="pagespeed.CriticalImages.checkImageForCriticality(this);">
                            </a>
                            <figcaption>
                                <h4><a href="room-details.aspx">Delux Room</a></h4>
                                <span class="f_right"><a href="room-details.aspx" class="button btn_sm btn_blue">VIEW DETAILS</a></span>
                            </figcaption>
                        </figure>
                    </article>
                </div>--%>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <a class="button btn_sm btn_yellow" style="display: block; width: 159px; margin: 0 auto;" href="rooms-list.html">VIEW ROOMS LIST</a>
                </div>

            </div>
        </div>
    </section>
    <hr>
    <br>
    <br>

    <section id="members">
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <div class="item">
                        <div class="client-pic">
                            <img src="/WebSite/images/chairman.jpg" alt="Lili Kids">
                        </div>
                        <cite>CHAIRMAN</cite>
                        <blockquote>
                            <strong>Md. Shafeenul Islam</strong>
                            <br>
                            <small>Major General, ndc, psc</small>
                            <br>
                            joined on 18/02/2016.
                        </blockquote>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="item">
                        <div class="client-pic">
                            <img src="/WebSite/images/co.jpg" alt="Lili Kids">
                        </div>
                        <cite>C.O & EXCUTIVE IN-CHARGE</cite>
                        <blockquote>
                            <strong>A K M Rafikul Hoque</strong>
                            <br>
                            <small>Controlling Officer & Executive in-charge</small>
                            <br>
                            joined on 28/02/2017
                        </blockquote>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="item">
                        <div class="client-pic">
                            <img src="/WebSite/images/co.jpg" alt="Lili Kids">
                        </div>
                        <cite>EXECUTIVE IN-CHARGE</cite>
                        <blockquote>
                            <strong>Md. Jahangir Alam</strong>
                            <br>
                            <small>Assistant In-charge</small>
                            <br>
                            joined on 28/02/2017
                        </blockquote>
                    </div>
                </div>
            </div>
        </div>
    </section>
    
    
    <script src="js/jquery-2.1.3.js"></script>
    <link href="/MenuCssJs/ui-gray/jquery-ui.css" rel="stylesheet" />
    <script src="/MenuCssJs/js/jquery-2.1.3.js"></script>
    <script src="/MenuCssJs/js/jquery-ui.js"></script>
    <script>
        function BindControlEvents() {
            $(function () {
                $("#txtCheckIn").datepicker({
                    defaultDate: "",
                    dateFormat: "yy-mm-dd",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-0:+10",
                    onClose: function (selectedDate) {
                        $("#txtcheckOut").datepicker("option", "minDate", selectedDate);
                    }
                });
                $("#txtcheckOut").datepicker({
                    defaultDate: "",
                    dateFormat: "yy-mm-dd",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-0:+10",
                    onClose: function (selectedDate) {
                        $("#txtCheckIn").datepicker("option", "maxDate", selectedDate);
                    }
                });
            });
        }
    </script>

</asp:Content>
