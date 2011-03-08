<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  <% LangText.GetText(Page.User.Identity.Name); %>
  <%: LangText.GetText("SUBMIT_PROBLEM_SUCCESSFLLY")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1><%: LangText.GetText("THANK_YOU") %>. <%: LangText.GetText("SUBMIT_PROBLEM_SUCCESSFLLY")%> !</h1>
<fieldset class="fieldsetborder">
     
    <%: LangText.GetText("FOR_MORE_INFORMATION,PLEASE_USE_PACIFIC_MESSENGER_TO_DISSCUS_WITH_WEBSITE_ADMIN")%>
</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>something here</center>
</asp:Content>