<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/StoreManager.Master" Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.ViewModels.StoreDashboarshViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Dashboard
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Dashboard</h2>

    <table>
        <tr>
            <td><%: Html.LabelFor(m => m.Status) %></td>
            <td><%: Model.Status %></td>
        </tr>
        <tr>
            <td><%: Html.LabelFor(m => m.LastTransactions) %></td>
            <td><%: Model.LastTransactions %></td>
        </tr>        
        <tr>
            <td><%: Html.LabelFor(m => m.AmountFromCustomer) %></td>
            <td><%: Model.AmountFromCustomer.ToString("n0") %></td>
        </tr>        
        <tr>
            <td><%: Html.LabelFor(m => m.LastCollectDate) %></td>
            <td><%: Model.LastCollectDate.ToShortDateString() %></td>
        </tr>        
    </table>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back", "Index") %>
    </p>

</asp:Content>

