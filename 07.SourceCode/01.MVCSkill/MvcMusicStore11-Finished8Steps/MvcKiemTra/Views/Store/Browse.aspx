<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<MvcKiemTra.ViewModels.StoreBrowseViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Browse
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <h2>Browsing Genre: <%: Model.Genre.Name %></h2>
 
    <ul>
 
    <% foreach (var album in Model.Albums) { %>
        <li>
        <%: Html.ActionLink(album.Title, "Details", new { id = album.AlbumId } )%>
        </li>
    <% } %>
 
    </ul>
</asp:Content>