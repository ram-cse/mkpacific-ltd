<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.AdminListAmountViewModel>" %>
<%@ Import Namespace="MoneyPacificSite.ViewModels" %>
<%@ Import Namespace = "MoneyPacificSite.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ListAmount
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>StoreManagers' Amount</h2>

    <%:ViewData["message"] %><br /><br />
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        
        <b>Amount</b>
        <table>
            <tr>
                <th>AREA</th>
                <th>Shop ID</th>
                <th>Store Manager Name</th>
                <th>Store Manager Phone</th>
                <th>Address</th>
                <th>BAL</th>
                <th>Selected</th>
            </tr>
            
            <%for(int i = 0; i < Model.StoreManagers.Count(); i++)
              { 
                  StoreManagerBalanceSelect item = Model.StoreManagers[i];
                  %>
            <tr>
                <%:Html.HiddenFor(model => model.StoreManagers[i].Id) %>
                <%:Html.HiddenFor(model => model.StoreManagers[i].Area) %>
                <%:Html.HiddenFor(model => model.StoreManagers[i].IdShop) %>
                <%:Html.HiddenFor(model => model.StoreManagers[i].Address) %>
                <%:Html.HiddenFor(model => model.StoreManagers[i].Balance) %>

                <td align="left"><%:item.Area%></td>
                <td align="left"><%:item.IdShop %></td>
                <td align="left"><%:item.ManagerName %></td>
                <td align="left"><%:item.ManagerPhone %></td>
                <td><%:item.Address %></td>
                <td><%:Html.formatMoney(item.Balance) %></td>
                <td align="left"><%:Html.CheckBoxFor(model => model.StoreManagers[i].Selected)%></td>
            </tr>
                <%} %>
            
        </table>

    <fieldset>
        <legend>Agents</legend>
        <%: Html.DropDownList("AgentIdSelected", new SelectList(Model.Agents, "Id","Username","0"))%>
    </fieldset>    

    <p>
        <input type="submit" value="Save" />
    </p>
        

    <% } %>
  
</asp:Content>

