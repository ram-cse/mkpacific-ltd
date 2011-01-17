<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.SecurityViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Security
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <% using (Html.BeginForm()){ %>        
        <h2><%: Model.storeManagerName %></h2><br /><br />
        <%:Html.HiddenFor(model=>model.managerId) %>
        <table width="100%">
            <tr>
                <th></th>
                <% for (int i = 0; i < 24; i++)
                   { %>
                   <td>
                        <%:("0" + i.ToString()).Substring(("0" + i.ToString()).Length==3?1:0)%> 
                   </td>
                <%} %>
            </tr>
        <% for(int d = 0; d < Model.lstSecurityTimeDay.Count; d++)
           { var item = Model.lstSecurityTimeDay[d];
               %>
           <tr>
                <th><%:item.dateName %></th>
                <%: Html.HiddenFor(model=>model.lstSecurityTimeDay[d].dateName) %>
                <% for (int i = 0; i < 24; i++)                       
                   {%>
                   <td>                    
                        <%--<%:Model.lstSecurityTimeDay[d].lstTimeTable[i].TimeItem.Hour%>:--%>
                        <%: Html.HiddenFor(model => model.lstSecurityTimeDay[d].lstTimeTable[i].TimeItemId) %>
                        <%: Html.CheckBoxFor(model => model.lstSecurityTimeDay[d].lstTimeTable[i].Enabled)%>
                   </td>
                <%} %>
           </tr>
        <%} %>    
        </table>
        <br /><input type="submit" value="Save" />
    <%} %>
</asp:Content>