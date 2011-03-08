<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("REGISTER_SUCCESSFULLY") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: LangText.GetText("REGISTER_SUCCESSFULLY") %></h2>

     <%: LangText.GetText("PLEASE_CHECK_EMAIL_TO_ACTIVE_ACCOUNT") %>

</asp:Content>
