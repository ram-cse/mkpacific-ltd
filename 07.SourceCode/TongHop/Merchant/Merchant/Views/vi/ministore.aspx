<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/tplcontentVI.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.LoadPortal("VI"); %>
    <%: LangText.GetTextPortal("MINI_STORE") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% Response.Write(ViewData["content"]); %>

</asp:Content>

<asp:Content ContentPlaceHolderID="Sidebar" runat="server">
<br />
<center>
<img src="/Content/Images/shoppingsidebar.jpg" border="0" /><br /><br />
<strong><%: LangText.GetTextPortal("OUR_MINI_STORE_WILL_OPEN_SOON")%><br /><br />
Hẹn gặp lại...
</strong>
<br /><br /><br /><br /><br /><br />
<img src="/Content/Images/sqv.png" border="0"/>
<br /><br /><br />
<br /><br /><br />
</center>
<br />
</asp:Content>

