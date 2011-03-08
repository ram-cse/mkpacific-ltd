<%@ Page Title="" Language="C#"  Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Set Minimum Withdraw</title>
</head>
<body>
    <h2>Minimum Money for Webmaster to Withdraw</h2>

  <% using (Ajax.BeginForm("setWithDraw", "Admin",
        new AjaxOptions { UpdateTargetId = "messageArea" }))
     {%>

      <div id="messageArea">
      Minimum Amount <input type="text" id="Amount" name="Amount" value="<%:ViewData["Amount"] %>" style="width:350px;"/> VND (ex:1,000,000)
      <br />
      <br />
      <input type="submit" value="Save" />

      </div>
    <%} %>
</body>
</html>
