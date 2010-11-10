<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Customer.Master" Inherits="System.Web.Mvc.ViewPage<F5_MoneyPacificSite.ViewModels.PacificCodeSendMoneyViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SendMoney
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Send Money</h2>
    <%: ViewData["message"] %><br />

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodeNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodeNumber) %>
                <%: Html.ValidationMessageFor(model => model.CodeNumber) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PhoneNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PhoneNumber) %>
                <%: Html.ValidationMessageFor(model => model.PhoneNumber) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PhoneNumberConfirm) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PhoneNumberConfirm) %>
                <%: Html.ValidationMessageFor(model => model.PhoneNumberConfirm) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Amount) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Amount, String.Format("{0:F}", Model.Amount)) %>
                <%: Html.ValidationMessageFor(model => model.Amount) %>
            </div>
            
            <p>
                <input type="submit" value="Send Money" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

