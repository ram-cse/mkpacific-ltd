<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.OrderNewViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	On delivery Products
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>On delivery</h2>
    <ul>
    <%foreach (var x in Model.list)
      { %>
      <li><a href="/order/details/<%:x.Id %>"><%:x.Name %></a>  -  <%:x.Website.URL %></li>
    <%} %>
    </ul>
</asp:Content>
