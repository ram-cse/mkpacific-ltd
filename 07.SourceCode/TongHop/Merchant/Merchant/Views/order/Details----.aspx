<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.OrderDetailsViewModel>" %>
<%@ Import Namespace="Merchant.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%  MPWebmasterEntities StoreDB = new MPWebmasterEntities();
     
    Website ws = StoreDB.Websites.Single(m=>m.Id == Model.Order.WebsiteId);
    
     %>
    <h2>Order Details</h2>

    <fieldset>
        <legend>Order Details</legend>
        <div class="display-label"><b>Website:</b> <%: ws.URL %></div>
        <div class="display-label"><b>Name: </b><%: Model.Order.Name %></div>
        
        
        <div class="display-label"><b>Date Order: </b><%: String.Format("{0:g}", Model.Order.Date) %></div>
        
        
        <div class="display-label"><b>Status:</b>
        <%if (Model.Order.Status == 411)
          { %>
          <em style="color:Green">New Order</em>   
        <%} %>
        <%if (Model.Order.Status == 1)
          { %>
          <em style="color:Green">On Delivery</em>
        <%} %>
        <%if (Model.Order.Status == 2)
          { %>
          <em style="color:Green">End Transaction</em>
        <%} %>
        </div>
        <div class="display-label"><b>Amount: </b><%: String.Format("{0:n}", Model.Order.Amount ) %></div>
        <div class="display-label"><b>BuyingId: </b><%: Model.Order.BuyingId %></div>
        </fieldset>
        <fieldset><legend>Delivery Information</legend>
        <% using( Html.BeginForm()){ %>
        <div class="display-label"><b>Receiver Address:</b></div>
        <%: Model.BuyCustomer.DeliveryAddress %>
        <div class="display-label"><b>Delivery Company</b></div>
        <input type="text" id="company" name="company" value="<%: Model.BuyCustomer.DeliveryCompany %>"/>
        <div class="display-field"><b>Tracking Code</b></div>
        <input type="text" id="trackingId" name="trackingId" value="<%: Model.BuyCustomer.TrackingNumber %>" />
        <div class="display-field"><b>Date Send</b></div>
        <input type="text" id="date" name="date" value="<%: Model.BuyCustomer.DateSend %>" />
        <div class="display-field"><b>Note</b></div>
        <textarea id="note" name="note" cols="47" rows="3" ><%: Model.BuyCustomer.Note %></textarea>
        <input type="hidden" name="buyingId" id="buyingId" value="<%: Model.BuyCustomer.BuyingId %>" />
        <input type="hidden" name="id" value="<%: Model.Order.Id %>" />
        <input type="submit" value="Send Product" />
        </fieldset>
        <%} %>
</asp:Content>

