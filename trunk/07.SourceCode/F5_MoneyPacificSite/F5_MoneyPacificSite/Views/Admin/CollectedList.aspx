<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<F5_MoneyPacificSite.ViewModels.CollectMoneyView>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Collected List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Collected List</h2>

    <table>
        <tr>
            <th>
                Collect Number
            </th>
            <th>
                Shop ID
            </th>
            <th>
                Address
            </th>
            <th>
                Amount
            </th>
            <th>
                Status
            </th>
            <th>
                Create Date
            </th>
            <th>
                Exprire Date
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.CollectNumber %>
            </td>
            <td>
                <%: item.IdShop %>
            </td>
            <td>
                <%: item.Address %>
            </td>
            <td>
                <%: item.Amount %>
            </td>
            <td>
                <%: item.Status %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.CreateDate) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.ExprireDate) %>
            </td>
        </tr>
    
    <% } %>

    </table>


</asp:Content>

