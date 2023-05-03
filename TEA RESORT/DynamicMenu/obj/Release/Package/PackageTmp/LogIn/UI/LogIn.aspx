<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="DynamicMenu.LogIn.UI.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="Sergey Pozhilov (GetTemplate.com)" />
    <script src="../assets/js/jquery-2.1.3.js"></script>
    <script src="../../MenuCssJs/js/session.js"></script>
    <script src="../assets/js/bootstrap.min.js"></script>
   
    <title>Sign in</title>
    <script>
        $(document).ready(function () {
            $('#<%=txtlink.ClientID%>').val($.session.get('URLLINK'));
            $.getJSON("https://api.ipify.org/?format=json",
                function (data) {
                    $("#<%=txtIp.ClientID %>").val(data.ip);
                });
            
        });
        $(function() {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
    <link rel="shortcut icon" href="../assets/images/favicon.ico" />

    <link rel="stylesheet" media="screen" href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,700" />
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/css/font-awesome.min.css" />

    <!-- Custom styles for our template -->
    <link rel="stylesheet" href="../assets/css/bootstrap-theme.css" media="screen" />
    <link rel="stylesheet" href="../assets/css/main.css" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="script1"></asp:ScriptManager>
        <!-- Fixed navbar -->

        <div class="navbar navbar-inverse navbar-fixed-top headroom" style="background: #F3D218">
            <div class="container">
                <div class="navbar-header">
                    <!-- Button for smallest screens -->
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse"><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                    <a class="navbar-brand" href="http://alchemy-bd.com" data-toggle="tooltip" data-placement="bottom" title="Vist our web site">
                        <%--<img src="../assets/images/logo.png" alt="Progressus HTML5 template" />--%>
                        <span class="header">TEA RESORT & MUSEUM</span>
                    </a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav pull-right">
                        <%--<li><a href="#">Home</a></li>
                        <li><a href="#">About</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">More Pages <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a href="#">Menu 1</a></li>
                                <li><a href="#">Menu 2</a></li>
                            </ul>
                        </li>
                        <li><a href="#">Contact</a></li>--%>
                        <li class="active"><a class="btn" href="#">SIGN IN</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </div>
        <!-- /.navbar -->

        <header id="head" class="secondary"></header>

        <!-- container -->
        <div class="container">

            <div class="row">

                <!-- Article main content -->
                <article class="col-xs-12 maincontent">
                    <%--<header class="page-header">
					<h1 class="page-title">Sign in</h1>
				</header>--%>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <asp:TextBox runat="server" Style="display: none" ID="txtIp" ClientIDMode="Static"></asp:TextBox>
                            <div class="col-md-4 col-md-offset-4 col-sm-8 col-sm-offset-2" style="padding-top: 10px">
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <h3 class="thin text-center">Sign in to your account</h3>

                                        <hr />
                                        <asp:TextBox runat="server" Style="display: none" ID="txtLotiLongTude"></asp:TextBox>

                                        <div class="top-margin">
                                            <label>Username/Email <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtUser" type="text" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="top-margin">
                                            <label>Password <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtPassword" type="password" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="text-center; top-margin">
                                            <asp:Label runat="server" ID="lblMsg" Visible="False" ForeColor="red"></asp:Label>
                                        </div>
                                        <asp:TextBox ID="txtlink" ClientIDMode="Static" Style="display: none" class="form-control" runat="server"></asp:TextBox>
                                        
                                        <div>
                                            <asp:CheckBox runat="server" ID="checkRememebrMe"  Text="&nbsp; Remember my user name and password."/>
                                        </div>
                                        <hr />
                                        <div class="row">
                                            <%--  <div class="col-lg-6">
                                                <b><a href="#">Forgot password?</a></b>
                                            </div>--%>
                                            <div class="col-lg-12 text-center">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-action" type="submit" Text="Sign in" OnClick="btnSubmit_Click"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </article>
                <!-- /Article -->

            </div>
        </div>
        <!-- /container -->


        <footer id="footer" class="top-space">

            <div class="footer1">
                <div class="container">
                    <div class="row">

                        <div class="col-md-3 widget">
                            <h3 class="widget-title">Corporate Office</h3>
                            <div class="widget-body">
                                <p>
                                 Executive in-Charge +8801712-071502 <br>
                                 Supervisor +8801712-916001 <br>
                                 Booking Asst: +8801749-014306
                                   <br>
                                    <a href="mailto:#">tearesort@yahoo.com </a>
                                    <br>
                                   Bangladesh Tea Board, 
                                    Srimongal, Moulvibazar.
                                </p>
                            </div>
                        </div>
                        <div class="col-md-1 widget">
                        </div>
                        <div class="col-md-3 widget">
                            <%--<h3 class="widget-title">Chittagong Office</h3>
                            <div class="widget-body">
                                <p>
                                    +880-1925 444999, +880-1816 910849<br>
                                    <a href="mailto:#">alchemysoftware@yahoo.com</a><br>
                                    <br>
                                    1047, O.R. Nizam Road,
                                    <br>
                                    Suborna R/A, Chittagong-4000, Bangladesh.
                                </p>
                            </div>--%>
                        </div>
                        <div class="col-md-2 widget">
                        </div>

                        <div class="col-md-3 widget">
                            <h3 class="widget-title">Follow Us</h3>
                            <div class="widget-body">
                                <p id="social-icons">
                                    <a href="https://www.facebook.com/tea.resort/?rf=460723427381511" target="_blank">
                                        <i data-toggle="tooltip" data-placement="top" title="Like Us" class="fa fa-facebook fa-2x"></i>
                                    </a>
                                    <a href="#" target="_blank">
                                        <i data-toggle="tooltip" data-placement="top" title="Follow Us" class="fa fa-twitter fa-2x"></i>
                                    </a>
                                    <a href="#" target="_blank">
                                        <i data-toggle="tooltip" data-placement="top" title="Add Us" class="fa fa-google-plus fa-2x"></i>
                                    </a>
                                    <a href="#" target="_blank">
                                        <i data-toggle="tooltip" data-placement="top" title="Subscribe Us" class="fa fa-youtube fa-2x"></i>
                                    </a>
                                    <a href="#" target="_blank">
                                        <i data-toggle="tooltip" data-placement="top" title="alchemysoftware.ltd" class="fa fa-skype fa-2x"></i>
                                    </a>

                                </p>

                                <p>
                                    Copyright &copy; <%=DateTime.Now.Year %>, Alchemy Software<br />
                                    Developed by <a href="http://alchemy-bd.com/" rel="designer">Alchemy Software</a>
                                </p>
                            </div>
                        </div>

                    </div>
                    <!-- /row of widgets -->
                </div>
            </div>


        </footer>





        <!-- JavaScript libs are placed at the end of the document so the pages load faster -->


        <script>
            $(document).ready(function () {
                navigator.geolocation.getCurrentPosition(showPosition);
                function showPosition(position) {
                    var coordinates = position.coords;
                    var long = coordinates.longitude;
                    var loti = coordinates.latitude;
                    $("#<%=txtLotiLongTude.ClientID %>").val(loti + ", " + long);

                }
            });
        </script>
    </form>
</body>
</html>
