<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.Models.Agent>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detail</h2>

    <table>
        <tr>
            <th>Username</th>
            <td><%: Model.Username %></td>
        </tr>

        <tr>
            <th>Password</th>
            <td><%: Model.Password %></td>
        </tr>

        <tr>
            <th>StatusId</th>
            <td><%: Model.StatusId %></td>
        </tr>

        <tr>
            <th>FistName</th>
            <td><%: Model.FistName %></td>
        </tr>

        <tr>
            <th>LastName</th>
            <td><%: Model.LastName %></td>
        </tr>

        <tr>
            <th>Address</th>
            <td><%: Model.Address %></td>
        </tr>

        <tr>
            <th>Phone</th>
            <td><%: Model.Phone %></td>
        </tr>

        <tr>
            <th>Email</th>
            <td><%: Model.Email %></td>
        </tr>

        <tr>
            <th>Comment</th>
            <td><%: Model.Comment %></td>
        </tr>
    </table>    

    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Back to List", "Browse") %>
    </p>

</asp:Content>

