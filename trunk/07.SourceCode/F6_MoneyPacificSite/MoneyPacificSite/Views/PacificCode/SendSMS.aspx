<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.PacificCodeSendSMSViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SendSMS
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>SendSMS</h2>
    
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            <%: ViewData["message"] %><br />        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PhoneNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PhoneNumber)%>
                <%: Html.ValidationMessageFor(model => model.PhoneNumber)%>
            </div>
            
            <div>
            The technical’s fee are <%: "500 VND" %>, charge on one of your Pacific Code.
I agree with the terms, and certify I ‘m the owner of this money.<br />

                <input type="submit" value="Confirm" />
                <script type="text/javascript">
                    function go() {
                        window.location = "Index/";
                    }
                </script>
                <input type="button" value="Cancel" onclick="go();"/>
            </div>
        </fieldset>

    <% } %>
</asp:Content>

