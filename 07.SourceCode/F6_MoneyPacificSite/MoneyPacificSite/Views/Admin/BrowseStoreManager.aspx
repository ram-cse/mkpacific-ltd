<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<IEnumerable<MoneyPacificSite.ViewModels.StoreManagerBaseViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BrowseStoreManager
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>BrowseStoreManager</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Name
            </th>
            <th>
                NameOfStore
            </th>
            <th>
                Address
            </th>
            <th>
                Town
            </th>
            <th>
                Phone
            </th>
            <th>
                ManagerPhone
            </th>
            <th>
                Email
            </th>
            <th>
                WebSite
            </th>
            <th>
                Status
            </th>
            <th>
                CreateDate
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "EditStoreManager", new { id=item.Id  }) %> 
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.NameOfStore %>
            </td>
            <td>
                <%: item.Address %>
            </td>
            <td>
                <%: item.Town %>
            </td>
            <td>
                <%: item.Phone %>
            </td>
            <td>
                <%: item.ManagerPhone %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.WebSite %>
            </td>
            <td>
                <%: item.Status %>
            </td>
            <td>
                <%: String.Format("{0:dd-MMM-yyyy}", item.CreateDate) %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

