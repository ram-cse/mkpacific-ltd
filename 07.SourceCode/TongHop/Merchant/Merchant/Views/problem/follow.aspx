<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<Merchant.Models.MessageViewModel>" %>
<%@ Import Namespace="Merchant.Models" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.GetText(Page.User.Identity.Name); %>
    <%: LangText.GetText("FOLLOW_PROBLEM") %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% MPWebmasterEntities db = new MPWebmasterEntities();
   MyRoleProvider role = new MyRoleProvider();   
%>
    <script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.loadingdotdotdot.js" type="text/javascript"></script>

    <script type="text/javascript">
        function Disable() {
      //  alert("");
        $("#spanthongbao").Loadingdotdotdot({
                    "speed": 400,
                    "maxDots": 4
                }); 
              var URL = "/admin/disableFollow/"+$("#buyingcode").val();

              $.get(URL, function (data) {
                  $("#msg").html('<%: LangText.GetText("THE_FOLLOW_ORDER_IS_CLOSED_SUCCESSFULLY") %>').ready(function () {
                      $("#message").attr('disabled', true);
                      $("#btnsubmit").attr('disabled', true);
                      $("#customer").attr('disabled', true);
                      $("#webmaster").attr('disabled', true);
                      $("#file").attr('disabled', true);
                      $("#moneypacific").attr('disabled', true);

                      $("#spanthongbao").Loadingdotdotdot("Stop");
                      $("#spanthongbao").fadeOut(500);
                  });

              });

          }

          function ValidateProof() {
              $("#spanthongbao").Loadingdotdotdot({
                  "speed": 400,
                  "maxDots": 4
              });
              var URL = "/admin/ValidateProof/" + $("#buyingcode").val();
             
              $.get(URL, function (data) {
                  $("#msg").html('<%: LangText.GetText("THE_PROOF_OF_THE_ORDER_IS_VALIDATED_AND_THE_MONEY_NOW_IS_AVAILABLE_FOR_WEBMASTER.NOW_YOU_CAN_CLOSE_THE_FOLLOW_ORDER") %>').ready(function () {
//                      $("#message").attr('disabled', true);
//                      $("#btnsubmit").attr('disabled', true);
//                      $("#customer").attr('disabled', true);
//                      $("#webmaster").attr('disabled', true);
//                      $("#file").attr('disabled', true);
//                      $("#moneypacific").attr('disabled', true);

                      $("#spanthongbao").Loadingdotdotdot("Stop");
                      $("#spanthongbao").fadeOut(500);
                  });

              });

          }


          function DontValidateProof() {
              $("#spanthongbao").Loadingdotdotdot({
                  "speed": 400,
                  "maxDots": 4
              });
              var URL = "/admin/DontValidateProof/" + $("#buyingcode").val();

              $.get(URL, function (data) {
                  $("#msg").html('<%: LangText.GetText("MONEY_PACIFIC_DONT_VALIDATE_THE_PROOF_OF_ORDER_THAT_WEBMASTER_SENT_TO_US.YOUR_TRANSACTION_IS_NOT_SUCCESSFUL_AND_WE_WILL_GENARATE_A_NEW_PACIFIC_CODE_FOR_THE_CUSTOMER") %>').ready(function () {
//                      $("#message").attr('disabled', true);
//                      $("#btnsubmit").attr('disabled', true);
//                      $("#customer").attr('disabled', true);
//                      $("#webmaster").attr('disabled', true);
//                      $("#file").attr('disabled', true);
//                      $("#moneypacific").attr('disabled', true);

                      $("#spanthongbao").Loadingdotdotdot("Stop");
                      $("#spanthongbao").fadeOut(500);
                  });

              });

          }

    </script>

    <h1><%: LangText.GetText("MESSAGE") %></h1>
        <fieldset class="fieldsetborder">


    <%if (role.IsUserInRole(Page.User.Identity.Name, "Admin"))
      { %>
    <div class="button">
    <a href="javascript:void(0)" onclick="Disable();"><%: LangText.GetText("CLOSE_THE_FOLLOW_ORDER")%></a>
    </div>
    <div class="button">
    <a href="javascript:void(0)" onclick="ValidateProof();"><%: LangText.GetText("VALIDATE_PROOF")%></a>
    </div>
    <div class="button">
    <a href="javascript:void(0)" onclick="DontValidateProof();"><%: LangText.GetText("DONT_VALIDATE_PROOF")%></a>
    </div>
    <div id="msg" style="color:Green;font-weight:bold;font-size:15px;padding-top:10px;"></div>
    <div id="spanthongbao" style="color:Red"></div>
    <%} %>
     
    <% string disable="";
       string messageDisplay = "";
       if (Model.msgList.Any())
       {
           if (Model.msgList.FirstOrDefault().IsClose == true)
           {
               disable = "disabled";
               messageDisplay = LangText.GetText("THIS_FOLLOW_IS_CLOSED_BY_MONEY_PACIFIC_ADMIN");
           }
           %>
           
     <%} %>
     <span style="color:Red;font-weight:bold;text-decoration:blink;"><%:messageDisplay %></span><br /><br />
    <form action="/problem/postmessage" method="post" enctype="multipart/form-data">
       <textarea id="message" name="message" cols="70" rows="5" <%:disable %> > </textarea>
       <br /><br />
       <%: LangText.GetText("ATTACH_FILE")%>: <input type="file" id="file" name="file" <%:disable %> />
      <input type="checkbox" id="customer" name="customer"  checked <%:disable %> /> <%: LangText.GetText("CUSTOMER") %>
        
      <input type="checkbox" id="webmaster" name="webmaster" checked  <%:disable %> /> <%: LangText.GetText("WEBMASTER")%>

      <% if(ViewData["status"].ToString() == "423") {%>
        
        <input type="checkbox" id="moneypacific" name="moneypacific"  <%:disable %>
        <%if (role.IsUserInRole(Page.User.Identity.Name, "Admin"))
      { %> checked
      <%} %>
        /> <%: LangText.GetText("MONEY_PACIFIC") %>
      <%} %>
       <br /><br />
       <input type="hidden" id="buyingcode" name="buyingcode"  value="<%:ViewData["code"]%>"/>

       <input id="btnsubmit" type="submit" value="<%: LangText.GetText("POST_MESSAGE") %>" <%:disable %> />

   </form>
