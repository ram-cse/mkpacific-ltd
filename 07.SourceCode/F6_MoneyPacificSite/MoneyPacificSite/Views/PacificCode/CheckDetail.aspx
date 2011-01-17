<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.PacificCodeCheckDetailViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CheckDetail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Check Detail</h2>

    
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <%:ViewData["message"] %>        
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodeNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodeNumber) %>
                <%: Html.ValidationMessageFor(model => model.CodeNumber) %>
            </div>            
            <input type="submit" value="View" />
        </fieldset>
    <% } %>

</asp:Content>

