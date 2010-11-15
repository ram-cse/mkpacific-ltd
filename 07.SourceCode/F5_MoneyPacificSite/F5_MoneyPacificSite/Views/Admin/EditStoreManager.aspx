<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<F5_MoneyPacificSite.ViewModels.StoreManagerViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditStoreManager
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>EditStoreManager</h2>

    <%:ViewData["message"] %><br /><br />

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Information</legend>
            <%: Html.EditorFor(model => model.storeManager, 
                    new {StoreManagerStates = Model.storeManagerStates,
                        InternetAccessRoles = Model.internetAccessRoles}) %>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

