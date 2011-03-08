<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Merchant.Models.LogOnModel>" %>
<%@ Import Namespace="Merchant.Helper" %>

   <div id="han">
   <script type="text/javascript">
       function redirectPage() {
           var check = document.getElementById("han");
           var valueHan = check.innerHTML;
           var url = '<%: ConfigurationManager.AppSettings["URL"] %>';
          
           if (valueHan == '') //webmaster
               window.location =  url + '/account/'
           else if (valueHan == 0)//customer
               window.location = url + '/customer'
           else if (valueHan == 1)//admin
                window.location = url + '/admin'
             
       }
    </script>
   <% LangText.Load(Page.User.Identity.Name.ToString()); %>
    <h2>
      <%: LangText.GetText("LOGIN")%></h2>
    <p>
    <%: LangText.GetText("PLEASE_ENTER_YOUR_USERNAME_AND_PASSWORD")%>
    
    <span style="background-color:Green;"><%: Html.ActionLink(LangText.GetText("REGISTER"), "Register") %> </span>

    <%:LangText.GetText("IF_YOU_DONT_HAVE_AN_ACCOUNT")%>
    </p>
   
    <% using (Ajax.BeginForm("login", "Account", new AjaxOptions { UpdateTargetId = "han", OnSuccess = "redirectPage" }))
       { %>
        <%: Html.ValidationSummary(true, LangText.GetText("LOGIN_WAS_UNSUCCESSFUL_PLEASE_CORRECT_THE_ERRORS_AND_TRY_AGAIN"))%>
        <div>
            <fieldset>
                <legend><%: LangText.GetText("ACCOUNT_INFORMATION")%></legend>
                
                <div class="editor-label">
                    <%: LangText.GetText("USERNAME")%>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName)%>
                    <%: Html.ValidationMessageFor(m => m.UserName)%>
                </div>
                
                <div class="editor-label">
                    <%: LangText.GetText("PASSWORD")%>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password)%>
                    <%: Html.ValidationMessageFor(m => m.Password)%>
                </div>
                
                <div class="editor-label">
                    <%: Html.CheckBoxFor(m => m.RememberMe)%>
                     <%: LangText.GetText("REMEMBER_PASSWORD")%>
                </div>
                
                <p>
                    <input type="submit" value="<%: LangText.GetText("LOGIN") %>" />
                </p>
            </fieldset>
        </div>
    <% } %>

     </div>