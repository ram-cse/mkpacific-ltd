<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.RegisterModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Webmaster Information
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Webmaster Information</h2>

           
          <%if (Model.AccountType == 0)
            { %>
            <fieldset>
            <legend>Personal Account Information</legend>
              <div class="editor-label">
                <%: Html.LabelFor(model => model.Name)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name, new { disabled = true})%>
                <%: Html.ValidationMessageFor(model => model.Name)%>
            </div>
             
             <div class="editor-label">
                <%: Html.LabelFor(model => model.UserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.UserName, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.UserName) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>

             <div class="editor-label">
                <%: Html.LabelFor(model => model.Phone) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Phone, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.Phone) %>
            </div>
            </fieldset>
            <fieldset><legend>Contact Information</legend>
             <div class="editor-label">
                <%: Html.LabelFor(model => model.Street) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Street, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.Street) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ward) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ward, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.Ward) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.City) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.City, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.City) %>
            </div>

            </fieldset>

            <fieldset><legend>Payment Information</legend>
             <div class="editor-label">
                <%: Html.LabelFor(model => model.ATM) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ATM, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.ATM) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Bank) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Bank, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.Bank) %>
            </div>
            
            </fieldset>

            <%}
                
            else
            { %>
            <fieldset>
            <legend>Business Account Information</legend>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CompanyName)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CompanyName, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.CompanyName)%>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.UserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.UserName, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.UserName) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>

             <div class="editor-label">
                <%: Html.LabelFor(model => model.Phone) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Phone, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.Phone) %>
            </div>
             <div class="editor-label">
                <%: Html.LabelFor(model => model.TaxCode) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TaxCode, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.TaxCode) %>
            </div>

            </fieldset>
            <fieldset><legend>Company Address</legend>
             <div class="editor-label">
                <%: Html.LabelFor(model => model.Street) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Street, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.Street) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ward) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ward, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.Ward) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.City) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.City, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.City) %>
            </div>

            </fieldset>

            <fieldset><legend>Payment Information</legend>
             <div class="editor-label">
                <%: Html.LabelFor(model => model.ATM) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ATM, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.ATM) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Bank) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Bank, new { disabled = true })%>
                <%: Html.ValidationMessageFor(model => model.Bank) %>
            </div>
            

            </fieldset>
           
            
        </fieldset>

    <% } %>

   

</asp:Content>

