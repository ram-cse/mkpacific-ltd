<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.AdminPaymentReportViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	paymentReport
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.loadingdotdotdot.js" type="text/javascript"></script>

 <script type="text/javascript">
     function showURL() {
         
         $("#detailsMessage").fadeIn(0);
         $("#detailsMessage").Loadingdotdotdot({
             "speed": 400,
             "maxDots": 4
         });
         var url = "/admin/viewURL/" + $("#byWebmaster").val();
         $.get(url, function (data) {
             $("#byURL").html(data).ready(function () {
                 $("#detailsMessage").Loadingdotdotdot("Stop");
                 $("#detailsMessage").fadeOut(500);

             })
         }
            );
     }
     function ViewPaymentDetails() {
         $("#detailsMessage").fadeIn(0);
         $("#detailsMessage").Loadingdotdotdot({
             "speed": 400,
             "maxDots": 4
         });
         var url = "/admin/ViewPaymentDetails/" + $("#byWebmaster").val() + "_" + $("#byURL").val();
         $.get(url, function (data) {
             $("#details").html(data).ready(function () {
                 $("#detailsMessage").Loadingdotdotdot("Stop");
                 $("#detailsMessage").fadeOut(500);

             })
         }
            );

     }   
    </script>



    <h2>Financial Report</h2>
    <fieldset><legend>Webmaster Money Available</legend>
    FilterBy <select id="byWebmaster" name="byWebmaster" onchange="showURL();">
        <option value="" selected>----select----</option>
        <%foreach (var key in Model.listwebmaster)
          { %>
          <option value="<%:key.Id %>"><%:key.Username %></option>
        <%} %>
    </select>
   

   Website <select id="byURL" name="byURL" onchange="ViewPaymentDetails();">
       
    </select>

    <span id="detailsMessage" style="color:Red"></span>

    <div id="details">
    <ul>
     <% int Total=0;
        foreach (var key in Model.listOrder)
        {
            Total += key.Amount;
        %>
            <li><a href="/order/details/<%:key.Id %>"> <%: key.BuyingId %></a> - <%: key.Amount.ToString("n0") %> VND - <%: key.Date %></li>
      <%} %>
   
    </ul>
   <b> Total: <%: Total.ToString("n0") %> VND </b>
    </div>
    
    </fieldset>
</asp:Content>
