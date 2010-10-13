<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.ViewModels.PacificCodeSendMoneyViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SendMoney
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>SendMoney</h2>

    <%: Html.Encode(ViewData["Co loi xay ra"]) %>
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
                <%: Html.LabelFor(model => model.Amount) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Amount) %>
                <%: Html.ValidationMessageFor(model => model.Amount) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PhoneNumber) %>
            </div>            
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PhoneNumber)%>
                <%: Html.ValidationMessageFor(model => model.PhoneNumber)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PhoneNumberConfirm)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PhoneNumberConfirm)%>
                <%: Html.ValidationMessageFor(model => model.PhoneNumberConfirm)%>
            </div>
            
            <div>
                <input type="submit" value="Send Money" />
            </div>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

