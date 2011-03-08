<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Merchant.Models.Webmaster>" %>

<%@ Import Namespace="Merchant.Helper" %>

	<% LangText.Load(Page.User.Identity.Name);%>
 
     <h2><%: LangText.GetText("NOTIFICATION") %></h2>
     <div id="han">
     
     
     </div>
    <fieldset> <legend><%:LangText.GetText("NOTIFICATION") %></legend>
   
    <% using (Ajax.BeginForm("notification", "Account", new AjaxOptions { UpdateTargetId="han"}))
       {%>
       <div class="display-label"><%:LangText.GetText("EMAIL_FOR_NEW_ORDER")%></div> 
       <input type="text" id="notificationNewOrder" name="notificationNewOrder" value="<%:Model.NotificationNewOrder  %>" />
       <div class="display-label"><%:LangText.GetText("EMAIL_FOR_NEW_MESSAGE")%></div>
       <input type="text" id="notificationNewMessage" name="notificationNewMessage"value="<%:Model.NotificationNewMessage  %>" />
       <div class="display-label"><%:LangText.GetText("EMAIL_FOR_REPORT_PROBLEM")%></div>

       <input type="text" id="notificationNewProblem" name="notificationNewProblem" value="<%:Model.NotificationNewProblem  %>" />
       <br /><br />
       <p>
       <input type="submit" value="OK" />
       </p>
    <%} %>
    
    