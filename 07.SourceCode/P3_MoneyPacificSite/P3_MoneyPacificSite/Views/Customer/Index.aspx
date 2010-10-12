<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<P3_MoneyPacificSite.Models.Customer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>



    <fieldset>
        <legend>Customer Informations</legend>
        <% using (Html.BeginForm())
           { %>
           <%: Html.ValidationSummary(true) %>
           <%: Html.EditorFor(model => model) %>
        <%}; %>
        <!--
        <div class="display-label">ID</div>
        <div class="display-field">< % : Model.ID %></div>
        
        <div class="display-label">Phone</div>
        <div class="display-field">< %: Model.Phone %></div>
        
        <div class="display-label">FirstName</div>
        <div class="display-field">< %: Model.FirstName %></div>
        
        <div class="display-label">LastName</div>
        <div class="display-field">< %: Model.LastName %></div>
        
        <div class="display-label">Username</div>
        <div class="display-field">< %: Model.Username %></div>
        
        <div class="display-label">Password</div>
        <div class="display-field">< %: Model.Password %></div>
        
        <div class="display-label">Email</div>
        <div class="display-field">< %: Model.Email %></div>
        
        <div class="display-label">Address</div>
        <div class="display-field">< %: Model.Address %></div>
        
        <div class="display-label">CreateDate</div>
        <div class="display-field">< %: String.Format("{0:g}", Model.CreateDate) %></div>
        
        <div class="display-label">LastDate</div>
        <div class="display-field">< %: String.Format("{0:g}", Model.LastDate) %></div>
        
        <div class="display-label">CurrentPacificCoded</div>
        <div class="display-field">< %: Model.CurrentPacificCoded %></div>
        
        <div class="display-label">TotalAmount</div>
        <div class="display-field">< %: Model.TotalAmount %></div>
        
        <div class="display-label">NumberTransaction</div>
        <div class="display-field">< %: Model.NumberTransaction %></div>
        
        <div class="display-label">BadTransaction</div>
        <div class="display-field">< %: Model.BadTransaction %></div>
        
        <div class="display-label">SecurCode</div>
        <div class="display-field">< %: Model.SecurCode %></div>
        
        <div class="display-label">Pincode</div>
        <div class="display-field">< %: Model.Pincode %></div>
        
        <div class="display-label">StatusID</div>
        <div class="display-field">< %: Model.StatusID %></div>
        -->
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

