<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MPSecureValue
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
    <h2>Payment with Money Pacific</h2>
    <form action="http://localhost:50315/payment/MPSecureValue" name="frm" method="post">

    <fieldset><legend>Enter Money Pacific Code(limit 5 codes)</legend>
    <ol id="pacific_area">
        <li>
        <input type="text" name="code_1" id="code_1" /></li>
        </ol>
            <a href="javascript:void();" onclick="addField('code_','code_',5);">Add more code</a>
            <input type="hidden" id="hash" name="hash" value="<%:ViewData["hashbutton"] %>" />
      </fieldset>
    <%if (ViewData["CustomnerAddress"].ToString() == "1")
      {%>
     <fieldset><legend>Receive Information</legend>
     Reciever Address:<br />
     <input type="text" id="ReceiverAddress" name="ReceiverAddress" /><br /><br />
     Email: <br />
     <input type="text" id="email" name="email" />
     
     </fieldset>

     <%} %>
     <input type="submit" value="Pay Now" />
    
    </form>
   
   
    <%}
   else if(ViewData["type"].ToString() == "S")
   { %>
        <h1>Payment is successfully. System is redirecting in 5 seconds... </h1>
       

        <script language="javascript" type="text/javascript">
            window.setTimeout('window.location=" <%: ViewData["returnURL"] %>"; ', 5000);
         </script>

    <%} %>
</asp:Content>
