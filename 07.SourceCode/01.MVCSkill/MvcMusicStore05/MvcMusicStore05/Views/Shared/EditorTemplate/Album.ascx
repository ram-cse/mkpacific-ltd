<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcMusicStore05.Models.Album>" %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.AlbumId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.AlbumId) %>
                <%: Html.ValidationMessageFor(model => model.AlbumId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.GenreId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.GenreId) %>
                <%: Html.ValidationMessageFor(model => model.GenreId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ArtistId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ArtistId) %>
                <%: Html.ValidationMessageFor(model => model.ArtistId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title) %>
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Price) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Price, String.Format("{0:F}", Model.Price)) %>
                <%: Html.ValidationMessageFor(model => model.Price) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.AlbumArtUrl) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.AlbumArtUrl) %>
                <%: Html.ValidationMessageFor(model => model.AlbumArtUrl) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>


