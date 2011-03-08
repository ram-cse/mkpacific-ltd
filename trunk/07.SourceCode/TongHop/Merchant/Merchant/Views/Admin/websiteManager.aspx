<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Merchant.Models.Website>>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	websiteManager
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.loadingdotdotdot.js" type="text/javascript"></script>
   
    <script type="text/javascript">
        function Active(id) {

            $("#msg" + id).Loadingdotdotdot({
                "speed": 400,
                "maxDots": 4
            });

            var URL = "/admin/ValidateWebsite/" + id;
            $.get(URL, function (data) {
                $("#" + id).html("Validated!").ready(function () {
                    $("#msg" + id).Loadingdotdotdot("Stop");
                    $("#msg" + id).fadeOut(500);
                });

            });

        }


        
    </script>

    <h2>Website Manager</h2>
    <table>
    <tr>
    <th>Webmaster</th>
    <th>Title</th>
    <th>URL</th>
    <th>Date</th>
    <th>Description</th>
    <th>Status</th>
    </tr>
    <%foreach (var key in Model)
      { %>
    <tr>
    <td><%: key.Webmaster.Username%></td>
    <td><%:key.Title%></td>
    <td><%:key.URL%> </td>
    <td><%:key.DateJoin%></td>
    <td><%:Html.ShortString(key.Description, 100)%></td>
    
    <td>
 
    <%if (key.Status == 0)
      { %>
      <span id="<%:key.Id %>"><a href="javascript:void()" onclick="Active('<%:key.Id %>');">Validate Now!</a></span>
      <span id="msg<%:key.Id %>" style="color:Red"></span>
    <%}
      else
      { %>
      Validated
    <%} %>
    </td>
    </tr>
    <%} %>
    </table>
</asp:Content>

