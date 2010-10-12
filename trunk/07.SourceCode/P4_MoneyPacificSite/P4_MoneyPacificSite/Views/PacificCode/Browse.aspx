<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<P4_MoneyPacificSite.Models.PacificCode>>" %>
<%@ Import Namespace = "P4_MoneyPacificSite.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Browse
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- %: Html.ActionLink("A. Detail of Pacific Code","Index") %>
    < %: Html.ActionLink("B. Change the Code of Pacific Code","Index") %>
    < %: Html.ActionLink("C. Send a Money of Pacific","Index") %>
    < %: Html.ActionLink("D. I don't receive of Pacific Code","Index") % -->

    <h2>Browse</h2>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

    <table>
        <tr>
            <th>STT</th>
            <th>CodeNumber</th>
            <th>Customer Phone</th>
            <th>Store Phone</th>
            <th>Initial Amount</th>
            <th>Actual Amount</th>
            <th>Create Date</th>
            <th>Last Date</th>
            <th>ExpireDate</th>
        </tr>

    <%  int i = 0;
        foreach (var item in Model) {
            i++;
            %>
    
        <tr>
            <td><%: i %></td>
            <td><%: Html.ActionLink(
                                    Html.insertSeparateChar(item.CodeNumber, '-', 4)
                                    ,"ChiTiet"
                                    ,"PacificCode"
                                    , new {id =  item.ID}
                                    ,null) %>
            </td>
            <td><%: item.Customer.Phone %></td>
            <td><%: item.Store.Phone %></td>
            <td><%: item.InitialAmount %></td>
            <td><%: item.ActualAmount %></td>
            <td><%: String.Format("{0:dd-MMM-yyyy}", item.Date) %></td>
            <td><%: String.Format("{0:dd-MMM-yyyy}", item.LastDate)%></td>
            <td><%: String.Format("{0:dd-MMM-yyyy}", item.ExpireDate)%></td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

