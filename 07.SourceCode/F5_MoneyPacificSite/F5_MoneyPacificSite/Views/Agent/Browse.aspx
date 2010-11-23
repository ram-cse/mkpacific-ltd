<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<F5_MoneyPacificSite.ViewModels.AgentListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Browse
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>
        <legend>List</legend>
        <p>
            <%: Html.ActionLink("Create New", "Create", "Agent") %>
        </p>

        <table>
        <tr>
            <th></th>
            <th>
                Username
            </th>
            <th>
                Password
            </th>
            <th>
                Status
            </th>
            <th>
                Fist Name
            </th>
            <th>
                Last Name
            </th>
            <th>
                Address
            </th>
            <th>
                Phone
            </th>
            <th>
                Email
            </th>
            <th>
                Comment
            </th>
        </tr>

    <% foreach (var item in Model.agents) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.Id })%> |
            </td>
            <td>
                <%: item.Username %>
            </td>
            <td>
                ******
            </td>
            <td>
                <%: Html.DropDownList("StatusId", 
                    new SelectList(Model.agentStates,"Id", "Name",item.StatusId) )%>
            </td>
            <td>
                <%: item.FistName %>
            </td>
            <td>
                <%: item.LastName %>
            </td>
            <td>
                <%: item.Address %>
            </td>
            <td>
                <%: item.Phone %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.Comment %>
            </td>
        </tr>
    
    <% } %>

    </table>

    </fieldset>
    
        
    
</asp:Content>

