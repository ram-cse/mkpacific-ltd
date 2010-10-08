<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<P2_MoneyPacificSite.ViewModels.CustomerBrowseViewModel>" %>
<%@ Import Namespace="P2_MoneyPacificSite.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Browse
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Browse</h2>

    <fieldset>
        <legend>Fields</legend>
        
        
        <div class="display-field">So PacificCode: <%= Html.Encode(Model.NumberOfPacificCode) %></div>
        <% foreach (PacificCode p in Model.PacificCodes)
           { %>
           <%: Html.ActionLink(p.ID.ToString(),"Details","PacificCode",new{id = p.ID},null) %>
           <br />
        <%}; %>
        
    </fieldset>
    <p>
        <%= Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

