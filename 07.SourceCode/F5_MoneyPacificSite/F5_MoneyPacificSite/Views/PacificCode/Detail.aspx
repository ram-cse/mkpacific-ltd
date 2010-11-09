<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Customer.Master" Inherits="System.Web.Mvc.ViewPage<F5_MoneyPacificSite.ViewModels.PacificCodeDetailViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detail</h2>

    <fieldset>
        <legend>Thông tin</legend>
        
        <div class="display-label">CodeNumber</div>
        <div class="display-field"><%: Model.CodeNumber %></div>
        
        <div class="display-label">LastTransaction</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.LastTransaction) %></div>
        
        <div class="display-label">CustomerPhone</div>
        <div class="display-field"><%: Model.CustomerPhone %></div>
        
        <div class="display-label">InitialAmount</div>
        <div class="display-field"><%: Model.InitialAmount %></div>
        
        <div class="display-label">ActualAmount</div>
        <div class="display-field"><%: Model.ActualAmount %></div>
        
        <div class="display-label">CreateDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.CreateDate) %></div>
        
        <div class="display-label">ExpireDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.ExpireDate) %></div>
        
        <div class="display-label">Comment</div>
        <div class="display-field"><%: Model.Comment %></div>
        
        <div class="display-label">StorePhone</div>
        <div class="display-field"><%: Model.StorePhone %></div>
        
    </fieldset>
</asp:Content>

