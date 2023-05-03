<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/WebSiteMasterPage.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="DynamicMenu.WebSite.Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- header theme section start -->
    <section class="headerThemeSection row-fluid animated fadeIn">
        <div id="subHeader">
            <h2>Gallery
            </h2>
        </div>
    </section>
    <!-- header theme section end -->
    <br>
    <section id="overview">
        <div class="container">
            <div class="row">
                <div class="row">
                    <div class="col-md-4">
                        <article class="room">
                            <figure>

                                <a class="hover_effect h_blue h_link" href="room.html">
                                    <img src="https://www.eagle-themes.com/zantehotel/images/rooms/xsingle-room.jpg.pagespeed.ic.UZ6NiWnfp9.webp" class="img-responsive" alt="Image" data-pagespeed-url-hash="2307781969" onload="pagespeed.CriticalImages.checkImageForCriticality(this);">
                                </a>
                                <figcaption>
                                    <h4><a href="room.html">Single Room</a></h4>

                                </figcaption>
                            </figure>
                        </article>
                    </div>
                    <div class="col-md-4">
                        <article class="room">
                            <figure>

                                <a class="hover_effect h_blue h_link" href="room.html">
                                    <img src="https://www.eagle-themes.com/zantehotel/images/rooms/xdouble-room.jpg.pagespeed.ic.MahbaI_mcg.webp" class="img-responsive" alt="Image" data-pagespeed-url-hash="3557007964" onload="pagespeed.CriticalImages.checkImageForCriticality(this);">
                                </a>
                                <figcaption>
                                    <h4><a href="room.html">Double Room</a></h4>

                                </figcaption>
                            </figure>
                        </article>
                    </div>
                    <div class="col-md-4">
                        <article class="room">
                            <figure>

                                <a class="hover_effect h_blue h_link" href="room.html">
                                    <img src="https://www.eagle-themes.com/zantehotel/images/rooms/xdeluxe-room.jpg.pagespeed.ic.6tRvw-Rb2_.webp" class="img-responsive" alt="Image" data-pagespeed-url-hash="1599658418" onload="pagespeed.CriticalImages.checkImageForCriticality(this);">
                                </a>
                                <figcaption>
                                    <h4><a href="room.html">Delux Room</a></h4>

                                </figcaption>
                            </figure>
                        </article>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <br>

    <br>
</asp:Content>
