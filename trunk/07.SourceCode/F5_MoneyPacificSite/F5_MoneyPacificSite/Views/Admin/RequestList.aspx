<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<F5_MoneyPacificSite.ViewModels.StoreManagerBaseViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Request
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Request</h2>

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
                Phone
            </th>
            <th>
                Email
            </th>
            <th>
                Status
            </th>
            <th>
                Internet Access
            </th>
            <th>
                CreateDate
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Set request", "EditStoreManager", new { id = item.Id })%>
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
                <%: item.Phone %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.Status %>
            </td>
            <td>
                <%: item.StoreInternetAccessId %>
            </td>
            <td>
                <%: String.Format("{0:dd-MMM-yyyy}", item.CreateDate)%>                
            </td>
        </tr>
    
    <% } %>

    </table>


</asp:Content>

