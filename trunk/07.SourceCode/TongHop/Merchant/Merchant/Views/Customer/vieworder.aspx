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
    <script type="text/javascript">
        function follow(id) {
            window.location = "/problem/follow/" + id;
        }
    </script>
   

    <fieldset>
        <legend><%: LangText.GetText("ORDER_DETAILS") %></legend>
        <div class="display-label"><b><%: LangText.GetText("WEBSITE") %>:</b> <%: ws.URL %></div>
        <div class="display-label"><b><%: LangText.GetText("NAME_PRODUCT")  %>: </b><%: Model.Order.Name %></div>
        
        
        <div class="display-label"><b><%: LangText.GetText("DATE_ORDER")%>: </b><%: String.Format("{0:g}", Model.Order.Date) %></div>
        
        
        <div class="display-label"><b><%: LangText.GetText("STATUS") %>:</b>
        <%if (Model.Order.Status == 411)
          { %>
          <em style="color:Green"> <%:LangText.GetText("NEW_ORDER_411")%>  </em>   
        <%} %>
        <%else if (Model.Order.Status == 412)
          { %>
          <em style="color:Green"><%: LangText.GetText("ON_DELIVERY_412") %></em>
        <%} %>
        <%else if (Model.Order.Status == 413)
          { %>
          <em style="color:Green"><%: LangText.GetText("END_TRANSACTION_413")%></em>
        <%} %>

        <%else if (Model.Order.Status == 421 || Model.Order.Status == 422 || Model.Order.Status == 423)
            { %>
            <em style="color:Green"><%: LangText.GetText("ORDER_PROBLEM")%></em>
          <%} %>
        </div>
        <div class="display-label"><b><%: LangText.GetText("AMOUNT")%> : </b><%: String.Format("{0:n}", Model.Order.Amount ) %> VND</div> 
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


        <% if(Model.Order.ProductType == 0){ %>

        <fieldset><legend><%: LangText.GetText("DELIVERY_INFORMATION") %></legend>
        
        <div class="display-label"><b><%: LangText.GetText("RECEIVER_ADDRESS")%></b>:</div>
        <%: Model.BuyCustomer.DeliveryAddress %>
        <div class="display-label"><b><%:LangText.GetText("DELIVERY_COMPANY")%>: </b></div>
        <input type="text" id="company" name="company" value="<%: Model.BuyCustomer.DeliveryCompany %>" disabled/>
        <div class="display-field"><b><%: LangText.GetText("TRACKING_CODE")%>: </b></div>
        <input type="text" id="trackingId" name="trackingId" value="<%: Model.BuyCustomer.TrackingNumber %>" disabled />
        <div class="display-field"><b><%: LangText.GetText("DATE_SEND") %>: </b></div>

        <input type="text" id="date" name="date" value="<%: Model.BuyCustomer.DateSend %>"disabled />
        <div class="display-field"><b><%: LangText.GetText("NOTE")%></b></div>

        <textarea id="note" name="note" cols="47" rows="3" disabled ><%: Model.BuyCustomer.Note %></textarea>
       
        
        </fieldset>
        

        <%} %>
</asp:Content>

