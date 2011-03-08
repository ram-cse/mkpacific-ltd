<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<MoneyPacificSite.ViewModels.PartPacificCodeViewModel>" %>

    <h2>Detail</h2>

    <fieldset>
        <legend>Pacific Code Details</legend>

        <div class="display-label">CodeNumber: <%: Model.PartCodeNumber%></div>
        
        
        <div class="display-label">ExpireDate: <%: String.Format("{0:dd-MM-yyyy}", Model.ExpireDate)%></div>
        
        
        <div class="display-label">ActualAmount: <%: Model.ActualAmount %></div>
        
                       
        <div class="display-label">Customer Phone: <%: Model.CustomerPhone%></div>
        
        
    </fieldset>


