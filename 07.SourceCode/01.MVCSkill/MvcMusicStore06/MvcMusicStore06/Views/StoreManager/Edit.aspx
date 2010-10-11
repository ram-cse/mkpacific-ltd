<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcMusicStore06.ViewModels.StoreManagerViewModel>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Edit</h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) %>
    <% { %>
        <fieldset>
            <legend>Thông tin Album</legend>
            
            <%: Html.EditorFor(model => model.Album,
                new {Artists = Model.Artists, Genres = Model.Genres})%>
            <p>
                <input type="submit" value="Save" />
            </p>

        </fieldset>
    <%} %>
    <div>
        <%: Html.ActionLink("Back to Albums", "Index") %>
    </div>
</asp:Content>

