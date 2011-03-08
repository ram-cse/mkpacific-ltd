<%@ Page Language="C#" MasterPageFile="~/Views/Shared/EN.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <% LangText.LoadPortal("EN"); %>
    <%: LangText.GetTextPortal("WELCOME_ACCOUNT_INDEX")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <span class="titleHeader">How does it work ?</span>
   <ul style="list-style:decimal;">
    <li>Buy a Pacific code in our partner store</li>
    <li>Use your Pacific code to buy online</li>
    <li>If you don’t receive good,... MONEY PACIFIC just refund you !!!</li>
   </ul>
   <br /><br />

   <span class="Ihavequestion"><a href="/en/question">I have a question</a> </span>

   <span class="Iwanttoknowmore"><a href="/en/more">I want to know more</a> </span>
</asp:Content>
