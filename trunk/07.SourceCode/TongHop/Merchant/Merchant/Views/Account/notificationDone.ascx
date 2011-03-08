<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%@ Import Namespace="Merchant.Helper" %>
<% LangText.Load(Page.User.Identity.Name); %>

<h1 style="color:Green;font-size:larger;"><%: LangText.GetText("YOUR_NOTIFICATION_SAVED_SUCCESSFULLY") %> </h1>

