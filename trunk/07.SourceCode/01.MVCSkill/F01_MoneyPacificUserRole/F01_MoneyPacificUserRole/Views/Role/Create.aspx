<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<F01_MoneyPacificUserRole.Models.aspnet_MPRoles>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <br />
    <%:ViewData["Message"] %>
    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.RoleId) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.RoleId) %>
                <%= Html.ValidationMessageFor(model => model.RoleId) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.RoleName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.RoleName) %>
                <%= Html.ValidationMessageFor(model => model.RoleName) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.LowerRoleNam) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.LowerRoleNam) %>
                <%= Html.ValidationMessageFor(model => model.LowerRoleNam) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Description) %>
                <%= Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

