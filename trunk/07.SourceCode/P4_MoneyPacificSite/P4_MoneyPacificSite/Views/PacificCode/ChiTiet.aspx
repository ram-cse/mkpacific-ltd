<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.Models.PacificCode>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ChiTiet
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

    <h2>ChiTiet</h2>

    <% using (Html.BeginForm())
       { %>

    <fieldset>
        <legend>Fields</legend>
       <%: Html.EditorFor(model => Model) %>

    </fieldset>
    <%} %>
</asp:Content>

