<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.PacificCodeSendMoneyViewModel>" %>
<div id="han">
<h2>Send Money To Friend</h2>
<% using (Ajax.BeginForm("SendMoney", "PacificCode", new AjaxOptions { UpdateTargetId = "han" }))
   {%>
    <%: Html.ValidationSummary(true)%>
<fieldset> <legend>Information</legend>         
            <%: ViewData["message"]%><br />

            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodeNumber)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodeNumber)%>
                <%: Html.ValidationMessageFor(model => model.CodeNumber)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PhoneNumber)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PhoneNumber)%>
                <%: Html.ValidationMessageFor(model => model.PhoneNumber)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PhoneNumberConfirm)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PhoneNumberConfirm)%>
                <%: Html.ValidationMessageFor(model => model.PhoneNumberConfirm)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Amount)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Amount, String.Format("{0:F}", Model.Amount))%>
                <%: Html.ValidationMessageFor(model => model.Amount)%>
            </div>
            
            <p>
                <input type="submit" value="Send Money" />
            </p>
        </fieldset>
<% } %>



</div>