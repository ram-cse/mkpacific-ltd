<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.ViewModels.MessageViewViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	View
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>View</h2>

    <fieldset>
        <legend>Fields</legend>
        
    </fieldset>
    <div>
        <%: Model.Message %>
    </div>

    <div>
        <%: Html.Action("Back", Model.Action, Model.Controller); %>
    </div>

</asp:Content>

