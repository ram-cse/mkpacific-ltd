<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>
<% LangText.Load(Page.User.Identity.Name); %>

 <h2><%: LangText.GetText("YOU_REQUEST_TO_RECOVERY_THE_PASSWORD_SUCCESSFULLY._PLEASE_CHECK_YOUR_EMAIL_TO_GET_THE_LINK_FOR_GENERATE_THE_PASSWORD") %></h2>


