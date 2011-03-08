<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/tplcontentEN.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.LoadPortal("EN"); %>
    <%: LangText.GetTextPortal("CUSTOMER_AREA") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% Response.Write(ViewData["content"]); %>

 <span class="pageTitle">Money Pacific... The natural way to buy online</span>
<br/><br/>
<strong>
It’s so simple, now you know :
<ul>
 
  <li>We provide the solution for online payment with cash</li>
  <li>We select the best website for you</li>
  <li>We refund you if you don’t receive what you order </li>
  <li>We use the last technologies to protect your transaction</li>
</ul>
  
<span style="float:right;"> ...We just take care of you and your happiness.</span>
</strong>
<br/><br/>

<span class="pageTitle">Buy a Pacific Code</span>
<br/>
<br/>

<div class="box">
  <a href="/en/buycash"> <strong>Buy with Cash</strong><br/>
  Where to buy a Pacific Code</a>
</div>

<div class="box">
  <a href="/en/buycredit"> <strong>Buy with Credit card<br/>
  Or PayPal</strong>
  </a>
</div>

<div class="box">
  <a href="/StoreManager/AsktoBePartner"> <strong>Become a dealer</strong><br/>
    <span style="font-size:10px">You want make money<br/>
  and sale code</span>
  </a>
</div>
<br/>
<br/>
<br/>
<br/>
<br/>
<span class="pageTitle">Manage your Pacific Code</span>
<br/>
<br/>
<div class="box1">
   
        <a href="/PacificCode/CheckDetail?height=350&amp;width=450" class="thickbox">
        <strong>Info & Value</strong></a>
   
  <br/>
 
</div>

<div class="box1">
 
         <a href="/PacificCode/ChangeCode?height=200&amp;width=400" class="thickbox">
        <strong>Change my Code</strong>
      </a>
     
</div>

<div class="box1">
 
        
            <a href="/Account/Login?height=350&amp;width=650" class="thickbox">
           <strong>Refund my Code</strong>
            </a> 



	  
</div>

<br/>
<br/>
<br/>
<br/>
<br/>
<span class="pageTitle">Manage your order</span>
<br/>
<br/>
<div class="box1">
 
         <a href="/Account/Login?height=350&amp;width=650" class="thickbox">
           <strong>Pacific Messenger</strong>
            </a> 
 
  <br/>

</div>

<div class="box1">
  
  
            <a href="/Account/Login?height=350&amp;width=650" class="thickbox">
            <strong>Report a problem</strong>
            </a> 

  
</div>

<div class="box1">
 

            <a href="/Account/Login?height=350&amp;width=650" class="thickbox">
             <strong>Follow your order</strong>
            </a> 

 
</div>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar" runat="server">
  <% Response.Write(ViewData["contentPanel"]); %>
</asp:Content>


