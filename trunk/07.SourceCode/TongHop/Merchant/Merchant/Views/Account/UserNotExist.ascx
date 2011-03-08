<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

	<% LangText.Load(Page.User.Identity.Name); %>
 

    <h2 style="color:Red"><%: LangText.GetText("USER_NOT_EXIST")%></h2>

