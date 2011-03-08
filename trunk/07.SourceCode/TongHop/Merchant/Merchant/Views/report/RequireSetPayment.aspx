<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("REQUIRE_SET_PAYMENT")%>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: LangText.GetText("TO_VIEW_THE_MONEY_OVERVIEW,_YOU_MUST_SET_THE_PAYMENT_IN_THE_SETTING_MENU")%></h2>

</asp:Content>
