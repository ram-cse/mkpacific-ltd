<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Customer.Master" Inherits="System.Web.Mvc.ViewPage<F5_MoneyPacificSite.ViewModels.PacificCodeDetailViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detail & Value</h2>

    
    <%using (Html.BeginForm())
      {
          if (Model.CodeNumber != null)
          {
              Html.DisplayFor(Model);
          }
          else
          {
          %>
            <div class="display-field"><%: Html.TextBoxFor(model => model.CodeNumber) %></div>
          <%
          }
          %>
          <input type = "submit" value = "View Detail" />
          <%
       } %>       
        
</asp:Content>

