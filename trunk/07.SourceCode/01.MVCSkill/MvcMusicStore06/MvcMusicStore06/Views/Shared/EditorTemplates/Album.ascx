﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcMusicStore05.Models.Album>" %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
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
            <%: Html.TextBoxFor(model => model.AlbumArtUrl) %>
            <%: Html.ValidationMessageFor(model => model.AlbumArtUrl) %>
        </p>

        <p>
            <%: Html.LabelFor(model => model.Artist) %>
            <%: Html.DropDownList("ArtistId", 
                new SelectList(ViewData["Artists"] as IEnumerable,
                                "ArtistId", 
                                "Name", 
                                Model.ArtistId)
                            )%>
        </p>
        <p>
            <%: Html.LabelFor(model => model.Genre) %>
            <%: Html.DropDownList("GenreId", new SelectList(ViewData["Genres"] as IEnumerable,
                    "GenreId", "Name", Model.GenreId)) %>
        </p>
        <p>
                <input type="submit" value="Save" />
        </p>
    <% } %>



