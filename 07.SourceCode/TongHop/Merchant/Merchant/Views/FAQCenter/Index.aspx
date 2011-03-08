<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
<% LangText.Load(Page.User.Identity.Name); %>
<%: LangText.GetText("FAQ") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1><%: LangText.GetText("FAQ") %></h1>

<fieldset class="fieldsetborder">
 <% Response.Write(ViewData["content"]); %>

</fieldset>

   

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>some thing here</center>

</asp:Content>