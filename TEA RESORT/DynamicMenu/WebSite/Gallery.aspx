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
                    <asp:Repeater runat="server" ID="rpttr1" OnItemCommand="rpttr1_OnItemCommand">
                        <ItemTemplate>
                            <div class="col-md-3">
                                <article class="room" style="margin-bottom: 20px">
                                    <figure>

                                        <a class="hover_effect h_blue h_link" href="#">
                                            <img src='<%#Eval("IMGURL")%>' class="img-responsive" alt="Image" data-pagespeed-url-hash="2307781969" onload="pagespeed.CriticalImages.checkImageForCriticality(this);" style="width: 750px; height: 180px;">
                                        </a>
                                        <figcaption>
                                           <%-- <h5><a href="#" onclick=""><%#Eval("ALBAMNM")%> </a></h5>--%>
                                            <h5><asp:LinkButton ID="hypAlbam" runat="server"  Text='<%#Eval("ALBAMNM")%>' CommandName="BidNow" CommandArgument='<%#Eval("ALBAMNM")+","+Eval("ALBAMID")+","+Eval("IMGURL")+","+Eval("IMGID")%>'></asp:LinkButton></h5>
                                            

                                           <%--  <span class="f_right">
                                            <asp:LinkButton runat="server" ID="btnViewDetails" class="button btn_sm btn_blue">View</asp:LinkButton></span>--%>
                                        </figcaption>
                                    </figure>
                                </article>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--   <div class="col-md-4">
                        <article class="room">
                            <figure>

                                <a class="hover_effect h_blue h_link" href="room.html">
                                    <img src="https://www.ticketshala.com/hotels/img/hotels/GSkJIvZVuiWFubLiUJXEKDiQV4.jpg" class="img-responsive" alt="Image" data-pagespeed-url-hash="3557007964" onload="pagespeed.CriticalImages.checkImageForCriticality(this);">
                                </a>
                                <figcaption>
                                    <h4><a href="room.html">Double Room</a></h4>

                                </figcaption>
                            </figure>
                        </article>
                    </div>--%>
                    <%-- <div class="col-md-4">
                        <article class="room">
                            <figure>

                                <a class="hover_effect h_blue h_link" href="room.html">
                                    <img src="https://media-cdn.tripadvisor.com/media/photo-s/05/a6/e7/7a/room-view.jpg" class="img-responsive" alt="Image" data-pagespeed-url-hash="1599658418" onload="pagespeed.CriticalImages.checkImageForCriticality(this);">
                                </a>
                                <figcaption>
                                    <h4><a href="room.html">Delux Room</a></h4>

                                </figcaption>
                            </figure>
                        </article>
                    </div>--%>
                </div>
            </div>
        </div>
    </section>
    <br>

    <br>
</asp:Content>
