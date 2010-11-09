<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<F5_MoneyPacificSite.ViewModels.PacificCodeDetailViewModel>" %>


<table> 
    <tr>
        <th><%: Html.LabelFor(model=>model.CodeNumber) %></th>
        <td><%: Html.DisplayTextFor(model=>model.CodeNumber)%></td>
    </tr>
</table>

    <fieldset>
        <legend>Thông tin</legend>        

        <div class="display-label">CodeNumber</div>
        <div class="display-field"><%: Model.CodeNumber %></div>
        
        <div class="display-label">LastTransaction</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.LastTransaction) %></div>
        
        <div class="display-label">CustomerPhone</div>
        <div class="display-field"><%: Model.CustomerPhone %></div>
        
        <div class="display-label">InitialAmount</div>
        <div class="display-field"><%: Model.InitialAmount %></div>
        
        <div class="display-label">ActualAmount</div>
        <div class="display-field"><%: Model.ActualAmount %></div>
        
        <div class="display-label">CreateDate</div>
        <div class="display-field"><%: Model.CreateDate %></div>
        
        <div class="display-label">ExpireDate</div>
        <div class="display-field"><%: Model.ExpireDate %></div>
        
        <div class="display-label">Comment</div>
        <div class="display-field"><%: Model.Comment %></div>
        
        <div class="display-label">StorePhone</div>
        <div class="display-field"><%: Model.StorePhone %></div>
        
    </fieldset>


