<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
    <% LangText.GetText(Page.User.Identity.Name); %>
    <%: LangText.GetText("INVALID_BUYINGCODE") %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1> <%: LangText.GetText("INVALID_BUYINGCODE") %></h1>
<fieldset class="fieldsetborder">
    
</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>something here</center>
</asp:Content>