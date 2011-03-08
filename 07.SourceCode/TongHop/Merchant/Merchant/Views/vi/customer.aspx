<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/tplcontentVI.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.LoadPortal("VI"); %>
    <%: LangText.GetTextPortal("CUSTOMER_AREA") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% Response.Write(ViewData["content"]); %>

<span class="pageTitle">Money Pacific... Giải pháp tuyệt vời để mua hàng trực tuyến</span>
<br/><br/>
<strong>
Thật đơn giản, giờ bạn sẽ được Chúng Tôi
<ul>
 
  <li>Cung cấp giải pháp thanh toán trực tuyến bằng Tiền Mặt</li>
  <li>Chọn những website tốt nhất cho bạn</li>
  <li>Sẽ hoàn trả lại tiền nếu bạn không nhận hàng</li>
  <li>Sử dụng công nghệ hiện đại nhất để bảo đảm giao dịch của bạn</li>
</ul>
  
<span style="float:right;"> ...Chúng tôi quan tâm đến khách hàng và sự hài lòng của khách hàng.</span>
</strong>
<br/><br/>

<span class="pageTitle">Mua Mã Pacific</span>
<br/>
<br/>

<div class="box">

  <a href="/vi/buycash">
    <strong>Mua bằng Tiền Mặt</strong><br/>Mua Mã ở đâu
  </a>
  
</div>

<div class="box">

  <a href="/vi/buycredit">
    <strong>
      Mua bằng Thẻ Tín Dụng<br/>
      hoặc PayPal
    </strong>
  </a>
 
  
</div>

<div class="box">

  <a href="/StoreManager/AsktoBePartner">
    <strong>Trở thành Đại lý</strong><br/>
      <span style="font-size:10px;">
        Bạn muốn kiếm tiền<br/>
        và bán Mã Pacific
      </span>
    </a>

</div>
<br/>
<br/>
<br/>
<br/>
<br/>
<span class="pageTitle">Quản lý Mã Pacific</span>
<br/>
<br/>
<div class="box1">
 
     <a href="/PacificCode/CheckDetail?height=350&amp;width=450" class="thickbox">
              <strong>Thông tin và Giá trị Mã</strong>
            </a> 

</div>

<div class="box1">

     <a href="/PacificCode/ChangeCode?height=200&amp;width=400" class="thickbox">
             <strong>Đổi Mã Pacific</strong>
            </a> 

 
</div>

<div class="box1">
  
  <% if (Page.Request.IsAuthenticated)
     { %>
     <a href="#">
        <strong>Trả lại Mã Pacific</strong>
    </a>
  <%}
     else
     { %>

            <a href="/Account/Login?height=350&amp;width=650" class="thickbox">
            <strong>Trả lại Mã Pacific</strong>
            </a> 
    <%} %>
</div>

<br/>
<br/>
<br/>
<br/>
<br/>
<span class="pageTitle">Quản lý đơn hàng</span>
<br/>
<br/>
<div class="box1">
  

            <a href="/Account/Login?height=350&amp;width=650" class="thickbox">
            <strong>
                 Pacific Messenger
            </strong>
            </a> 
    

</div>

<div class="box1">
  
            <a href="/Account/Login?height=350&amp;width=650" class="thickbox">
            <strong>
            Báo cáo rắc rối
            </strong>
            </a> 
   
</div>

<div class="box1">
  

            <a href="/Account/Login?height=350&amp;width=650" class="thickbox">
             <strong>Theo dõi đơn hàng</strong>
            </a> 
   
</div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar" runat="server">
<center>
<span style="color:#663333;font-size:14.5px;text-align:center;font-weight:bold;">
<%: LangText.GetTextPortal("HOW_DOES_IT_WORK")%> <br />
<%: LangText.GetTextPortal("INFORMATION_CENTER") %>...</span>
</center>
<br />
<hr />
<br />
<span class="sidebartitle"><%: LangText.GetTextPortal("ADVANCE_FUNCTION")%> </span>
<ul>
<li><a href="/PacificCode/SendMoney?height=350&amp;width=450" class="thickbox"> <%: LangText.GetTextPortal("SEND_MONEY_TO_A_FRIEND")%> </a></li>
<li><a href="/PacificCode/SendSMS?height=300&amp;width=400" class="thickbox"><%: LangText.GetTextPortal("RECEIVE_AGAIN_MY_LAST_SMS")%></a></li>
<li><a href="/vi/createweb"><%: LangText.GetTextPortal("I_WANT_TO_CREATE_A_WEB_SITE_AND_SELL_ONLINE")%></a></li>
</ul>
<br />
<br />
<strong><%: LangText.GetTextPortal("RECOMMEND_US_AND_RECEIVE_A_GIFT")%></strong>
<ul>
<li><a href="/StoreManager/AskToBePartner"><%: LangText.GetTextPortal("SUGGEST_US_A_NEW_STORE")%></a></li>
<li><a href="/StoreManager/AskToBePartner"><%: LangText.GetTextPortal("SUGGEST_US_A_NEW_WEBSITE")%></a></li>
</ul>
<br />
<hr />
<br />
<span class="sidebartitle"><%: LangText.GetTextPortal("DISCOVER_THE_MINI_STORE")%></span>
<br /><br />
<center>
<%: LangText.GetTextPortal("DISCOVER_THE_MINI_STORE_TEXT1")%><br />
	<%: LangText.GetTextPortal("DISCOVER_THE_MINI_STORE_TEXT2")%><br />
    <br />
	<a href="/vi/ministore" class="visit"><%: LangText.GetTextPortal("VISIT_THE_MINI_SHOP_NOW")%></a>
</center>

<br />
<hr />
<br />
<span class="sidebartitle"><%: LangText.GetTextPortal("MONEY_PACIFIC_BY_PHONE")%></span>
<br /><br />
<ul>
<li><a href="/vi/question#phonefunctionlist"><%: LangText.GetTextPortal("LIST_OF_THE_FUNCTION_AVAILABLE_BY_PHONE")%></a></li>
<li><a href="/vi/question#myphoneislock"><%: LangText.GetTextPortal("MY PHONE_IS_LOCK_WHAT_IS_THE_SOLUTION")%></a></li>
</ul>
<br /><br />
</asp:Content>


