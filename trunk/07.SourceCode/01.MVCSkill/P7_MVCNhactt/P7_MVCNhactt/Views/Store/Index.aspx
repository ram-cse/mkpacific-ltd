<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<P7_MVCNhactt.ViewModels.StoreIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <ul>
    <%for (int i = 0; i < Model.NumberOfGenre; i++)
      { %>
      <li><%: Model.Genres[i].Name.ToString() %></li>
    <%} %>
    </ul>
</asp:Content>
