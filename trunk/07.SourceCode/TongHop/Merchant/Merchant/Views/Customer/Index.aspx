<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("CUSTOMER_HOME")%>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  <h1><%: LangText.GetText("CUSTOMER_HOME")%></h1>
  
  <fieldset class="fieldsetborder">
   

  Welcome to Money Pacific Customer Area

   </fieldset>

</asp:Content>
