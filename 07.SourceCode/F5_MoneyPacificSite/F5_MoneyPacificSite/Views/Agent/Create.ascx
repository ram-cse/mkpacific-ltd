<%@ Control Language="C#" 
Inherits="System.Web.Mvc.ViewUserControl<F5_MoneyPacificSite.ViewModels.AgentCreateViewModel>" %>

<h2>Create</h2>

<% using (Html.BeginForm()) {%>
    <%: Html.ValidationSummary(true) %>
    <%: Html.EditorFor(model => model.newAgent, new { AgentStates = Model.agentStates })%>
<% } %>


