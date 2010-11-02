<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdminSite.Master" 
Inherits="System.Web.Mvc.ViewPage<IEnumerable<P4_MoneyPacificSite.Models.StoreManager>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BrowseStores
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>BrowseStores</h2>
    <p>
        <%: Html.ActionLink("New Store", "Create") %>
    </p>

    <table>
        <tr>
            <th></th>
            <th>
                Username
            </th>
            <th>
                Name
            </th>
            <th>
                NameOfStore
            </th>
            <th>
                StatusId
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
                WebSite
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "EditStore", new { id=item.Id }) %> |
                <%: Html.ActionLink("Detail", "DetailStore", new { id=item.Id })%> |
                <%--<%: Html.ActionLink("Delete", "Delete", new { id=item.Id })%>--%>
            </td>
            <td>
                <%: item.Username %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.NameOfStore %>
            </td>
            <td>
                <%: item.StatusId %>
            </td>
            <td>
                <%: item.Address %>
            </td>
            <td>
                <%: item.Phone %>
            </td>
            <td>
                <%: item.EmailAlert %>
            </td>
            <td>
                <%: item.WebSite %>
            </td>
        </tr>
    <% } %>

    </table>
</asp:Content>

