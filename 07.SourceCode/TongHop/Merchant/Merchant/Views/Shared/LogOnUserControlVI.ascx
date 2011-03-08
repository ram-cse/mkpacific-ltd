<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Merchant.Helper" %>
<%
    LangText.LoadPortal("VI");
    if (Request.IsAuthenticated) {
%>

        <%:LangText.GetText("WELCOME") %> <b><%: Page.User.Identity.Name %></b>!
        [ <%: Html.ActionLink(LangText.GetText("LOGOUT"), "Logout", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink(LangText.GetText("LOGIN"), "login", "Account", new { height = 400, width = 600 }, new { @class = "thickbox" }) %> ] &nbsp; &nbsp; [ <%: Html.ActionLink(LangText.GetText("REGISTER"), "Register", "Account") %> ]&nbsp;&nbsp;[<%: Html.ActionLink(LangText.GetText("FOR_GOT_PASSWORD"), "forgotpw", "Account",  new { height = 500, width = 600 }, new { @class = "thickbox" })%>]
        <%
    }
%>
