<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/WebSiteMasterPage.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="DynamicMenu.WebSite.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../MenuCssJs/ui-gray/jquery-ui.css" rel="stylesheet" />
    <script src="../MenuCssJs/js/jquery-2.1.3.js"></script>
    <script src="/MenuCssJs/js/angular.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.2.0rc1/angular-route.min.js"></script>
    <script src="../MenuCssJs/js/jquery-ui.js"></script>
    <script src="../MenuCssJs/js/Controler.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            // loaddata();

            //var TestCtrl = function ($scope, $http) {
            //    $scope.firstCall = function () {
            //        $http({
            //                url: "/search.asmx/ShowNewsFeed",
            //                dataType: 'json',
            //                method: 'POST',
            //                headers: {
            //                    "Content-Type": "application/json"
            //                }
            //            }).success(function (response) {
            //                debugger;
            //                $scope.NewsList = response;
            //            })
            //            .error(function (error) {
            //                alert(error);
            //            });
            //    }
            //}
        });
        function loaddata() {
            $.ajax({
                url: "/search.asmx/ShowNewsFeed",
                contentType: "application/json; charset=utf-8;",
                type: "POST",
                dataType: "json",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    var html = "";
                    $("#newsbody").empty();
                    $.each(data.d, function (index, element) {
                        html += "<div class='media'><div class='media-left media-top'><a href='" + element.FileName + "' target='_blank'>";
                        html += "<img class='media-object' src='" + element.FileName + "' style='height: 80px; width: 80px' alt=''/></a></div>";
                        html += "<div class='media-body'><h4>" + element.Title + "</h4>";
                        html += "<p><small>Post on:" + element.Date + "</small></p>";
                        html += "</div></div><p style='text-align: justify;'>" + element.Descrition + " </p> <br>";
                    });
                    $("#newsbody").append(html);
                },
                error: function (result) {
                    alert(result.responseText);
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- header theme section start -->
    <section class="headerThemeSection row-fluid animated fadeIn">
        <div id="subHeader">
            <h2>News
            </h2>
        </div>
    </section>
    <!-- header theme section end -->
    <br>
    

    <section ng-app="myApp">

        <div class="container">


            <div class="row" ng-controller="NewsFeed" ng-init="NewsData()">
                <!--single-->
                <div class="col-md-12" id="newsbody">
                    <div class="media" ng-repeat="newsdata in NewsList">
                        <div class="media-left media-top">
                            <a ng-href="{{newsdata.FileName}}" target="_blank">
                                <img class="media-object" ng-src="{{newsdata.FileName}}" style="height: 50px; width: 50px" alt="" />
                            </a>
                        </div>
                        <div class="media-body">
                            <h4>{{newsdata.Title}}</h4>
                            <p><small>Post on: {{newsdata.Date}}</small></p>

                        </div>
                        <p style="text-align: justify">{{newsdata.Descrition}}</p>
                    </div>

                </div>
                <!--single-->
            </div>
        </div>
    </section>
    <br>
</asp:Content>
