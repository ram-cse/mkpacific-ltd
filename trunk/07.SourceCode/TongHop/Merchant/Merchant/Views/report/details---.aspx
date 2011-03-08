<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.ReportDetailsViewModels>" %>
<%@ Import Namespace="Merchant.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.loadingdotdotdot.js" type="text/javascript"></script>



    <h2>Details </h2>
        <select id="byday" name="byday">
        <option value="1" >All Time</option>
        <option value="0" >Today</option>
        <option value="-1" >Yesterday</option>
        <option value="-7" >Last Week</option>
        <option value="-30" >Last Month</option>
        <option value="-90" >Last 3 Months</option>
        </select>
    
    <select id="byUrl" name="byUrl">
    <option value="-1">All Url</option>
       <%foreach(var key in Model.listUrl){ %>
           <option value= "<%:key.Id %>"><%:key.URL %></option>
            
        
        <%} %>

    </select>
         <script type="text/javascript">
             function View() {
                 $("#sortMsg").fadeIn(0);
                 $("#sortMsg").Loadingdotdotdot({
                     "speed": 400,
                     "maxDots": 4
                 });

                 var URL = "/report/viewdetails/" + $("#byday").val() + "_" + $("#byUrl").val();
                 $.get(URL, function (data) {
                     $("#tbcontent").html(data).ready(function () {
                         $("#sortMsg").Loadingdotdotdot("Stop");
                         $("#sortMsg").fadeOut(500);


                     })
                 });
                 

             }

            </script>
   
    <input type="button" value="View Report" onclick="javascript:View();"/>
    <br /><br />
    

       <span id="sortMsg" style="text-align:center;color:Red;font-size:20px;display:none;"></span>

       <table id="tbcontent">
            <tr>
               <th>1</th>
               <th>2</th>
               <th>3</th>
           </tr>
       
           <%foreach(var x in Model.list){ %>
               <tr>
                   <td><%:x.BuyingId %></td>
                   <td><%:x.Date %></td>
                   <td><%:x.Amount %></td>
               </tr>
           <%} %>
       </table>

</asp:Content>
