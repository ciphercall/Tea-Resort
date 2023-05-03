<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/WebSiteMasterPage.Master" AutoEventWireup="true" CodeBehind="room-details.aspx.cs" Inherits="DynamicMenu.WebSite.room_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<!-- header theme section start -->
<section class="headerThemeSection row-fluid animated fadeIn">
	<div id="subHeader">
		<h2>
			Double Room
		</h2>
	</div>
</section>
<!-- header theme section end -->
<br>
<section>
	<div class="container">
		<div class="row">
			<div class="col-md-8 room-preview-box" >
                <div class="view thumbnail">
                    <img  src="https://www.eagle-themes.com/zantehotel/images/rooms/xsingle-room.jpg.pagespeed.ic.UZ6NiWnfp9.webp" alt="">
                </div>

                <div class="thum-box">
                    <div class="thum thumbnail">
                        <img class="img-responsive" src="images/museum/1.jpg" alt="">
                    </div>
                    <div class="thum thumbnail">
                        <img class="img-responsive" src="images/museum/2.jpg" alt="">
                    </div>
                     <div class="thum thumbnail">
                        <img class="img-responsive" src="images/museum/3.jpg" alt="">
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title"><i class="fa fa-calendar"></i> BOOK ONLINE</h3>
                    </div>
                    <div class="panel-body">
                        <input type="text" class="form-control" placeholder="Enter Your Name">
                        <input type="email" class="form-control" placeholder="Enter Email Address">
                        <input type="text" class="form-control" placeholder="Enter Your Phone">
                        
                        <input type="number" style="width:50%; float:left" class="form-control" placeholder="Adult">
                        <input type="number" style="width:50%; float:left" class="form-control" placeholder="Children">

                        <input type="text" style="width:50%; float:left" class="form-control datepicker" placeholder="Checkin">
                        <input type="text" style="width:50%; float:left" class="form-control datepicker clearfix" placeholder="Checkout">
                        <p class="clearfix"></p>
                        <button type="button" class="btn btn_full color_yellow clearfix">BOOK NOW</button>
                        
                    </div>
                </div>
            </div>
			
		</div>
	</div>
</section>
<br>
<!--description-->
<section>
    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Facilities</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <!--facility-->
                                <div class="facility-box">
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-check-circle"></i></span> <span class="text">80 Sq mt </span></p>
                                    </div>
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-check-circle"></i></span> <span class="text">6 Persons </span></p>
                                    </div>
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-times-circle"></i></span> <span class="text">Free Internet </span></p>
                                    </div>
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-check-circle"></i></span> <span class="text">Free Wi-Fi </span></p>
                                    </div>
                                </div>
                                <!--facility-->
                            </div>
                            <div class="col-md-4">
                                <!--facility-->
                                <div class="facility-box">
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-check-circle"></i></span> <span class="text">80 Sq mt </span></p>
                                    </div>
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-check-circle"></i></span> <span class="text">Private Balcony </span></p>
                                    </div>
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-check-circle"></i></span> <span class="text">Free Internet </span></p>
                                    </div>
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-check-circle"></i></span> <span class="text">Breakfast Include </span></p>
                                    </div>
                                </div>
                                <!--facility-->
                            </div>
                            <div class="col-md-4">
                                <!--facility-->
                                <div class="facility-box">
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-times-circle"></i></span> <span class="text">Newspapaer </span></p>
                                    </div>
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-check-circle"></i></span> <span class="text">Flat Screen Tv </span></p>
                                    </div>
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-times-circle"></i></span> <span class="text">Beach View </span></p>
                                    </div>
                                    <div class="item">
                                        <p><span class="icon"><i class="fa fa-check-circle"></i></span> <span class="text">Room Service </span></p>
                                    </div>
                                </div>
                                <!--facility-->
                            </div>
                        </div>
                        
                    </div>
                </div>

                <div class="panel panel-default overview">
                    <div class="panel-heading">
                        <h3 class="panel-title">Overview</h3>
                    </div>
                    <div class="panel-body">
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Repudiandae quas quae dolorem suscipit sunt fugit optio dignissimos. Laborum voluptates totam facilis, illo, officiis eligendi ad tempora mollitia, nobis dolorem sed, quidem! Praesentium eligendi autem consectetur itaque assumenda eius rem, deserunt, accusantium amet laboriosam hic, distinctio harum sunt porro illo ut.</p>
                         <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Repudiandae quas quae dolorem suscipit sunt fugit optio dignissimos. Laborum voluptates totam facilis, illo, officiis eligendi ad tempora mollitia, nobis dolorem sed, quidem! Praesentium eligendi autem consectetur itaque assumenda eius rem, deserunt, accusantium amet laboriosam hic, distinctio harum sunt porro illo ut.</p>
                    </div>
                </div>

            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Related Room</h3>
                    </div>
                    <div class="panel-body">
                          <article class="room">
                            <figure>
                                <div class="price">৳189 <span>/ night</span></div>
                                <a class="hover_effect h_blue h_link" href="room-details.aspx">
                                    <img src="https://www.eagle-themes.com/zantehotel/images/rooms/xdeluxe-room.jpg.pagespeed.ic.6tRvw-Rb2_.webp" class="img-responsive" alt="Image" data-pagespeed-url-hash="1599658418" onload="pagespeed.CriticalImages.checkImageForCriticality(this);"/>
                                </a>
                                <figcaption>
                                    <h4><a href="room-details.aspx">Delux Room</a></h4>
                                    <span class="f_right"><a href="room-details.aspx" class="button btn_sm btn_blue">VIEW DETAILS</a></span>
                                </figcaption>
                            </figure>
                        </article>

                    </div>
                </div>
            </div>
        </div>
    </div>
</section>


<br>

<br>

<script>
    $(function(){
        $('.thum').click(function(){
            var img=$(this).find('img').eq(0).attr('src');
            $('.view').find('img').eq(0).attr('src',img)
        })

        // var pano = $(".view").pano({
        //             img: $(".view img").eq(0).attr('src'),
        //             interval: 100,
        //             speed: 50
        //             });
            
        // pano.moveLeft();
        // pano.stopMoving();
        // pano.moveRight();
        // pano.stopMoving();
            
       
    })
</script>
</asp:Content>
