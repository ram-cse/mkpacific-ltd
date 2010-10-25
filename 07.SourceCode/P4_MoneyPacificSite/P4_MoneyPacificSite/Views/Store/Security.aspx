<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/StoreManager.Master" 
Inherits="System.Web.Mvc.ViewPage<P4_MoneyPacificSite.ViewModels.StoreSecurityViewModel>" %>
<%@ Import Namespace="P4_MoneyPacificSite.ViewModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Security
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Security</h2>

    <table>
        <tr>
        <% 
        // for(int i = 0; i < Model.BuyPacificCodeSchedule.arrDays.Count(); i++)
        // Chuyển ngày tháng sang bảng matrận cho dễ hiển thị 
        int[,] matrixSchedule = new int[7,4];
        int r = 0;
        foreach (ScheduleDay day in Model.BuyPacificCodeSchedule.arrDays)
        {   
            %>
        
            <th width="120px"><%: day.Name %></th>
        
        <% for (int j = 0; j < 4; j++)
           {
               matrixSchedule[r, 0] = day.FromAM;
               matrixSchedule[r, 1] = day.ToAM;
               matrixSchedule[r, 2] = day.FromPM;
               matrixSchedule[r, 3] = day.ToPM;             
           }
           r++;
        %>
        
        <%} %>
        </tr>

        <%for (int i = 0; i<4; i++)
          { %>
          <tr>
          <% for (int j = 0; j<7; j++)
             { %>
             <td align="center">
                <!--input width="50px" value="< %:matrixSchedule[j,i] %>" /-->
                <%:matrixSchedule[j,i] %>
             </td>
          <%} %>
          </tr>
        <%} %>
    </table>
</asp:Content>

