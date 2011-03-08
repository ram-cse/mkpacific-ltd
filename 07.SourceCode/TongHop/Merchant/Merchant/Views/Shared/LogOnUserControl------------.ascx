<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%: Page.User.Identity.Name %></b>!
        [ <%: Html.ActionLink("Logout", "Logout", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("Login", "login", "Account") %> ] &nbsp; &nbsp; [ <%: Html.ActionLink("Register", "Register", "Account") %> ]&nbsp;&nbsp;[<%: Html.ActionLink("Money Pacific Area","Index","Admin") %>]&nbsp;&nbsp;[<%:Html.ActionLink("Submit Problem","submit","Problem")%>]&nbsp;&nbsp;[<%: Html.ActionLink("Follow Problem","follow","Problem") %>]
<%
    }
%>
