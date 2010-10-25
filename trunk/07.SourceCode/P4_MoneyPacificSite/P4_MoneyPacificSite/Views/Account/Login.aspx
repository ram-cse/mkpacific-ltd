<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/StoreManager.Master" 
Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.ViewModels.AccountLoginViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login</h2>
    <%:ViewData["Message"] %><br />
    <p>
        Please enter your username and password.
    </p>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Login</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Username) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Username) %>
                <%: Html.ValidationMessageFor(model => model.Username) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Password) %>
                <%: Html.ValidationMessageFor(model => model.Password) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.RememberMe) %>
            </div>
            <div class="editor-field">                
                <%: Html.CheckBoxFor(model => model.RememberMe) %>
                <%: Html.ValidationMessageFor(model => model.RememberMe) %>
            </div>            
            <p>
                <input type="submit" value="Login" />
            </p>
        </fieldset>
    <% } %>
</asp:Content>

