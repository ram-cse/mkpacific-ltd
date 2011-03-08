<%@ Page Language="C#" MasterPageFile="~/Views/Shared/VI.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <% LangText.LoadPortal("VI"); %>
    <%: LangText.GetTextPortal("WELCOME_TO_MONEY_PACIFIC") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <span class="titleHeader"><%: LangText.GetTextPortal("HOW_DOES_IT_WORK") %></span>
   <ul style="list-style:decimal; margin-top: 15px;">
    <li><%: LangText.GetTextPortal("BUY_A_PACIFIC_CODE_IN_OUR_PARTNER_STORE")%></li>
    <li><%: LangText.GetTextPortal("USE_YOUR_PACIFIC_CODE_TO_BUY_ONLINE")%> </li>
    <li><%: LangText.GetTextPortal("YOU_DONT_RECEIVE_GOOD")%> </li>
   </ul>
   <br /><br />

   <span class="Ihavequestion"><a href="/vi/question"><%: LangText.GetTextPortal("I_HAVE_A_QUESTION")%></a> </span>

   <span class="Iwanttoknowmore"><a href="/vi/more"><%: LangText.GetTextPortal("I_WANT_TO_KNOW_MORE")%></a> </span>
</asp:Content>