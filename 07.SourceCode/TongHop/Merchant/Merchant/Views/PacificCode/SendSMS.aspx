<%@ Page Title="" Language="C#"  Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.PacificCodeSendSMSViewModel>" %>

<div id="han">
    <h2>Send SMS</h2>

    <% using (Ajax.BeginForm("SendSMS", "PacificCode", new AjaxOptions { UpdateTargetId = "han" }))
       {%>
        <%: Html.ValidationSummary(true)%>

        <fieldset>
            <legend>Phone Information</legend>
            <div style="color:Red"><%: ViewData["message"]%><br /></div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PhoneNumber)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PhoneNumber)%>
                <%: Html.ValidationMessageFor(model => model.PhoneNumber)%>
            </div>
            
            <div>
            The technical’s fee are <%: "500 VND"%>, charge on one of your Pacific Code.
I agree with the terms, and certify I ‘m the owner of this money.<br />

                <input type="submit" value="Confirm" />
                <script type="text/javascript">
                    function go() {
                        window.location = "Index/";
                    }
                </script>
                <%--<input type="button" value="Cancel" onclick="go();"/>--%>
            </div>
        </fieldset>

    <% } %>


    </div>
