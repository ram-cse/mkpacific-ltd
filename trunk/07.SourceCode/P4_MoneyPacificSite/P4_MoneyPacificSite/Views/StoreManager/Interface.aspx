<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/StoreManager.Master" 
Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.ViewModels.StoreManagerInterfaceViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Interface
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Interface</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <table>
            <tr>
                <th><%: Html.LabelFor(model => model.Name) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.Name) %>
                    <%: Html.ValidationMessageFor(model => model.Name) %>
                </td>
            </tr>
            <tr>
                <th><%: Html.LabelFor(model => model.Status) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.Status) %>
                    <%: Html.ValidationMessageFor(model => model.Status) %>
                </td>
            </tr>
            <tr>
                <th><%: Html.LabelFor(model => model.TotalTransaction) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.TotalTransaction) %>
                    <%: Html.ValidationMessageFor(model => model.TotalTransaction) %>
                </td>
            </tr>
            <tr>
                <th></th>
                <td>
                </td>
            </tr>
            <tr>
                <th></th>
                <td>
                </td>
            </tr>
            <tr>
                <th><%: Html.LabelFor(model => model.TotalLastMonthAmount) %></th>
                <td>
                    <%: Html.TextBoxFor(model => model.TotalLastMonthAmount) %>
                    <%: Html.ValidationMessageFor(model => model.TotalLastMonthAmount) %>
                </td>
            </tr>
            <tr>
                <th><%: Html.LabelFor(model => model.LastCollectDate) %></th>
                <td>                    
                    <%if (Model.LastCollectDate != null)
                      {%>
                          <%: Html.TextBoxFor(model => model.LastCollectDate, String.Format("{0:g}", Model.LastCollectDate)) %>
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

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

