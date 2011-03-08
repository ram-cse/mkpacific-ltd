<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("ACTIVE_ACCOUNT_SUCCESSFULLY!")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: LangText.GetText("ACTIVE_ACCOUNT_SUCCESSFULLY!")%></h2>
    
    <% Response.Write(ViewData["message"]); %>

</asp:Content>
