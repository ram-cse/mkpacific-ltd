<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
<% LangText.Load(Page.User.Identity.Name); %>
<%: LangText.GetText("RECOVERY_PASSWORD")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: LangText.GetText("RECOVERY_SUCCESSFULLY")%></h2>

</asp:Content>
