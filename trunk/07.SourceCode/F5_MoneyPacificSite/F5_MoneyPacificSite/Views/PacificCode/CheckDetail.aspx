<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Customer.Master" Inherits="System.Web.Mvc.ViewPage<F5_MoneyPacificSite.ViewModels.PacificCodeCheckDetailViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CheckDetail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Check Detail</h2>

    <%:ViewData["message"] %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.CodeNumber) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.CodeNumber) %>
            <%: Html.ValidationMessageFor(model => model.CodeNumber) %>
        </div>
        <input type="submit" value="View" />
    <% } %>

</asp:Content>

