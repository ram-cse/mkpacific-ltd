<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<IEnumerable<MoneyPacificSite.ViewModels.PartPacificCodeViewModel>>" %>
<%@ Import Namespace="MoneyPacificSite.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Browse
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Browse</h2>

    <table>
        <tr>
            <th> </th>
            <th>CodeNumber</th>
            <th>Customer Phone</th>
            <th>Store Phone</th>
<%--            <th>Initial Amount</th>
            <th>Actual Amount</th>--%>
            <th>ExpireDate</th>
        </tr>


    <% foreach (var item in Model) { %>
        <tr>
            <td><%: item.Stt %></td>
            <td><%: Html.ActionLink(
                                    Html.insertSeparateChar(item.PartCodeNumber,'-',4)
                                    ,"ChiTiet"
                                    ,"PacificCode"
                                    , new {id =  item.Id}
                                    ,null) %>                                    
            </td>
            <td><%: item.CustomerPhone %></td>
            <td><%: item.StorePhone %></td>
<%--            <td><%: item.InitialAmount %></td>
            <td><%: item.ActualAmount %></td>

            <td>createdate</td>
            <td>lastdate</td>
--%>
            <td><%: String.Format("{0:dd-MMM-yyyy}", item.ExpireDate)%></td>
        </tr>    
    <% } %>

    </table>

</asp:Content>