<br />
<br />
<table class="tablefollow">
<tr>
<th align="center" bgcolor="#339966"><center><%: LangText.GetText("SENDER") %></center></th>
<th align="center" width="400px" bgcolor="#339966"><center><%: LangText.GetText("MESSAGE|ATTACH_FILE")%></center></th>
<th align="center" bgcolor="#339966"><center><%: LangText.GetText("DATE|TIME")%></center></th>
<th align="center" bgcolor="#339966"><center><%: LangText.GetText("AVAILABLE_FOR")%></center></th>
</tr>
<% 
   string userlogin = Page.User.Identity.Name;
   bool IsWebmaster = role.IsUserInRole(userlogin,"Webmaster");
   bool IsCustomer = role.IsUserInRole(userlogin,"ProblemUser");
   bool IsMoneyPacific = role.IsUserInRole(userlogin, "Admin");  
    %>
    <%foreach(var message in Model.msgList){
            if(IsWebmaster && message.ToWebmaster)      // gui cho webmaster thi webmaster moi duoc xem 
            {
                   %>
   
           <% string sender = "";
              if (message.Sender == 0) {
                  sender = LangText.GetText("CUSTOMER");
            %>
                  <tr style="background-color:#d1e5f9">
            <% }
              else if (message.Sender == 1){
                  sender = LangText.GetText("WEBMASTER");
            %>
                  <tr style="background-color:#f5e0bb">
            <%}
              else if (message.Sender == 2)
              {
                  sender = LangText.GetText("MONEY_PACIFIC"); 
            %>
              <tr style="background-color:#ffce5a;">
            
             <%} %>
      
        <td><%:sender %></td>
        <td width="400px"><%  Response.Write(message.Message1); %><%if(message.DateSend.Date.ToShortDateString() == DateTime.Now.Date.ToShortDateString()) {%> <img src="/Content/Images/new.jpg" border="0" /><%} %>
        <br /><br />
        <%if (message.AttachFile != null)
          {%>
                 <% string file = message.AttachFile.Replace("/Content/File/","");
                    string urlroot = Request.Url.GetLeftPart(UriPartial.Authority);
                 %>
                 Attach File: <a href="<%:urlroot %><%:message.AttachFile %>"><%:file %></a>

        <%} %>
        <%if (message.Reason != null)
          { %>
          <b style="color:Green">REASON:</b> <%:message.Reason %>

        <%} %>
        </td>
        <td><%: message.DateSend %></td>
        <td>

        <input type="checkbox" <%if(message.ToCustomer) {%>checked<%} %> disabled /> C<br />
        <input type="checkbox" <%if(message.ToWebmaster) {%>checked<%} %> disabled /> W<br />
        <input type="checkbox" <%if(message.ToMPAdmin) {%>checked<%} %> disabled/> MP

        </td>
        </tr>

        <%}else if(message.ToCustomer && IsCustomer){ %> <!-- Gui cho khach hang thi Khach hang moi duoc xem -->
            
            <% string sender = "";
              if (message.Sender == 0) {
                  sender = "Customer";
            %>
                  <tr style="background-color:#d1e5f9">
            <% }
              else if (message.Sender == 1){ 
                   sender = "Website Admin";
            %>
                  <tr style="background-color:#f5e0bb">
            <%}
              else if (message.Sender == 2)
              {
                  sender = "Money Pacific Admin"; 
            %>
              <tr style="background-color:Yellow">
            
             <%} %>
      
        <td><%:sender %></td>
        <td width="400px"><%  Response.Write(message.Message1); %>
        <br /><br />
        <%if (message.AttachFile != null)
          {%>
                 <% string file = message.AttachFile.Replace("/Content/File/","");
                    string urlroot = Request.Url.GetLeftPart(UriPartial.Authority);
                 %>
                 Attach File: <a href="<%:urlroot %><%:message.AttachFile %>"><%:file %></a>

        <%} %>
        <%if (message.Reason != null)
          { %>
          <b style="color:Green">REASON:</b> <%:message.Reason %>

        <%} %>
        </td>
        <td><%: message.DateSend %></td>
        <td>

        <input type="checkbox" <%if(message.ToCustomer) {%>checked<%} %> disabled /> Customer<br />
        <input type="checkbox" <%if(message.ToWebmaster) {%>checked<%} %> disabled /> Website Admin<br />
        <input type="checkbox" <%if(message.ToMPAdmin) {%>checked<%} %> disabled/> Money Pacific

        </td>
        </tr>

        <%} else if(IsMoneyPacific && message.ToMPAdmin) {%><!-- Gui cho Money Pacific thi chi co money pacific duoc xem -->
            
            <% string sender = "";
              if (message.Sender == 0) {
                  sender = "Customer";
            %>
                  <tr style="background-color:#d1e5f9">
            <% }
              else if (message.Sender == 1){ 
                   sender = "Website Admin";
            %>
                  <tr style="background-color:#f5e0bb">
            <%}
              else if (message.Sender == 2)
              {
                  sender = "Money Pacific Admin"; 
            %>
              <tr style="background-color:Yellow">
            
             <%} %>
      
        <td><%:sender %></td>
        <td width="400px"><%  Response.Write(message.Message1); %>
        <br /><br />
        <%if (message.AttachFile != null)
          {%>
                 <% string file = message.AttachFile.Replace("/Content/File/","");
                    string urlroot = Request.Url.GetLeftPart(UriPartial.Authority);
                 %>
                 Attach File: <a href="<%:urlroot %><%:message.AttachFile %>"><%:file %></a>

        <%} %>
        <%if (message.Reason != null)
          { %>
          <b style="color:Green">REASON:</b> <%:message.Reason %>

        <%} %>
        </td>
        <td><%: message.DateSend %></td>
        <td>

        <input type="checkbox" <%if(message.ToCustomer) {%>checked<%} %> disabled /> Customer<br />
        <input type="checkbox" <%if(message.ToWebmaster) {%>checked<%} %> disabled /> Website Admin<br />
        <input type="checkbox" <%if(message.ToMPAdmin) {%>checked<%} %> disabled/> Money Pacific

        </td>
        </tr>

        <%} %>
<%} %>

</table>

</fieldset>

</asp:Content>

<asp:Content ContentPlaceHolderID="SidebarInformation" runat="server">

<center>something here</center>
</asp:Content>