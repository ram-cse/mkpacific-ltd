<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("SORRY!TIME_NOT_AVAILABLE_FOR_REPORT.YOUR_ORDER_MAYBE_ON_THE_WAY_TO_DELEVERY")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: LangText.GetText("SORRY!TIME_NOT_AVAILABLE_FOR_REPORT.YOUR_ORDER_MAYBE_ON_THE_WAY_TO_DELEVERY")%></h2>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>something here</center>
</asp:Content>