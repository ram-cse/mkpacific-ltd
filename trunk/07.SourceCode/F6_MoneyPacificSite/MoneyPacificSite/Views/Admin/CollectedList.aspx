<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<IEnumerable<MoneyPacificSite.ViewModels.CollectMoneyView>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Collected List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Collected List</h2>

    <table>
        <tr>
            <th>
                Manager Name
            </th>
            <th>
                Manager Phone
            </th>
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
                Agent
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
            <th>
                Collected Date
            </th>
        </tr>
        

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.ManagerName %>
            </td>
            <td>
                <%: item.ManagerPhone %>
            </td>


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
                <%: item.Agent %>
            </td>
            <td>
                <%: item.Status %>
            </td>
            <td>
                <%: String.Format("{0:dd-MMM-yyyy}", item.CreateDate)%>
            </td>
            <td>
                <%: String.Format("{0:dd-MMM-yyyy}", item.ExprireDate)%>
            </td>
            <td>
                <%: String.Format("{0:dd-MMM-yyyy}", item.CollectedDate) %>
            </td>
        </tr>
    
    <% } %>

    </table>


</asp:Content>

