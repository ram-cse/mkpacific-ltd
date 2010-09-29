<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcMusicStore05.ViewModels.StoreIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Store Home</h2>
    <p>Browsing <%:Model.NumberOfGenres %> genres:</p>    
    <ul>
        <%foreach (string genresName in Model.Genres)
          {%>
          <li>
            <%:Html.ActionLink(genresName,"Browse","Store",new {genre=genresName},null) %>
            <!-- Html.ActionLink(genresName,"Browse","Store",new {genre=genresName},null)
            genreName -> Label
            "Browse" -> Phương thức cần gọi
            "Store" -> Gọi từ Store Controller
            new (..) -> biến truyền HTML (thay cho các biến truyền trên chuỗi url)
            null -> attribute, chưa sử dụng đến
            -->
          </li>
        <%} %>
    </ul>

</asp:Content>
