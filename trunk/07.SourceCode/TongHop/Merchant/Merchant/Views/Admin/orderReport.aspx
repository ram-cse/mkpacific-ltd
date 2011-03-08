<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.AdminOrderReportViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	orderReport
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.loadingdotdotdot.js" type="text/javascript"></script>
    
    <h2>Order Report</h2>
    <script type="text/javascript">
        function showURL() {
            $("#msg").fadeIn(0);
            $("#msg").Loadingdotdotdot({
                "speed": 400,
                "maxDots": 4
            });
            var url = "/admin/viewURL/" + $("#byWebmaster").val();
            $.get(url, function (data) {
                $("#byURL").html(data).ready(function () {
                    $("#msg").Loadingdotdotdot("Stop");
                    $("#msg").fadeOut(500);
                
                })
            }
            );
        }
        function ViewDetails() {
            $("#detailsMessage").fadeIn(0);
            $("#detailsMessage").Loadingdotdotdot({
                "speed": 400,
                "maxDots": 4
            });
            var url = "/admin/showdetaildata/" + $("#byWebmaster").val() + "_" + $("#byURL").val();
            
            $.get(url, function (data) {
                $("#details").html(data).ready(function () {
                    $("#detailsMessage").Loadingdotdotdot("Stop");
                    $("#detailsMessage").fadeOut(500);

                })
            }
            );


        }
    
    </script>
    <fieldset><legend>All Order</legend>
    FilterBy <select id="byWebmaster" name="byWebmaster" onchange="showURL();">
       <option value="" selected>----select----</option>
        <%foreach (var key in Model.listWebmaster)
          { %>
          <option value="<%:key.Id %>"><%:key.Username %></option>
        <%} %>
    </select>
    <span id="msg" style="color:Red"></span>

   Website <select id="byURL" name="byURL" onchange="ViewDetails();">
     
    </select>

    <span id="detailsMessage" style="color:Red"></span>
    <ul id="details">
     <% foreach (var key in Model.listOrder)
       { %>
    <li><%: key.BuyingId %> - <%: key.Amount.ToString("n0") %> VND - <%:key.Date %></li>
    <%} %>
   
    </ul>
     </fieldset>
</asp:Content>
