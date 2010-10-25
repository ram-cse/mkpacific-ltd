<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/StoreManager.Master" Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.Models.Store>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Information
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Information</h2>

    <table>
        <tr>
            <th>ID</th>
            <td><%: Model.ID %></td>
        </tr>
        <tr>
            <th>Phone</th>
            <td><%: Model.Phone %></td>
        </tr>
        <tr>
            <th>Pass Store</th>
            <td><%: Model.PassStore %></td>
        </tr>
        <tr>
            <th>Create Date</th>
            <td><%: String.Format("{0:g}", Model.CreateDate) %></td>
        </tr>
        <tr>
            <th>Last Date</th>
            <td><%: String.Format("{0:g}", Model.LastDate) %></td>
        </tr>
        <tr>
            <th>Last Transaction</th>
            <td><%: Model.LastTransaction %></td>
        </tr>
        <tr>
            <th>Number Sales</th>
            <td><%: ((int)Model.NumberSales).ToString("n0")%></td>
        </tr>
        <tr>
            <th>Total Sales</th>
            <td><%: ((int)Model.TotalSales).ToString("n0")%> VND</td>
        </tr>
        <tr>
            <th>Comment</th>
            <td><%: Model.Comment %></td>
        </tr>
        <tr>
            <th>Address</th>
            <td><%: Model.Address %></td>
        </tr>
        <tr>
            <th>Name</th>
            <td><%: Model.Name %></td>
        </tr>
        <tr>
            <th>Email</th>
            <td><%: Model.Email %></td>
        </tr>
        <tr>
            <th>Status ID</th>
            <td><%: Model.StatusID %></td>
        </tr>

    </table>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
</asp:Content>

