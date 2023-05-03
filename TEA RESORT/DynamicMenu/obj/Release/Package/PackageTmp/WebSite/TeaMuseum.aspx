<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/WebSiteMasterPage.Master" AutoEventWireup="true" CodeBehind="TeaMuseum.aspx.cs" Inherits="DynamicMenu.WebSite.TeaMuseum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<!-- header theme section start -->
<section class="headerThemeSection row-fluid animated fadeIn">
	<div id="subHeader">
		<h2>
			Tea Museum
		</h2>
	</div>
</section>
<!-- header theme section end -->
<br>
<section id="overview">
	<div class="container">
		<div class="row">
			<div class="row"> 
			    <div class="col-md-3">
			        <article class="room">
			            <figure>
			                <a class="hover_effect h_blue h_link">
			                    <img src="images/museum/1.jpg" class="img-responsive" alt="Image">
			                </a>
			                <figcaption>
			                    <h4><a href="room.html">Tea Class 1</a></h4>
			                </figcaption>
			            </figure>
			        </article>
			    </div>
			    <div class="col-md-3">
			        <article class="room">
			            <figure>
			                
			                <a class="hover_effect h_blue h_link">
			                    <img src="images/museum/2.jpg" class="img-responsive" alt="Image">
			                </a>
			                <figcaption>
			                    <h4><a href="room.html">Tea Class 2</a></h4>
			                    
			                </figcaption>
			            </figure>
			        </article>
			    </div>
			    <div class="col-md-3">
			        <article class="room">
			            <figure>
			                
			                <a class="hover_effect h_blue h_link">
			                    <img src="images/museum/3.jpg" class="img-responsive" alt="Image">
			                </a>
			                <figcaption>
			                    <h4><a href="room.html">Tea Class 3</a></h4>
			                    
			                </figcaption>
			            </figure>
			        </article>
			    </div>
				<div class="col-md-3">
			        <article class="room">
			            <figure>
			                
			                <a class="hover_effect h_blue h_link">
			                    <img src="images/museum/4.jpg" class="img-responsive" alt="Image">
			                </a>
			                <figcaption>
			                    <h4><a href="room.html">Tea Class 4</a></h4>
			                    
			                </figcaption>
			            </figure>
			        </article>
			    </div>
			   
			</div>
			<!-- row end -->
			
		</div>
	</div>
</section>
<br>

<br>
</asp:Content>
