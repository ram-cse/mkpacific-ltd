<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcMusicStore03.ViewModels.StoreIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Browse Genres</h2>
    <p>Select from  <%:Model.NumberOfGenres %> genres</p>
    <ul>
        <%foreach (String genreName in Model.Genres)
          { %>
          <li><%:genreName %></li>
        <%} %>
    </ul>


</asp:Content>
