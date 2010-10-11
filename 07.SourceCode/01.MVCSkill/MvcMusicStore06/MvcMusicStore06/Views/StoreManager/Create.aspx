<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcMusicStore06.ViewModels.StoreManagerViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

    <h2>Create</h2>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <fieldset>
            <legend>Create Albums</legend>
            <%: Html.EditorFor(model => model.Album, 
                new {Artists = Model.Artists,Genres = Model.Genres}) %>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>
    

</asp:Content>

