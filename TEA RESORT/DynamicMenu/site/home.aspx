<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/hall.Master" CodeBehind="home.aspx.cs" Inherits="AdminPenalWatchCtg.site.home" %>

<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="AdminPenalWatchCtg" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="format-detection" content="telephone=no" />
    <link rel="icon" href="images/favicon.ico" type="image/x-icon">
    <title>Online Hall Booking System</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.css" rel="stylesheet">

    <!-- Links -->
    <link rel="stylesheet" href="css/search.css">
    <link href="css/font-awesome.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery-migrate-1.2.1.min.js"></script>
    <script src="js/rd-smoothscroll.min.js"></script>
    <script src='js/device.min.js'></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page">
        <main>        
      <section class="well well4"> 
        <div class="container center991">
          <h2>
            Top
            <small>
              Ranking Hall
            </small>
          </h2>  
                     <%
                         SqlConnection con = new SqlConnection(MyFunctions.connection);
                         con.Open();
                         SqlCommand cmd = new SqlCommand(@"SELECT     TOP 7 ROW_NUMBER() OVER ( order by COMUNAME) as serial,   COMUREG.SL, COMUREG.COMUID, 
CASE WHEN LEN(COMUREG.COMUNAME)>20 THEN  SUBSTRING(COMUREG.COMUNAME,0,20)+'...' ELSE COMUREG.COMUNAME END COMUNAME, 
CASE WHEN LEN(COMUREG.PARTICULAR)>80 THEN  SUBSTRING(COMUREG.PARTICULAR,0,80)+'...' ELSE COMUREG.PARTICULAR END PARTICULAR,
  COMUREG.DISTRICTID, DISTRICT.DISTRICTNM,
CASE WHEN ISNULL(IMAGEURL,'')='' THEN '' ELSE SUBSTRING(IMAGEURL,0,16) END IMAGEURL
FROM  COMUREG INNER JOIN DISTRICT ON COMUREG.DISTRICTID = DISTRICT.DISTRICTID WHERE (COMUREG.STATUS = 'A') AND ISNULL(IMAGEURL,'')<>''", con);
                         SqlDataReader dr = cmd.ExecuteReader();

                         foreach (var item in dr)
                         {
                             string id = dr["serial"].ToString();
                             string URL = "../site/cover/"+dr["IMAGEURL"].ToString();
                    %>
                    <%if (id == "1"){ %>
          <div class="row offs3">
             <%} %>
              <%if (id == "1")
                { %>
            <div class="col-md-4 col-sm-12 col-xs-12">
              <div class="thumbnail thumb-shadow">
                <img src='<% =URL  %>' style="height:370px; width:370px" alt="">
                <div class="caption bg3 capt_hover1" style="5px !important">
                  <h5>
                    <% =dr["COMUNAME"].ToString()  %>
                  </h5>
                  <div class="wrap">
                    <p> 
                         <%=dr["PARTICULAR"].ToString()%>
                    </p>
                     <p style="font-weight: bold; color: #681111; font-size: 10pt; text-decoration: underline">
                           <%=dr["DISTRICTNM"].ToString() %>
                      </p>
                    <a href="details?<%=dr["SL"].ToString() %>" class="btn-link fa-angle-right"></a>
                  </div>  
                </div>
              </div>              
            </div>
                <%}
                if (id == "2")
                { %> 
            <div class="col-md-8 col-sm-12 col-xs-12">
              <div class="thumbnail thumb-shadow">
                 <img src='<% =URL  %>'  style="height:370px; width:770px"  alt="">
                <div class="caption bg3 capt_hover1">
                  <h5> 
                      <% =dr["COMUNAME"].ToString()  %>
                  </h5>
                  <div class="wrap">
                    <p class="thumb_ins1"> 
                         <%=dr["PARTICULAR"].ToString()%>
                    </p>
                      <p style="font-weight: bold; color: #681111; font-size: 10pt; text-decoration: underline">
                          <%=dr["DISTRICTNM"].ToString() %>
                      </p>
                   <a href="details?<%=dr["SL"].ToString() %>" class="btn-link fa-angle-right"></a>
                  </div>  
                </div>
              </div> 
            </div>
              <%} %>
                <%if (id == "2"){ %>
          </div>
             <%} %>
          
            <%if (id == "3"){ %>
          <div class="row">
             <%} %> 
               <%if (id == "3")
                 { %> 
            <div class="col-md-4 col-sm-12 col-xs-12">
              <div class="thumbnail thumb-shadow">
                <img src='<% =URL  %>'  style="height:370px; width:370px" alt="">
                <div class="caption bg3 capt_hover1">
                  <h5> 
                       <% =dr["COMUNAME"].ToString()  %>
                  </h5>
                  <div class="wrap">
                    <p> 
                         <%=dr["PARTICULAR"].ToString()%>
                    </p>
                     <p style="font-weight: bold; color: #681111; font-size: 10pt; text-decoration: underline">
                          <%=dr["DISTRICTNM"].ToString() %>
                      </p>
                    <a href="details?<%=dr["SL"].ToString() %>" class="btn-link fa-angle-right"></a>
                  </div>  
                </div>
              </div>         
            </div> <%}
                 if (id == "4")
                 { %> 
            <div class="col-md-4 col-sm-12 col-xs-12">
              <div class="thumbnail thumb-shadow">
                <img src='<% =URL %>'  style="height:370px; width:370px" alt="">
                <div class="caption bg3 capt_hover1">
                  <h5> 
                       <% =dr["COMUNAME"].ToString()  %>
                  </h5>
                  <div class="wrap">
                    <p> 
                         <%=dr["PARTICULAR"].ToString()%>
                    </p>
                     <p style="font-weight: bold; color: #681111; font-size: 10pt; text-decoration: underline">
                          <%=dr["DISTRICTNM"].ToString() %>
                      </p>
                   <a href="details?<%=dr["SL"].ToString() %>" class="btn-link fa-angle-right"></a>
                  </div>  
                </div>
              </div>              
            </div>
              <%}
                 if (id == "5")
                 { %> 
            <div class="col-md-4 col-sm-12 col-xs-12">
              <div class="thumbnail thumb-shadow">
                 <img src='<% =URL  %>'   style="height:370px; width:370px" alt="">
                <div class="caption bg3 capt_hover1">
                  <h5> 
                        <% =dr["COMUNAME"].ToString()  %>
                  </h5>
                  <div class="wrap">
                    <p> 
                        <%=dr["PARTICULAR"].ToString()%>
                    </p>
                     <p style="font-weight: bold; color: #681111; font-size: 10pt; text-decoration: underline">
                           <%=dr["DISTRICTNM"].ToString() %>
                      </p>
                    <a href="details?<%=dr["SL"].ToString() %>" class="btn-link fa-angle-right"></a>
                  </div>  
                </div>
              </div>              
            </div>
              <%} %>
            <%if (id == "5"){ %>
          </div>
             <%} %> 
             <%if (id == "6"){ %>
         <div class="row">
             <%} %> 
          
              <%if (id == "6")
                { %> 
            <div class="col-md-4 col-sm-12 col-xs-12">
              <div class="thumbnail thumb-shadow">
                 <img src='<% =URL  %>'  style="height:370px; width:370px" alt="">
                <div class="caption bg3 capt_hover1">
                  <h5> 
                       <% =dr["COMUNAME"].ToString()  %>
                  </h5>
                  <div class="wrap">
                    <p> 
                        <%=dr["PARTICULAR"].ToString()%>
                    </p>
                      <p style="font-weight: bold; color: #681111; font-size: 10pt; text-decoration: underline">
                          <%=dr["DISTRICTNM"].ToString() %>
                      </p>
                    <a href="details?<%=dr["SL"].ToString() %>" class="btn-link fa-angle-right"></a>
                  </div>  
                </div>
              </div>           
            </div>
              <%}
                if (id == "7")
                { %> 
            <div class="col-md-8 col-sm-12 col-xs-12">
              <div class="thumbnail thumb-shadow">
                 <img src='<% =URL  %>'  style="height:370px; width:770px"  alt="">
                <div class="caption bg3 capt_hover1">
                  <h5> 
                        <% =dr["COMUNAME"].ToString()  %>
                  </h5>
                  <div class="wrap">
                    <p class="thumb_ins1"> 
                        <%=dr["PARTICULAR"].ToString()%>
                    </p>
                      <p style="font-weight: bold; color: #681111; font-size: 10pt; text-decoration: underline">
                          <%=dr["DISTRICTNM"].ToString() %>
                      </p>
                    <a href="details?<%=dr["SL"].ToString() %>" class="btn-link fa-angle-right"></a>
                  </div>  
                </div>
              </div> 
            </div>
              <%} %> 
             <%if (id == "7"){ %>
          </div>
             <%} %> 
                    <%} %> 
        </div>  
      </section>
      
      <section class="well well2 bg1">
        <div class="container">
        <h2>
        special
          <small>
            offer
          </small>
        </h2>
          <div class="row offs1">
            <div class="col-md-6 col-sm-12">
              <p>
                Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt. Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
              </p>
            </div>
            <div class="col-md-6 col-sm-12">
              <p>
                Ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt. Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                <a href="#" class="btn-link l-h1 fa-angle-right"></a>
              </p>
            </div>
          </div>
        </div>
      </section>

    </main>

        <!--========================================================
                            FOOTER
  =========================================================-->
        <footer>
            <section class="well1">
                <div class="container">
                    <p class="rights">
                        Business Company &#169; <span id="copyright-year"></span>
                        <a href="index-5.html">Privacy Policy</a>
                    </p>
                </div>
            </section>
        </footer>
    </div>



    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <script src="js/tm-scripts.js"></script>
    <!-- </script> -->


</asp:Content>

