<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.Models.PacificCode>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => Model.Id) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => Model.Id) %>
                <%: Html.ValidationMessageFor(model => Model.Id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodeNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodeNumber) %>
                <%: Html.ValidationMessageFor(model => model.CodeNumber) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LastTransaction) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.LastTransaction) %>
                <%: Html.ValidationMessageFor(model => model.LastTransaction) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CustomerID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CustomerID) %>
                <%: Html.ValidationMessageFor(model => model.CustomerID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.StoreID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StoreID) %>
                <%: Html.ValidationMessageFor(model => model.StoreID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CateID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CateID) %>
                <%: Html.ValidationMessageFor(model => model.CateID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.InitialAmount) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.InitialAmount) %>
                <%: Html.ValidationMessageFor(model => model.InitialAmount) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ActualAmount) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ActualAmount) %>
                <%: Html.ValidationMessageFor(model => model.ActualAmount) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Date) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Date) %>
                <%: Html.ValidationMessageFor(model => model.Date) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LastDate) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.LastDate) %>
                <%: Html.ValidationMessageFor(model => model.LastDate) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ExpireDate) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ExpireDate) %>
                <%: Html.ValidationMessageFor(model => model.ExpireDate) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Comment) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Comment) %>
                <%: Html.ValidationMessageFor(model => model.Comment) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => Model.StatusId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => Model.StatusId) %>
                <%: Html.ValidationMessageFor(model => Model.StatusId) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

