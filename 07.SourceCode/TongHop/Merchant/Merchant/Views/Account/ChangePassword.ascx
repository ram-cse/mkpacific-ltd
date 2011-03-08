<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Merchant.Models.ChangePasswordModel>" %>
<%@ Import Namespace="Merchant.Helper" %>
<div id="han">
<% LangText.Load(Page.User.Identity.Name);%>
   <h2> <%: LangText.GetText("CHANGE_PASSWORD")%></h2>
   
    <p>
        <%: LangText.GetText("NEW_PASSWORDS_ARE_REQUIRED_TO_BE_A_MINIMUM_OF")%> <%: ViewData["PasswordLength"] %> <%:LangText.GetText("CHARACTERS_IN_LENGTH")%>
    </p>

     <% using (Ajax.BeginForm("changepassword", "Account", new AjaxOptions { UpdateTargetId = "han" }))
        {%>
        
        <div>
            <fieldset>
                <legend><%:LangText.GetText("ACCOUNT_INFORMATION")%></legend>
                
                <div class="editor-label">
                    <%: LangText.GetText("CURRENT_PASSWORD")%>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.OldPassword)%><br />
                    <%: Html.ValidationMessageFor(m => m.OldPassword)%>
                </div>
                
                <div class="editor-label">
                    <%:LangText.GetText("NEW_PASSWORD")%>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.NewPassword)%><br />
                    <%: Html.ValidationMessageFor(m => m.NewPassword)%>
                </div>
                
                <div class="editor-label">
                    <%:LangText.GetText("CONFIRM_PASSWORD")%>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.ConfirmPassword)%><br />
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword)%>
                </div>
                
                <p>
                    <input type="submit" value="OK" />
                </p>
            </fieldset>
        </div>
    <% } %>
    </div>