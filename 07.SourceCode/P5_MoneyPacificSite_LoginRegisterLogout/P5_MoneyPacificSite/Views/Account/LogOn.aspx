<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<P5_MoneyPacificSite.Models.LogOnModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LogOn
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>LogOn</h2>

    <p>
        Please enter your username and password. <%:Html.ActionLink("Register", "Register") %> if you don't have an account.

    </p>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true, "Login unsuccessful. Please correct the error and try again") %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.UserName) %>
                <%: Html.ValidationMessageFor(model => model.UserName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(m=>m.Password) %>
                <%: Html.ValidationMessageFor(model => model.Password) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.RememberMe) %>
            </div>
            <div class="editor-field">
                <%= Html.CheckBoxFor(m => m.RememberMe) %>
                <%: Html.ValidationMessageFor(model => model.RememberMe) %>
            </div>
            
            <p>
                <input type="submit" value="Log On" />
            </p>
        </fieldset>

    <% } %>
</asp:Content>

