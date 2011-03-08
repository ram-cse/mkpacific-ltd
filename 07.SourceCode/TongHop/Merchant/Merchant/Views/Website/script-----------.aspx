<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.Script>" %>
<%@ Import Namespace="Merchant.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	script
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
    MPWebmasterEntities StoreDb = new MPWebmasterEntities();
    string loginId = Page.User.Identity.Name;
    int webmasterId = StoreDb.Webmasters.Single(m=>m.Username == loginId).Id;
    var website = from w in StoreDb.Websites
                  where (w.WebmasterId == webmasterId)
                  select w;
 %>
    <h2>Get Script </h2>
     
    <% using (Html.BeginForm())
       {%>
        <%: Html.ValidationSummary(true)%>
       
        <input type="hidden" id="Type" name="Type" value="<%: ViewData["key"] %>" />
<%if (ViewData["key"].ToString() == "0")
  { %>
  
    <table>

    <tr>
    <td valign="top">
   <div class="editor-label">
   Select Website
   </div>
    <select id="website" name="website">
    <% foreach (var x in website)
       { %>
            <option value="<%:x.Id%>"><%:x.URL%></option>
    <%} %>
    </select>
    <input type="checkbox" id="virtual" name="virtual" /> Virtual Product
    <input type="checkbox" id="deliveryAddress" name="deliveryAddress" checked /> Delivery Address
    <div class="editor-label">
   Script Name
   </div>
   <input type="text" id="scriptName" name="scriptName" />

    <div class="editor-label">
   Item Name
   </div>
   <input type="text" id="ItemName" name="ItemName"/>
   
    <div class="editor-label">
   Item Id
   </div>
   <input type="text" id="ItemId" name="ItemId"/>

     <div class="editor-label">
    Price
   </div>

   <input type="text" id="Price" name="Price" value="0" />
   <select name="Currency" id="Currency">
   <option value="VND">VND</option>
   </select>
   </td>
   <td>
   <span id="picture"><img src="/Content/Images/bt1.jpg" /></span>
   <script type="text/javascript">
       function DisplayThumbail() {
           var getid = document.getElementById("buttonStyle");
           var button = getid.selectedIndex;
           var picture = document.getElementById("picture");
           var buttonUrl = "/Content/Images/bt" + (button+1) + ".jpg";
         //  alert(buttonUrl);
           picture.innerHTML = '<img src="'+buttonUrl+'"/>';
       };

       function code() {
           var codeplace = document.getElementById("codeplace");
           codeplace.style.display = "block";

       }
   </script>
   
   </td>
   <td valign="top">
    <div class="editor-label">
    Button Style
   </div>
   <select id="buttonStyle" name="buttonStyle" onchange="DisplayThumbail();">
   <option value="1" selected>Button 1</option>
   <option value="2">Button 2</option>
   </select>

    <div class="editor-label">
    Return Url(If success)
   </div>
   <input type="text" id="urlsuccess" name="urlsuccess"/>

    <div class="editor-label">
    Return Url(If fail)
   </div>
   <input type="text" id="urlfail" name="urlfail" />

    <div class="editor-label">
    Email to Receive Notification
   </div>
   <input type="text" id="EmailNotification" name="EmailNotification" />

   
   </td>
   </tr>
   </table>
   
  <!-- <textarea id="codeplace" name="codeplace" cols="50" rows="5" style="display:none;" ></textarea> -->
 
   
   

       <% }
       // truong hop da co rui
           if(ViewData["key"] == "1") 
        {%>
          
   <%
       var websites = from m in StoreDb.Websites
                     where(m.Webmaster.Username == Page.User.Identity.Name)
                     select m;
       
        %>
    
    <input type="hidden" id="scriptId" name="scriptId" value="<%:Model.Id %>"/>
          
    <table>

    <tr>
    <td valign="top">
   <div class="editor-label">
   Select Website
   </div>
    <select id="website1" name="website1">
    <% foreach (var x in websites)
       { %>
        <option value="<%:x.Id%>" <% if(x.Id == Model.WebsiteId){ %>
            selected
    <%}%>>
    
    <%:x.URL %></option>
    
    <%} %>
    </select>
    
     <input type="checkbox" id="virtual1" name="virtual1" 
    <% if(Model.Virtual == 1) {%> checked
     <%} %>
     /> Virtual Product
     
    <input type="checkbox" id="virtual1" name="deliveryAddress1" 
    <% if(Model.CustomerAddress == 1) {%> checked
     <%} %>  
     /> Delivery Address

    <div class="editor-label">
   Script Name
   </div>                                          
   <input type="text" id="scriptName1" name="scriptName1" value="<%:Model.ScriptName %>"/>

    <div class="editor-label">
   Item Name
   </div>
   <input type="text" id="ItemName1" name="ItemName1" value="<%: Model.ItemName %>"/>
   
    <div class="editor-label">
   Item Id
   </div>
   <input type="text" id="ItemId1" name="ItemId1" value="<%: Model.ItemId %>"/>

     <div class="editor-label">
    Price
   </div>
   
   <input type="text" id="Price1" name="Price1"  value="<%: Model.Price %>"/>
   loai tien: <%:Model.Currency %>
   <select name="Currency1" id="Currency1">
  
   <option value="VND" <% if(Model.Currency == "VND") {%> selected <%} %> >VND</option>
   <option value="USD" <% if(Model.Currency == "USD") {%> selected <%} %> >USD</option>
   </select>
   </td>
   <td>
   <span id="picture1"> 

   <% if(Model.ButtonStyle==1){ %>
   <img src="/Content/Images/bt1.jpg" border="0"/>
   <%} %>
    <% if(Model.ButtonStyle==2){ %>
   <img src="/Content/Images/bt2.jpg" border="0"/>
   <%} %>
   
   </span>
   <script type="text/javascript">
       function DisplayThumbail1() {
           var getid = document.getElementById("buttonStyle1");
           var button = getid.selectedIndex;
           var picture = document.getElementById("picture1");
           var buttonUrl = "/Content/Images/bt" + (button + 1) + ".jpg";
           //  alert(buttonUrl);
           picture.innerHTML = '<img src="' + buttonUrl + '"/>';
       };

       function code() {
           var codeplace = document.getElementById("codeplace");
           codeplace.style.display = "block";

       }
   </script>
   
   </td>
   <td valign="top">
    <div class="editor-label">
    Button Style
   </div>
   <select id="buttonStyle1" name="buttonStyle1" onchange="DisplayThumbail1();">
   <option value="1" <% if(Model.ButtonStyle == 1) {%> selected <%} %> >Button 1</option>
   <option value="2" <% if(Model.ButtonStyle == 2) {%> selected <%} %>>Button 2</option>
   </select>

    <div class="editor-label">
    Return Url(If success)
   </div> 
   <input type="text" id="urlsuccess1" name="urlsuccess1" value="<%: Model.URLSuccess %>"/>

    <div class="editor-label">
    Return Url(If fail)
   </div>
   <input type="text" id="urlfail1" name="urlfail1" value="<%: Model.URLFail %>" />

    <div class="editor-label">
    Email to Receive Notification
   </div>
   <input type="text" id="EmailNotification1" name="EmailNotification1" value="<%: Model.Email %>"/>

   
   </td>
   </tr>
   </table>
        



        <%} %>
        <center><input type="submit" value="Get Script" /></center>

    <%} %>
</asp:Content>
