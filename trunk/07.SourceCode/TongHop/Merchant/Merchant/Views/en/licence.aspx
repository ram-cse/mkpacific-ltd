<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/tplcontentEN.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.LoadPortal("EN"); %>
    <%: LangText.GetTextPortal("LICENCE")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% Response.Write(ViewData["content"]); %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar" runat="server">

<br />
<center>
<img src="/Content/Images/mpteam.jpg" border="0" /><br />
<strong>Welcom in the Money Pacific team...</strong>
<br /><br /><br /><br /><br /><br />
<img src="/Content/Images/sqv.png" border="0"/>
<br /><br /><br />
<br /><br /><br />
</center>
<br />

</asp:Content>
