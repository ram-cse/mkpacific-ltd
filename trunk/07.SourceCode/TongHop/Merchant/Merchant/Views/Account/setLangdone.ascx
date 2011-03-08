<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<% LangText.Load(Page.User.Identity.Name); %>

<%: LangText.GetText("YOUR_LANGUAGE_SET_SUCCESSFULLY")%>
