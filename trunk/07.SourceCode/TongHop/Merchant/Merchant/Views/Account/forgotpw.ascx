<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%@ Import  Namespace="Merchant.Helper" %>

	 <% LangText.Load(Page.User.Identity.Name); %>
   
    <h2><%: LangText.GetText("FORGOT_PASSWORD")%></h2>
    <p><%:LangText.GetText("TO_RECOVERY_YOUR_PASSWORD,PLEASE_ENTER_YOUR_USERNAME_OR_THE_EMAIL_TO_RECOVERY_YOUR_PASSWORD.THE_LINK_WILL_BE_SENT_TO_YOU_BY_EMAIL_TO_GENERATE_THE_PASSWORD")%>
   </p>
    <fieldset><legend><%:LangText.GetText("USERNAME") %></legend>
    <div id="han">
    </div>
   
    <% using (Ajax.BeginForm("recoverUsername", "Account", new AjaxOptions { UpdateTargetId = "han"})){ %>
    <%:LangText.GetText("ENTER_YOUR_USERNAME")%>: <input type="text" id="username" name="username" /><br /><br />
    <p>
    <input type="submit" value="OK" />
    </p>
    <%} %>
    </fieldset>

    <fieldset><legend>Email</legend>
    
    <% using (Ajax.BeginForm("recoverEmail", "Account", new AjaxOptions { UpdateTargetId = "han" }))
       { %>
    Email: <input type="text" id="email" name="email" /><br /><br />
    <p>
    <input type="submit" value="OK" />
    </p>
    <%} %>
    </fieldset>

