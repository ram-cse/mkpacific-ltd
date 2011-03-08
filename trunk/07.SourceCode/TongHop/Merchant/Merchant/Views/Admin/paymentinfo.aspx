<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.PaymentInfoViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Webmaster View Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Webmaster View Details</h2>

    <fieldset><legend>< Webmaster Information ></legend>
  <div class="display-label"> <b>Name: </b> <%:Model.webmaster.Name %><br /></div>
    <div class="display-label"><b>Account Type:</b> <%if(Model.webmaster.AccountType == 0){ %>
    Personal
    <%} else if(Model.webmaster.AccountType == 1){%>
    Business
    <%} %><br /></div>
    <div class="display-label"><b>Email: </b><%:Model.webmaster.Email %><br /></div>
    <div class="display-label"><b>Phone: </b><%:Model.webmaster.Phone %></div>
    </fieldset>
    
    <fieldset><legend>< Payment Information ></legend>
   <div class="display-label"> <b>Name: </b><%:Model.payment.Name %><br /></div>
    <div class="display-label"><b>Address: </b><%:Model.payment.Address %> <%:Model.payment.Ward %> <%: Model.payment.City %><br /></div>
   <div class="display-label"> <b>Email: </b><%:Model.payment.Email %><br /></div>
    <div class="display-label"><b>Phone: </b><%:Model.payment.Phone %><br /></div>
      
    </fieldset>

    <fieldset><legend>< Earning Information ></legend>
    <div class="display-label"><b>Total: </b><%:Model.earning.Amount.ToString("n0") %>VND <br /></div>
    <div class="display-label"><b>Last Withdraw: </b> <%:Model.earning.LastWithDraw.ToString() %></div>
        
    </fieldset>
    <p class="button">
    <a href="/Admin/webmasterManager">GO BACK TO WEBMASTER MANAGER</a>
    </p>
</asp:Content>
