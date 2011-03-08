<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.ReportDetailsViewModels>" %>
<%@ Import Namespace="Merchant.Models" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("REPORT_DETAILS")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.loadingdotdotdot.js" type="text/javascript"></script>


     <h1><%: LangText.GetText("REPORT_DETAILS")%> </h1>
    
    <fieldset class="fieldsetborder">
     
        <select id="byday" name="byday">
        <option value="1" ><%: LangText.GetText("ALL_TIME") %></option>
        <option value="0" ><%: LangText.GetText("TODAY") %></option>
        <option value="-1" ><%: LangText.GetText("YESTERDAY") %></option>
        <option value="-7" ><%: LangText.GetText("LAST_WEEK") %></option>
        <option value="-30" ><%: LangText.GetText("LAST_MONTH") %></option>
        <option value="-90" ><%: LangText.GetText("LAST_3_MONTH") %></option>
        </select>
    
    <select id="byUrl" name="byUrl">
    <option value="-1"><%: LangText.GetText("ALL_WEBSITE")%></option>
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
                         $("#sortMsg").html('');

                     })
                 });
                 

             }

            </script>
   
    <input class="button" type="button" value="<%: LangText.GetText("VIEW_REPORT") %>" onclick="javascript:View();"/>
    <br /><br />
    

       <span id="sortMsg" style="text-align:center;color:Red;font-size:20px; display:none; ">Loading</span>
       <br />
       <table id="tbcontent" class="tableindex">
            <tr>
               <th><%:LangText.GetText("BUYINGID") %></th>
               <th><%: LangText.GetText("DATE") %></th>
               <th><%: LangText.GetText("AMOUNT") %></th>
           </tr>
       
           <%foreach(var x in Model.list){ %>
               <tr>
                   <td><%:x.BuyingId %></td>
                   <td><%:x.Date %></td>
                   <td><%:x.Amount %></td>
               </tr>
           <%} %>
           <tr>
           <td colspan="3"></td>
           </tr>
           <tr>
           <td></td>
           <td></td>
           <td><strong><%: LangText.GetText("TOTAL") %>: <%: ViewData["total"] %> VND </strong></td>
           </tr>
       </table>
       
       </fieldset>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SidebarInformation" runat="server">

<center>some thing here</center>

</asp:Content>