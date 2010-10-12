<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.ViewModels.PacificCodeChangeCodeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ChangeCode
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ChangeCode</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
                        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PacificCode) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PacificCode) %>
                <%: Html.ValidationMessageFor(model => model.PacificCode) %>
            </div>
            
            <p>
                <input type="submit" value="Change Code" />
            </p>

        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

