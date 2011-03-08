<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/VI2.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.LoadPortal("VI"); %>
    <%: LangText.GetTextPortal("VIETNAM_CHILDREN") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% Response.Write(ViewData["content"]); %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar" runat="server">
<div style="text-align:center; font-size:23px; font-weight:bold; color:#333333;">
Làm việc với<br />
<span style="color:White">Money Pacific </span><br />
góp phần hổ trợ <br />điều quan trọng nhất 
trên trái đất : <br /><br />
<span style="font-size:36px; font-weight:bold; color:#3399FF">TRẺ EM CHÚNG TA</span>
</div><br />
<hr />
<br />
<center>
<img src="/Content/Images/heart.jpg" border="0" />
<br /><br />
Sol ASIA là tổ chức Nhân đạo <br /><br />
của năm 2011
<br /><br />
<hr />
<br />
<span style="font-size:16px;">Truy cập website nhân đạo <br />và tìm hiểu cách để giúp đỡ Trẻ Em.</span>
<br /><br />

<div class="linksolasia">
<a href="http://solasia.over-blog.com">http://solasia.over-blog.com</a><br /><br />
<a href="http://www.facebook.com/sol.asia">http://www.facebook.com/sol.asia</a><br /><br />
</div>
<br />
<img src="/Content/Images/heart.jpg" border="0" />
<br /><br />
<br /><br />
</center>

</asp:Content>
