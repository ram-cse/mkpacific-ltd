<%@ Import Namespace="MvcMusicStore03" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcMusicStore03.Models.Album>" %>

<p>
    <%: Html.LabelFor(model => model.Title) %>
    <%: Html.TextBoxFor(model => model.Title) %>
    <%: Html.ValidationMessageFor(model => model.Title) %>
</p>
<p>
    <%: Html.LabelFor(model => model.Price) %>
    <%: Html.TextBoxFor(model => model.Price) %>
    <%: Html.ValidationMessageFor(model => model.Price) %>
</p>

<p>
    <%: Html.LabelFor(model => model.AlbumArtUrl) %>
    <%: Html.TextBoxFor(model => model.AlbumArtUrl)%>
    <%: Html.ValidationMessageFor(model => model.AlbumArtUrl)%>
</p>
<p>
    <%: Html.LabelFor(model => model.Artist) %>
    <%: Html.DropDownList("Artist", new SelectList(ViewData["Artists"] as IEnumerable,"ArtistID","Name",Model.ArtistId)) %>
</p>
<p>
    <%: Html.LabelFor(model => model.Genre) %>
    <%: Html.DropDownList("Genre", new SelectList(ViewData["Genres"] as IEnumerable, "GenreID", "Name",Model.GenreId)) %>
</p>

