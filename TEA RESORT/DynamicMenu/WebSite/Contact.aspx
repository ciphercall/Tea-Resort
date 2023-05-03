<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/WebSiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DynamicMenu.WebSite.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- header theme section start -->
    <section class="headerThemeSection row-fluid animated fadeIn">
        <div id="subHeader">
            <h2>Contact Us
            </h2>
        </div>
    </section>
    <!-- header theme section end -->
    <section class="fow-fluid" id="contact">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-5">
                        <h2>Place your message</h2>
                        <form action="" method="">
                            <p>
                                <input type="text" class="form-control" placeholder="Enter your name"></p>
                            <p>
                                <input type="text" class="form-control" placeholder="Enter your email"></p>
                            <p>
                                <input type="text" class="form-control" placeholder="Enter your subject"></p>
                            <p>
                                <textarea name="" id="" cols="30" rows="10" class="form-control" placeholder="Enter your message"></textarea></p>
                            <input type="submit" class="btn" value="Send">
                        </form>

                    </div>
                    <!-- contact form end -->
                    <div class="col-md-4 pull-right" id="address">
                        <h2>Contact Details</h2>
                        <p>
                            <i class="fa fa-map-marker"></i>TEA RESORT & MUSEUM
                            <br>
                            Bangladesh Tea Board,
                            <br>
                            Srimongal, Moulvibazar
                        </p>

                        <p>
                            <i class="fa fa-phone"></i>
                            Executive in-Charge +8801712-071502
                            <br>
                            Supervisor +8801712-916001
                            <br>
                            Booking Asst: +8801749-014306
                        </p>
                        <p><i class="fa fa-envelope"></i>tearesort@yahoo.com</p>
                        <p><i class="fa fa-clock-o"></i>Everyday 9:00AM-6:00PM</p>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <section class="row-fluid">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2 align="center">Location</h2>

                    <script src='https://maps.googleapis.com/maps/api/js?v=3.exp&key=AIzaSyCgVqPrDWLk1yE-IDdA2BQeMfRQ2z_43Ic'></script>
                    <div style='overflow: hidden; height: 400px; width: 99%;'>
                        <div id='gmap_canvas' style='height: 400px; width: 99%;'></div>
                        <style>
                            #gmap_canvas img {
                                max-width: none !important;
                                background: none !important;
                            }
                        </style>
                    </div>
                    <a href='http://maps-generator.com/'>google map generator</a>
                    <script type='text/javascript' src='https://embedmaps.com/google-maps-authorization/script.js?id=dbd9701961bf20b381d3eba98f2761305772a7d0'></script>
                    <script type='text/javascript'>function init_map() { var myOptions = { zoom: 12, center: new google.maps.LatLng(24.308084545842505, 91.75482454387203), mapTypeId: google.maps.MapTypeId.ROADMAP }; map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions); marker = new google.maps.Marker({ map: map, position: new google.maps.LatLng(24.308084545842505, 91.75482454387203) }); infowindow = new google.maps.InfoWindow({ content: '<strong>TEA RESORT & MUSEUM</strong><br>Bangladesh Tea Board, Srimongal, Moulvibazar<br> Sylhet<br>' }); google.maps.event.addListener(marker, 'click', function () { infowindow.open(map, marker); }); infowindow.open(map, marker); } google.maps.event.addDomListener(window, 'load', init_map);</script>

                </div>
            </div>
        </div>
    </section>
</asp:Content>
