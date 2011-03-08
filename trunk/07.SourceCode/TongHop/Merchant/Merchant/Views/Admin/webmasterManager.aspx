<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Merchant.Models.Webmaster>>" %>
<%@ Import Namespace="Merchant.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	webmasterManager
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.loadingdotdotdot.js" type="text/javascript"></script>

    <script type="text/javascript">
        function Disable(id) {
            
            $("#msg" + id).fadeIn(0);
            $("#msg"+id).Loadingdotdotdot({
                "speed": 400,
                "maxDots": 4
            });
            var url = "/admin/disableWebmaster/"+id;
            $.get(url, function (data) {
                $("#"+id).html(data).ready(function () {
                    $("#msg" + id).Loadingdotdotdot("Stop");
                    $("#msg" + id).fadeOut(100);
                    


                })
            }
            );
        }

        function Enable(id) {
            
            $("#msg" + id).fadeIn(0);
            $("#msg" + id).Loadingdotdotdot({
                "speed": 400,
                "maxDots": 4
            });
            var url = "/admin/EnableWebmaster/" + id;
            $.get(url, function (data) {
                $("#" + id).html(data).ready(function () {
                    $("#msg" + id).Loadingdotdotdot("Stop");
                    $("#msg" + id).fadeOut(100);
                    
                })
            }
            );

        }   
    </script>
    <% MPWebmasterEntities db = new MPWebmasterEntities(); %>
    <h2>Webmaster List</h2>
   <b> Total: <%:ViewData["total"].ToString() %> Webmasters</b>
    <br /><br />
    <table>
    <tr>
    <th>Username</th>
    <th>Name</th>
    <th>Money Available</th>
    <th>Status</th>
    <th>Payment Information</th>
    <th>Enable/Disable</th>
    </tr>
    <%foreach(var key in Model){ %>
    <tr>
    <% var temp = db.Earnings.Single(o => o.WebmasterId == key.Id); %>
    <td><a href="/admin/userdetail/<%:key.Username %>"><%:key.Username %></a></td>
    <td><%:key.Name %></td>
    <td><%:temp.Amount.ToString("n0") %> VND</td>
    
    <td>
    <% string status = "";
       if (key.Status == 0)
           status = "Not Active";
       else if (key.Status == -1)
           status = "Disabled";
       else if (key.Status == 1)
           status = "Enabled";
    %>
    <%: status %>
    
    </td>
    
    <td><a href="/admin/paymentInfo/<%:key.Id %>">Payment Information</a></td>
   <td>
    <%if (key.Status == 1)
      { %>
      <span id="<%:key.Id %>"> <a href="javascript:void()" onclick="Disable('<%:key.Id %>');">Disable Now!</a></span><span id="msg<%:key.Id %>" style="color:Red;"></span>
       
    <%}
      else if (key.Status == -1)
      { %>
      <span id="<%:key.Id %>"> <a href="javascript:void()" onclick="Enable('<%:key.Id %>');">Enable Now!</a></span><span id="msg<%:key.Id %>" style="color:Red;"></span>
    <%} %>
    </td>
    </tr>
    
    <%} %>
    </table>

</asp:Content>

