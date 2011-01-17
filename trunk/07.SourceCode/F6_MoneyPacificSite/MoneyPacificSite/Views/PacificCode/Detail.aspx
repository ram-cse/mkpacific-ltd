<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.PacificCodeDetailViewModel>" %>
<%@ Import Namespace = "MoneyPacificSite.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Value & Detail</h2>

    <table>
        <tr>
            <th align="left"><%: Html.LabelFor(model => model.CodeNumber) %></th>
            <td><%: Html.insertSeparateChar(Model.CodeNumber,'-',4) %></td>
        </tr>
        <tr>
            <th align="left"><%: Html.LabelFor(model => model.LastTransaction)%></th>
            <td><%if (Model.LastTransaction != null)
                      String.Format("{0:g}", Model.LastTransaction);%></td>
        </tr>
        <tr>
            <th align="left"><%: Html.LabelFor(model => model.CustomerPhone)%></th>
            <td><%: Model.CustomerPhone %></td>
        </tr>
        <tr>
            <th align="left"><%: Html.LabelFor(model => model.InitialAmount)%></th>
            <td><%: Model.InitialAmount %></td>
        </tr>
        <tr>
            <th align="left"><%: Html.LabelFor(model => model.ActualAmount)%></th>
            <td><%: Model.ActualAmount %></td>
        </tr>
        <tr>
            <th align="left"><%: Html.LabelFor(model => model.CreateDate)%></th>
            <td><%: String.Format("{0:dd-MMM-yyyy}", Model.CreateDate)%></td>
        </tr>
        <tr>
            <th align="left"><%: Html.LabelFor(model => model.ExpireDate)%></th>
            <td><%: String.Format("{0:dd-MMM-yyyy}", Model.ExpireDate)%></td>
        </tr>
        <tr>
            <th align="left"><%: Html.LabelFor(model => model.Comment)%></th>
            <td><%: Model.Comment %></td>
        </tr>
        <tr>
            <th align="left"><%: Html.LabelFor(model => model.StorePhone)%></th>
            <td><%: Model.StorePhone %></td>
        </tr>
    </table>
</asp:Content>

