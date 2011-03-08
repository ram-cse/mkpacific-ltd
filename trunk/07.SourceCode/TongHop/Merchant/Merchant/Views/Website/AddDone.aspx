<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("ADD_WEBSITE_DONE")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%:LangText.GetText("YOUR WEBSITE_IS_ADDED_SUCCESSFULLY!_WE_WILL_REVIEW_YOUR_WEBSITE_AND_VALIDATE_IN_24_HOURS")%> <%: LangText.GetText("THANK_YOU") %>!</h2>
    <h2><%: Html.ActionLink(LangText.GetText("GO_BACK"),"add","Website") %></h2>
</asp:Content>
