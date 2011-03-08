<%@ Page Title="" Language="C#"  Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.PacificCodeChangeCodeViewModel>" %>

<div id="han">
    <h2>Change Code</h2>

    <% using (Ajax.BeginForm("ChangeCode", "PacificCode", new AjaxOptions { UpdateTargetId = "han" }))
       {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Code Information</legend>
            
            <%:ViewData["message"] %>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodeNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodeNumber) %>
                <%: Html.ValidationMessageFor(model => model.CodeNumber) %>
            </div>
                        
            <input type="submit" value="Change Code" />
            
        </fieldset>

    <% } %>

    </div>
