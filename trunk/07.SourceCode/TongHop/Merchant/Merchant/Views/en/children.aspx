<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EN2.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.LoadPortal("EN"); %>
    <%: LangText.GetTextPortal("VIETNAM_CHILDREN") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% Response.Write(ViewData["content"]); %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar" runat="server">
<div style="text-align:center; font-size:23px; font-weight:bold; color:#333333;">
Working with<br />
<span style="color:White">Money Pacific </span><br />
contribute to support <br />
the most important thing<br />
on the earth : <br /><br />
<span style="font-size:36px; font-weight:bold; color:#3399FF">Our Child</span>
</div><br />
<hr />
<br />
<center>
<img src="/Content/Images/heart.jpg" border="0" />
<br /><br />
Sol ASIA is humanitarian association <br /><br />
selected for 2011
<br /><br />
<hr />
<br />
<span style="font-size:16px;">Visit the website of the association <br />and discover how they help CHILD.</span>
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
