<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Barcode.aspx.cs" Inherits="WebApi.Barcode.Barcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../MenuCssJs/css/bootstrap.min.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-latest.min.js"></script>
    <script src="JS/jquery-barcode.min.js"></script>
    
    <script>
        $(document).ready(function () {

            $(".btn").bind("click", function () {
                $("#barcode").barcode($("#txtbarcode").val(), "code128");
            });
            $(".btn").click();

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="">
                <hr />
                Enter text :
                <input type="text" id="txtbarcode" value="2020100001" />
                <br />
                <br />
                <div id="barcode" style=" font-size: 20px; font-weight: 800; background: none"></div>
                <hr />
                <a class="btn btn-info">Generate Barcode</a>
            </div>
        </div>
    </form>
</body>
</html>
