<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.PacificCodeCheckDetailViewModel>" %>

<div id="han">
    <h2>CheckDetail</h2>

    <% using (Ajax.BeginForm("CheckDetail", "PacificCode", new AjaxOptions { UpdateTargetId = "han" }))
       {%>
        <%: Html.ValidationSummary(true)%>

    <fieldset>
            <%:ViewData["message"]%>        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodeNumber)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodeNumber)%>
                <%: Html.ValidationMessageFor(model => model.CodeNumber)%>
            </div>            
            <input type="submit" value="View" />        
    </fieldset>
    <% } %>

    </div>