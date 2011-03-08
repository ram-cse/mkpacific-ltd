<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.Script>" %>
<%@ Import Namespace="Merchant.Models" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
   Script
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function DisplayThumbail() {
            var getid = document.getElementById("buttonStyle");
            var button = getid.selectedIndex;
            var picture = document.getElementById("picture");
            var buttonUrl = "/Content/Images/bt" + (button + 1) + ".jpg";
            //  alert(buttonUrl);
            picture.innerHTML = '<img src="' + buttonUrl + '"/>';
        };
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
  <h1><%: LangText.GetText("GET_SCRIPT")%> </h1>
    <%
    MPWebmasterEntities StoreDb = new MPWebmasterEntities();
    string loginId = Page.User.Identity.Name;
    int webmasterId = StoreDb.Webmasters.Single(m=>m.Username == loginId).Id;
    var website = from w in StoreDb.Websites
                  where (w.WebmasterId == webmasterId && w.Status==1)
                  select w;
    %>

    <fieldset class="fieldsetborder">
        
         <p> <%: LangText.GetText("JUST_SELECT_YOUR_WEBSITE_AND_WE_WILL_GENERATE_A_NEW_SCRIPT_READY_TO_USE_FOR_YOUR_WEBSITE.")%></p>
         <p><%: LangText.GetText("YOU_CAN_CREATE_AS_MANY_SCRIPTS_AS_YOU_WANT_FOR_EACH_WEB_SITE.")%></p>
    
    <% using (Html.BeginForm())
    {%>
        <%: Html.ValidationSummary(true)%>
       
        <input type="hidden" id="Type" name="Type" value="<%: ViewData["key"] %>" />
        
        <%if (ViewData["key"].ToString() == "0")
         { %>
                <br /><br />
                <div style="margin-left:40px;">
                       
                     <strong><%: LangText.GetText("SELECT_WEBSITE")%></strong><br />
                     <%: LangText.GetText("IF_YOU_DONT_SEE_ANY_WEBSITE_IN_THIS_SECTION_YOU_MUST_GO_FIRST_IN_THE_MENU_WEBSITE/ADD_AND_EDIT")%><br /><br />
                    
                        <select id="website" name="website">
                        <% foreach (var x in website)
                           { %>
                                <option value="<%:x.Id%>"><%:x.URL%></option>
                        <%} %>
                        </select>
                        <br /><br /><br />


                        <input type="checkbox" id="virtual" name="virtual" />
                        <%: LangText.GetText("VIRTUAL_PRODUCT")%>
                        <br />
                        <span style="font-size:10px; color:Red;padding-right:150px;"> <%:LangText.GetText("YOU_MUST_SELECT_THIS_CHECK_BOX_ONLY_IF_THE_PRODUCT_YOU_WILL_SELL_IS_NOT_DELIVERED_BY_MAIL._DOWNLOAD_PRODUCT:_MUSIC,_SOFTWARE,_ACCESS_CODE")%>
                        <br /><br />
                        <%: LangText.GetText("YOU_CAN_ALSO_SELECT_THIS_CHECK_BOX_IF_YOU_DON’T_WANT_MONEY_PACIFIC_HELP_YOU_TO_MANAGE_THE_DELIVERY_(EXPERT_MODE)")%>
                        </span>


                        <br /><br /><br />
  
                          <%: LangText.GetText("SCRIPT_NAME")%><br />
                           <span style="font-size:10px;">
                                <%: LangText.GetText("THIS_NAME_IS_JUST_FOR_YOU,_TO_REMEMBER_WHAT_THIS_BUTTON_FOR")%>
                            </span>
                           
                           <br /><br />
                           <input type="text" id="scriptName" name="scriptName" />

                           <br /><br /><br />

                            <%: LangText.GetText("PRICE") %><br />
                            <span style="font-size:10px;">
                                    <%: LangText.GetText("INDICATE_HERE_THE_VALUE_OF_THE_BUTTON")%>
                            </span>
                            
                            <br /><br />

                           <input type="text" id="Price" name="Price" value="0" />
                                <select name="Currency" id="Currency" style="width:60px;">
                                <option value="VND">VND</option>
                           </select>
  
                            <br /><br /><br />
  
    
                           <%: LangText.GetText("RETURN_URL_SUCCESS")%>
                            <br />
                            <span style="font-size:10px;"> 
                                    <%: LangText.GetText("RETURN_URL_SUCCESS_TEXT") %>
                            </span>
                            <br /><br />

                            <input type="text" id="urlsuccess" name="urlsuccess"/>
                            <br /><br /><br />
  
                            <%: LangText.GetText("RETURN_URL_FAIL")%><br />
                            <span style="font-size:10px;">
                                <%: LangText.GetText("RETURN_URL_FAIL_TEXT") %>
                            </span>

                            <br /><br />
                            <input type="text" id="urlfail" name="urlfail" />
                            <br /><br /><br />
  
                            <%: LangText.GetText("BUTTON_STYLE")%><br />
                            <span style="font-size:10px;">
                                <%:LangText.GetText("JUST_SELECT_WHAT_DISPLAY_YOU_PREFER_FOR_THE_MONEY_PACIFIC_BUTTON_IN_YOUR_WEBSITE")%>
                            </span>
                            <br /><br />
                            
                            <select id="buttonStyle" name="buttonStyle" onchange="DisplayThumbail();">
                                <option value="1" selected>Button 1</option>
                                <option value="2">Button 2</option>
                            </select>

                            <br /><br />
                            
                            <span id="picture"><img src="/Content/Images/bt1.jpg" /></span>
  
                    </div>
  
 
       <% }
       // truong hop da co rui
           if(ViewData["key"] == "1") 
        {%>
          
            <%
                    var websites = from m in StoreDb.Websites
                         where(m.Webmaster.Username == Page.User.Identity.Name && m.Status==1)
                         select m;
            %>
    
            <input type="hidden" id="scriptId" name="scriptId" value="<%:Model.Id %>"/>
             <br /><br />
            <div style="margin-left:40px;">

                <strong><%: LangText.GetText("SELECT_WEBSITE")%></strong><br />
                <%: LangText.GetText("IF_YOU_DONT_SEE_ANY_WEBSITE_IN_THIS_SECTION_YOU_MUST_GO_FIRST_IN_THE_MENU_WEBSITE/ADD_AND_EDIT")%><br /><br />
   
                <select id="website1" name="website1">
                <% foreach (var x in websites)
                   { %>
                    <option value="<%:x.Id%>" <% if(x.Id == Model.WebsiteId){ %>
                        selected
                <%}%>>
    
                <%:x.URL %></option>
    
                <%} %>
                </select>
                
                <br /><br /><br />


                <input type="checkbox" id="virtual1" name="virtual1" 
                <% if(Model.Virtual == 1) {%> checked
                 <%} %>
                 />  <%: LangText.GetText("VIRTUAL_PRODUCT")%>
     
                  <br />
                <span style="font-size:10px; color:Red;padding-right:150px;">
                    <%:LangText.GetText("YOU_MUST_SELECT_THIS_CHECK_BOX_ONLY_IF_THE_PRODUCT_YOU_WILL_SELL_IS_NOT_DELIVERED_BY_MAIL._DOWNLOAD_PRODUCT:_MUSIC,_SOFTWARE,_ACCESS_CODE")%>
                <br /><br />
                <%: LangText.GetText("YOU_CAN_ALSO_SELECT_THIS_CHECK_BOX_IF_YOU_DON’T_WANT_MONEY_PACIFIC_HELP_YOU_TO_MANAGE_THE_DELIVERY_(EXPERT_MODE)")%>
                 </span>
                <br /><br /><br />
  
                  <%: LangText.GetText("SCRIPT_NAME")%><br />
                   <span style="font-size:10px;"><%: LangText.GetText("THIS_NAME_IS_JUST_FOR_YOU,_TO_REMEMBER_WHAT_THIS_BUTTON_FOR")%></span>
                   <br /><br />                             
                   <input type="text" id="scriptName1" name="scriptName1" value="<%:Model.ScriptName %>"/>
                   <br /><br /><br />


                   <%: LangText.GetText("PRICE") %><br />
                   <span style="font-size:10px;"><%: LangText.GetText("INDICATE_HERE_THE_VALUE_OF_THE_BUTTON")%></span>
                   <br /><br /> 
                   <input type="text" id="Price1" name="Price1"  value="<%: Model.Price %>"/>
                   <select name="Currency1" id="Currency1" style="width:60px;">
  
                   <option value="VND" <% if(Model.Currency == "VND") {%> selected <%} %> >VND</option>
                   <option value="USD" <% if(Model.Currency == "USD") {%> selected <%} %> >USD</option>
                   </select>
                   <br /><br /><br />

                    <%: LangText.GetText("RETURN_URL_SUCCESS")%><br />
                   <span style="font-size:10px;"> <%: LangText.GetText("RETURN_URL_SUCCESS_TEXT") %></span>
                    <br /><br />
                    <input type="text" id="urlsuccess1" name="urlsuccess1" value="<%: Model.URLSuccess %>"/>
   
                    <br /><br /><br />
  
                    <%: LangText.GetText("RETURN_URL_FAIL")%><br />
                    <span style="font-size:10px;"> <%: LangText.GetText("RETURN_URL_FAIL_TEXT") %></span>
                    <br /><br />
                        <input type="text" id="urlfail1" name="urlfail1" value="<%: Model.URLFail %>"/>
     
                    <br /><br /><br />

                    <%: LangText.GetText("BUTTON_STYLE")%><br />
                    <span style="font-size:10px;"> <%:LangText.GetText("JUST_SELECT_WHAT_DISPLAY_YOU_PREFER_FOR_THE_MONEY_PACIFIC_BUTTON_IN_YOUR_WEBSITE")%></span>
                    <br /><br />

                   <select id="buttonStyle1" name="buttonStyle1" onchange="DisplayThumbail1();">
                   <option value="1" <% if(Model.ButtonStyle == 1) {%> selected <%} %> >Button 1</option>
                   <option value="2" <% if(Model.ButtonStyle == 2) {%> selected <%} %>>Button 2</option>
                   </select>
                   <br /><br />

                   <span id="picture1"> 
                       <% if(Model.ButtonStyle==1){ %>
                       <img src="/Content/Images/bt1.jpg" border="0"/>
                       <%} %>
                        <% if(Model.ButtonStyle==2){ %>
                       <img src="/Content/Images/bt2.jpg" border="0"/>
                       <%} %>
                   </span>

             </div>
   
        <%} %>
        <center><input type="submit" value="<%: LangText.GetText("GET_SCRIPT") %>" /></center>

    <%} %>

      <p><%: LangText.GetText("AND_JUST_CUT_AND_PASTE_THIS_SCRIPT_IN_YOUR_WEBSITE_TO_THE_PLACE_YOU_WANT_THE_BUTTON")%></p>
    </fieldset>
</asp:Content>
<asp:Content ContentPlaceHolderID="SidebarInformation" runat="server">
<h3>Common Questions </h3>
<ul>
<li><a href="#">How to install Money Pacific on your website? </a></li>
<li><a href="#">What is the script? </a></li>
<li><a href="#">What is the return URL (success and fail)? </a></li>
<li><a href="#">What is a virtual product, and what this check for? </a></li>
</ul>

<div class="readmore"><a href="#">More questions</a></div>


<br /><br /><br /><br /><br /><br />

<center>
<div class="call">NEED HELP ?
<br/>

You don’t know how to do ...
<br/>

we will help you for FREE<br/>
Phone <span class="phonenumber"><%: ViewData["phone"] %></span> <br/>
Email: <a href="/messenger/create" >PACIFIC MESSENGER</a>
<br />
<span style="font-size:16px;">Y!M: <a href="ymsgr:sendIM?web_moneypacific"><img src="http://opi.yahoo.com/online?u=web_moneypacific&amp;m=g&amp;t=1" border="0" alt="" /> </a></span>

</div>
</center>



</asp:Content>