<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcMusicStore03.ViewModels.StoreBrowseViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Browse
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Browse Genre: <%:Model.Genre.Name %></h2>
    <ul>
    <%foreach (var album in Model.Albums)
      { %>
        <li><%:album.Title %></li>
    <%} %>
    </ul>
    
</asp:Content>
