<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<P3_MoneyPacificSite.Models.PacificCode>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <table>
            <tr>
                <th>Truong</th>
                <th>Gia Tri</th>
            </tr>
            <tr>
                <td>ID</td>
                <td><%: Model.ID %></td>
            </tr>
            <tr>
                <td>CodeNumber</td>
                <td><%: Model.CodeNumber %></td>
            </tr>
            <tr>
                <td>LastTransaction</td>
                <td><%: Model.LastTransaction %></td>
            </tr>
            <tr>
                <td>CustomerID</td>
                <td><%: Model.CustomerID %></td>
            </tr>
            <tr>
                <td>StoreID</td>
                <td><%: Model.StoreID %></td>
            </tr>
            <tr>
                <td>CateID</td>
                <td><%: Model.CateID %></td>
            </tr>
            <tr>
                <td>InitialAmount</td>
                <td><%: Model.InitialAmount %></td>
            </tr>
            <tr>
                <td>ActualAmount</td>
                <td><%: Model.ActualAmount %></td>
            </tr>
            <tr>
                <td>Date</td>
                <td><%: String.Format("{0:g}", Model.Date) %></td>
            </tr>
            <tr>
                <td>LastDate</td>
                <td><%: String.Format("{0:g}", Model.LastDate) %></td>
            </tr>
            <tr>
                <td>ExpireDate</td>
                <td><%: String.Format("{0:g}", Model.ExpireDate) %></td>
            </tr>
            <tr>
                <td>Comment</td>
                <td><%: Model.Comment %></td>
            </tr>
            <tr>
                <td>StatusID</td>
                <td><%: Model.StatusID %></td>
            </tr>
        </table>
        
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to List", "Index","Customer") %>
    </p>

</asp:Content>

