<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" 
Inherits="System.Web.Mvc.ViewPage<F5_MoneyPacificSite.ViewModels.AgentCreateViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <%: Html.EditorFor(model => model.newAgent, new { AgentStates = Model.agentStates })%>
    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

