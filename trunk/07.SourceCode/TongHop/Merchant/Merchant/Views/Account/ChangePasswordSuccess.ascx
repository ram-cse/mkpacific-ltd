<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import  Namespace="Merchant.Helper" %>

   <% LangText.Load(Page.User.Identity.Name); %>

  <br /><br /><br /><br />
   

      <h1 style="font-size:larger;">  <%:LangText.GetText("YOUR_PASSWORD_HAS_BEEN_CHANGED_SUCCESSFULLY")%></h2>
