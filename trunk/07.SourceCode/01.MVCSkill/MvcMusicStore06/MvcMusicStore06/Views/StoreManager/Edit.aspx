<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcMusicStore05.ViewModels.StoreManagerViewModel>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Edit
    </h2>
        <fieldset>
            <legend>Thông tin Album</legend>
            
            <%: Html.EditorFor(model => model.Album,
                new {Artists = Model.Artists, Genres = Model.Genres})%>
            
        </fieldset>

  
    

</asp:Content>

