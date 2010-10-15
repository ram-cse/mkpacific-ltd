<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<P5_MoneyPacificSite.Models.RegisterModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Register
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create New Account</h2>
    <p>
        Using the form below to create new account
    </p>
    <p>
        Passwords are required to be a minimum of <%= Html.Encode(ViewData["PasswordLength"]) %> characters in length.
    </p>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true, "Account creation was unsuccessful. Please correct the errors and try again.")%>

        <fieldset>
            <legend>Customer Information</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.UserName) %>
                <%: Html.ValidationMessageFor(model => model.UserName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Password) %>
                <%: Html.ValidationMessageFor(model => model.Password) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ConfirmPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ConfirmPassword) %>
                <%: Html.ValidationMessageFor(model => model.ConfirmPassword) %>
            </div>
            
            <p>
                <input type="submit" value="Register" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

