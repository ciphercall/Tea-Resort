<%@ Page Title="" Language="C#" MasterPageFile="~/site/hall.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="AdminPenalWatchCtg.site.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="format-detection" content="telephone=no" />
    <link rel="icon" href="images/favicon.ico" type="image/x-icon">
    <title>ABOUT</title>
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/search.css">
    <link rel="stylesheet" href="css/jquery.fancybox.css">
    <script src="js/jquery.js"></script>
    <script src="js/jquery-migrate-1.2.1.min.js"></script>
    <script src="js/rd-smoothscroll.min.js"></script>
    <script src='js/device.min.js'></script>
    <script src="js/jquery.cookie.js"></script>
    <style>
        /*.fxd {
            position: fixed;
            top: 188px;
            left: 0px;
            width: 72px;
            height: 200px;
            background-color: #CCFF00;
            border: 1px solid red;
            z-index: 10;
        }*/
    </style>

    <script>
        $(document).ready(function () {
            $('#Test').click(function () {
                alert($.cookie('CommunityID'));
                $.cookie('CommunityID', '', { expires: -1, path: '/' });
                $.cookie('cInfo', '', { expires: -1, path: '/' });
                alert($.cookie('CommunityID'));
            })
            // Handler for .ready() called.
            if ($('#ImageUpload').css('display') == 'none') {
                $('html, body').animate({
                    scrollTop: $('#stuck_container').offset().top
                }, 'slow');
            }
        });
        function clossImg(ids) {
            var imgID = (ids.id).substring(6, 7);// clsImg1 
            $('#img' + imgID).fadeOut(200);
            SubmitbtnShow();
        }
        $(document).ready(function () {
            $('#img1,#img2,#img3,#img4,#img5,#img6,#img7,#img8').hide();
            $('#loading2,#loadingX').hide();
            $('#addphoto').click(function () {
                $('#inTag').click();
            })
            function SubmitbtnShow() {
                for (var i = 1; i < 9; i++)
                    if ($('#img' + i).css('display') != 'none') {
                        $('#PhotoAdd').show();
                        break;
                    }
                    else
                        $('#PhotoAdd').hide();
            }
            $(function () {
                $('#inTag').on('change', function () {
                    var input = $(this)[0];
                    var file = input.files[0];
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        var fileExtension = ['jpg', 'png', 'gif'];
                        if ($.inArray($('#inTag').val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                            alert("Only formats are allowed : " + fileExtension.join(', '));
                        } else {
                            var rand = Math.floor(Math.random() * (600 - 100 + 1)) + 100;
                            $('#loading2').show();
                            setTimeout(function () {
                                $('#loading2').hide();

                                var i = '';
                                if ($('#img1').css('display') == 'none') {
                                    $('html, body').animate({
                                        scrollTop: $('#stuck_container').offset().top
                                    }, 'slow');
                                    $('#img1').show();
                                    $('#imgs1').attr('src', e.target.result);
                                    var file1 = document.querySelector('#inTag');
                                    var file2 = document.querySelector('#inTag1');
                                    file2.files = file1.files;
                                    i = 1;
                                }
                                else if ($('#img2').css('display') == 'none') {
                                    $('html, body').animate({
                                        scrollTop: $('#stuck_container').offset().top
                                    }, 'slow');
                                    $('#img2').show();
                                    $('#imgs2').attr('src', e.target.result);
                                    var file1 = document.querySelector('#inTag');
                                    var file2 = document.querySelector('#inTag2');
                                    file2.files = file1.files;
                                    i = 2;
                                }
                                else if ($('#img3').css('display') == 'none') {
                                    $('html, body').animate({
                                        scrollTop: $('#stuck_container').offset().top
                                    }, 'slow');
                                    $('#img3').show();
                                    $('#imgs3').attr('src', e.target.result);
                                    var file1 = document.querySelector('#inTag');
                                    var file2 = document.querySelector('#inTag3');
                                    file2.files = file1.files;
                                    i = 3;
                                }
                                else if ($('#img4').css('display') == 'none') {
                                    $('html, body').animate({
                                        scrollTop: $('#stuck_container').offset().top
                                    }, 'slow');
                                    $('#img4').show();
                                    $('#imgs4').attr('src', e.target.result);
                                    var file1 = document.querySelector('#inTag');
                                    var file2 = document.querySelector('#inTag4');
                                    file2.files = file1.files;
                                    i = 4;
                                }
                                else if ($('#img5').css('display') == 'none') {
                                    $('#img5').show();
                                    $('#imgs5').attr('src', e.target.result);
                                    var file1 = document.querySelector('#inTag');
                                    var file2 = document.querySelector('#inTag5');
                                    file2.files = file1.files;
                                    i = 5;
                                }
                                else if ($('#img6').css('display') == 'none') {
                                    $('#img6').show();
                                    $('#imgs6').attr('src', e.target.result);
                                    var file1 = document.querySelector('#inTag');
                                    var file2 = document.querySelector('#inTag6');
                                    file2.files = file1.files;
                                    i = 6;
                                }
                                else if ($('#img7').css('display') == 'none') {
                                    $('#img7').show();
                                    $('#imgs7').attr('src', e.target.result);
                                    var file1 = document.querySelector('#inTag');
                                    var file2 = document.querySelector('#inTag7');
                                    file2.files = file1.files;
                                    i = 7;
                                }
                                else {
                                    $('#img8').show();
                                    $('#imgs8').attr('src', e.target.result);
                                    var file1 = document.querySelector('#inTag');
                                    var file2 = document.querySelector('#inTag8');
                                    file2.files = file1.files;
                                    i = 8;
                                }
                                SubmitbtnShow();
                                $('#imgs' + i).css('width', '270px');
                                $('#imgs' + i).css('height', '270px');
                            }, rand);
                        }
                    }
                    reader.readAsDataURL(file);

                });
            });
        })
    </script>
    <script>
        function ImageUpload() {
            var data = new FormData();

            for (var d = 1; d < 9; d++) {
                var files = $("#inTag" + d).get(0).files;
                if (files.length > 0) {
                    data.append("Upload" + d, files[0]);
                }
            }
            $.ajax({
                type: 'POST',
                url: "fight.asmx/UploadFile",
                processData: false,
                contentType: false,
                data: data,
                success: function (response) {
                    $("#messages").fadeIn(500);
                    $("#ImageUpload").fadeOut(500);
                    $("#information").fadeOut(500);
                },
                error: function (result) {
                }
            });

        }

        $(document).ready(function () {
            $('#Refresh').on('click', function () {
                _doPostBack();
            });
            $('#district').change(function () {
                var disID = $("#district").val();
                $.ajax({
                    type: "POST",
                    url: "fight.asmx/LoadLocation",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: "{x: '" + disID + "'}",
                    success: function (response) {
                        $("#area").empty();
                        $("#area").append($("<option value=''>--SELECT--</option>"));
                        $.each(response.d, function (key, value) {
                            $("#area").append($("<option></option>").val(this['Value']).html(this['Text']));
                        });
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            })
            //$('#ImageUpload').show();
            $('#messages,#PhotoAdd').hide();
            // $('#PhotoAdd').show();
            $('#close').hide();
            $('#close').click(function () {
                $('#messages').fadeOut(500);
                $('#close').fadeOut(500);
            })
            $.ajax({
                type: "POST",
                url: "fight.asmx/LoadDistricts",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "{x: 'x'}",
                success: function (response) {
                    $("#district").empty();
                    $("#district").append($("<option value=''>--SELECT--</option>"));
                    $.each(response.d, function (key, value) {
                        $("#district").append($("<option></option>").val(this['Value']).html(this['Text']));
                    });

                },
                failure: function (response) {
                    alert(response.d);
                }
            });

            $('#addTotalInfo').click(function () {
                var communityID = '';
                $.ajax({
                    type: "POST",
                    url: "fight.asmx/cID",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: "{x: 'x'}",
                    success: function (data) {
                        communityID = data.d
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
                var HallName = $('#HallName').val();
                var HallSName = $('#HallSName').val();
                var HallYourNM = $('#HallYourNM').val();
                var HallAddress = $('#HallAddress').val();
                var district = $('#district').val();
                var area = $('#area').val();
                var HallParticular = $('#HallParticular').val();
                var HallSContact = $('#HallSContact').val();
                var HallOwnerContact = $('#HallOwnerContact').val();
                var HallSMail = $('#HallSMail').val();
                var HallWeb = $('#HallWeb').val();
                var HallPriceHall = $('#HallPriceHall').val();
                var HallPriceOther = $('#HallPriceOther').val();
                var priceNegot = $('#priceNegot').val();
                var priceOtherNegot = $('#priceOtherNegot').val();
                var HallOtherPriceDes = $('#HallOtherPriceDes').val();
                var Pass = $('#Pass').val();
                var ConPass = $('#ConPass').val();
                var e = $('#txtLotiLongTude').val();
                var HallPostal = $('#HallSPostal').val();
                var cc = HallName + "|" + HallSName + "|" + HallAddress + "|" + district + "|" + area + "|" + HallParticular + "|" + HallSContact
                    + "|" + HallOwnerContact + "|" + HallSMail + "|" + HallWeb + "|" + HallPriceHall + "|" + HallPriceOther + "|" + priceNegot + "|"
                    + priceOtherNegot + "|" + HallOtherPriceDes + "|" + Pass + "|" + ConPass + "|" + e + "|" + HallPostal + "|" + HallYourNM;

                $.ajax({
                    type: "POST",
                    url: "fight.asmx/IN",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: "{x: '" + cc + "'}",
                    success: function (data) {
                        if (data.d == 'true') {
                            $('#names').val('Hi ! ' + HallYourNM); $('#communitys').val(HallName);
                            $.cookie('cInfo', cc, { expires: 9999, path: '/' });
                            $('#information').fadeOut(400);
                            $('#ImageUpload').fadeIn(400);
                            $('html, body').animate({
                                scrollTop: $('#stuck_container').offset().top
                            }, 'slow');
                            $('#check').fadeIn(5600);
                            $('#close').fadeIn(600);
                            $('#HallName,#HallSName,#HallAddress,#HallYourNM,#district,#area,#HallParticular,#HallSContact,#HallOwnerContact').val('');
                            $('#HallSMail,#HallWeb,#HallPriceHall,#HallPriceOther,#priceNegot,#priceOtherNegot,#HallOtherPriceDes').val('');
                            //$('#img1,#img2,#img3,#img4,#img5,#img6,#img7,#img8').hide();
                            //$('#clsImg1,#clsImg2,#clsImg3,#clsImg4,#clsImg5,#clsImg6,#clsImg7,#clsImg8').hide();

                        }
                        else if (data.d == 'false')
                            alert('failed please try again.')
                        else
                            alert(data.d);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });

            });
        });


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Test">Test</div>
    <div class="page">
        <div id="messages">
            <br />
            <div class="alert alert-info alert-dismissable">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Success!</strong> Your information has been submitted successfully.
            </div>
            <div class="btn-wr text-primary" style="width: 100%">
                <a class="btn btn-primary" id="Refresh" data-type="submit" style="width: 100%; text-align: center; margin-top: 2px"><i class="fa fa-check"></i>&nbsp;&nbsp;Refresh</a>

            </div>
        </div>
        <section class="well well4 bg1 wow fadeIn" data-wow-duration='3s' id="ImageUpload" >
            <div class="container">
                <h3>Photo's 
                    <small>Of Your Community Hall
                    </small>
                </h3>
                <div class="btn-wr text-primary" style="width: 100%">
                    <a class="btn btn-primary" id="addphoto" data-type="submit" style="width: 100%; text-align: center; margin-top: 2px"><i class="fa fa-plus"></i>&nbsp;&nbsp;Add Photos</a>
                    <div id="loading2" style="text-align: center; margin-top: -67px; margin-left: -260px;">
                        <img width="50px" src="images/loading.gif" alt="loading" />
                    </div>
                    <input name="inTag" id="inTag" type="file" class="hidden" />
                    <input name="inTag1" id="inTag1" type="file" class="hidden" />
                    <input name="inTag2" id="inTag2" type="file" class="hidden" />
                    <input name="inTag3" id="inTag3" type="file" class="hidden" />
                    <input name="inTag4" id="inTag4" type="file" class="hidden" />
                    <input name="inTag5" id="inTag5" type="file" class="hidden" />
                    <input name="inTag6" id="inTag6" type="file" class="hidden" />
                    <input name="inTag7" id="inTag7" type="file" class="hidden" />
                    <input name="inTag8" id="inTag8" type="file" class="hidden" />
                </div>
                <asp:Label ID="lblCommunityIDD" runat="server" Visible="false"></asp:Label>
                <div class="row offs3 center767">
                    <div class="col-md-3 col-sm-6 col-xs-12" id="img5">
                        <div class="thumbnail thumb-shadow">
                            <div style="float: right; margin-bottom: -15px; margin-right: -6px;"><i class="fa fa-times hand" id="clsImg5" onclick="clossImg(this)"></i></div>
                            <img id="imgs5" alt="">
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12" id="img6">
                        <div class="thumbnail thumb-shadow">
                            <div style="float: right; margin-bottom: -15px; margin-right: -6px;"><i class="fa fa-times hand" id="clsImg6" onclick="clossImg(this)"></i></div>
                            <img id="imgs6" alt="">
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12" id="img7">
                        <div class="thumbnail thumb-shadow">
                            <div style="float: right; margin-bottom: -15px; margin-right: -6px;"><i class="fa fa-times hand" id="clsImg7" onclick="clossImg(this)"></i></div>
                            <img id="imgs7" alt="">
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12" id="img8">
                        <div class="thumbnail thumb-shadow">
                            <div style="float: right; margin-bottom: -15px; margin-right: -6px;"><i class="fa fa-times hand" id="clsImg8" onclick="clossImg(this)"></i></div>
                            <img id="imgs8" alt="">
                        </div>
                    </div>
                </div>
                <div class="row offs3 center767">
                    <div class="col-md-3 col-sm-6 col-xs-12" id="img1">
                        <div class="thumbnail thumb-shadow">
                            <div style="float: right; margin-bottom: -15px; margin-right: -6px;"><i class="fa fa-times hand" id="clsImg1" onclick="clossImg(this)"></i></div>
                            <img id="imgs1" alt="">
                            <div class="caption bg3 capt_hover1 paddintLess" style="background: rgba(169, 68, 66, 0.38) !important">
                                <h4 style="display: inline-block;">Front Image </h4>
                                <%--<div class="wrap"> 
                                    <a href="#" class="btn-link fa-angle-right"></a>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12" id="img2">
                        <div class="thumbnail thumb-shadow">
                            <div style="float: right; margin-bottom: -15px; margin-right: -6px;"><i class="fa fa-times hand" id="clsImg2" onclick="clossImg(this)"></i></div>
                            <img id="imgs2" alt="">
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12" id="img3">
                        <div class="thumbnail thumb-shadow">
                            <div style="float: right; margin-bottom: -15px; margin-right: -6px;"><i class="fa fa-times hand" id="clsImg3" onclick="clossImg(this)"></i></div>
                            <img id="imgs3" alt="">
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6 col-xs-12" id="img4">
                        <div class="thumbnail thumb-shadow">
                            <div style="float: right; margin-bottom: -15px; margin-right: -6px;"><i class="fa fa-times hand" id="clsImg4" onclick="clossImg(this)"></i></div>
                            <img id="imgs4" alt="">
                        </div>
                    </div>

                </div>
                <div class="btn-wr text-primary" style="width: 100%">
                    <a class="btn btn-primary" id="PhotoAdd" onclick="ImageUpload()" data-type="submit" style="width: 100%; text-align: center; margin-top: 2px"><i class="fa fa-check"></i>&nbsp;&nbsp;SUBMIT</a>
                    <div id="loadingX" style="text-align: center; margin-top: -67px; margin-left: -260px;">
                        <img width="50px" src="images/loading.gif" alt="loading" />
                    </div>
                </div>
            </div>
        </section>
        <section class="well well5" style="padding-top: 0px" id="information">
            <div class="container">
                <h3>Community 
                    <small>Profile Create
                    </small>
                </h3>
                <div class="row">
                    <div class="col-md-12 all0">
                        <div class="col-md-4 ">
                            <div class="row" style="margin-top: 8px;">
                                <div class="col-md-9">
                                    <p style="font-size: 8pt">Community Hall Name</p>
                                    <input type="text" id="HallName" style="width: 100%" name="name" placeholder=" Community Hall Name" value="" />
                                </div>
                                <div class="col-md-3">
                                    <p style="font-size: 8pt">Short Name</p>
                                    <input type="text" id="HallSName" style="width: 100%" name="name" placeholder="S. Name" value="" />
                                </div>
                            </div>
                            <div class="row" style="margin-top: 8px;">
                                <div class="col-md-12">
                                    <p style="font-size: 8pt">Your Name</p>
                                    <input id="HallYourNM" style="width: 100%;" name="name" placeholder="Your Name" />
                                </div>
                            </div>
                            <div class="row" style="margin-top: 8px;">
                                <div class="col-md-12">
                                    <p style="font-size: 8pt">Address</p>
                                    <textarea id="HallAddress" rows="8" style="width: 100%; height: 165px" name="name" placeholder="Type Community Hall Address..."></textarea>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 8px;">
                                <div class="col-md-4">
                                    <p style="font-size: 8pt">District</p>
                                    <select style="width: 100%" id="district">
                                    </select>
                                </div>
                                <div class="col-md-4">
                                    <p style="font-size: 8pt">Area</p>
                                    <select style="width: 100%" id="area">
                                    </select>
                                </div>
                                <div class="col-md-4">
                                    <p style="font-size: 8pt">Pstal Code</p>
                                    <input type="text" id="HallSPostal" style="width: 100%; height: 22px;" name="name" placeholder="Contact" value="" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row" style="margin-top: 8px;">
                                <div class="col-md-12">
                                    <p style="font-size: 8pt">Particulars</p>
                                    <textarea id="HallParticular" rows="12" style="width: 100%; height: 336px;" name="name" placeholder="Type Particulars ...."></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row" style="margin-top: 6px;">
                                <div class="col-md-6">
                                    <p style="font-size: 8pt">Contact</p>
                                    <input type="text" id="HallSContact" style="width: 100%" name="name" placeholder="01XXXXXXXXX" value="" />
                                </div>
                                <div class="col-md-6">
                                    <p style="font-size: 8pt">Owner Contact</p>
                                    <input type="text" id="HallOwnerContact" style="width: 100%" name="name" placeholder="01XXXXXXXXX" value="" />
                                </div>
                            </div>
                            <div class="row" style="margin-top: 0px;">
                                <div class="col-md-12">
                                    <p style="font-size: 8pt">Email</p>
                                    <input type="text" id="HallSMail" style="width: 100%" name="name" placeholder="XXX@host.com" value="" />
                                </div>

                            </div>
                            <div class="row" style="margin-top: 0px;">
                                <div class="col-md-12">
                                    <p style="font-size: 8pt">Web ID</p>
                                    <input type="text" id="HallWeb" style="width: 100%" name="name" placeholder="www.xxxx.com" value="" />
                                </div>
                            </div>
                            <div class="row" style="margin-top: 0px;">
                                <div class="col-md-6">
                                    <p style="font-size: 8pt; display: inline-block;">Price (Hall)</p>
                                    <div style="font-size: 8pt; float: right; display: inline-block;">
                                        <input id="priceNegot" type="checkbox" />Negotiable
                                    </div>
                                    <input type="text" id="HallPriceHall" style="width: 100%" name="name" placeholder="Cost/=" value="" />
                                </div>
                                <div class="col-md-6">
                                    <p style="font-size: 8pt; display: inline-block;">Price (Other)</p>
                                    <div style="font-size: 8pt; float: right; display: inline-block;">
                                        <input id="priceOtherNegot" type="checkbox" />Negotiable
                                    </div>
                                    <input type="text" id="HallPriceOther" style="width: 100%" name="name" placeholder="Cost/=" value="" />
                                </div>
                            </div>
                            <div class="row" style="margin-top: 4px;">
                                <div class="col-md-12">
                                    <textarea id="HallOtherPriceDes" rows="0" cols="0" style="width: 100%; height: 78px" name="name" placeholder="Why Other price ...."></textarea>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 0px;">
                                <div class="col-md-6">
                                    <p style="font-size: 8pt; display: inline-block;">Pasword</p>
                                    <input type="text" id="Pass" style="width: 100%" name="name" placeholder="Pasword" value="" />
                                </div>
                                <div class="col-md-6">
                                    <p style="font-size: 8pt; display: inline-block;">Confirm Password</p>
                                    <input type="text" id="ConPass" style="width: 100%" name="name" placeholder="Confirm Password</" value="" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="btn-wr text-primary" style="width: 100%">
                            <a class="btn btn-primary" id="addTotalInfo" data-type="submit" style="width: 100%; text-align: center; margin-top: -24px"><i class="fa fa-check" id="check">&nbsp;&nbsp;</i>SAVE & CONTINUE</a>

                        </div>
                    </div>
                </div>
            </div>
        </section>


        <section class="well well4">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-sm-12 col-xs-12">
                        <h2>advantages  
                        </h2>
                        <ul class="index-list">
                            <li>Quisque in metus nibh. In hac habit asse platea dictumst. Curabitur eu lor em ac lacus laoreet 
                            </li>
                            <li>Fusce vitae orci nec velit ornare rh
                  oncus ut tempus est. Mauris eu augue lorem. Suspendisse sit am
                            </li>
                            <li>Curabitur eu lor em ac lacus lao
                  reet auctor. Fusce vitae orci nec velit ornare rhoncus ut temp
                            </li>
                            <li>Saoreet auctor. Fusce vitae orci nec velit ornare rhoncus ut temus est. Mau ris eu augue lorem. Suspendi
                            </li>
                        </ul>
                    </div>

                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <h2>purposes
                        </h2>
                        <p class="lead">
                            Folor sit amet conse ctetur adipisicing elit
             
                        </p>

                        <p>
                            Curabitur eu lorem ac lacus laoreet auctor. Fusce vitae orci nec velit ornare rhoncus ut tempus est. Mauris eu augue lorem. Suspendisse sit amet vehi cula nisl, nec faucibus nisl. Proin ac fermentum orci, non semper metus. Nulla nulla tellus
             
                        </p>
                        <ul class="marked-list offs3">
                            <li>
                                <a href="#">Fusce itae orci nec velit ornare rhon
                                </a>
                            </li>
                            <li>
                                <a href="#">Ecus ut tempus estauris eu augue lorem.
                                </a>
                            </li>
                            <li>
                                <a href="#">Suspendisse sit amet vehicula
                                </a>
                            </li>
                            <li>
                                <a href="#">Anisl, nec faucibus nislroin ac fermentum 
                                </a>
                            </li>
                            <li>
                                <a href="#">Horci, non semper metusulla nulla
                                </a>
                            </li>
                            <li>
                                <a href="#">Dellus, tincidunt vel eros gravida, cursu
                                </a>
                            </li>
                            <li>
                                <a href="#">Nullam ac magna nisi. Integer 
                                </a>
                            </li>
                            <li>
                                <a href="#">Dictum sagittis vulputate ulla a purus 
                                </a>
                            </li>
                        </ul>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12">
                        <h2>testimonial
                        </h2>
                        <blockquote class="media offs3">
                            <div class="media-left media_ins1">
                                <img src="images/page-2_img6.jpg" alt="">
                            </div>
                            <div class="media-body">
                                <p>
                                    <q>"Curabitur eu lorem ac lacus laoreet auctor. Fusce vitae orci nec velit ornare rhoncus ut tem pus est. Mauris eu aug ue lorem. Suspendisse sit amet vehi cul"
                                    </q>
                                </p>
                                <cite>Edna Barton,<br />
                                    client
                                </cite>
                            </div>
                        </blockquote>
                    </div>
                </div>
            </div>
        </section>
        <footer>
            <section class="well1">
                <div class="container">
                    <p class="rights">
                        Business Company  &#169; <span id="copyright-year"></span>
                        <a href="index-5.html">Privacy Policy</a>
                    </p>
                </div>
            </section>
        </footer>
    </div>
    <script>
        $(document).ready(function () {
            //Community Befor Info loaded
            if ($.cookie('cInfo') != null) {
                var data = $.cookie('cInfo').split('|');
                $('#HallName').val(data[0]);
                $('#HallSName').val(data[1]);
                $('#HallAddress').val(data[2]);
                $("#district").val(data[3]);
                $('#area').val(data[4]);
                $('#HallParticular').val(data[5]);
                $('#HallSContact').val(data[6]);
                $('#HallOwnerContact').val(data[7]);
                $('#HallSMail').val(data[8]);
                $('#HallWeb').val(data[9]);
                $('#HallPriceHall').val(data[10]);
                $('#HallPriceOther').val(data[11]);
                $('#priceNegot').val(data[12]);
                $('#priceOtherNegot').val(data[13]);
                $('#HallOtherPriceDes').val(data[14]);
                $('#Pass').val(data[15]);
                $('#ConPass').val(data[16]);
                $('#HallSPostal').val(data[18]);
                $('#HallYourNM').val(data[19]);
                var name = $('#HallYourNM').val(data[19]);
                var Commmunity = $('#HallName').val(data[1]);
                if (name != '') {
                    $('#names').val('Hi !' + name);
                    $('#communitys').val(Commmunity);
                }
                $('#lblCommunityIDD').val($.cookie("Community"));
                //Photo SHow 
                if (data.length > 0) {
                    $('#ImageUpload').show(500);
                    $.ajax({
                        type: "POST",
                        url: "fight.asmx/BPhotos",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: "{x: 'x'}",
                        success: function (result) {
                            if (result.d != '') {
                                var img = result.d;
                                img = img.split('+');
                                for (var i = 1; i < 9; i++) {
                                    if (img[i] != '') {
                                        $('#img' + i).show();
                                        $('#imgs' + i).attr('src', img[i]);
                                    }
                                }
                            }
                        },
                        error: function (result) {
                        }
                    });
                }
            }
        });
    </script>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <script src="js/tm-scripts.js"></script>
    <!-- </script> -->
</asp:Content>
