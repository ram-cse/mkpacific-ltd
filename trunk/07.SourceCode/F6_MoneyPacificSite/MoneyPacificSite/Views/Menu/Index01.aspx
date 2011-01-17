<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Trình đơn
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript" src="/Scripts/jquery-1.4.1.js"></script>

<script  type="text/javascript">
    $(document).ready(function () {
        $(":button").click(function () {
            $(".test").fadeOut(2000);
            $(".test").fadeIn(100);
        });

        $("p").click(function () {
            $(".test").fadeIn(1000);
            $("#test").fadeIn(100);
        });

        $(".test").click(function () {
            $(this).hide();
        });

        $("#test").click(function () {
            $(this).hide();
        });

        $(".ex .hide").click(function () {
            $(this).hide();
        });
    });
</script>

<style type="text/css"> 
div.ex
{
	background-color:#e5eecc;
	padding:7px;
	border:solid 1px #c3c3c3;
}
</style>


    <p>If you click on me, I will disappear.</p>

    <p class="test" style="color:Yellow; border:1; background-color:Gray;"> class TEST. please click me</p>

    <p id="test" style="color:Red; border:1; background-color:Yellow"> p ID = TEST. please click me</p>

    <input type="button" value="CLICK" />
    
    <h2>Trình đơn kiểm</h2>

    <div class="ex">
        <button class"hide" >Hide me</button><br />
        noi dung <br />
        noi dung <br />
        noi dung 
    </div>
    <div class="ex">
        <button class"hide" >Hide me too</button><br />
        <H1>noi dung</H1>  
        noi dung <br />
        ABC DEF 
    </div>

</asp:Content>
