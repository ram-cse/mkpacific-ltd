<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Merchant.Models.Website>" %>
<%@ Import Namespace="Merchant.Helper" %>

	<% LangText.Load(Page.User.Identity.Name); %>
 

    <h2><%: LangText.GetText("EDIT_WEBSITE")%></h2>

    <% using (Html.BeginForm())
       {%>
        <%: Html.ValidationSummary(true)%>
        
        <fieldset>
           <legend><%: LangText.GetText("WEBSITE_INFORMATION")%></legend>
            
            <div class="editor-label">
                <%: LangText.GetText("WEBSITE_TITLE")%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title)%>
                <%: Html.ValidationMessageFor(model => model.Title)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.URL)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.URL)%>
                <%: Html.ValidationMessageFor(model => model.URL)%>
            </div>
            
            <div class="editor-label">
               <%: LangText.GetText("DESCRIPTION")%>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Description, new { rows = "5", cols = "47" })%>
                <%: Html.ValidationMessageFor(model => model.Description)%>
            </div>
            
           
           
            
            <p>
                <input type="submit" value="<%: LangText.GetText("SAVE") %>" />
            </p>
        </fieldset>

    <% } %>

   
