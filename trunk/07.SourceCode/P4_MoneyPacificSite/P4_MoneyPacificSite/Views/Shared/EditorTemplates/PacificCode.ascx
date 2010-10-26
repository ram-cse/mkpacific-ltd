<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<P4_MoneyPacificSite.Models.PacificCode>" %>
<%@ Import Namespace = "P4_MoneyPacificSite.Helpers" %>

<table>
    <tr>
        <th>Truong</th>
        <th>Gia Tri</th>
    </tr>
    <tr>
        <td>ID</td>
        <td><%: Model.Id %></td>
    </tr>
    <tr>
        <td>CodeNumber</td>
        <td><%: Html.insertSeparateChar(Model.CodeNumber,'-',4) %></td>
    </tr>
    <tr>
        <td>LastTransaction</td>
        <td><%: Model.LastTransaction %></td>
    </tr>
    <tr>
        <td>CustomerID</td>
        <td><%: Model.CustomerId %></td>
    </tr>
    <tr>
        <td>StoreID</td>
        <td><%: Model.StoreId %></td>
    </tr>
    <tr>
        <td>CateID</td>
        <td><%: Model.CateId %></td>
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
        <td><%: String.Format("{0:dd-MMM-yyyy}", Model.Date) %></td>
    </tr>
    <tr>
        <td>LastDate</td>
        <td><%: String.Format("{0:dd-MMM-yyyy}", Model.LastDate)%></td>
    </tr>
    <tr>
        <td>ExpireDate</td>
        <td><%: String.Format("{0:dd-MMM-yyyy}", Model.ExpireDate)%></td>
    </tr>
    <tr>
        <td>Comment</td>
        <td><%: Model.Comment %></td>
    </tr>
    <tr>
        <td>StatusID</td>
        <td><%: Model.StatusId %></td>
    </tr>
</table>

