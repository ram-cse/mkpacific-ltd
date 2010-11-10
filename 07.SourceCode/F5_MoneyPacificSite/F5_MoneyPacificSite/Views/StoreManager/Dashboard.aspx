<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Store.Master" Inherits="System.Web.Mvc.ViewPage<F5_MoneyPacificSite.ViewModels.StoreManagerDashboardViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Dashboard
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Dashboard (Store Manager)</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <table>
            <tr>
                <th><%: Html.LabelFor(model => model.Name) %></th>
                <td>
                    <%: Html.DisplayFor(model => model.Name) %>                    
                </td>
            </tr>
            <tr>
                <th><%: Html.LabelFor(model => model.Status) %></th>
                <td>
                    <%: Html.DisplayFor(model => model.Status)%>                    
                </td>
            </tr>
            <tr>
                <th><%: Html.LabelFor(model => model.TotalTransaction) %></th>
                <td>
                    <%: Html.DisplayFor(model => model.TotalTransaction)%>                    
                </td>
            </tr>
            <tr>
                <th><%: Html.LabelFor(model => model.TotalLastMonthAmount) %></th>
                <td>
                    <%: Html.DisplayFor(model => model.TotalLastMonthAmount)%>                    
                </td>
            </tr>
            <tr>
                <th><%: Html.LabelFor(model => model.LastCollectDate) %></th>
                <td>                    
                    <%if (Model.LastCollectDate != null)
                      {%>
                          <%: Html.DisplayFor(model => model.LastCollectDate, String.Format("{0:g}", Model.LastCollectDate))%>
                     <%}%>                
                </td>
            </tr>
            <tr>
                <th><%: Html.LabelFor(model => model.IsLocked) %></th>
                <td>
                <% if (Model.IsLocked)
                   { %>
                        <input type="submit" value="Enable" />
                    <%}
                   else
                   { %>
                        <input type="submit" value="Disable" />
                    <%} %>
                    <%--<%: Html.TextBoxFor(model => model.IsLocked) %>
                    <%: Html.ValidationMessageFor(model => model.IsLocked) %>--%>                
                </td>
            </tr>
        </table>

    <% } %>


</asp:Content>

