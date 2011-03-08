<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.StoreUserDashboardViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DashBoard
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>DashBoard (Phone User)</h2>
    <% /// TODO: không cần form submit & validation, một vài chức
       /// năng bị dư, sẽ sửa sau%>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
        <table >
            <tr>
                <th align="left"><%: Html.LabelFor(model => model.Name) %></th>
                <td>
                    <%: Html.DisplayFor(model => model.Name) %>
                    <%: Html.ValidationMessageFor(model => model.Name) %>
                </td>
            </tr>
            <tr>
                <th align="left"><%: Html.LabelFor(model => model.Status) %></th>
                <td>
                    <%: Html.DisplayFor(model => model.Status)%>
                    <%: Html.ValidationMessageFor(model => model.Status) %>
                </td>
            </tr>
            <tr>
                <th align="left"><%: Html.LabelFor(model => model.TotalTransaction) %></th>
                <td>
                    <%: Html.DisplayFor(model => model.TotalTransaction)%>
                    <%: Html.ValidationMessageFor(model => model.TotalTransaction) %>
                </td>
            </tr>
            <tr>
                <th align="left"><%: Html.LabelFor(model => model.TotalLastMonthAmount) %></th>
                <td>
                    <%: Html.DisplayFor(model => model.TotalLastMonthAmount)%>
                    <%: Html.ValidationMessageFor(model => model.TotalLastMonthAmount) %>
                </td>
            </tr>
            <tr>
                <th align="left"><%: Html.LabelFor(model => model.LastCollectDate) %></th>
                <td>                    
                    <%if (Model.LastCollectDate != null)
                      {%>
                          <%: Html.DisplayFor(model => model.LastCollectDate, String.Format("{0:g}", Model.LastCollectDate))%>
                     <%}%>                
                </td>
            </tr>
            <tr>
                <th align="left"><%: Html.LabelFor(model => model.IsLocked) %></th>
                <td><%: Html.DisplayFor(model => model.IsLocked)%>
                    <%: Html.ValidationMessageFor(model => model.IsLocked) %>
                </td>
            </tr>
        </table>
        </fieldset>
    <% } %>
</asp:Content>

