<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcKiemTra.ViewModels.StoreManagerViewModel>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
<script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
<script src="/Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>
 
Now we use the Html.EnableClientValidation helper method to "turn on" client-side validation. For the both the Create and Edit view templates, add that call directly above the Html.BeginForm call, like so:
<h2>Create</h2>
 
<% Html.EnableClientValidation(); %>
 
<% using (Html.BeginForm()) {%>
 
<fieldset>
    <legend>Create Album</legend>
    <%: Html.EditorFor(model => model.Album, new { Artists = Model.Artists, Genres = Model.Genres })%>
    <p>
        <input type="submit" value="Save" />
    </p>
</fieldset>
 
<% } %>

    <%--<h2>Create</h2>
 
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
 
    <fieldset>
        <legend>Create Album</legend>
        <%: Html.EditorFor(model => model.Album,
            new { Artists = Model.Artists, Genres = Model.Genres })%>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
 
 
    <% } %>
 --%>
</asp:Content>