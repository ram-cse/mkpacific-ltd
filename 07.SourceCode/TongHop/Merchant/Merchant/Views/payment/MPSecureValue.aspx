<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="Merchant.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<% LangText.Load(Page.User.Identity.Name); %>
    <%: LangText.GetText("PAYMENT_WITH_MONEY_PACIFIC")%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% if (ViewData["type"].ToString() == "F")
   { %>
<script type="text/javascript">
    //Add more fields dynamically.
    function addField(field, area, limit) {
        if (!document.getElementById) return; //Prevent older browsers from getting any further.
        var field_area = document.getElementById("pacific_area");
        var all_inputs = field_area.getElementsByTagName("input"); //Get all the input fields in the given area.
        //Find the count of the last element of the list. It will be in the format '<field><number>'. If the 
        //		field given in the argument is 'friend_' the last id will be 'friend_4'.
        var last_item = all_inputs.length - 1;
        var last = all_inputs[last_item].id;
        var count = Number(last.split("_")[1]) + 1;

        //If the maximum number of elements have been reached, exit the function.
        //		If the given limit is lower than 0, infinite number of fields can be created.
        if (count > limit && limit > 0) return;

        if (document.createElement) { //W3C Dom method.
            var li = document.createElement("li");
            var input = document.createElement("input");
            input.id = field + count;
            input.name = field + count;
            input.type = "text"; //Type of field - can be any valid input type like text,file,checkbox etc.
            li.appendChild(input);
            field_area.appendChild(li);
        } else { //Older Method
            field_area.innerHTML += "<li><input name='" + (field + count) + "' id='" + (field + count) + "' type='text' /></li>";
        }
    }

</script>
    <h2><%: LangText.GetText("PAYMENT_WITH_MONEY_PACIFIC")%></h2>
    <form action="http://localhost:50315/payment/MPSecureValue" name="frm" method="post">

    <fieldset><legend><%: LangText.GetText("ENTER_MONEY_PACIFIC_CODE(LIMIT_5_CODES)")%></legend>
    <ol id="pacific_area">
        <li>
           <input type="text" name="code_1" id="code_1" />
        </li>
    
    </ol>
        
    <a href="javascript:void();" onclick="addField('code_','code_',5);"><%: LangText.GetText("ADD_MORE_CODE") %></a>
    <input type="hidden" id="hash" name="hash" value="<%:ViewData["hashbutton"] %>" />
        
    <br /><br />

    Email: <input type="text" id="email" name="email" /><br /><br />
    <input type="hidden" id="virtualProduct" name="virtualProduct" value="<%:ViewData["virutal"] %>" />
    
    <%
        string buttonTitle = LangText.GetText("PAY_NOW!");
        if (ViewData["virutal"].ToString() == "0")
            buttonTitle = LangText.GetText("NEXT");
    %>
    <input type="submit" value="<%:buttonTitle %>" />
     </fieldset>

    <%}
   else if(ViewData["type"].ToString() == "S")// form thanh toan thanh cong
   { %>
        <h1><%: LangText.GetText("PAYMENT_IS_SUCCESSFULLY._SYSTEM_IS_REDIRECTING_IN_5_SECONDS...")%></h1>
       
        <script language="javascript" type="text/javascript">
            window.setTimeout('window.location=" <%: ViewData["returnURL"] %>"; ', 5000);
         </script>

    <%}// form nhap address of customer
   else if (ViewData["type"].ToString() == "A")
   {%>
    <h2><%: LangText.GetText("PAYMENT_WITH_MONEY_PACIFIC")%></h2>

     <form action="http://localhost:50315/payment/MPSecureValue" name="frm" method="post">
     
     <fieldset><legend><%: LangText.GetText("RECEIVER_INFORMATION")%></legend>
     <%:LangText.GetText("NAME") %><br />
     <input type="text" id="name" name="name" /><br /><br />
     <%:LangText.GetText("RECEIVER_ADDRESS") %>:<br />
     <input type="text" id="ReceiverAddress" name="ReceiverAddress" /><br /><br />
     <%: LangText.GetText("PHONE") %>:<br />
     <input type="text" id="phone" name="phone" />
     <input type="hidden" id="Hanhashbutton" name="Hanhashbutton" value="<%:ViewData["hash"]%>" />
     <input type="hidden" id="emailaddress" name="emailaddress" value="<%:ViewData["email"]%>" />
     <input type="hidden" id="codelist" name="codelist" value="<%:ViewData["codelist"] %>" />
     <input type="hidden" id="checkit" name="checkit" value="0" />;
     <input type="submit" value="<%:LangText.GetText("PAY_NOW!") %>" />
     </fieldset>
     </form>

    <%} %>

</asp:Content>
