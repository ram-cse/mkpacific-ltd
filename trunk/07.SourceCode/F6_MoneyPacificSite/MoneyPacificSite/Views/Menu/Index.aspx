<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" 
Inherits="System.Web.Mvc.ViewPage<dynamic>" %>




<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Trình đơn
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript" src="/Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#test").click(function () {
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

<h3>Island Trading</h3>
<div id="test">
Garden House Crowther Way<br />
London
</div>


</asp:Content>
