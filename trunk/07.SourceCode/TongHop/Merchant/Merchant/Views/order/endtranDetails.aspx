<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.OrderDetailsViewModel>" %>
<%@ Import Namespace="Merchant.Models" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("ORDER_DETAILS") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%  MPWebmasterEntities StoreDB = new MPWebmasterEntities();
     
    Website ws = StoreDB.Websites.Single(m=>m.Id == Model.Order.WebsiteId);
    
     %>
    <h2><%: LangText.GetText("ORDER_DETAILS") %></h2>

    <fieldset>
        <legend><%: LangText.GetText("ORDER_DETAILS") %></legend>
        <div class="display-label"><b><%: LangText.GetText("WEBSITE") %>:</b><%: ws.URL %></div>
        <div class="display-label"><b><%: LangText.GetText("NAME_PRODUCT")  %>: </b><%: Model.Order.Name %></div>
        
        
        <div class="display-label"><b><%: LangText.GetText("DATE_ORDER")%>: </b><%: String.Format("{0:g}", Model.Order.Date) %></div>
        
        
        <div class="display-label"><%: LangText.GetText("STATUS") %>:</b>
          <em style="color:Green"><%: LangText.GetText("END_TRANSACTION_413")%></em>
        </div>

        <div class="display-label"><b><%: LangText.GetText("AMOUNT")%> : </b><%: String.Format("{0:n}", Model.Order.Amount ) %></div>
        <div class="display-label"><b><%:LangText.GetText("BUYINGID")%> : </b><%: Model.Order.BuyingId %></div>
        <br />
        <% if (Model.Order.ProductType == 0)
           { %>
        <b style="color:Green"><%: LangText.GetText("REAL_PRODUCT")%></b>
        <%}
           else
           { %>
          <b style="color:Green"> <%: LangText.GetText("VIRTUAL_PRODUCT")%></b>
        <%} %>
        </fieldset>

       <fieldset><legend><%: LangText.GetText("DELIVERY_INFORMATION") %></legend>
        <div class="display-label"><b><%: LangText.GetText("RECEIVER_ADDRESS")%></b>: <%: Model.BuyCustomer.DeliveryAddress %></div>
        
        <div class="display-label"><b><%:LangText.GetText("DELIVERY_COMPANY")%>: </b><%: Model.BuyCustomer.DeliveryCompany %></div>
        <div class="display-field"><b><%: LangText.GetText("TRACKING_CODE")%>: </b><%: Model.BuyCustomer.TrackingNumber %></div>
        
        <div class="display-field"><b><%: LangText.GetText("DATE_SEND") %>: </b><%: Model.BuyCustomer.DateSend %></div>
        <div class="display-field"><b><%: LangText.GetText("NOTE")%></b><%: Model.BuyCustomer.Note %></div>
        
        </fieldset>
        
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>some thing here</center>

</asp:Content>