﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IStaff")]
public interface IStaff
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaff/DisplayStaff", ReplyAction="http://tempuri.org/IStaff/DisplayStaffResponse")]
    string DisplayStaff();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaff/GetBirthday", ReplyAction="http://tempuri.org/IStaff/GetBirthdayResponse")]
    System.DateTime GetBirthday(int staffId);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IStaffChannel : IStaff, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class StaffClient : System.ServiceModel.ClientBase<IStaff>, IStaff
{
    
    public StaffClient()
    {
    }
    
    public StaffClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public StaffClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public StaffClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public StaffClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string DisplayStaff()
    {
        return base.Channel.DisplayStaff();
    }
    
    public System.DateTime GetBirthday(int staffId)
    {
        return base.Channel.GetBirthday(staffId);
    }
}