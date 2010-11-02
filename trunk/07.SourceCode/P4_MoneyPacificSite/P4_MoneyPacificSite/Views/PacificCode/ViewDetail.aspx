<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.ViewModels.PacificCodeViewDetailViewModel>" %>

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewDetail</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewDetail</h2>
    <%: Html.Encode(ViewData["ErrorMessage"]) %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            <div class="editor-label">
                Pacific Code:                
            </div>
            <div class="editor-field">
                
                <%: Html.TextBoxFor(model => model.CodeNumber)%>
                <%: Html.ValidationMessageFor(model => model.CodeNumber)%>
            </div>
            
            <div>
                <input type="submit" value="View Detail" />
            </div>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to Index", "Index") %>
    </div>

</asp:Content>

